using FxMap.Exceptions;
using FxMap.Helpers;
using Shouldly;
using Xunit;

namespace FxMap.Tests.UnitTests.Helpers;

public class ParameterConverterTests
{
    [Fact]
    public void ConvertToDictionary_WithNull_ReturnsEmptyDictionary()
    {
        // Act
        var result = ParameterConverter.ConvertToDictionary(null);

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeEmpty();
    }

    [Fact]
    public void ConvertToDictionary_WithDictionary_ReturnsSameInstance()
    {
        // Arrange
        var dict = new Dictionary<string, string>
        {
            ["key1"] = "value1",
            ["key2"] = "value2"
        };

        // Act
        var result = ParameterConverter.ConvertToDictionary(dict);

        // Assert
        result.ShouldBeSameAs(dict);
        result["key1"].ShouldBe("value1");
        result["key2"].ShouldBe("value2");
    }

    [Fact]
    public void ConvertToDictionary_WithAnonymousType_ConvertsCorrectly()
    {
        // Arrange
        var parameters = new { index = 1, order = "asc", name = "test" };

        // Act
        var result = ParameterConverter.ConvertToDictionary(parameters);

        // Assert
        result.ShouldNotBeNull();
        result.Count.ShouldBe(3);
        result["index"].ShouldBe("1");
        result["order"].ShouldBe("asc");
        result["name"].ShouldBe("test");
    }

    [Fact]
    public void ConvertToDictionary_WithRegularObject_ConvertsCorrectly()
    {
        // Arrange
        var parameters = new TestParameters
        {
            UserId = "123",
            Count = 42,
            IsActive = true
        };

        // Act
        var result = ParameterConverter.ConvertToDictionary(parameters);

        // Assert
        result.ShouldNotBeNull();
        result.Count.ShouldBe(3);
        result["UserId"].ShouldBe("123");
        result["Count"].ShouldBe("42");
        result["IsActive"].ShouldBe("True");
    }

    [Fact]
    public void ConvertToDictionary_WithNullPropertyValues_HandlesGracefully()
    {
        // Arrange
        var parameters = new TestParameters
        {
            UserId = null,
            Count = 0
        };

        // Act
        var result = ParameterConverter.ConvertToDictionary(parameters);

        // Assert
        result.ShouldNotBeNull();
        result["UserId"].ShouldBeNull();
        result["Count"].ShouldBe("0");
    }

    [Fact]
    public void ConvertToDictionary_WithArray_ThrowsInvalidParameterType()
    {
        // Arrange
        var parameters = new[] { 1, 2, 3 };

        // Act & Assert
        var exception = Should.Throw<DistributedMapException.InvalidParameterType>(
            () => ParameterConverter.ConvertToDictionary(parameters));

        exception.Message.ShouldContain("IEnumerable");
        exception.Message.ShouldContain("not supported");
    }

    [Fact]
    public void ConvertToDictionary_WithList_ThrowsInvalidParameterType()
    {
        // Arrange
        var parameters = new List<string> { "a", "b", "c" };

        // Act & Assert
        var exception = Should.Throw<DistributedMapException.InvalidParameterType>(
            () => ParameterConverter.ConvertToDictionary(parameters));

        exception.Message.ShouldContain("IEnumerable");
    }

    [Fact]
    public void ConvertToDictionary_WithString_DoesNotThrow()
    {
        // Arrange - string is IEnumerable but should be allowed
        var parameters = new { name = "test" };

        // Act & Assert
        Should.NotThrow(() => ParameterConverter.ConvertToDictionary(parameters));
    }

    [Fact]
    public void ConvertToDictionary_CachesConverter_ForSameType()
    {
        // Arrange
        var params1 = new { index = 1 };
        var params2 = new { index = 2 };

        // Act
        ParameterConverter.ConvertToDictionary(params1);
        var cacheSizeAfterFirst = ParameterConverter.CacheSize;

        ParameterConverter.ConvertToDictionary(params2); // Same type, should use cache
        var cacheSizeAfterSecond = ParameterConverter.CacheSize;

        // Assert
        cacheSizeAfterSecond.ShouldBe(cacheSizeAfterFirst); // No new entry
    }

    [Fact]
    public void ConvertToDictionary_CreatesSeparateCache_ForDifferentTypes()
    {
        // Arrange
        var params1 = new { index = 1 };
        var params2 = new { index = 1, order = "asc" }; // Different type
        var initialCacheSize = ParameterConverter.CacheSize;

        // Act
        ParameterConverter.ConvertToDictionary(params1);
        var cacheSizeAfterFirst = ParameterConverter.CacheSize;

        ParameterConverter.ConvertToDictionary(params2);
        var cacheSizeAfterSecond = ParameterConverter.CacheSize;

        // Assert
        cacheSizeAfterFirst.ShouldBe(initialCacheSize + 1);
        cacheSizeAfterSecond.ShouldBe(initialCacheSize + 2); // New entry
    }

    [Fact]
    public void ClearCache_RemovesAllCachedConverters()
    {
        // Arrange
        ParameterConverter.ConvertToDictionary(new { a = 1 });
        ParameterConverter.ConvertToDictionary(new { b = 2 });
        var sizeBeforeClear = ParameterConverter.CacheSize;

        // Act
        ParameterConverter.ClearCache();

        // Assert
        sizeBeforeClear.ShouldBeGreaterThan(0);
        ParameterConverter.CacheSize.ShouldBe(0);
    }

    [Fact]
    public void ConvertToDictionary_WithEmptyObject_ReturnsEmptyDictionary()
    {
        // Arrange
        var parameters = new EmptyClass();

        // Act
        var result = ParameterConverter.ConvertToDictionary(parameters);

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeEmpty();
    }

    [Fact]
    public void ConvertToDictionary_PerformanceTest_IsFasterThanReflection()
    {
        // Arrange - warm up cache
        var parameters = new { index = 1, order = "asc", name = "test", value = 42 };
        ParameterConverter.ConvertToDictionary(parameters);

        // Act - measure cached performance. The best of a few rounds: the other tests run in parallel and a shared CI
        // runner is slow at times, so one round measures the machine's load as much as the converter.
        var best = long.MaxValue;
        for (var round = 0; round < 5; round++)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            for (var i = 0; i < 10_000; i++) ParameterConverter.ConvertToDictionary(parameters);
            sw.Stop();
            best = Math.Min(best, sw.ElapsedMilliseconds);
        }

        // Assert - cached calls take ~1-5μs, so 10k iterations take ~10-50ms. Compiling the converter on every call
        // (~100-200μs) would take 1-2s: the limit catches that with room for a slow runner.
        best.ShouldBeLessThan(500);
    }

    private class TestParameters
    {
        public string UserId { get; set; }
        public int Count { get; set; }
        public bool IsActive { get; set; }
    }

    private class EmptyClass
    {
    }
}

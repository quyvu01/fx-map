using Service1.Data;
using Service2.Data;
using Service3Api.Data;
using Shouldly;
using Xunit;

namespace Samples.Tests.UnitTests;

/// <summary>The seed data itself: the counts, unique ids, and the provinces the other services point at.</summary>
public class SeedDataTests
{
    [Fact]
    public void Service3_seeds_eight_countries_and_their_provinces()
    {
        Service3SeedData.Countries.Count.ShouldBe(8);
        Service3SeedData.Provinces.Count.ShouldBe(26);
        Service3SeedData.Countries.Select(c => c.Id).ShouldBeUnique();
        Service3SeedData.Provinces.Select(p => p.Id).ShouldBeUnique();
    }

    [Fact]
    public void Every_province_belongs_to_a_seeded_country()
    {
        var countries = Service3SeedData.Countries.Select(c => c.Id).ToHashSet();
        Service3SeedData.Provinces.ShouldAllBe(p => countries.Contains(p.CountryId));
        Service3SeedData.Countries.ShouldAllBe(c => c.Provinces == null);
    }

    [Fact]
    public void Province_ids_by_country_are_the_provinces_of_that_country()
    {
        Service3SeedData.GetProvinceIdsByCountry("US").Count.ShouldBe(5);
        Service3SeedData.GetProvinceIdsByCountry("VN")
            .ShouldBe([
                Guid.Parse("01962f9a-f7f8-7d2e-4f3a-1234567abcde"),
                Guid.Parse("01962f9a-f7f8-7e3f-5a4b-234567abcdef"),
                Guid.Parse("01962f9a-f7f8-7f4a-6b5c-34567abcdef0")
            ]);
        Service3SeedData.GetProvinceIdsByCountry("XX").ShouldBeEmpty();
        Service3SeedData.GetAllProvinceIds().Count.ShouldBe(26);
    }

    [Fact]
    public void Service2_seeds_users_in_seeded_provinces_with_a_constant_utc_creation_time()
    {
        var provinces = Service3SeedData.GetAllProvinceIds().Select(p => p.ToString()).ToHashSet();
        Service2SeedData.Users.Count.ShouldBe(54);
        Service2SeedData.Users.Select(u => u.Id).ShouldBeUnique();
        Service2SeedData.Users.ShouldAllBe(u => provinces.Contains(u.ProvinceId));
        Service2SeedData.Users.ShouldAllBe(u => u.CreatedTime == Service2SeedData.CreatedTime);
        Service2SeedData.CreatedTime.Kind.ShouldBe(DateTimeKind.Utc);
    }

    [Fact]
    public void Service1_seeds_member_addresses_in_seeded_provinces()
    {
        var provinces = Service3SeedData.GetAllProvinceIds().Select(p => p.ToString()).ToHashSet();
        Service1SeedData.MemberAddresses.Count.ShouldBe(35);
        Service1SeedData.MemberAddresses.Select(a => a.Id).ShouldBeUnique();
        Service1SeedData.MemberAddresses.ShouldAllBe(a => provinces.Contains(a.ProvinceId));
    }

    [Fact]
    public void Service1_seeds_the_member_additional_data()
    {
        Service1SeedData.MemberAdditionalDatas.Count.ShouldBe(20);
        Service1SeedData.MemberAdditionalDatas.Select(m => m.Id).ShouldBeUnique();
        Service1SeedData.MemberAdditionalDatas[0].Id.ShouldBe("member-001");
        Service1SeedData.MemberAdditionalDatas[0].Name.ShouldBe("Alice Cooper");
    }
}

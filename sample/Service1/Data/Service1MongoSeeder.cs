using MongoDB.Driver;
using Service1.Models;

namespace Service1.Data;

/// <summary>
/// Seeds <see cref="MemberSocial"/> into MongoDB when the service starts. MongoDB has no migrations, so this is the one
/// seed that stays in code; the PostgreSQL data is in the migrations (see <see cref="Service1SeedData"/>).
/// </summary>
public static class Service1MongoSeeder
{
    #region MemberSocial Data

    private static readonly
        List<(int Id, string Name, string Platform, string Handle, List<(string Key, string Value, int Order)> Metadata
            )> MemberSocialData =
        [
            (1, "Tech Influencer Alpha", "Twitter", "@techinfluencer", [
                ("Followers", "150000", 1),
                ("Verified", "True", 2),
                ("Category", "Technology", 3)
            ]),

            (2, "Code Master Beta", "GitHub", "codemaster", [
                ("Stars", "25000", 1),
                ("Repositories", "150", 2),
                ("Language", "C#", 3)
            ]),

            (3, "Design Guru Gamma", "Dribbble", "designguru", [
                ("Likes", "50000", 1),
                ("Projects", "200", 2),
                ("Specialty", "UI/UX", 3)
            ]),

            (4, "DevOps Expert Delta", "LinkedIn", "devopsexpert", [
                ("Connections", "5000", 1),
                ("Posts", "500", 2),
                ("Focus", "Cloud Infrastructure", 3)
            ]),

            (5, "Data Scientist Epsilon", "Kaggle", "datascientist", [
                ("Rank", "Expert", 1),
                ("Competitions", "25", 2),
                ("Gold Medals", "5", 3)
            ]),

            (6, "Security Researcher Zeta", "Twitter", "@securityresearcher", [
                ("CVEs", "12", 1),
                ("Bounties", "50000", 2),
                ("Area", "Web Security", 3)
            ]),

            (7, "Mobile Dev Eta", "Medium", "@mobiledev", [
                ("Articles", "100", 1),
                ("Followers", "25000", 2),
                ("Topics", "iOS,Android", 3)
            ]),

            (8, "Cloud Architect Theta", "YouTube", "cloudarchitect", [
                ("Subscribers", "100000", 1),
                ("Videos", "250", 2),
                ("Focus", "AWS,Azure", 3)
            ]),

            (9, "AI Researcher Iota", "arXiv", "airesearcher", [
                ("Papers", "15", 1),
                ("Citations", "500", 2),
                ("Field", "Deep Learning", 3)
            ]),

            (10, "Blockchain Dev Kappa", "GitHub", "blockchaindev", [
                ("Smart Contracts", "50", 1),
                ("Audits", "20", 2),
                ("Chain", "Ethereum", 3)
            ])
        ];

    #endregion

    public static async Task SeedMemberSocialAsync(IMongoCollection<MemberSocial> memberSocialCollection,
        CancellationToken cancellationToken = default)
    {
        foreach (var (id, name, platform, handle, metadata) in MemberSocialData)
        {
            var existed = await memberSocialCollection
                .Find(m => m.Id.Equals(id))
                .FirstOrDefaultAsync(cancellationToken);

            if (existed != null)
                await memberSocialCollection.DeleteOneAsync(x => x.Id == id, cancellationToken: cancellationToken);

            await memberSocialCollection.InsertOneAsync(new MemberSocial
            {
                Id = id,
                Name = name,
                OtherValue = $"{platform}: {handle}",
                CreatedTime = DateTime.UtcNow,
                Metadata = metadata.Select(m => new MemerSocialMetadata
                {
                    Key = m.Key,
                    Value = m.Value,
                    Order = m.Order,
                    ExternalOfMetadata = new ExternalOfMetadata
                    {
                        JustForTest = $"Metadata for {name}"
                    }
                }).ToList()
            }, cancellationToken: cancellationToken);
        }
    }
}

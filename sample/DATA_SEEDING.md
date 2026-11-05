# Data Seeding Documentation

This document describes the seed data of the three sample services and their relationships.

The PostgreSQL data is seeded by the EF Core migrations, not by code that runs when a service starts: each context
declares its rows with `HasData` (the `Data/*SeedData.cs` classes) and the `*_SeedData` migration inserts them. Only
MemberSocial (MongoDB, which has no migrations) is still seeded in code.

## Overview

The sample project consists of three services with the following data relationships:

```
Service3 (Foundation)
   └─> Countries (8 countries)
       └─> Provinces (26 total provinces)
           ├─> Service2: Users (54 users reference provinces)
           └─> Service1: MemberAddress (35 addresses reference provinces)

Service1 (Additional data)
   ├─> MemberAdditionalData (20 members - standalone)
   └─> MemberSocial (10 social profiles - MongoDB, standalone)
```

---

## Service 3: Countries & Provinces (Foundation Data)

**Files**: `sample/Service3/Data/Service3SeedData.cs`, `sample/Service3/Migrations/*_SeedData.cs`

**Database**: PostgreSQL (`FxMapTestService3`)

### Data Structure

Service3 provides the foundation geographic data that other services reference.

**Countries (8 total)**:
- US (United States) - 5 provinces
- CA (Canada) - 3 provinces
- UK (United Kingdom) - 3 provinces
- AU (Australia) - 3 provinces
- DE (Germany) - 3 provinces
- FR (France) - 3 provinces
- JP (Japan) - 3 provinces
- VN (Vietnam) - 3 provinces

**Total Provinces**: 26

### Example Data

| Country ID | Country Name | Province ID | Province Name |
|------------|--------------|-------------|---------------|
| US | United States | `01962f9a-f7f8-7f61-941c-6a086fe96cd2` | California |
| US | United States | `01962f9a-f7f8-7b4c-9b4d-eae8ea6e5fc7` | New York |
| US | United States | `01962f9a-f7f8-7e54-a79d-575a8e882eb8` | Texas |
| CA | Canada | `01962f9a-f7f8-7c3d-8e4f-6a7b8c9d0123` | Ontario |
| UK | United Kingdom | `01962f9a-f7f8-7a7b-9c8d-0e1f23456789` | England |

### Models

```csharp
public class Country
{
    public string Id { get; set; }  // e.g., "US", "CA"
    public string Name { get; set; }
    public List<Province> Provinces { get; set; }
}

public class Province
{
    public Guid Id { get; set; }  // UUID
    public string Name { get; set; }
    public string CountryId { get; set; }  // FK to Country
}
```

### Relationships
- **1 Country → Many Provinces** (one-to-many)
- The migration inserts the countries first, then the provinces

---

## Service 2: Users

**Files**: `sample/Service2/Data/Service2SeedData.cs`, `sample/Service2/Migrations/*_SeedData.cs`

**Database**: PostgreSQL (`FxMapTestService2`)

### Data Structure

Service2 contains user data, where each user is associated with a province from Service3.

**Total Users**: 54 users distributed across all 26 provinces

### Distribution
- **California**: 4 users (user-001 to user-004)
- **New York**: 4 users (user-004 to user-007)
- **Texas**: 3 users (user-007 to user-009)
- **Florida**: 2 users (user-009 to user-010)
- **Illinois**: 2 users (user-011 to user-012)
- ... (continues for all provinces)

### Example Data

| User ID | Name | Email | Province ID |
|---------|------|-------|-------------|
| user-001 | John Smith | john.smith@email.com | California |
| user-004 | Emily Davis | emily.davis@email.com | New York |
| user-013 | Daniel Martin | daniel.m@email.com | Ontario |

### Model

```csharp
public class User
{
    public string Id { get; set; }  // e.g., "user-001"
    public string Name { get; set; }
    public string Email { get; set; }
    public string ProvinceId { get; set; }  // FK to Service3.Province.Id (as string)
}
```

### Relationships
- **User → Province** (many-to-one)
- **Foreign Key**: `ProvinceId` references `Service3.Province.Id`
- Users cannot exist without a valid Province reference

---

## Service 1: Member Data

**Files**: `sample/Service1/Data/Service1SeedData.cs` with `sample/Service1/ContextMigrations/*_SeedData.cs` and
`sample/Service1/OtherContextMigrations/*_SeedData.cs` (PostgreSQL), `sample/Service1/Data/Service1MongoSeeder.cs` (MongoDB)

**Databases**:
- PostgreSQL: `FxMapService1` (MemberAdditionalData)
- PostgreSQL: `FxMapOtherService1` (MemberAddress)
- MongoDB: `Service1MongoDb` (MemberSocial)

### 1. MemberAddress (OtherService1Context)

Member addresses linked to provinces.

**Total Addresses**: 35 addresses distributed across provinces

#### Distribution
- **California**: 4 addresses (addr-001 to addr-004)
- **New York**: 4 addresses (addr-005 to addr-008)
- **Texas**: 3 addresses (addr-009 to addr-011)
- ... (continues for other provinces)

#### Example Data

| Address ID | Province | Street | City | Zip Code |
|------------|----------|--------|------|----------|
| addr-001 | California | 123 Silicon Valley Blvd | San Francisco | 94102 |
| addr-005 | New York | 100 Wall Street | New York | 10005 |
| addr-016 | Ontario | 1200 Bay St | Toronto | M5J 2R8 |

#### Model

```csharp
public class MemberAddress
{
    public string Id { get; set; }  // e.g., "addr-001"
    public string ProvinceId { get; set; }  // FK to Service3.Province.Id (as string)
    public string Street { get; set; }  // e.g., "123 Silicon Valley Blvd"
    public string City { get; set; }  // e.g., "San Francisco"
    public string ZipCode { get; set; }  // e.g., "94102"
}
```

#### Relationships
- **MemberAddress → Province** (many-to-one)
- **Foreign Key**: `ProvinceId` references `Service3.Province.Id`

### 2. MemberAdditionalData (Service1Context)

Standalone member data (no foreign keys).

**Total Members**: 20 members

#### Example Data

| Member ID | Name | Bio |
|-----------|------|-----|
| member-001 | Alice Cooper | Software Engineer specializing in distributed systems |
| member-002 | Bob Dylan | Product Manager with 10 years experience |
| member-005 | Edward Norton | Full Stack Developer \| Open Source Contributor |

#### Model

```csharp
public class MemberAdditionalData
{
    public string Id { get; set; }  // e.g., "member-001"
    public string Name { get; set; }
    // Note: Bio, JoinDate may not exist in actual model
}
```

#### Relationships
- **Standalone** - no foreign keys

### 3. MemberSocial (MongoDB)

Social media profiles stored in MongoDB.

**Total Profiles**: 10 social media profiles

#### Example Data

| ID | Name | Platform | Handle | Metadata |
|----|------|----------|--------|----------|
| 1 | Tech Influencer Alpha | Twitter | @techinfluencer | Followers: 150000, Verified: True |
| 2 | Code Master Beta | GitHub | codemaster | Stars: 25000, Repositories: 150 |
| 5 | Data Scientist Epsilon | Kaggle | datascientist | Rank: Expert, Competitions: 25 |

#### Model

```csharp
public class MemberSocial
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string OtherValue { get; set; }  // Platform: Handle
    public DateTime CreatedTime { get; set; }
    public List<MemerSocialMetadata> Metadata { get; set; }
}

public class MemerSocialMetadata
{
    public string Key { get; set; }
    public string Value { get; set; }
    public int Order { get; set; }
    public ExternalOfMetadata ExternalOfMetadata { get; set; }
}
```

#### Relationships
- **Standalone** - no foreign keys
- MongoDB document with embedded metadata

---

## Seeding Order

The services do not depend on each other at startup: the ids are fixed, and the references between services
(ProvinceId) are plain values, not foreign keys across databases. Service3 is still the foundation the others point at.

### Execution

Each service's `Program.cs` applies its migrations when it starts, which creates the tables and inserts the seed data
once (`MigrationDatabase.MigrationDatabaseAsync<TContext>` runs only the pending migrations):

```csharp
// Service3/Program.cs
await MigrationDatabase.MigrationDatabaseAsync<Service3Context>(app);

// Service2/Program.cs
await MigrationDatabase.MigrationDatabaseAsync<Service2Context>(app);

// Service1/Program.cs
await MigrationDatabase.MigrationDatabaseAsync<Service1Context>(app);
await MigrationDatabase.MigrationDatabaseAsync<OtherService1Context>(app);
// MongoDB has no migrations, so MemberSocial is still seeded in code
await Service1.Data.Service1MongoSeeder.SeedMemberSocialAsync(memberSocialCollection);
```

The migrations can also be applied without running the service, for example `dotnet ef database update` in
`sample/Service3` (Service1 has two contexts: add `--context Service1Context` or `--context OtherService1Context`).

### Changing the seed data

Edit the `Data/*SeedData.cs` class of the service, then add a migration, which EF Core generates from the difference:

```bash
cd sample/Service2 && dotnet ef migrations add AddMoreUsers
cd sample/Service1 && dotnet ef migrations add AddMoreAddresses --context OtherService1Context -o OtherContextMigrations
```

`sample/Samples.Tests` fails when the seed data and the migrations are out of step (`HasPendingModelChanges`).

### Databases seeded by the old code

Before the migrations held the seed data, the services seeded the same rows in code when they started. The `*_SeedData`
migrations first delete the rows with the seeded ids, then insert them, so a database the old code filled takes the
migration; rows with other ids are kept.

---

## Data Statistics

| Service | Entity | Count | Database | Relationships |
|---------|--------|-------|----------|---------------|
| Service3 | Countries | 8 | PostgreSQL | 1 → Many Provinces |
| Service3 | Provinces | 26 | PostgreSQL | Parent of Users & Addresses |
| Service2 | Users | 54 | PostgreSQL | Many → 1 Province |
| Service1 | MemberAddress | 35 | PostgreSQL | Many → 1 Province |
| Service1 | MemberAdditionalData | 20 | PostgreSQL | Standalone |
| Service1 | MemberSocial | 10 | MongoDB | Standalone |

**Total Records**: 153 records across 6 entities

---

## Seed Data Features

✅ **In the migrations**: Inserted once by the `*_SeedData` migrations, reverted by their `Down`
✅ **Constant values**: Fixed ids and values (Service2 users share one UTC creation time), as migrations require
✅ **Checked by tests**: `sample/Samples.Tests` checks the data, that the migrations match it, and applies them to a
real PostgreSQL (Testcontainers)
✅ **Meaningful Data**: Realistic names, emails, addresses
✅ **Comprehensive Coverage**: All provinces have at least 1 user

---

## Testing the Seeding

To verify seeding works correctly:

```bash
# Start databases
docker-compose up -d postgres mongodb

# Run services in order
cd sample/Service3 && dotnet run  # Migrations seed Countries & Provinces
cd sample/Service2 && dotnet run  # Migrations seed Users
cd sample/Service1 && dotnet run  # Migrations seed MemberAddresses, MemberAdditionalDatas; code seeds MemberSocial

# Or the tests, which need only Docker
dotnet test sample/Samples.Tests
```

Check database:
```sql
-- Service3
SELECT COUNT(*) FROM "Countries";  -- Should be 8
SELECT COUNT(*) FROM "Provinces";  -- Should be 26

-- Service2
SELECT COUNT(*) FROM "Users";  -- Should be 54

-- Service1 (FxMapOtherService1)
SELECT COUNT(*) FROM "MemberAddresses";  -- Should be 35

-- Service1 (FxMapService1)
SELECT COUNT(*) FROM "MemberAdditionalDatas";  -- Should be 20
```

Check MongoDB:
```javascript
use Service1MongoDb
db.MemberSocials.count()  // Should be 10
```

---

## Notes

1. **Province IDs are UUIDs**: All province references use Guid/UUID format
2. **Consistent FK Format**: ProvinceId is stored as string (Guid.ToString())
3. **No Circular References**: Data flow is one-way: Service3 → Service2/Service1
4. **MongoDB Separation**: MemberSocial is isolated in MongoDB with no FK constraints
5. **Realistic Data**: Uses real city names, streets, and professional titles
6. **Cross-Service Testing**: You can test FxMap distributed mapping across services by fetching User → Province → Country data

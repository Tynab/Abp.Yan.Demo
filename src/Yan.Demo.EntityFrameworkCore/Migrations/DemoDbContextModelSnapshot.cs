using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using Yan.Demo.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DeleteBehavior;
using static Volo.Abp.EntityFrameworkCore.EfCoreDatabaseProvider;

#nullable disable

namespace Yan.Demo.Migrations;

[DbContext(typeof(DemoDbContext))]
partial class DemoDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.HasAnnotation("_Abp_DatabaseProvider", SqlServer).HasAnnotation("ProductVersion", "7.0.1").HasAnnotation("Relational:MaxIdentifierLength", 128);
        _ = SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);
        _ = modelBuilder.Entity("Volo.Abp.AuditLogging.AuditLog", b =>
        {
            _ = b.Property<Guid>("Id").ValueGeneratedOnAdd().HasColumnType("uniqueidentifier");
            _ = b.Property<string>("ApplicationName").HasMaxLength(96).HasColumnType("nvarchar(96)").HasColumnName("ApplicationName");
            _ = b.Property<string>("BrowserInfo").HasMaxLength(512).HasColumnType("nvarchar(512)").HasColumnName("BrowserInfo");
            _ = b.Property<string>("ClientId").HasMaxLength(64).HasColumnType("nvarchar(64)").HasColumnName("ClientId");
            _ = b.Property<string>("ClientIpAddress").HasMaxLength(64).HasColumnType("nvarchar(64)").HasColumnName("ClientIpAddress");
            _ = b.Property<string>("ClientName").HasMaxLength(128).HasColumnType("nvarchar(128)").HasColumnName("ClientName");
            _ = b.Property<string>("Comments").HasMaxLength(256).HasColumnType("nvarchar(256)").HasColumnName("Comments");
            _ = b.Property<string>("ConcurrencyStamp").IsConcurrencyToken().HasMaxLength(40).HasColumnType("nvarchar(40)").HasColumnName("ConcurrencyStamp");
            _ = b.Property<string>("CorrelationId").HasMaxLength(64).HasColumnType("nvarchar(64)").HasColumnName("CorrelationId");
            _ = b.Property<string>("Exceptions").HasColumnType("nvarchar(max)");
            _ = b.Property<int>("ExecutionDuration").HasColumnType("int").HasColumnName("ExecutionDuration");
            _ = b.Property<DateTime>("ExecutionTime").HasColumnType("datetime2");
            _ = b.Property<string>("ExtraProperties").HasColumnType("nvarchar(max)").HasColumnName("ExtraProperties");
            _ = b.Property<string>("HttpMethod").HasMaxLength(16).HasColumnType("nvarchar(16)").HasColumnName("HttpMethod");
            _ = b.Property<int?>("HttpStatusCode").HasColumnType("int").HasColumnName("HttpStatusCode");
            _ = b.Property<Guid?>("ImpersonatorTenantId").HasColumnType("uniqueidentifier").HasColumnName("ImpersonatorTenantId");
            _ = b.Property<string>("ImpersonatorTenantName").HasMaxLength(64).HasColumnType("nvarchar(64)").HasColumnName("ImpersonatorTenantName");
            _ = b.Property<Guid?>("ImpersonatorUserId").HasColumnType("uniqueidentifier").HasColumnName("ImpersonatorUserId");
            _ = b.Property<string>("ImpersonatorUserName").HasMaxLength(256).HasColumnType("nvarchar(256)").HasColumnName("ImpersonatorUserName");
            _ = b.Property<Guid?>("TenantId").HasColumnType("uniqueidentifier").HasColumnName("TenantId");
            _ = b.Property<string>("TenantName").HasMaxLength(64).HasColumnType("nvarchar(64)").HasColumnName("TenantName");
            _ = b.Property<string>("Url").HasMaxLength(256).HasColumnType("nvarchar(256)").HasColumnName("Url");
            _ = b.Property<Guid?>("UserId").HasColumnType("uniqueidentifier").HasColumnName("UserId");
            _ = b.Property<string>("UserName").HasMaxLength(256).HasColumnType("nvarchar(256)").HasColumnName("UserName");
            _ = b.HasKey("Id");
            _ = b.HasIndex("TenantId", "ExecutionTime");
            _ = b.HasIndex("TenantId", "UserId", "ExecutionTime");
            _ = b.ToTable("AbpAuditLogs", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.AuditLogging.AuditLogAction", b =>
        {
            _ = b.Property<Guid>("Id").ValueGeneratedOnAdd().HasColumnType("uniqueidentifier");
            _ = b.Property<Guid>("AuditLogId").HasColumnType("uniqueidentifier").HasColumnName("AuditLogId");
            _ = b.Property<int>("ExecutionDuration").HasColumnType("int").HasColumnName("ExecutionDuration");
            _ = b.Property<DateTime>("ExecutionTime").HasColumnType("datetime2").HasColumnName("ExecutionTime");
            _ = b.Property<string>("ExtraProperties").HasColumnType("nvarchar(max)").HasColumnName("ExtraProperties");
            _ = b.Property<string>("MethodName").HasMaxLength(128).HasColumnType("nvarchar(128)").HasColumnName("MethodName");
            _ = b.Property<string>("Parameters").HasMaxLength(2000).HasColumnType("nvarchar(2000)").HasColumnName("Parameters");
            _ = b.Property<string>("ServiceName").HasMaxLength(256).HasColumnType("nvarchar(256)").HasColumnName("ServiceName");
            _ = b.Property<Guid?>("TenantId").HasColumnType("uniqueidentifier").HasColumnName("TenantId");
            _ = b.HasKey("Id");
            _ = b.HasIndex("AuditLogId");
            _ = b.HasIndex("TenantId", "ServiceName", "MethodName", "ExecutionTime");
            _ = b.ToTable("AbpAuditLogActions", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.AuditLogging.EntityChange", b =>
        {
            _ = b.Property<Guid>("Id").ValueGeneratedOnAdd().HasColumnType("uniqueidentifier");
            _ = b.Property<Guid>("AuditLogId").HasColumnType("uniqueidentifier").HasColumnName("AuditLogId");
            _ = b.Property<DateTime>("ChangeTime").HasColumnType("datetime2").HasColumnName("ChangeTime");
            _ = b.Property<byte>("ChangeType").HasColumnType("tinyint").HasColumnName("ChangeType");
            _ = b.Property<string>("EntityId").IsRequired().HasMaxLength(128).HasColumnType("nvarchar(128)").HasColumnName("EntityId");
            _ = b.Property<Guid?>("EntityTenantId").HasColumnType("uniqueidentifier");
            _ = b.Property<string>("EntityTypeFullName").IsRequired().HasMaxLength(128).HasColumnType("nvarchar(128)").HasColumnName("EntityTypeFullName");
            _ = b.Property<string>("ExtraProperties").HasColumnType("nvarchar(max)").HasColumnName("ExtraProperties");
            _ = b.Property<Guid?>("TenantId").HasColumnType("uniqueidentifier").HasColumnName("TenantId");
            _ = b.HasKey("Id");
            _ = b.HasIndex("AuditLogId");
            _ = b.HasIndex("TenantId", "EntityTypeFullName", "EntityId");
            _ = b.ToTable("AbpEntityChanges", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.AuditLogging.EntityPropertyChange", b =>
        {
            _ = b.Property<Guid>("Id").ValueGeneratedOnAdd().HasColumnType("uniqueidentifier");
            _ = b.Property<Guid>("EntityChangeId").HasColumnType("uniqueidentifier");
            _ = b.Property<string>("NewValue").HasMaxLength(512).HasColumnType("nvarchar(512)").HasColumnName("NewValue");
            _ = b.Property<string>("OriginalValue").HasMaxLength(512).HasColumnType("nvarchar(512)").HasColumnName("OriginalValue");
            _ = b.Property<string>("PropertyName").IsRequired().HasMaxLength(128).HasColumnType("nvarchar(128)").HasColumnName("PropertyName");
            _ = b.Property<string>("PropertyTypeFullName").IsRequired().HasMaxLength(64).HasColumnType("nvarchar(64)").HasColumnName("PropertyTypeFullName");
            _ = b.Property<Guid?>("TenantId").HasColumnType("uniqueidentifier").HasColumnName("TenantId");
            _ = b.HasKey("Id");
            _ = b.HasIndex("EntityChangeId");
            _ = b.ToTable("AbpEntityPropertyChanges", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.BackgroundJobs.BackgroundJobRecord", b =>
        {
            _ = b.Property<Guid>("Id").ValueGeneratedOnAdd().HasColumnType("uniqueidentifier");
            _ = b.Property<string>("ConcurrencyStamp").IsConcurrencyToken().HasMaxLength(40).HasColumnType("nvarchar(40)").HasColumnName("ConcurrencyStamp");
            _ = b.Property<DateTime>("CreationTime").HasColumnType("datetime2").HasColumnName("CreationTime");
            _ = b.Property<string>("ExtraProperties").HasColumnType("nvarchar(max)").HasColumnName("ExtraProperties");
            _ = b.Property<bool>("IsAbandoned").ValueGeneratedOnAdd().HasColumnType("bit").HasDefaultValue(false);
            _ = b.Property<string>("JobArgs").IsRequired().HasMaxLength(1048576).HasColumnType("nvarchar(max)");
            _ = b.Property<string>("JobName").IsRequired().HasMaxLength(128).HasColumnType("nvarchar(128)");
            _ = b.Property<DateTime?>("LastTryTime").HasColumnType("datetime2");
            _ = b.Property<DateTime>("NextTryTime").HasColumnType("datetime2");
            _ = b.Property<byte>("Priority").ValueGeneratedOnAdd().HasColumnType("tinyint").HasDefaultValue((byte)15);
            _ = b.Property<short>("TryCount").ValueGeneratedOnAdd().HasColumnType("smallint").HasDefaultValue((short)0);
            _ = b.HasKey("Id");
            _ = b.HasIndex("IsAbandoned", "NextTryTime");
            _ = b.ToTable("AbpBackgroundJobs", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.FeatureManagement.FeatureDefinitionRecord", b =>
        {
            _ = b.Property<Guid>("Id").ValueGeneratedOnAdd().HasColumnType("uniqueidentifier");
            _ = b.Property<string>("AllowedProviders").HasMaxLength(256).HasColumnType("nvarchar(256)");
            _ = b.Property<string>("DefaultValue").HasMaxLength(256).HasColumnType("nvarchar(256)");
            _ = b.Property<string>("Description").HasMaxLength(256).HasColumnType("nvarchar(256)");
            _ = b.Property<string>("DisplayName").IsRequired().HasMaxLength(256).HasColumnType("nvarchar(256)");
            _ = b.Property<string>("ExtraProperties").HasColumnType("nvarchar(max)").HasColumnName("ExtraProperties");
            _ = b.Property<string>("GroupName").IsRequired().HasMaxLength(128).HasColumnType("nvarchar(128)");
            _ = b.Property<bool>("IsAvailableToHost").HasColumnType("bit");
            _ = b.Property<bool>("IsVisibleToClients").HasColumnType("bit");
            _ = b.Property<string>("Name").IsRequired().HasMaxLength(128).HasColumnType("nvarchar(128)");
            _ = b.Property<string>("ParentName").HasMaxLength(128).HasColumnType("nvarchar(128)");
            _ = b.Property<string>("ValueType").HasMaxLength(2048).HasColumnType("nvarchar(2048)");
            _ = b.HasKey("Id");
            _ = b.HasIndex("GroupName");
            _ = b.HasIndex("Name").IsUnique();
            _ = b.ToTable("AbpFeatures", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.FeatureManagement.FeatureGroupDefinitionRecord", b =>
        {
            _ = b.Property<Guid>("Id").ValueGeneratedOnAdd().HasColumnType("uniqueidentifier");
            _ = b.Property<string>("DisplayName").IsRequired().HasMaxLength(256).HasColumnType("nvarchar(256)");
            _ = b.Property<string>("ExtraProperties").HasColumnType("nvarchar(max)").HasColumnName("ExtraProperties");
            _ = b.Property<string>("Name").IsRequired().HasMaxLength(128).HasColumnType("nvarchar(128)");
            _ = b.HasKey("Id");
            _ = b.HasIndex("Name").IsUnique();
            _ = b.ToTable("AbpFeatureGroups", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.FeatureManagement.FeatureValue", b =>
        {
            _ = b.Property<Guid>("Id").ValueGeneratedOnAdd().HasColumnType("uniqueidentifier");
            _ = b.Property<string>("Name").IsRequired().HasMaxLength(128).HasColumnType("nvarchar(128)");
            _ = b.Property<string>("ProviderKey").HasMaxLength(64).HasColumnType("nvarchar(64)");
            _ = b.Property<string>("ProviderName").HasMaxLength(64).HasColumnType("nvarchar(64)");
            _ = b.Property<string>("Value").IsRequired().HasMaxLength(128).HasColumnType("nvarchar(128)");
            _ = b.HasKey("Id");
            _ = b.HasIndex("Name", "ProviderName", "ProviderKey").IsUnique().HasFilter("[ProviderName] IS NOT NULL AND [ProviderKey] IS NOT NULL");
            _ = b.ToTable("AbpFeatureValues", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.Identity.IdentityClaimType", b =>
        {
            _ = b.Property<Guid>("Id").HasColumnType("uniqueidentifier");
            _ = b.Property<string>("ConcurrencyStamp").IsConcurrencyToken().HasMaxLength(40).HasColumnType("nvarchar(40)").HasColumnName("ConcurrencyStamp");
            _ = b.Property<string>("Description").HasMaxLength(256).HasColumnType("nvarchar(256)");
            _ = b.Property<string>("ExtraProperties").HasColumnType("nvarchar(max)").HasColumnName("ExtraProperties");
            _ = b.Property<bool>("IsStatic").HasColumnType("bit");
            _ = b.Property<string>("Name").IsRequired().HasMaxLength(256).HasColumnType("nvarchar(256)");
            _ = b.Property<string>("Regex").HasMaxLength(512).HasColumnType("nvarchar(512)");
            _ = b.Property<string>("RegexDescription").HasMaxLength(128).HasColumnType("nvarchar(128)");
            _ = b.Property<bool>("Required").HasColumnType("bit");
            _ = b.Property<int>("ValueType").HasColumnType("int");
            _ = b.HasKey("Id");
            _ = b.ToTable("AbpClaimTypes", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.Identity.IdentityLinkUser", b =>
        {
            _ = b.Property<Guid>("Id").HasColumnType("uniqueidentifier");
            _ = b.Property<Guid?>("SourceTenantId").HasColumnType("uniqueidentifier");
            _ = b.Property<Guid>("SourceUserId").HasColumnType("uniqueidentifier");
            _ = b.Property<Guid?>("TargetTenantId").HasColumnType("uniqueidentifier");
            _ = b.Property<Guid>("TargetUserId").HasColumnType("uniqueidentifier");
            _ = b.HasKey("Id");
            _ = b.HasIndex("SourceUserId", "SourceTenantId", "TargetUserId", "TargetTenantId").IsUnique().HasFilter("[SourceTenantId] IS NOT NULL AND [TargetTenantId] IS NOT NULL");
            _ = b.ToTable("AbpLinkUsers", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.Identity.IdentityRole", b =>
        {
            _ = b.Property<Guid>("Id").HasColumnType("uniqueidentifier");
            _ = b.Property<string>("ConcurrencyStamp").IsConcurrencyToken().HasMaxLength(40).HasColumnType("nvarchar(40)").HasColumnName("ConcurrencyStamp");
            _ = b.Property<string>("ExtraProperties").HasColumnType("nvarchar(max)").HasColumnName("ExtraProperties");
            _ = b.Property<bool>("IsDefault").HasColumnType("bit").HasColumnName("IsDefault");
            _ = b.Property<bool>("IsPublic").HasColumnType("bit").HasColumnName("IsPublic");
            _ = b.Property<bool>("IsStatic").HasColumnType("bit").HasColumnName("IsStatic");
            _ = b.Property<string>("Name").IsRequired().HasMaxLength(256).HasColumnType("nvarchar(256)");
            _ = b.Property<string>("NormalizedName").IsRequired().HasMaxLength(256).HasColumnType("nvarchar(256)");
            _ = b.Property<Guid?>("TenantId").HasColumnType("uniqueidentifier").HasColumnName("TenantId");
            _ = b.HasKey("Id");
            _ = b.HasIndex("NormalizedName");
            _ = b.ToTable("AbpRoles", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.Identity.IdentityRoleClaim", b =>
        {
            _ = b.Property<Guid>("Id").HasColumnType("uniqueidentifier");
            _ = b.Property<string>("ClaimType").IsRequired().HasMaxLength(256).HasColumnType("nvarchar(256)");
            _ = b.Property<string>("ClaimValue").HasMaxLength(1024).HasColumnType("nvarchar(1024)");
            _ = b.Property<Guid>("RoleId").HasColumnType("uniqueidentifier");
            _ = b.Property<Guid?>("TenantId").HasColumnType("uniqueidentifier").HasColumnName("TenantId");
            _ = b.HasKey("Id");
            _ = b.HasIndex("RoleId");
            _ = b.ToTable("AbpRoleClaims", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.Identity.IdentitySecurityLog", b =>
        {
            _ = b.Property<Guid>("Id").HasColumnType("uniqueidentifier");
            _ = b.Property<string>("Action").HasMaxLength(96).HasColumnType("nvarchar(96)");
            _ = b.Property<string>("ApplicationName").HasMaxLength(96).HasColumnType("nvarchar(96)");
            _ = b.Property<string>("BrowserInfo").HasMaxLength(512).HasColumnType("nvarchar(512)");
            _ = b.Property<string>("ClientId").HasMaxLength(64).HasColumnType("nvarchar(64)");
            _ = b.Property<string>("ClientIpAddress").HasMaxLength(64).HasColumnType("nvarchar(64)");
            _ = b.Property<string>("ConcurrencyStamp").IsConcurrencyToken().HasMaxLength(40).HasColumnType("nvarchar(40)").HasColumnName("ConcurrencyStamp");
            _ = b.Property<string>("CorrelationId").HasMaxLength(64).HasColumnType("nvarchar(64)");
            _ = b.Property<DateTime>("CreationTime").HasColumnType("datetime2");
            _ = b.Property<string>("ExtraProperties").HasColumnType("nvarchar(max)").HasColumnName("ExtraProperties");
            _ = b.Property<string>("Identity").HasMaxLength(96).HasColumnType("nvarchar(96)");
            _ = b.Property<Guid?>("TenantId").HasColumnType("uniqueidentifier").HasColumnName("TenantId");
            _ = b.Property<string>("TenantName").HasMaxLength(64).HasColumnType("nvarchar(64)");
            _ = b.Property<Guid?>("UserId").HasColumnType("uniqueidentifier");
            _ = b.Property<string>("UserName").HasMaxLength(256).HasColumnType("nvarchar(256)");
            _ = b.HasKey("Id");
            _ = b.HasIndex("TenantId", "Action");
            _ = b.HasIndex("TenantId", "ApplicationName");
            _ = b.HasIndex("TenantId", "Identity");
            _ = b.HasIndex("TenantId", "UserId");
            _ = b.ToTable("AbpSecurityLogs", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.Identity.IdentityUser", b =>
        {
            _ = b.Property<Guid>("Id").HasColumnType("uniqueidentifier");
            _ = b.Property<int>("AccessFailedCount").ValueGeneratedOnAdd().HasColumnType("int").HasDefaultValue(0).HasColumnName("AccessFailedCount");
            _ = b.Property<string>("ConcurrencyStamp").IsConcurrencyToken().HasMaxLength(40).HasColumnType("nvarchar(40)").HasColumnName("ConcurrencyStamp");
            _ = b.Property<DateTime>("CreationTime").HasColumnType("datetime2").HasColumnName("CreationTime");
            _ = b.Property<Guid?>("CreatorId").HasColumnType("uniqueidentifier").HasColumnName("CreatorId");
            _ = b.Property<Guid?>("DeleterId").HasColumnType("uniqueidentifier").HasColumnName("DeleterId");
            _ = b.Property<DateTime?>("DeletionTime").HasColumnType("datetime2").HasColumnName("DeletionTime");
            _ = b.Property<string>("Email").IsRequired().HasMaxLength(256).HasColumnType("nvarchar(256)").HasColumnName("Email");
            _ = b.Property<bool>("EmailConfirmed").ValueGeneratedOnAdd().HasColumnType("bit").HasDefaultValue(false).HasColumnName("EmailConfirmed");
            _ = b.Property<string>("ExtraProperties").HasColumnType("nvarchar(max)").HasColumnName("ExtraProperties");
            _ = b.Property<bool>("IsActive").HasColumnType("bit").HasColumnName("IsActive");
            _ = b.Property<bool>("IsDeleted").ValueGeneratedOnAdd().HasColumnType("bit").HasDefaultValue(false).HasColumnName("IsDeleted");
            _ = b.Property<bool>("IsExternal").ValueGeneratedOnAdd().HasColumnType("bit").HasDefaultValue(false).HasColumnName("IsExternal");
            _ = b.Property<DateTime?>("LastModificationTime").HasColumnType("datetime2").HasColumnName("LastModificationTime");
            _ = b.Property<Guid?>("LastModifierId").HasColumnType("uniqueidentifier").HasColumnName("LastModifierId");
            _ = b.Property<bool>("LockoutEnabled").ValueGeneratedOnAdd().HasColumnType("bit").HasDefaultValue(false).HasColumnName("LockoutEnabled");
            _ = b.Property<DateTimeOffset?>("LockoutEnd").HasColumnType("datetimeoffset");
            _ = b.Property<string>("Name").HasMaxLength(64).HasColumnType("nvarchar(64)").HasColumnName("Name");
            _ = b.Property<string>("NormalizedEmail").IsRequired().HasMaxLength(256).HasColumnType("nvarchar(256)").HasColumnName("NormalizedEmail");
            _ = b.Property<string>("NormalizedUserName").IsRequired().HasMaxLength(256).HasColumnType("nvarchar(256)").HasColumnName("NormalizedUserName");
            _ = b.Property<string>("PasswordHash").HasMaxLength(256).HasColumnType("nvarchar(256)").HasColumnName("PasswordHash");
            _ = b.Property<string>("PhoneNumber").HasMaxLength(16).HasColumnType("nvarchar(16)").HasColumnName("PhoneNumber");
            _ = b.Property<bool>("PhoneNumberConfirmed").ValueGeneratedOnAdd().HasColumnType("bit").HasDefaultValue(false).HasColumnName("PhoneNumberConfirmed");
            _ = b.Property<string>("SecurityStamp").IsRequired().HasMaxLength(256).HasColumnType("nvarchar(256)").HasColumnName("SecurityStamp");
            _ = b.Property<string>("Surname").HasMaxLength(64).HasColumnType("nvarchar(64)").HasColumnName("Surname");
            _ = b.Property<Guid?>("TenantId").HasColumnType("uniqueidentifier").HasColumnName("TenantId");
            _ = b.Property<bool>("TwoFactorEnabled").ValueGeneratedOnAdd().HasColumnType("bit").HasDefaultValue(false).HasColumnName("TwoFactorEnabled");
            _ = b.Property<string>("UserName").IsRequired().HasMaxLength(256).HasColumnType("nvarchar(256)").HasColumnName("UserName");
            _ = b.HasKey("Id");
            _ = b.HasIndex("Email");
            _ = b.HasIndex("NormalizedEmail");
            _ = b.HasIndex("NormalizedUserName");
            _ = b.HasIndex("UserName");
            _ = b.ToTable("AbpUsers", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.Identity.IdentityUserClaim", b =>
        {
            _ = b.Property<Guid>("Id").HasColumnType("uniqueidentifier");
            _ = b.Property<string>("ClaimType").IsRequired().HasMaxLength(256).HasColumnType("nvarchar(256)");
            _ = b.Property<string>("ClaimValue").HasMaxLength(1024).HasColumnType("nvarchar(1024)");
            _ = b.Property<Guid?>("TenantId").HasColumnType("uniqueidentifier").HasColumnName("TenantId");
            _ = b.Property<Guid>("UserId").HasColumnType("uniqueidentifier");
            _ = b.HasKey("Id");
            _ = b.HasIndex("UserId");
            _ = b.ToTable("AbpUserClaims", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.Identity.IdentityUserLogin", b =>
        {
            _ = b.Property<Guid>("UserId").HasColumnType("uniqueidentifier");
            _ = b.Property<string>("LoginProvider").HasMaxLength(64).HasColumnType("nvarchar(64)");
            _ = b.Property<string>("ProviderDisplayName").HasMaxLength(128).HasColumnType("nvarchar(128)");
            _ = b.Property<string>("ProviderKey").IsRequired().HasMaxLength(196).HasColumnType("nvarchar(196)");
            _ = b.Property<Guid?>("TenantId").HasColumnType("uniqueidentifier").HasColumnName("TenantId");
            _ = b.HasKey("UserId", "LoginProvider");
            _ = b.HasIndex("LoginProvider", "ProviderKey");
            _ = b.ToTable("AbpUserLogins", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.Identity.IdentityUserOrganizationUnit", b =>
        {
            _ = b.Property<Guid>("OrganizationUnitId").HasColumnType("uniqueidentifier");
            _ = b.Property<Guid>("UserId").HasColumnType("uniqueidentifier");
            _ = b.Property<DateTime>("CreationTime").HasColumnType("datetime2").HasColumnName("CreationTime");
            _ = b.Property<Guid?>("CreatorId").HasColumnType("uniqueidentifier").HasColumnName("CreatorId");
            _ = b.Property<Guid?>("TenantId").HasColumnType("uniqueidentifier").HasColumnName("TenantId");
            _ = b.HasKey("OrganizationUnitId", "UserId");
            _ = b.HasIndex("UserId", "OrganizationUnitId");
            _ = b.ToTable("AbpUserOrganizationUnits", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.Identity.IdentityUserRole", b =>
        {
            _ = b.Property<Guid>("UserId").HasColumnType("uniqueidentifier");
            _ = b.Property<Guid>("RoleId").HasColumnType("uniqueidentifier");
            _ = b.Property<Guid?>("TenantId").HasColumnType("uniqueidentifier").HasColumnName("TenantId");
            _ = b.HasKey("UserId", "RoleId");
            _ = b.HasIndex("RoleId", "UserId");
            _ = b.ToTable("AbpUserRoles", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.Identity.IdentityUserToken", b =>
        {
            _ = b.Property<Guid>("UserId").HasColumnType("uniqueidentifier");
            _ = b.Property<string>("LoginProvider").HasMaxLength(64).HasColumnType("nvarchar(64)");
            _ = b.Property<string>("Name").HasMaxLength(128).HasColumnType("nvarchar(128)");
            _ = b.Property<Guid?>("TenantId").HasColumnType("uniqueidentifier").HasColumnName("TenantId");
            _ = b.Property<string>("Value").HasColumnType("nvarchar(max)");
            _ = b.HasKey("UserId", "LoginProvider", "Name");
            _ = b.ToTable("AbpUserTokens", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.Identity.OrganizationUnit", b =>
        {
            _ = b.Property<Guid>("Id").HasColumnType("uniqueidentifier");
            _ = b.Property<string>("Code").IsRequired().HasMaxLength(95).HasColumnType("nvarchar(95)").HasColumnName("Code");
            _ = b.Property<string>("ConcurrencyStamp").IsConcurrencyToken().HasMaxLength(40).HasColumnType("nvarchar(40)").HasColumnName("ConcurrencyStamp");
            _ = b.Property<DateTime>("CreationTime").HasColumnType("datetime2").HasColumnName("CreationTime");
            _ = b.Property<Guid?>("CreatorId").HasColumnType("uniqueidentifier").HasColumnName("CreatorId");
            _ = b.Property<Guid?>("DeleterId").HasColumnType("uniqueidentifier").HasColumnName("DeleterId");
            _ = b.Property<DateTime?>("DeletionTime").HasColumnType("datetime2").HasColumnName("DeletionTime");
            _ = b.Property<string>("DisplayName").IsRequired().HasMaxLength(128).HasColumnType("nvarchar(128)").HasColumnName("DisplayName");
            _ = b.Property<string>("ExtraProperties").HasColumnType("nvarchar(max)").HasColumnName("ExtraProperties");
            _ = b.Property<bool>("IsDeleted").ValueGeneratedOnAdd().HasColumnType("bit").HasDefaultValue(false).HasColumnName("IsDeleted");
            _ = b.Property<DateTime?>("LastModificationTime").HasColumnType("datetime2").HasColumnName("LastModificationTime");
            _ = b.Property<Guid?>("LastModifierId").HasColumnType("uniqueidentifier").HasColumnName("LastModifierId");
            _ = b.Property<Guid?>("ParentId").HasColumnType("uniqueidentifier");
            _ = b.Property<Guid?>("TenantId").HasColumnType("uniqueidentifier").HasColumnName("TenantId");
            _ = b.HasKey("Id");
            _ = b.HasIndex("Code");
            _ = b.HasIndex("ParentId");
            _ = b.ToTable("AbpOrganizationUnits", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.Identity.OrganizationUnitRole", b =>
        {
            _ = b.Property<Guid>("OrganizationUnitId").HasColumnType("uniqueidentifier");
            _ = b.Property<Guid>("RoleId").HasColumnType("uniqueidentifier");
            _ = b.Property<DateTime>("CreationTime").HasColumnType("datetime2").HasColumnName("CreationTime");
            _ = b.Property<Guid?>("CreatorId").HasColumnType("uniqueidentifier").HasColumnName("CreatorId");
            _ = b.Property<Guid?>("TenantId").HasColumnType("uniqueidentifier").HasColumnName("TenantId");
            _ = b.HasKey("OrganizationUnitId", "RoleId");
            _ = b.HasIndex("RoleId", "OrganizationUnitId");
            _ = b.ToTable("AbpOrganizationUnitRoles", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.OpenIddict.Applications.OpenIddictApplication", b =>
        {
            _ = b.Property<Guid>("Id").ValueGeneratedOnAdd().HasColumnType("uniqueidentifier");
            _ = b.Property<string>("ClientId").HasMaxLength(100).HasColumnType("nvarchar(100)");
            _ = b.Property<string>("ClientSecret").HasColumnType("nvarchar(max)");
            _ = b.Property<string>("ClientUri").HasColumnType("nvarchar(max)");
            _ = b.Property<string>("ConcurrencyStamp").IsConcurrencyToken().HasMaxLength(40).HasColumnType("nvarchar(40)").HasColumnName("ConcurrencyStamp");
            _ = b.Property<string>("ConsentType").HasMaxLength(50).HasColumnType("nvarchar(50)");
            _ = b.Property<DateTime>("CreationTime").HasColumnType("datetime2").HasColumnName("CreationTime");
            _ = b.Property<Guid?>("CreatorId").HasColumnType("uniqueidentifier").HasColumnName("CreatorId");
            _ = b.Property<Guid?>("DeleterId").HasColumnType("uniqueidentifier").HasColumnName("DeleterId");
            _ = b.Property<DateTime?>("DeletionTime").HasColumnType("datetime2").HasColumnName("DeletionTime");
            _ = b.Property<string>("DisplayName").HasColumnType("nvarchar(max)");
            _ = b.Property<string>("DisplayNames").HasColumnType("nvarchar(max)");
            _ = b.Property<string>("ExtraProperties").HasColumnType("nvarchar(max)").HasColumnName("ExtraProperties");
            _ = b.Property<bool>("IsDeleted").ValueGeneratedOnAdd().HasColumnType("bit").HasDefaultValue(false).HasColumnName("IsDeleted");
            _ = b.Property<DateTime?>("LastModificationTime").HasColumnType("datetime2").HasColumnName("LastModificationTime");
            _ = b.Property<Guid?>("LastModifierId").HasColumnType("uniqueidentifier").HasColumnName("LastModifierId");
            _ = b.Property<string>("LogoUri").HasColumnType("nvarchar(max)");
            _ = b.Property<string>("Permissions").HasColumnType("nvarchar(max)");
            _ = b.Property<string>("PostLogoutRedirectUris").HasColumnType("nvarchar(max)");
            _ = b.Property<string>("Properties").HasColumnType("nvarchar(max)");
            _ = b.Property<string>("RedirectUris").HasColumnType("nvarchar(max)");
            _ = b.Property<string>("Requirements").HasColumnType("nvarchar(max)");
            _ = b.Property<string>("Type").HasMaxLength(50).HasColumnType("nvarchar(50)");
            _ = b.HasKey("Id");
            _ = b.HasIndex("ClientId");
            _ = b.ToTable("OpenIddictApplications", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.OpenIddict.Authorizations.OpenIddictAuthorization", b =>
        {
            _ = b.Property<Guid>("Id").ValueGeneratedOnAdd().HasColumnType("uniqueidentifier");
            _ = b.Property<Guid?>("ApplicationId").HasColumnType("uniqueidentifier");
            _ = b.Property<string>("ConcurrencyStamp").IsConcurrencyToken().HasMaxLength(40).HasColumnType("nvarchar(40)").HasColumnName("ConcurrencyStamp");
            _ = b.Property<DateTime?>("CreationDate").HasColumnType("datetime2");
            _ = b.Property<DateTime>("CreationTime").HasColumnType("datetime2").HasColumnName("CreationTime");
            _ = b.Property<Guid?>("CreatorId").HasColumnType("uniqueidentifier").HasColumnName("CreatorId");
            _ = b.Property<Guid?>("DeleterId").HasColumnType("uniqueidentifier").HasColumnName("DeleterId");
            _ = b.Property<DateTime?>("DeletionTime").HasColumnType("datetime2").HasColumnName("DeletionTime");
            _ = b.Property<string>("ExtraProperties").HasColumnType("nvarchar(max)").HasColumnName("ExtraProperties");
            _ = b.Property<bool>("IsDeleted").ValueGeneratedOnAdd().HasColumnType("bit").HasDefaultValue(false).HasColumnName("IsDeleted");
            _ = b.Property<DateTime?>("LastModificationTime").HasColumnType("datetime2").HasColumnName("LastModificationTime");
            _ = b.Property<Guid?>("LastModifierId").HasColumnType("uniqueidentifier").HasColumnName("LastModifierId");
            _ = b.Property<string>("Properties").HasColumnType("nvarchar(max)");
            _ = b.Property<string>("Scopes").HasColumnType("nvarchar(max)");
            _ = b.Property<string>("Status").HasMaxLength(50).HasColumnType("nvarchar(50)");
            _ = b.Property<string>("Subject").HasMaxLength(400).HasColumnType("nvarchar(400)");
            _ = b.Property<string>("Type").HasMaxLength(50).HasColumnType("nvarchar(50)");
            _ = b.HasKey("Id");
            _ = b.HasIndex("ApplicationId", "Status", "Subject", "Type");
            _ = b.ToTable("OpenIddictAuthorizations", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.OpenIddict.Scopes.OpenIddictScope", b =>
        {
            _ = b.Property<Guid>("Id").ValueGeneratedOnAdd().HasColumnType("uniqueidentifier");
            _ = b.Property<string>("ConcurrencyStamp").IsConcurrencyToken().HasMaxLength(40).HasColumnType("nvarchar(40)").HasColumnName("ConcurrencyStamp");
            _ = b.Property<DateTime>("CreationTime").HasColumnType("datetime2").HasColumnName("CreationTime");
            _ = b.Property<Guid?>("CreatorId").HasColumnType("uniqueidentifier").HasColumnName("CreatorId");
            _ = b.Property<Guid?>("DeleterId").HasColumnType("uniqueidentifier").HasColumnName("DeleterId");
            _ = b.Property<DateTime?>("DeletionTime").HasColumnType("datetime2").HasColumnName("DeletionTime");
            _ = b.Property<string>("Description").HasColumnType("nvarchar(max)");
            _ = b.Property<string>("Descriptions").HasColumnType("nvarchar(max)");
            _ = b.Property<string>("DisplayName").HasColumnType("nvarchar(max)");
            _ = b.Property<string>("DisplayNames").HasColumnType("nvarchar(max)");
            _ = b.Property<string>("ExtraProperties").HasColumnType("nvarchar(max)").HasColumnName("ExtraProperties");
            _ = b.Property<bool>("IsDeleted").ValueGeneratedOnAdd().HasColumnType("bit").HasDefaultValue(false).HasColumnName("IsDeleted");
            _ = b.Property<DateTime?>("LastModificationTime").HasColumnType("datetime2").HasColumnName("LastModificationTime");
            _ = b.Property<Guid?>("LastModifierId").HasColumnType("uniqueidentifier").HasColumnName("LastModifierId");
            _ = b.Property<string>("Name").HasMaxLength(200).HasColumnType("nvarchar(200)");
            _ = b.Property<string>("Properties").HasColumnType("nvarchar(max)");
            _ = b.Property<string>("Resources").HasColumnType("nvarchar(max)");
            _ = b.HasKey("Id");
            _ = b.HasIndex("Name");
            _ = b.ToTable("OpenIddictScopes", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.OpenIddict.Tokens.OpenIddictToken", b =>
        {
            _ = b.Property<Guid>("Id").ValueGeneratedOnAdd().HasColumnType("uniqueidentifier");
            _ = b.Property<Guid?>("ApplicationId").HasColumnType("uniqueidentifier");
            _ = b.Property<Guid?>("AuthorizationId").HasColumnType("uniqueidentifier");
            _ = b.Property<string>("ConcurrencyStamp").IsConcurrencyToken().HasMaxLength(40).HasColumnType("nvarchar(40)").HasColumnName("ConcurrencyStamp");
            _ = b.Property<DateTime?>("CreationDate").HasColumnType("datetime2");
            _ = b.Property<DateTime>("CreationTime").HasColumnType("datetime2").HasColumnName("CreationTime");
            _ = b.Property<Guid?>("CreatorId").HasColumnType("uniqueidentifier").HasColumnName("CreatorId");
            _ = b.Property<Guid?>("DeleterId").HasColumnType("uniqueidentifier").HasColumnName("DeleterId");
            _ = b.Property<DateTime?>("DeletionTime").HasColumnType("datetime2").HasColumnName("DeletionTime");
            _ = b.Property<DateTime?>("ExpirationDate").HasColumnType("datetime2");
            _ = b.Property<string>("ExtraProperties").HasColumnType("nvarchar(max)").HasColumnName("ExtraProperties");
            _ = b.Property<bool>("IsDeleted").ValueGeneratedOnAdd().HasColumnType("bit").HasDefaultValue(false).HasColumnName("IsDeleted");
            _ = b.Property<DateTime?>("LastModificationTime").HasColumnType("datetime2").HasColumnName("LastModificationTime");
            _ = b.Property<Guid?>("LastModifierId").HasColumnType("uniqueidentifier").HasColumnName("LastModifierId");
            _ = b.Property<string>("Payload").HasColumnType("nvarchar(max)");
            _ = b.Property<string>("Properties").HasColumnType("nvarchar(max)");
            _ = b.Property<DateTime?>("RedemptionDate").HasColumnType("datetime2");
            _ = b.Property<string>("ReferenceId").HasMaxLength(100).HasColumnType("nvarchar(100)");
            _ = b.Property<string>("Status").HasMaxLength(50).HasColumnType("nvarchar(50)");
            _ = b.Property<string>("Subject").HasMaxLength(400).HasColumnType("nvarchar(400)");
            _ = b.Property<string>("Type").HasMaxLength(50).HasColumnType("nvarchar(50)");
            _ = b.HasKey("Id");
            _ = b.HasIndex("AuthorizationId");
            _ = b.HasIndex("ReferenceId");
            _ = b.HasIndex("ApplicationId", "Status", "Subject", "Type");
            _ = b.ToTable("OpenIddictTokens", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.PermissionManagement.PermissionDefinitionRecord", b =>
        {
            _ = b.Property<Guid>("Id").ValueGeneratedOnAdd().HasColumnType("uniqueidentifier");
            _ = b.Property<string>("DisplayName").IsRequired().HasMaxLength(256).HasColumnType("nvarchar(256)");
            _ = b.Property<string>("ExtraProperties").HasColumnType("nvarchar(max)").HasColumnName("ExtraProperties");
            _ = b.Property<string>("GroupName").IsRequired().HasMaxLength(128).HasColumnType("nvarchar(128)");
            _ = b.Property<bool>("IsEnabled").HasColumnType("bit");
            _ = b.Property<byte>("MultiTenancySide").HasColumnType("tinyint");
            _ = b.Property<string>("Name").IsRequired().HasMaxLength(128).HasColumnType("nvarchar(128)");
            _ = b.Property<string>("ParentName").HasMaxLength(128).HasColumnType("nvarchar(128)");
            _ = b.Property<string>("Providers").HasMaxLength(128).HasColumnType("nvarchar(128)");
            _ = b.Property<string>("StateCheckers").HasMaxLength(256).HasColumnType("nvarchar(256)");
            _ = b.HasKey("Id");
            _ = b.HasIndex("GroupName");
            _ = b.HasIndex("Name").IsUnique();
            _ = b.ToTable("AbpPermissions", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.PermissionManagement.PermissionGrant", b =>
        {
            _ = b.Property<Guid>("Id").ValueGeneratedOnAdd().HasColumnType("uniqueidentifier");
            _ = b.Property<string>("Name").IsRequired().HasMaxLength(128).HasColumnType("nvarchar(128)");
            _ = b.Property<string>("ProviderKey").IsRequired().HasMaxLength(64).HasColumnType("nvarchar(64)");
            _ = b.Property<string>("ProviderName").IsRequired().HasMaxLength(64).HasColumnType("nvarchar(64)");
            _ = b.Property<Guid?>("TenantId").HasColumnType("uniqueidentifier").HasColumnName("TenantId");
            _ = b.HasKey("Id");
            _ = b.HasIndex("TenantId", "Name", "ProviderName", "ProviderKey").IsUnique().HasFilter("[TenantId] IS NOT NULL");
            _ = b.ToTable("AbpPermissionGrants", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.PermissionManagement.PermissionGroupDefinitionRecord", b =>
        {
            _ = b.Property<Guid>("Id").ValueGeneratedOnAdd().HasColumnType("uniqueidentifier");
            _ = b.Property<string>("DisplayName").IsRequired().HasMaxLength(256).HasColumnType("nvarchar(256)");
            _ = b.Property<string>("ExtraProperties").HasColumnType("nvarchar(max)").HasColumnName("ExtraProperties");
            _ = b.Property<string>("Name").IsRequired().HasMaxLength(128).HasColumnType("nvarchar(128)");
            _ = b.HasKey("Id");
            _ = b.HasIndex("Name").IsUnique();
            _ = b.ToTable("AbpPermissionGroups", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.SettingManagement.Setting", b =>
        {
            _ = b.Property<Guid>("Id").ValueGeneratedOnAdd().HasColumnType("uniqueidentifier");
            _ = b.Property<string>("Name").IsRequired().HasMaxLength(128).HasColumnType("nvarchar(128)");
            _ = b.Property<string>("ProviderKey").HasMaxLength(64).HasColumnType("nvarchar(64)");
            _ = b.Property<string>("ProviderName").HasMaxLength(64).HasColumnType("nvarchar(64)");
            _ = b.Property<string>("Value").IsRequired().HasMaxLength(2048).HasColumnType("nvarchar(2048)");
            _ = b.HasKey("Id");
            _ = b.HasIndex("Name", "ProviderName", "ProviderKey").IsUnique().HasFilter("[ProviderName] IS NOT NULL AND [ProviderKey] IS NOT NULL");
            _ = b.ToTable("AbpSettings", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.TenantManagement.Tenant", b =>
        {
            _ = b.Property<Guid>("Id").HasColumnType("uniqueidentifier");
            _ = b.Property<string>("ConcurrencyStamp").IsConcurrencyToken().HasMaxLength(40).HasColumnType("nvarchar(40)").HasColumnName("ConcurrencyStamp");
            _ = b.Property<DateTime>("CreationTime").HasColumnType("datetime2").HasColumnName("CreationTime");
            _ = b.Property<Guid?>("CreatorId").HasColumnType("uniqueidentifier").HasColumnName("CreatorId");
            _ = b.Property<Guid?>("DeleterId").HasColumnType("uniqueidentifier").HasColumnName("DeleterId");
            _ = b.Property<DateTime?>("DeletionTime").HasColumnType("datetime2").HasColumnName("DeletionTime");
            _ = b.Property<string>("ExtraProperties").HasColumnType("nvarchar(max)").HasColumnName("ExtraProperties");
            _ = b.Property<bool>("IsDeleted").ValueGeneratedOnAdd().HasColumnType("bit").HasDefaultValue(false).HasColumnName("IsDeleted");
            _ = b.Property<DateTime?>("LastModificationTime").HasColumnType("datetime2").HasColumnName("LastModificationTime");
            _ = b.Property<Guid?>("LastModifierId").HasColumnType("uniqueidentifier").HasColumnName("LastModifierId");
            _ = b.Property<string>("Name").IsRequired().HasMaxLength(64).HasColumnType("nvarchar(64)");
            _ = b.HasKey("Id");
            _ = b.HasIndex("Name");
            _ = b.ToTable("AbpTenants", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.TenantManagement.TenantConnectionString", b =>
        {
            _ = b.Property<Guid>("TenantId").HasColumnType("uniqueidentifier");
            _ = b.Property<string>("Name").HasMaxLength(64).HasColumnType("nvarchar(64)");
            _ = b.Property<string>("Value").IsRequired().HasMaxLength(1024).HasColumnType("nvarchar(1024)");
            _ = b.HasKey("TenantId", "Name");
            _ = b.ToTable("AbpTenantConnectionStrings", (string)null);
        });
        _ = modelBuilder.Entity("Volo.Abp.AuditLogging.AuditLogAction", b => b.HasOne("Volo.Abp.AuditLogging.AuditLog", null).WithMany("Actions").HasForeignKey("AuditLogId").OnDelete(Cascade).IsRequired());
        _ = modelBuilder.Entity("Volo.Abp.AuditLogging.EntityChange", b => b.HasOne("Volo.Abp.AuditLogging.AuditLog", null).WithMany("EntityChanges").HasForeignKey("AuditLogId").OnDelete(Cascade).IsRequired());
        _ = modelBuilder.Entity("Volo.Abp.AuditLogging.EntityPropertyChange", b => b.HasOne("Volo.Abp.AuditLogging.EntityChange", null).WithMany("PropertyChanges").HasForeignKey("EntityChangeId").OnDelete(Cascade).IsRequired());
        _ = modelBuilder.Entity("Volo.Abp.Identity.IdentityRoleClaim", b => b.HasOne("Volo.Abp.Identity.IdentityRole", null).WithMany("Claims").HasForeignKey("RoleId").OnDelete(Cascade).IsRequired());
        _ = modelBuilder.Entity("Volo.Abp.Identity.IdentityUserClaim", b => b.HasOne("Volo.Abp.Identity.IdentityUser", null).WithMany("Claims").HasForeignKey("UserId").OnDelete(Cascade).IsRequired());
        _ = modelBuilder.Entity("Volo.Abp.Identity.IdentityUserLogin", b => b.HasOne("Volo.Abp.Identity.IdentityUser", null).WithMany("Logins").HasForeignKey("UserId").OnDelete(Cascade).IsRequired());
        _ = modelBuilder.Entity("Volo.Abp.Identity.IdentityUserOrganizationUnit", b =>
        {
            _ = b.HasOne("Volo.Abp.Identity.OrganizationUnit", null).WithMany().HasForeignKey("OrganizationUnitId").OnDelete(Cascade).IsRequired();
            _ = b.HasOne("Volo.Abp.Identity.IdentityUser", null).WithMany("OrganizationUnits").HasForeignKey("UserId").OnDelete(Cascade).IsRequired();
        });
        _ = modelBuilder.Entity("Volo.Abp.Identity.IdentityUserRole", b =>
        {
            _ = b.HasOne("Volo.Abp.Identity.IdentityRole", null).WithMany().HasForeignKey("RoleId").OnDelete(Cascade).IsRequired();
            _ = b.HasOne("Volo.Abp.Identity.IdentityUser", null).WithMany("Roles").HasForeignKey("UserId").OnDelete(Cascade).IsRequired();
        });
        _ = modelBuilder.Entity("Volo.Abp.Identity.IdentityUserToken", b => b.HasOne("Volo.Abp.Identity.IdentityUser", null).WithMany("Tokens").HasForeignKey("UserId").OnDelete(Cascade).IsRequired());
        _ = modelBuilder.Entity("Volo.Abp.Identity.OrganizationUnit", b => b.HasOne("Volo.Abp.Identity.OrganizationUnit", null).WithMany().HasForeignKey("ParentId"));
        _ = modelBuilder.Entity("Volo.Abp.Identity.OrganizationUnitRole", b =>
        {
            _ = b.HasOne("Volo.Abp.Identity.OrganizationUnit", null).WithMany("Roles").HasForeignKey("OrganizationUnitId").OnDelete(Cascade).IsRequired();
            _ = b.HasOne("Volo.Abp.Identity.IdentityRole", null).WithMany().HasForeignKey("RoleId").OnDelete(Cascade).IsRequired();
        });
        _ = modelBuilder.Entity("Volo.Abp.OpenIddict.Authorizations.OpenIddictAuthorization", b => b.HasOne("Volo.Abp.OpenIddict.Applications.OpenIddictApplication", null).WithMany().HasForeignKey("ApplicationId"));
        _ = modelBuilder.Entity("Volo.Abp.OpenIddict.Tokens.OpenIddictToken", b =>
        {
            _ = b.HasOne("Volo.Abp.OpenIddict.Applications.OpenIddictApplication", null).WithMany().HasForeignKey("ApplicationId");
            _ = b.HasOne("Volo.Abp.OpenIddict.Authorizations.OpenIddictAuthorization", null).WithMany().HasForeignKey("AuthorizationId");
        });
        _ = modelBuilder.Entity("Volo.Abp.TenantManagement.TenantConnectionString", b => b.HasOne("Volo.Abp.TenantManagement.Tenant", null).WithMany("ConnectionStrings").HasForeignKey("TenantId").OnDelete(Cascade).IsRequired());
        _ = modelBuilder.Entity("Volo.Abp.AuditLogging.AuditLog", b =>
        {
            _ = b.Navigation("Actions");
            _ = b.Navigation("EntityChanges");
        });
        _ = modelBuilder.Entity("Volo.Abp.AuditLogging.EntityChange", b => b.Navigation("PropertyChanges"));
        _ = modelBuilder.Entity("Volo.Abp.Identity.IdentityRole", b => b.Navigation("Claims"));
        _ = modelBuilder.Entity("Volo.Abp.Identity.IdentityUser", b =>
        {
            _ = b.Navigation("Claims");
            _ = b.Navigation("Logins");
            _ = b.Navigation("OrganizationUnits");
            _ = b.Navigation("Roles");
            _ = b.Navigation("Tokens");
        });
        _ = modelBuilder.Entity("Volo.Abp.Identity.OrganizationUnit", b => b.Navigation("Roles"));
        _ = modelBuilder.Entity("Volo.Abp.TenantManagement.Tenant", b => b.Navigation("ConnectionStrings"));
    }
}

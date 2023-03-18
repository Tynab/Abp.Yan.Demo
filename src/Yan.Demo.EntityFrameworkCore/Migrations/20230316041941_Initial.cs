using Microsoft.EntityFrameworkCore.Migrations;
using System;
using static Microsoft.EntityFrameworkCore.Migrations.ReferentialAction;

#nullable disable

namespace Yan.Demo.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.CreateTable(name: "AbpAuditLogs", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            ApplicationName = b.Column<string>(type: "nvarchar(96)", maxLength: 96, nullable: true),
            UserId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            UserName = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            TenantId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            TenantName = b.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
            ImpersonatorUserId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            ImpersonatorUserName = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            ImpersonatorTenantId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            ImpersonatorTenantName = b.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
            ExecutionTime = b.Column<DateTime>(type: "datetime2", nullable: false),
            ExecutionDuration = b.Column<int>(type: "int", nullable: false),
            ClientIpAddress = b.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
            ClientName = b.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
            ClientId = b.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
            CorrelationId = b.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
            BrowserInfo = b.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
            HttpMethod = b.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
            Url = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            Exceptions = b.Column<string>(type: "nvarchar(max)", nullable: true),
            Comments = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            HttpStatusCode = b.Column<int>(type: "int", nullable: true),
            ExtraProperties = b.Column<string>(type: "nvarchar(max)", nullable: true),
            ConcurrencyStamp = b.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
        }, constraints: x => x.PrimaryKey("PK_AbpAuditLogs", y => y.Id));
        _ = migrationBuilder.CreateTable(name: "AbpBackgroundJobs", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            JobName = b.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            JobArgs = b.Column<string>(type: "nvarchar(max)", maxLength: 1048576, nullable: false),
            TryCount = b.Column<short>(type: "smallint", nullable: false, defaultValue: (short)0),
            CreationTime = b.Column<DateTime>(type: "datetime2", nullable: false),
            NextTryTime = b.Column<DateTime>(type: "datetime2", nullable: false),
            LastTryTime = b.Column<DateTime>(type: "datetime2", nullable: true),
            IsAbandoned = b.Column<bool>(type: "bit", nullable: false, defaultValue: false),
            Priority = b.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)15),
            ExtraProperties = b.Column<string>(type: "nvarchar(max)", nullable: true),
            ConcurrencyStamp = b.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
        }, constraints: x => x.PrimaryKey("PK_AbpBackgroundJobs", y => y.Id));
        _ = migrationBuilder.CreateTable(name: "AbpClaimTypes", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            Name = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
            Required = b.Column<bool>(type: "bit", nullable: false),
            IsStatic = b.Column<bool>(type: "bit", nullable: false),
            Regex = b.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
            RegexDescription = b.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
            Description = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            ValueType = b.Column<int>(type: "int", nullable: false),
            ExtraProperties = b.Column<string>(type: "nvarchar(max)", nullable: true),
            ConcurrencyStamp = b.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
        }, constraints: x => x.PrimaryKey("PK_AbpClaimTypes", y => y.Id));
        _ = migrationBuilder.CreateTable(name: "AbpFeatureGroups", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            Name = b.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            DisplayName = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
            ExtraProperties = b.Column<string>(type: "nvarchar(max)", nullable: true)
        }, constraints: x => x.PrimaryKey("PK_AbpFeatureGroups", y => y.Id));
        _ = migrationBuilder.CreateTable(name: "AbpFeatures", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            GroupName = b.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            Name = b.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            ParentName = b.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
            DisplayName = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
            Description = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            DefaultValue = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            IsVisibleToClients = b.Column<bool>(type: "bit", nullable: false),
            IsAvailableToHost = b.Column<bool>(type: "bit", nullable: false),
            AllowedProviders = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            ValueType = b.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
            ExtraProperties = b.Column<string>(type: "nvarchar(max)", nullable: true)
        }, constraints: x => x.PrimaryKey("PK_AbpFeatures", y => y.Id));
        _ = migrationBuilder.CreateTable(name: "AbpFeatureValues", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            Name = b.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            Value = b.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            ProviderName = b.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
            ProviderKey = b.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
        }, constraints: x => x.PrimaryKey("PK_AbpFeatureValues", y => y.Id));
        _ = migrationBuilder.CreateTable(name: "AbpLinkUsers", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            SourceUserId = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            SourceTenantId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            TargetUserId = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            TargetTenantId = b.Column<Guid>(type: "uniqueidentifier", nullable: true)
        }, constraints: x => x.PrimaryKey("PK_AbpLinkUsers", y => y.Id));
        _ = migrationBuilder.CreateTable(name: "AbpOrganizationUnits", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            TenantId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            ParentId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            Code = b.Column<string>(type: "nvarchar(95)", maxLength: 95, nullable: false),
            DisplayName = b.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            ExtraProperties = b.Column<string>(type: "nvarchar(max)", nullable: true),
            ConcurrencyStamp = b.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
            CreationTime = b.Column<DateTime>(type: "datetime2", nullable: false),
            CreatorId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            LastModificationTime = b.Column<DateTime>(type: "datetime2", nullable: true),
            LastModifierId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            IsDeleted = b.Column<bool>(type: "bit", nullable: false, defaultValue: false),
            DeleterId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            DeletionTime = b.Column<DateTime>(type: "datetime2", nullable: true)
        }, constraints: x =>
        {
            _ = x.PrimaryKey("PK_AbpOrganizationUnits", y => y.Id);
            _ = x.ForeignKey(name: "FK_AbpOrganizationUnits_AbpOrganizationUnits_ParentId", column: y => y.ParentId, principalTable: "AbpOrganizationUnits", principalColumn: "Id");
        });
        _ = migrationBuilder.CreateTable(name: "AbpPermissionGrants", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            TenantId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            Name = b.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            ProviderName = b.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
            ProviderKey = b.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
        }, constraints: x => x.PrimaryKey("PK_AbpPermissionGrants", y => y.Id));
        _ = migrationBuilder.CreateTable(name: "AbpPermissionGroups", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            Name = b.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            DisplayName = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
            ExtraProperties = b.Column<string>(type: "nvarchar(max)", nullable: true)
        }, constraints: x => x.PrimaryKey("PK_AbpPermissionGroups", y => y.Id));
        _ = migrationBuilder.CreateTable(name: "AbpPermissions", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            GroupName = b.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            Name = b.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            ParentName = b.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
            DisplayName = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
            IsEnabled = b.Column<bool>(type: "bit", nullable: false),
            MultiTenancySide = b.Column<byte>(type: "tinyint", nullable: false),
            Providers = b.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
            StateCheckers = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            ExtraProperties = b.Column<string>(type: "nvarchar(max)", nullable: true)
        }, constraints: x => x.PrimaryKey("PK_AbpPermissions", y => y.Id));
        _ = migrationBuilder.CreateTable(name: "AbpRoles", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            TenantId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            Name = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
            NormalizedName = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
            IsDefault = b.Column<bool>(type: "bit", nullable: false),
            IsStatic = b.Column<bool>(type: "bit", nullable: false),
            IsPublic = b.Column<bool>(type: "bit", nullable: false),
            ExtraProperties = b.Column<string>(type: "nvarchar(max)", nullable: true),
            ConcurrencyStamp = b.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
        }, constraints: x => x.PrimaryKey("PK_AbpRoles", y => y.Id));
        _ = migrationBuilder.CreateTable(name: "AbpSecurityLogs", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            TenantId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            ApplicationName = b.Column<string>(type: "nvarchar(96)", maxLength: 96, nullable: true),
            Identity = b.Column<string>(type: "nvarchar(96)", maxLength: 96, nullable: true),
            Action = b.Column<string>(type: "nvarchar(96)", maxLength: 96, nullable: true),
            UserId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            UserName = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            TenantName = b.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
            ClientId = b.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
            CorrelationId = b.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
            ClientIpAddress = b.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
            BrowserInfo = b.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
            CreationTime = b.Column<DateTime>(type: "datetime2", nullable: false),
            ExtraProperties = b.Column<string>(type: "nvarchar(max)", nullable: true),
            ConcurrencyStamp = b.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
        }, constraints: x => x.PrimaryKey("PK_AbpSecurityLogs", y => y.Id));
        _ = migrationBuilder.CreateTable(name: "AbpSettings", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            Name = b.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            Value = b.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
            ProviderName = b.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
            ProviderKey = b.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
        }, constraints: x => x.PrimaryKey("PK_AbpSettings", y => y.Id));
        _ = migrationBuilder.CreateTable(name: "AbpTenants", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            Name = b.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
            ExtraProperties = b.Column<string>(type: "nvarchar(max)", nullable: true),
            ConcurrencyStamp = b.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
            CreationTime = b.Column<DateTime>(type: "datetime2", nullable: false),
            CreatorId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            LastModificationTime = b.Column<DateTime>(type: "datetime2", nullable: true),
            LastModifierId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            IsDeleted = b.Column<bool>(type: "bit", nullable: false, defaultValue: false),
            DeleterId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            DeletionTime = b.Column<DateTime>(type: "datetime2", nullable: true)
        }, constraints: x => x.PrimaryKey("PK_AbpTenants", y => y.Id));
        _ = migrationBuilder.CreateTable(name: "AbpUsers", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            TenantId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            UserName = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
            NormalizedUserName = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
            Name = b.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
            Surname = b.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
            Email = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
            NormalizedEmail = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
            EmailConfirmed = b.Column<bool>(type: "bit", nullable: false, defaultValue: false),
            PasswordHash = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            SecurityStamp = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
            IsExternal = b.Column<bool>(type: "bit", nullable: false, defaultValue: false),
            PhoneNumber = b.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
            PhoneNumberConfirmed = b.Column<bool>(type: "bit", nullable: false, defaultValue: false),
            IsActive = b.Column<bool>(type: "bit", nullable: false),
            TwoFactorEnabled = b.Column<bool>(type: "bit", nullable: false, defaultValue: false),
            LockoutEnd = b.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
            LockoutEnabled = b.Column<bool>(type: "bit", nullable: false, defaultValue: false),
            AccessFailedCount = b.Column<int>(type: "int", nullable: false, defaultValue: 0),
            ExtraProperties = b.Column<string>(type: "nvarchar(max)", nullable: true),
            ConcurrencyStamp = b.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
            CreationTime = b.Column<DateTime>(type: "datetime2", nullable: false),
            CreatorId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            LastModificationTime = b.Column<DateTime>(type: "datetime2", nullable: true),
            LastModifierId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            IsDeleted = b.Column<bool>(type: "bit", nullable: false, defaultValue: false),
            DeleterId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            DeletionTime = b.Column<DateTime>(type: "datetime2", nullable: true)
        }, constraints: x => x.PrimaryKey("PK_AbpUsers", y => y.Id));
        _ = migrationBuilder.CreateTable(name: "OpenIddictApplications", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            ClientId = b.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            ClientSecret = b.Column<string>(type: "nvarchar(max)", nullable: true),
            ConsentType = b.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            DisplayName = b.Column<string>(type: "nvarchar(max)", nullable: true),
            DisplayNames = b.Column<string>(type: "nvarchar(max)", nullable: true),
            Permissions = b.Column<string>(type: "nvarchar(max)", nullable: true),
            PostLogoutRedirectUris = b.Column<string>(type: "nvarchar(max)", nullable: true),
            Properties = b.Column<string>(type: "nvarchar(max)", nullable: true),
            RedirectUris = b.Column<string>(type: "nvarchar(max)", nullable: true),
            Requirements = b.Column<string>(type: "nvarchar(max)", nullable: true),
            Type = b.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            ClientUri = b.Column<string>(type: "nvarchar(max)", nullable: true),
            LogoUri = b.Column<string>(type: "nvarchar(max)", nullable: true),
            ExtraProperties = b.Column<string>(type: "nvarchar(max)", nullable: true),
            ConcurrencyStamp = b.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
            CreationTime = b.Column<DateTime>(type: "datetime2", nullable: false),
            CreatorId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            LastModificationTime = b.Column<DateTime>(type: "datetime2", nullable: true),
            LastModifierId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            IsDeleted = b.Column<bool>(type: "bit", nullable: false, defaultValue: false),
            DeleterId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            DeletionTime = b.Column<DateTime>(type: "datetime2", nullable: true)
        }, constraints: x => x.PrimaryKey("PK_OpenIddictApplications", y => y.Id));
        _ = migrationBuilder.CreateTable(name: "OpenIddictScopes", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            Description = b.Column<string>(type: "nvarchar(max)", nullable: true),
            Descriptions = b.Column<string>(type: "nvarchar(max)", nullable: true),
            DisplayName = b.Column<string>(type: "nvarchar(max)", nullable: true),
            DisplayNames = b.Column<string>(type: "nvarchar(max)", nullable: true),
            Name = b.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
            Properties = b.Column<string>(type: "nvarchar(max)", nullable: true),
            Resources = b.Column<string>(type: "nvarchar(max)", nullable: true),
            ExtraProperties = b.Column<string>(type: "nvarchar(max)", nullable: true),
            ConcurrencyStamp = b.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
            CreationTime = b.Column<DateTime>(type: "datetime2", nullable: false),
            CreatorId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            LastModificationTime = b.Column<DateTime>(type: "datetime2", nullable: true),
            LastModifierId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            IsDeleted = b.Column<bool>(type: "bit", nullable: false, defaultValue: false),
            DeleterId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            DeletionTime = b.Column<DateTime>(type: "datetime2", nullable: true)
        }, constraints: x => x.PrimaryKey("PK_OpenIddictScopes", y => y.Id));
        _ = migrationBuilder.CreateTable(name: "AbpAuditLogActions", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            TenantId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            AuditLogId = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            ServiceName = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            MethodName = b.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
            Parameters = b.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
            ExecutionTime = b.Column<DateTime>(type: "datetime2", nullable: false),
            ExecutionDuration = b.Column<int>(type: "int", nullable: false),
            ExtraProperties = b.Column<string>(type: "nvarchar(max)", nullable: true)
        }, constraints: x =>
        {
            _ = x.PrimaryKey("PK_AbpAuditLogActions", y => y.Id);
            _ = x.ForeignKey(name: "FK_AbpAuditLogActions_AbpAuditLogs_AuditLogId", column: y => y.AuditLogId, principalTable: "AbpAuditLogs", principalColumn: "Id", onDelete: Cascade);
        });
        _ = migrationBuilder.CreateTable(name: "AbpEntityChanges", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            AuditLogId = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            TenantId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            ChangeTime = b.Column<DateTime>(type: "datetime2", nullable: false),
            ChangeType = b.Column<byte>(type: "tinyint", nullable: false),
            EntityTenantId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            EntityId = b.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            EntityTypeFullName = b.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            ExtraProperties = b.Column<string>(type: "nvarchar(max)", nullable: true)
        }, constraints: x =>
        {
            _ = x.PrimaryKey("PK_AbpEntityChanges", y => y.Id);
            _ = x.ForeignKey(name: "FK_AbpEntityChanges_AbpAuditLogs_AuditLogId", column: y => y.AuditLogId, principalTable: "AbpAuditLogs", principalColumn: "Id", onDelete: Cascade);
        });
        _ = migrationBuilder.CreateTable(name: "AbpOrganizationUnitRoles", columns: b => new
        {
            RoleId = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            OrganizationUnitId = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            TenantId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            CreationTime = b.Column<DateTime>(type: "datetime2", nullable: false),
            CreatorId = b.Column<Guid>(type: "uniqueidentifier", nullable: true)
        }, constraints: x =>
        {
            _ = x.PrimaryKey("PK_AbpOrganizationUnitRoles", x => new
            {
                x.OrganizationUnitId,
                x.RoleId
            });
            _ = x.ForeignKey(name: "FK_AbpOrganizationUnitRoles_AbpOrganizationUnits_OrganizationUnitId", column: y => y.OrganizationUnitId, principalTable: "AbpOrganizationUnits", principalColumn: "Id", onDelete: Cascade);
            _ = x.ForeignKey(name: "FK_AbpOrganizationUnitRoles_AbpRoles_RoleId", column: y => y.RoleId, principalTable: "AbpRoles", principalColumn: "Id", onDelete: Cascade);
        });
        _ = migrationBuilder.CreateTable(name: "AbpRoleClaims", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            RoleId = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            TenantId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            ClaimType = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
            ClaimValue = b.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
        }, constraints: x =>
        {
            _ = x.PrimaryKey("PK_AbpRoleClaims", y => y.Id);
            _ = x.ForeignKey(name: "FK_AbpRoleClaims_AbpRoles_RoleId", column: y => y.RoleId, principalTable: "AbpRoles", principalColumn: "Id", onDelete: Cascade);
        });
        _ = migrationBuilder.CreateTable(name: "AbpTenantConnectionStrings", columns: b => new
        {
            TenantId = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            Name = b.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
            Value = b.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
        }, constraints: x =>
        {
            _ = x.PrimaryKey("PK_AbpTenantConnectionStrings", x => new
            {
                x.TenantId,
                x.Name
            });
            _ = x.ForeignKey(name: "FK_AbpTenantConnectionStrings_AbpTenants_TenantId", column: y => y.TenantId, principalTable: "AbpTenants", principalColumn: "Id", onDelete: Cascade);
        });
        _ = migrationBuilder.CreateTable(name: "AbpUserClaims", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            UserId = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            TenantId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            ClaimType = b.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
            ClaimValue = b.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
        }, constraints: x =>
        {
            _ = x.PrimaryKey("PK_AbpUserClaims", y => y.Id);
            _ = x.ForeignKey(name: "FK_AbpUserClaims_AbpUsers_UserId", column: y => y.UserId, principalTable: "AbpUsers", principalColumn: "Id", onDelete: Cascade);
        });
        _ = migrationBuilder.CreateTable(name: "AbpUserLogins", columns: b => new
        {
            UserId = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            LoginProvider = b.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
            TenantId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            ProviderKey = b.Column<string>(type: "nvarchar(196)", maxLength: 196, nullable: false),
            ProviderDisplayName = b.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
        }, constraints: x =>
        {
            _ = x.PrimaryKey("PK_AbpUserLogins", x => new
            {
                x.UserId,
                x.LoginProvider
            });
            _ = x.ForeignKey(name: "FK_AbpUserLogins_AbpUsers_UserId", column: y => y.UserId, principalTable: "AbpUsers", principalColumn: "Id", onDelete: Cascade);
        });
        _ = migrationBuilder.CreateTable(name: "AbpUserOrganizationUnits", columns: b => new
        {
            UserId = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            OrganizationUnitId = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            TenantId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            CreationTime = b.Column<DateTime>(type: "datetime2", nullable: false),
            CreatorId = b.Column<Guid>(type: "uniqueidentifier", nullable: true)
        }, constraints: x =>
        {
            _ = x.PrimaryKey("PK_AbpUserOrganizationUnits", x => new
            {
                x.OrganizationUnitId,
                x.UserId
            });
            _ = x.ForeignKey(name: "FK_AbpUserOrganizationUnits_AbpOrganizationUnits_OrganizationUnitId", column: y => y.OrganizationUnitId, principalTable: "AbpOrganizationUnits", principalColumn: "Id", onDelete: Cascade);
            _ = x.ForeignKey(name: "FK_AbpUserOrganizationUnits_AbpUsers_UserId", column: y => y.UserId, principalTable: "AbpUsers", principalColumn: "Id", onDelete: Cascade);
        });
        _ = migrationBuilder.CreateTable(name: "AbpUserRoles", columns: b => new
        {
            UserId = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            RoleId = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            TenantId = b.Column<Guid>(type: "uniqueidentifier", nullable: true)
        }, constraints: x =>
        {
            _ = x.PrimaryKey("PK_AbpUserRoles", x => new
            {
                x.UserId,
                x.RoleId
            });
            _ = x.ForeignKey(name: "FK_AbpUserRoles_AbpRoles_RoleId", column: y => y.RoleId, principalTable: "AbpRoles", principalColumn: "Id", onDelete: Cascade);
            _ = x.ForeignKey(name: "FK_AbpUserRoles_AbpUsers_UserId", column: y => y.UserId, principalTable: "AbpUsers", principalColumn: "Id", onDelete: Cascade);
        });
        _ = migrationBuilder.CreateTable(name: "AbpUserTokens", columns: b => new
        {
            UserId = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            LoginProvider = b.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
            Name = b.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            TenantId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            Value = b.Column<string>(type: "nvarchar(max)", nullable: true)
        }, constraints: x =>
        {
            _ = x.PrimaryKey("PK_AbpUserTokens", x => new
            {
                x.UserId,
                x.LoginProvider,
                x.Name
            });
            _ = x.ForeignKey(name: "FK_AbpUserTokens_AbpUsers_UserId", column: y => y.UserId, principalTable: "AbpUsers", principalColumn: "Id", onDelete: Cascade);
        });
        _ = migrationBuilder.CreateTable(name: "OpenIddictAuthorizations", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            ApplicationId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            CreationDate = b.Column<DateTime>(type: "datetime2", nullable: true),
            Properties = b.Column<string>(type: "nvarchar(max)", nullable: true),
            Scopes = b.Column<string>(type: "nvarchar(max)", nullable: true),
            Status = b.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            Subject = b.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
            Type = b.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            ExtraProperties = b.Column<string>(type: "nvarchar(max)", nullable: true),
            ConcurrencyStamp = b.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
            CreationTime = b.Column<DateTime>(type: "datetime2", nullable: false),
            CreatorId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            LastModificationTime = b.Column<DateTime>(type: "datetime2", nullable: true),
            LastModifierId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            IsDeleted = b.Column<bool>(type: "bit", nullable: false, defaultValue: false),
            DeleterId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            DeletionTime = b.Column<DateTime>(type: "datetime2", nullable: true)
        }, constraints: x =>
        {
            _ = x.PrimaryKey("PK_OpenIddictAuthorizations", y => y.Id);
            _ = x.ForeignKey(name: "FK_OpenIddictAuthorizations_OpenIddictApplications_ApplicationId", column: y => y.ApplicationId, principalTable: "OpenIddictApplications", principalColumn: "Id");
        });
        _ = migrationBuilder.CreateTable(name: "AbpEntityPropertyChanges", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            TenantId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            EntityChangeId = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            NewValue = b.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
            OriginalValue = b.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
            PropertyName = b.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            PropertyTypeFullName = b.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
        }, constraints: x =>
        {
            _ = x.PrimaryKey("PK_AbpEntityPropertyChanges", y => y.Id);
            _ = x.ForeignKey(name: "FK_AbpEntityPropertyChanges_AbpEntityChanges_EntityChangeId", column: y => y.EntityChangeId, principalTable: "AbpEntityChanges", principalColumn: "Id", onDelete: Cascade);
        });
        _ = migrationBuilder.CreateTable(name: "OpenIddictTokens", columns: b => new
        {
            Id = b.Column<Guid>(type: "uniqueidentifier", nullable: false),
            ApplicationId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            AuthorizationId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            CreationDate = b.Column<DateTime>(type: "datetime2", nullable: true),
            ExpirationDate = b.Column<DateTime>(type: "datetime2", nullable: true),
            Payload = b.Column<string>(type: "nvarchar(max)", nullable: true),
            Properties = b.Column<string>(type: "nvarchar(max)", nullable: true),
            RedemptionDate = b.Column<DateTime>(type: "datetime2", nullable: true),
            ReferenceId = b.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            Status = b.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            Subject = b.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
            Type = b.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            ExtraProperties = b.Column<string>(type: "nvarchar(max)", nullable: true),
            ConcurrencyStamp = b.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
            CreationTime = b.Column<DateTime>(type: "datetime2", nullable: false),
            CreatorId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            LastModificationTime = b.Column<DateTime>(type: "datetime2", nullable: true),
            LastModifierId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            IsDeleted = b.Column<bool>(type: "bit", nullable: false, defaultValue: false),
            DeleterId = b.Column<Guid>(type: "uniqueidentifier", nullable: true),
            DeletionTime = b.Column<DateTime>(type: "datetime2", nullable: true)
        }, constraints: x =>
        {
            _ = x.PrimaryKey("PK_OpenIddictTokens", y => y.Id);
            _ = x.ForeignKey(name: "FK_OpenIddictTokens_OpenIddictApplications_ApplicationId", column: y => y.ApplicationId, principalTable: "OpenIddictApplications", principalColumn: "Id");
            _ = x.ForeignKey(name: "FK_OpenIddictTokens_OpenIddictAuthorizations_AuthorizationId", column: y => y.AuthorizationId, principalTable: "OpenIddictAuthorizations", principalColumn: "Id");
        });
        _ = migrationBuilder.CreateIndex(name: "IX_AbpAuditLogActions_AuditLogId", table: "AbpAuditLogActions", column: "AuditLogId");
        _ = migrationBuilder.CreateIndex(name: "IX_AbpAuditLogActions_TenantId_ServiceName_MethodName_ExecutionTime", table: "AbpAuditLogActions", columns: new[]
        {
            "TenantId",
            "ServiceName",
            "MethodName",
            "ExecutionTime"
        });
        _ = migrationBuilder.CreateIndex(name: "IX_AbpAuditLogs_TenantId_ExecutionTime", table: "AbpAuditLogs", columns: new[]
        {
            "TenantId",
            "ExecutionTime"
        });
        _ = migrationBuilder.CreateIndex(name: "IX_AbpAuditLogs_TenantId_UserId_ExecutionTime", table: "AbpAuditLogs", columns: new[]
        {
            "TenantId",
            "UserId",
            "ExecutionTime"
        });
        _ = migrationBuilder.CreateIndex(name: "IX_AbpBackgroundJobs_IsAbandoned_NextTryTime", table: "AbpBackgroundJobs", columns: new[]
        {
            "IsAbandoned",
            "NextTryTime"
        });
        _ = migrationBuilder.CreateIndex(name: "IX_AbpEntityChanges_AuditLogId", table: "AbpEntityChanges", column: "AuditLogId");
        _ = migrationBuilder.CreateIndex(name: "IX_AbpEntityChanges_TenantId_EntityTypeFullName_EntityId", table: "AbpEntityChanges", columns: new[]
        {
            "TenantId",
            "EntityTypeFullName",
            "EntityId"
        });
        _ = migrationBuilder.CreateIndex(name: "IX_AbpEntityPropertyChanges_EntityChangeId", table: "AbpEntityPropertyChanges", column: "EntityChangeId");
        _ = migrationBuilder.CreateIndex(name: "IX_AbpFeatureGroups_Name", table: "AbpFeatureGroups", column: "Name", unique: true);
        _ = migrationBuilder.CreateIndex(name: "IX_AbpFeatures_GroupName", table: "AbpFeatures", column: "GroupName");
        _ = migrationBuilder.CreateIndex(name: "IX_AbpFeatures_Name", table: "AbpFeatures", column: "Name", unique: true);
        _ = migrationBuilder.CreateIndex(name: "IX_AbpFeatureValues_Name_ProviderName_ProviderKey", table: "AbpFeatureValues", columns: new[]
        {
            "Name",
            "ProviderName",
            "ProviderKey"
        }, unique: true, filter: "[ProviderName] IS NOT NULL AND [ProviderKey] IS NOT NULL");
        _ = migrationBuilder.CreateIndex(name: "IX_AbpLinkUsers_SourceUserId_SourceTenantId_TargetUserId_TargetTenantId", table: "AbpLinkUsers", columns: new[]
        {
            "SourceUserId",
            "SourceTenantId",
            "TargetUserId",
            "TargetTenantId"
        }, unique: true, filter: "[SourceTenantId] IS NOT NULL AND [TargetTenantId] IS NOT NULL");
        _ = migrationBuilder.CreateIndex(name: "IX_AbpOrganizationUnitRoles_RoleId_OrganizationUnitId", table: "AbpOrganizationUnitRoles", columns: new[]
        {
            "RoleId",
            "OrganizationUnitId"
        });
        _ = migrationBuilder.CreateIndex(name: "IX_AbpOrganizationUnits_Code", table: "AbpOrganizationUnits", column: "Code");
        _ = migrationBuilder.CreateIndex(name: "IX_AbpOrganizationUnits_ParentId", table: "AbpOrganizationUnits", column: "ParentId");
        _ = migrationBuilder.CreateIndex(name: "IX_AbpPermissionGrants_TenantId_Name_ProviderName_ProviderKey", table: "AbpPermissionGrants", columns: new[]
        {
            "TenantId",
            "Name",
            "ProviderName",
            "ProviderKey"
        }, unique: true, filter: "[TenantId] IS NOT NULL");
        _ = migrationBuilder.CreateIndex(name: "IX_AbpPermissionGroups_Name", table: "AbpPermissionGroups", column: "Name", unique: true);
        _ = migrationBuilder.CreateIndex(name: "IX_AbpPermissions_GroupName", table: "AbpPermissions", column: "GroupName");
        _ = migrationBuilder.CreateIndex(name: "IX_AbpPermissions_Name", table: "AbpPermissions", column: "Name", unique: true);
        _ = migrationBuilder.CreateIndex(name: "IX_AbpRoleClaims_RoleId", table: "AbpRoleClaims", column: "RoleId");
        _ = migrationBuilder.CreateIndex(name: "IX_AbpRoles_NormalizedName", table: "AbpRoles", column: "NormalizedName");
        _ = migrationBuilder.CreateIndex(name: "IX_AbpSecurityLogs_TenantId_Action", table: "AbpSecurityLogs", columns: new[]
        {
            "TenantId",
            "Action"
        });
        _ = migrationBuilder.CreateIndex(name: "IX_AbpSecurityLogs_TenantId_ApplicationName", table: "AbpSecurityLogs", columns: new[]
        {
            "TenantId",
            "ApplicationName"
        });
        _ = migrationBuilder.CreateIndex(name: "IX_AbpSecurityLogs_TenantId_Identity", table: "AbpSecurityLogs", columns: new[]
        {
            "TenantId",
            "Identity"
        });
        _ = migrationBuilder.CreateIndex(name: "IX_AbpSecurityLogs_TenantId_UserId", table: "AbpSecurityLogs", columns: new[]
        {
            "TenantId",
            "UserId"
        });
        _ = migrationBuilder.CreateIndex(name: "IX_AbpSettings_Name_ProviderName_ProviderKey", table: "AbpSettings", columns: new[]
        {
            "Name",
            "ProviderName",
            "ProviderKey"
        }, unique: true, filter: "[ProviderName] IS NOT NULL AND [ProviderKey] IS NOT NULL");
        _ = migrationBuilder.CreateIndex(name: "IX_AbpTenants_Name", table: "AbpTenants", column: "Name");
        _ = migrationBuilder.CreateIndex(name: "IX_AbpUserClaims_UserId", table: "AbpUserClaims", column: "UserId");
        _ = migrationBuilder.CreateIndex(name: "IX_AbpUserLogins_LoginProvider_ProviderKey", table: "AbpUserLogins", columns: new[]
        {
            "LoginProvider",
            "ProviderKey"
        });
        _ = migrationBuilder.CreateIndex(name: "IX_AbpUserOrganizationUnits_UserId_OrganizationUnitId", table: "AbpUserOrganizationUnits", columns: new[]
        {
            "UserId",
            "OrganizationUnitId"
        });
        _ = migrationBuilder.CreateIndex(name: "IX_AbpUserRoles_RoleId_UserId", table: "AbpUserRoles", columns: new[]
        {
            "RoleId",
            "UserId"
        });
        _ = migrationBuilder.CreateIndex(name: "IX_AbpUsers_Email", table: "AbpUsers", column: "Email");
        _ = migrationBuilder.CreateIndex(name: "IX_AbpUsers_NormalizedEmail", table: "AbpUsers", column: "NormalizedEmail");
        _ = migrationBuilder.CreateIndex(name: "IX_AbpUsers_NormalizedUserName", table: "AbpUsers", column: "NormalizedUserName");
        _ = migrationBuilder.CreateIndex(name: "IX_AbpUsers_UserName", table: "AbpUsers", column: "UserName");
        _ = migrationBuilder.CreateIndex(name: "IX_OpenIddictApplications_ClientId", table: "OpenIddictApplications", column: "ClientId");
        _ = migrationBuilder.CreateIndex(name: "IX_OpenIddictAuthorizations_ApplicationId_Status_Subject_Type", table: "OpenIddictAuthorizations", columns: new[]
        {
            "ApplicationId",
            "Status",
            "Subject", "Type" });
        _ = migrationBuilder.CreateIndex(name: "IX_OpenIddictScopes_Name", table: "OpenIddictScopes", column: "Name");
        _ = migrationBuilder.CreateIndex(name: "IX_OpenIddictTokens_ApplicationId_Status_Subject_Type", table: "OpenIddictTokens", columns: new[]
        {
            "ApplicationId",
            "Status",
            "Subject",
            "Type"
        });
        _ = migrationBuilder.CreateIndex(name: "IX_OpenIddictTokens_AuthorizationId", table: "OpenIddictTokens", column: "AuthorizationId");
        _ = migrationBuilder.CreateIndex(name: "IX_OpenIddictTokens_ReferenceId", table: "OpenIddictTokens", column: "ReferenceId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(name: "AbpAuditLogActions");
        _ = migrationBuilder.DropTable(name: "AbpBackgroundJobs");
        _ = migrationBuilder.DropTable(name: "AbpClaimTypes");
        _ = migrationBuilder.DropTable(name: "AbpEntityPropertyChanges");
        _ = migrationBuilder.DropTable(name: "AbpFeatureGroups");
        _ = migrationBuilder.DropTable(name: "AbpFeatures");
        _ = migrationBuilder.DropTable(name: "AbpFeatureValues");
        _ = migrationBuilder.DropTable(name: "AbpLinkUsers");
        _ = migrationBuilder.DropTable(name: "AbpOrganizationUnitRoles");
        _ = migrationBuilder.DropTable(name: "AbpPermissionGrants");
        _ = migrationBuilder.DropTable(name: "AbpPermissionGroups");
        _ = migrationBuilder.DropTable(name: "AbpPermissions");
        _ = migrationBuilder.DropTable(name: "AbpRoleClaims");
        _ = migrationBuilder.DropTable(name: "AbpSecurityLogs");
        _ = migrationBuilder.DropTable(name: "AbpSettings");
        _ = migrationBuilder.DropTable(name: "AbpTenantConnectionStrings");
        _ = migrationBuilder.DropTable(name: "AbpUserClaims");
        _ = migrationBuilder.DropTable(name: "AbpUserLogins");
        _ = migrationBuilder.DropTable(name: "AbpUserOrganizationUnits");
        _ = migrationBuilder.DropTable(name: "AbpUserRoles");
        _ = migrationBuilder.DropTable(name: "AbpUserTokens");
        _ = migrationBuilder.DropTable(name: "OpenIddictScopes");
        _ = migrationBuilder.DropTable(name: "OpenIddictTokens");
        _ = migrationBuilder.DropTable(name: "AbpEntityChanges");
        _ = migrationBuilder.DropTable(name: "AbpTenants");
        _ = migrationBuilder.DropTable(name: "AbpOrganizationUnits");
        _ = migrationBuilder.DropTable(name: "AbpRoles");
        _ = migrationBuilder.DropTable(name: "AbpUsers");
        _ = migrationBuilder.DropTable(name: "OpenIddictAuthorizations");
        _ = migrationBuilder.DropTable(name: "AbpAuditLogs");
        _ = migrationBuilder.DropTable(name: "OpenIddictApplications");
    }
}

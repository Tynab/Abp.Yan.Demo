using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using OpenIddict.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.OpenIddict.Applications;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Uow;
using static OpenIddict.Abstractions.OpenIddictConstants;
using static OpenIddict.Abstractions.OpenIddictConstants.ClientTypes;
using static OpenIddict.Abstractions.OpenIddictConstants.ConsentTypes;
using static OpenIddict.Abstractions.OpenIddictConstants.Permissions.Endpoints;
using static OpenIddict.Abstractions.OpenIddictConstants.Permissions.Prefixes;
using static OpenIddict.Abstractions.OpenIddictConstants.Permissions.ResponseTypes;
using static OpenIddict.Abstractions.OpenIddictConstants.Permissions.Scopes;
using static System.StringComparison;
using static System.Uri;
using static System.UriKind;
using static Volo.Abp.Authorization.Permissions.ClientPermissionValueProvider;
using static Volo.Abp.Check;

namespace Yan.Demo.OpenIddict;

public class OpenIddictDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    #region Fields
    private readonly IConfiguration _configuration;
    private readonly IAbpApplicationManager _applicationManager;
    private readonly IOpenIddictScopeManager _scopeManager;
    private readonly IPermissionDataSeeder _permissionDataSeeder;
    private readonly IStringLocalizer<OpenIddictResponse> L;
    #endregion

    #region Constructors
    public OpenIddictDataSeedContributor(IConfiguration configuration, IAbpApplicationManager applicationManager, IOpenIddictScopeManager scopeManager, IPermissionDataSeeder permissionDataSeeder, IStringLocalizer<OpenIddictResponse> l)
    {
        _configuration = configuration;
        _applicationManager = applicationManager;
        _scopeManager = scopeManager;
        _permissionDataSeeder = permissionDataSeeder;
        L = l;
    }
    #endregion

    #region Implements
    [UnitOfWork]
    public virtual async Task SeedAsync(DataSeedContext context)
    {
        await CreateScopesAsync();
        await CreateApplicationsAsync();
    }
    #endregion

    #region Methods
    private async Task CreateScopesAsync()
    {
        if (await _scopeManager.FindByNameAsync("Demo") == null)
        {
            _ = await _scopeManager.CreateAsync(new OpenIddictScopeDescriptor
            {
                Name = "Demo",
                DisplayName = "Demo API",
                Resources =
                {
                    "Demo"
                }
            });
        }
    }

    private async Task CreateApplicationsAsync()
    {
        var commonScopes = new List<string>
        {
            Address,
            Email,
            Phone,
            Profile,
            Roles,
            "Demo"
        };
        var configurationSection = _configuration.GetSection("OpenIddict:Applications");
        // web Client
        var webClientId = configurationSection["Demo_Web:ClientId"];
        if (!webClientId.IsNullOrWhiteSpace())
        {
            var webClientRootUrl = configurationSection["Demo_Web:RootUrl"].EnsureEndsWith('/');
            await CreateApplicationAsync(name: webClientId, type: Confidential, consentType: Implicit, displayName: "Web Application", secret: configurationSection["Demo_Web:ClientSecret"] ?? "1q2w3e*", grantTypes: new List<string>
            {
                GrantTypes.AuthorizationCode,
                GrantTypes.Implicit
            }, scopes: commonScopes, redirectUri: $"{webClientRootUrl}signin-oidc", clientUri: webClientRootUrl, postLogoutRedirectUri: $"{webClientRootUrl}signout-callback-oidc");
        }
        // console test / angular client
        var consoleAndAngularClientId = configurationSection["Demo_App:ClientId"];
        if (!consoleAndAngularClientId.IsNullOrWhiteSpace())
        {
            var consoleAndAngularClientRootUrl = configurationSection["Demo_App:RootUrl"]?.TrimEnd('/');
            await CreateApplicationAsync(name: consoleAndAngularClientId, type: Public, consentType: Implicit, displayName: "Console Test / Angular Application", secret: null, grantTypes: new List<string>
            {
                GrantTypes.AuthorizationCode,
                GrantTypes.Password,
                GrantTypes.ClientCredentials,
                GrantTypes.RefreshToken
            }, scopes: commonScopes, redirectUri: consoleAndAngularClientRootUrl, clientUri: consoleAndAngularClientRootUrl, postLogoutRedirectUri: consoleAndAngularClientRootUrl);
        }
        // blazor client
        var blazorClientId = configurationSection["Demo_Blazor:ClientId"];
        if (!blazorClientId.IsNullOrWhiteSpace())
        {
            var blazorRootUrl = configurationSection["Demo_Blazor:RootUrl"].TrimEnd('/');
            await CreateApplicationAsync(name: blazorClientId, type: Public, consentType: Implicit, displayName: "Blazor Application", secret: null, grantTypes: new List<string>
            {
                GrantTypes.AuthorizationCode,
            }, scopes: commonScopes, redirectUri: $"{blazorRootUrl}/authentication/login-callback", clientUri: blazorRootUrl, postLogoutRedirectUri: $"{blazorRootUrl}/authentication/logout-callback");
        }
        // blazor server tiered client
        var blazorServerTieredClientId = configurationSection["Demo_BlazorServerTiered:ClientId"];
        if (!blazorServerTieredClientId.IsNullOrWhiteSpace())
        {
            var blazorServerTieredRootUrl = configurationSection["Demo_BlazorServerTiered:RootUrl"].EnsureEndsWith('/');
            await CreateApplicationAsync(name: blazorServerTieredClientId, type: Confidential, consentType: Implicit, displayName: "Blazor Server Application", secret: configurationSection["Demo_BlazorServerTiered:ClientSecret"] ?? "1q2w3e*", grantTypes: new List<string>
            {
                GrantTypes.AuthorizationCode,
                GrantTypes.Implicit
            }, scopes: commonScopes, redirectUri: $"{blazorServerTieredRootUrl}signin-oidc", clientUri: blazorServerTieredRootUrl, postLogoutRedirectUri: $"{blazorServerTieredRootUrl}signout-callback-oidc");
        }
        // swagger client
        var swaggerClientId = configurationSection["Demo_Swagger:ClientId"];
        if (!swaggerClientId.IsNullOrWhiteSpace())
        {
            var swaggerRootUrl = configurationSection["Demo_Swagger:RootUrl"].TrimEnd('/');
            await CreateApplicationAsync(name: swaggerClientId, type: Public, consentType: Implicit, displayName: "Swagger Application", secret: null, grantTypes: new List<string>
            {
                GrantTypes.AuthorizationCode,
            }, scopes: commonScopes, redirectUri: $"{swaggerRootUrl}/swagger/oauth2-redirect.html", clientUri: swaggerRootUrl);
        }
    }

    private async Task CreateApplicationAsync([NotNull] string name, [NotNull] string type, [NotNull] string consentType, string displayName, string secret, List<string> grantTypes, List<string> scopes, string clientUri = null, string redirectUri = null, string postLogoutRedirectUri = null, List<string> permissions = null)
    {
        if (!string.IsNullOrEmpty(secret) && string.Equals(type, Public, OrdinalIgnoreCase))
        {
            throw new BusinessException(L["NoClientSecretCanBeSetForPublicApplications"]);
        }
        if (string.IsNullOrEmpty(secret) && string.Equals(type, Confidential, OrdinalIgnoreCase))
        {
            throw new BusinessException(L["TheClientSecretIsRequiredForConfidentialApplications"]);
        }
        if (!string.IsNullOrEmpty(name) && await _applicationManager.FindByClientIdAsync(name) != null)
        {
            return;
        }
        if (await _applicationManager.FindByClientIdAsync(name) == null)
        {
            var application = new AbpApplicationDescriptor
            {
                ClientId = name,
                Type = type,
                ClientSecret = secret,
                ConsentType = consentType,
                DisplayName = displayName,
                ClientUri = clientUri,
            };
            _ = NotNullOrEmpty(grantTypes, nameof(grantTypes));
            _ = NotNullOrEmpty(scopes, nameof(scopes));
            if (new[]
            {
                GrantTypes.AuthorizationCode,
                GrantTypes.Implicit
            }.All(grantTypes.Contains))
            {
                _ = application.Permissions.Add(CodeIdToken);
                if (string.Equals(type, Public, OrdinalIgnoreCase))
                {
                    _ = application.Permissions.Add(CodeIdTokenToken);
                    _ = application.Permissions.Add(CodeToken);
                }
            }
            if (!redirectUri.IsNullOrWhiteSpace() || !postLogoutRedirectUri.IsNullOrWhiteSpace())
            {
                _ = application.Permissions.Add(Logout);
            }
            foreach (var grantType in grantTypes)
            {
                if (grantType == GrantTypes.AuthorizationCode)
                {
                    _ = application.Permissions.Add(Permissions.GrantTypes.AuthorizationCode);
                    _ = application.Permissions.Add(Code);
                }
                if (grantType is GrantTypes.AuthorizationCode or GrantTypes.Implicit)
                {
                    _ = application.Permissions.Add(Authorization);
                }
                if (grantType is GrantTypes.AuthorizationCode or GrantTypes.ClientCredentials or GrantTypes.Password or GrantTypes.RefreshToken or GrantTypes.DeviceCode)
                {
                    _ = application.Permissions.Add(Permissions.Endpoints.Token);
                    _ = application.Permissions.Add(Revocation);
                    _ = application.Permissions.Add(Introspection);
                }
                if (grantType == GrantTypes.ClientCredentials)
                {
                    _ = application.Permissions.Add(Permissions.GrantTypes.ClientCredentials);
                }
                if (grantType == GrantTypes.Implicit)
                {
                    _ = application.Permissions.Add(Permissions.GrantTypes.Implicit);
                }
                if (grantType == GrantTypes.Password)
                {
                    _ = application.Permissions.Add(Permissions.GrantTypes.Password);
                }
                if (grantType == GrantTypes.RefreshToken)
                {
                    _ = application.Permissions.Add(Permissions.GrantTypes.RefreshToken);
                }
                if (grantType == GrantTypes.DeviceCode)
                {
                    _ = application.Permissions.Add(Permissions.GrantTypes.DeviceCode);
                    _ = application.Permissions.Add(Device);
                }
                if (grantType == GrantTypes.Implicit)
                {
                    _ = application.Permissions.Add(IdToken);
                    if (string.Equals(type, Public, OrdinalIgnoreCase))
                    {
                        _ = application.Permissions.Add(IdTokenToken);
                        _ = application.Permissions.Add(Permissions.ResponseTypes.Token);
                    }
                }
            }
            var buildInScopes = new[]
            {
                Address,
                Email,
                Phone,
                Profile,
                Roles
            };
            foreach (var scope in scopes)
            {
                _ = buildInScopes.Contains(scope) ? application.Permissions.Add(scope) : application.Permissions.Add(Scope + scope);
            }
            if (redirectUri != null)
            {
                if (!redirectUri.IsNullOrEmpty())
                {
                    if (!TryCreate(redirectUri, Absolute, out var uri) || !uri.IsWellFormedOriginalString())
                    {
                        throw new BusinessException(L["InvalidRedirectUri", redirectUri]);
                    }
                    if (application.RedirectUris.All(u => u != uri))
                    {
                        _ = application.RedirectUris.Add(uri);
                    }
                }
            }
            if (postLogoutRedirectUri != null)
            {
                if (!postLogoutRedirectUri.IsNullOrEmpty())
                {
                    if (!TryCreate(postLogoutRedirectUri, Absolute, out var uri) || !uri.IsWellFormedOriginalString())
                    {
                        throw new BusinessException(L["InvalidPostLogoutRedirectUri", postLogoutRedirectUri]);
                    }
                    if (application.PostLogoutRedirectUris.All(u => u != uri))
                    {
                        _ = application.PostLogoutRedirectUris.Add(uri);
                    }
                }
            }
            if (permissions != null)
            {
                await _permissionDataSeeder.SeedAsync(ProviderName, name, permissions, null);
            }
            _ = await _applicationManager.CreateAsync(application);
        }
    }
    #endregion
}

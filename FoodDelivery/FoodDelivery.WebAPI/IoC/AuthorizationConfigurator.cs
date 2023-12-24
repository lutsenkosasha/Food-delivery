using Duende.IdentityServer.Models;
using FoodDelivery.DataAccess;
using FoodDelivery.DataAccess.Entities;
using FoodDelivery.WebAPI.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ElectronicMenu.Services.IoC
{
    public static class AuthorizationConfigurator
    {
        public static void ConfigureServices(this IServiceCollection services, FoodDeliverySettings settings)
        {
            IdentityModelEventSource.ShowPII = true;
            services.AddIdentity<UserEntity, UserRoleEntity>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
            })
                .AddEntityFrameworkStores<FoodDeliveryDbContext>()
                .AddSignInManager<SignInManager<UserEntity>>()
                .AddDefaultTokenProviders();

            services.AddIdentityServer()
                .AddInMemoryApiScopes(new[] { new ApiScope("api") })
                .AddInMemoryClients(new[]
                {
                new Client()
                {
                    ClientName = settings.ClientId,
                    ClientId = settings.ClientId,
                    Enabled = true,
                    AllowOfflineAccess = true,
                    AllowedGrantTypes = new List<string>()
                    {
                        GrantType.ClientCredentials,
                        GrantType.ResourceOwnerPassword
                    },
                    ClientSecrets = new List<Duende.IdentityServer.Models.Secret>()
                    {
                        new(settings.ClientSecret.Sha256())
                    },
                    AllowedScopes = new List<string>() { "api" }
                }
                })
                .AddAspNetIdentity<UserEntity>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.RequireHttpsMetadata = false;
                options.Authority = settings.IdentityServerUri;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = false,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
                options.Audience = "api";
            });

            services.AddAuthorization();
        }

        public static void ConfigureApplication(IApplicationBuilder app)
        {
            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
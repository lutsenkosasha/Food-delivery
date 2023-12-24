using FoodDelivery.BL.Auth.Entities;
using FoodDelivery.DataAccess.Entities;

namespace FoodDelivery.BL.Auth;

public class AuthProvider : IAuthProvider
{
    private readonly SignInManager<UserEntity> _signInManager;
    private readonly UserManager<UserEntity> _userManager;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _identityServerUri;
    private readonly string _clientId;
    private readonly string _clientSecret;

    public AuthProvider(SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager,
    IHttpClientFactory httpClientFactory,
    string identityServerUri,
    string clientId,
    string clientSecret)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _identityServerUri = identityServerUri;
        _httpClientFactory = httpClientFactory;
        _clientId = clientId;
        _clientSecret = clientSecret;
    }

    public Task<TokensResponse> AuthorizeUser(string email, string password)
    {
        var user = await _userManager.FindByNameAsync(email);
        if (user is null)
        {
            throw new Exception();
        }

        var verificationPasswordResult = await _signInManager.CheckPasswordSignInAsync(user, password, false);
        if (!verificationPasswordResult.Succeeded)
        {
            throw new Exception();
        }

        var client = _httpClientFactory.CreateClient();
        var discoveryDoc = await client.GetDiscoveryDocumentAsync(_identityServerUri);
        if (discoveryDoc.IsError)
        {
            throw new Exception();
        }

        var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest()
        {
            Address = discoveryDoc.TokenEndpoint,
            GrantType = GrantType.ResourceOwnerPassword,
            ClientId = _clientId,
            ClientSecret = _clientSecret,
            Email = user.Email,
            Password = password,
            Scope = "api offline_access"
        });

        if (tokenResponse.IsError)
        {
            throw new Exception();
        }

        return new TokensResponse()
        {
            AccessToken = tokenResponse.AccessToken,
            RefreshToken = tokenResponse.RefreshToken
        };
    }

    public Task RegisterUser(RegisterUserModel model)
    {
        var user = await _userManager.FindByNameAsync(model.Email);
        if (!(user is null))
        {
            throw new Exception();  //Пользователь уже есть
        }

        UserEntity userEntity = new UserEntity()
        {
            Email = model.Email,
            PhoneNumber = model.PhoneNumber
        };

        var identityResult = _userManager.CreateAsync(userEntity, model.Password);
        if (!identityResult.IsCompletedSuccessfully)
        {
            throw new Exception();
        }
    }
}

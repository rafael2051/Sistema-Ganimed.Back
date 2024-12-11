using Sistema_Ganimedes.Application.Interfaces;
using System.Text;
using Sistema_Ganimedes.Domain.Entities;
using Newtonsoft.Json;
using System.Net;

namespace Sistema_Ganimedes.Application.Services
{
    public class LoginService : ILoginService
    {

        private readonly String _authenticationServiceUrl;
        private readonly String _authenticateEndpoint;
        private readonly String _validateTokenEndpoint;

        public LoginService()
        {
            _authenticationServiceUrl = Environment.GetEnvironmentVariable("AUTHENTICATION_SERVICE_URL")!;
            _authenticateEndpoint = _authenticationServiceUrl + Environment.GetEnvironmentVariable("AUTHENTICATE_ENDPOINT")!;
            _validateTokenEndpoint = _authenticationServiceUrl + Environment.GetEnvironmentVariable("VALIDATE_TOKEN")!;
        }

        public async Task<LoginResponse> ValidarLogin(string email, string senha)
        {

            var response = await new HttpClient().
                PostAsync(_authenticateEndpoint, new StringContent(
                    JsonConvert.SerializeObject(new Login(email, senha)),
                    Encoding.UTF8,
                    "application/json"
                ));

            var loginResponse = new LoginResponse();
            loginResponse.statusCode = response.StatusCode;

            if (response.StatusCode != HttpStatusCode.Accepted)
                return loginResponse;

            var responseBody = await response.Content.ReadAsStringAsync();

            var tokenFromResponse = JsonConvert.DeserializeObject<Token?>(responseBody);

            loginResponse.nUsp = tokenFromResponse!.nUsp;
            loginResponse.token = tokenFromResponse!.token;
            loginResponse.dataExpiracao = tokenFromResponse!.expiresAt;

            return loginResponse;

        }
    }
}

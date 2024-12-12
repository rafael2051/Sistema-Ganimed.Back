using Newtonsoft.Json;
using Sistema_Ganimedes.Application.Interfaces;
using Sistema_Ganimedes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Ganimedes.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly String _authenticationServiceUrl;
        private readonly String _validateTokenEndpoint;

        public AuthenticationService()
        {
            _authenticationServiceUrl = Environment.GetEnvironmentVariable("AUTHENTICATION_SERVICE_URL")!;
            _validateTokenEndpoint = _authenticationServiceUrl + Environment.GetEnvironmentVariable("VALIDATE_TOKEN")!;
        }

        public async Task<bool> ValidarToken(string token, string nUsp)
        {

            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", token);

            var response = await httpClient.GetAsync(_validateTokenEndpoint.Replace("@nUsp", nUsp));

            if(response.StatusCode != HttpStatusCode.Accepted)
                return false;

            return true;

        }
    }
}

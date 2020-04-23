using Auth0.ManagementApi;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerAuth.Api
{
    public class General
    {
        public static ManagementApiClient getAuthManagementApiToken()
        {
            string token = "";
            var client = new RestClient("https://nitinborse.auth0.com/oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\"client_id\":\"1lL7026rmoAEUK7w8qa7gAY7YwNCgOGe\",\"client_secret\":\"B7uurkD7zL1q0pK6bmbm8bj2xs5-dk5zXC7s9CqeA9CmLvx-OQFDrxcxu0WtfFzk\",\"audience\":\"https://nitinborse.auth0.com/api/v2/\",\"grant_type\":\"client_credentials\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string strResponse = response.Content;
            var definition = new { access_token = "", token_type = "" };
            var resp = JsonConvert.DeserializeAnonymousType(strResponse, definition);
            token = resp.access_token;
            return new ManagementApiClient(token, new Uri("https://nitinborse.auth0.com/api/v2/"));
        }
    }
}

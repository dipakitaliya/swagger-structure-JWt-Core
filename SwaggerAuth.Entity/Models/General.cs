using Auth0.ManagementApi;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwaggerAuth.Entity.Models
{
    public class General
    {
        //public static ManagementApiClient getAuthManagementApiToken()
        //{
        //    string token = "";
        //    var client = new RestClient("https://dev-v118yn1m.auth0.com/oauth/token");
        //    var request = new RestRequest(Method.POST);
        //    request.AddHeader("content-type", "application/json");
        //    request.AddParameter("application/json", "{\"client_id\":\"xPUFG6AmYxfjHDIj66i5pGqJ696d0kmk\",\"client_secret\":\"GHwcZW7rpuwCeVpyTT67IhlQbZUd7SSRxYgCdF1qClGxwbugAes9xHgelnoQrtge\",\"audience\":\"https://dev-v118yn1m.auth0.com/api/v2/\",\"grant_type\":\"client_credentials\"}", ParameterType.RequestBody);
        //    IRestResponse response = client.Execute(request);
        //    string strResponse = response.Content;
        //    var definition = new { access_token = "", token_type = "" };
        //    var resp = JsonConvert.DeserializeAnonymousType(strResponse, definition);
        //    token = resp.access_token;
        //    return new ManagementApiClient(token, new Uri("https://dev-v118yn1m.auth0.com/api/v2/"));
        //}
    }
}

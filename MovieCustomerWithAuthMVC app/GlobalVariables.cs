using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MovieCustomerWithAuthMVC_app
{
    public static class GlobalVariables
    {
        public static HttpClient webApiClient = new HttpClient();
        static GlobalVariables()
        {
            webApiClient.BaseAddress = new Uri("https://localhost:44344/api/");
            webApiClient.DefaultRequestHeaders.Accept.Clear();
            webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
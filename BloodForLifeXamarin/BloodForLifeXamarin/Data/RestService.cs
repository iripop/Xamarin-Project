﻿using BloodForLifeXamarin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BloodForLifeXamarin.Data
{
    public class RestService
    {
        HttpClient client;
        string grant_type = "password";

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded' "));
        }

        public async Task<Token> Login(Donor donor)
        {
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("grant_type", grant_type));
            postData.Add(new KeyValuePair<string, string>("username", donor.Username));
            postData.Add(new KeyValuePair<string, string>("password", donor.Password));
            var content = new FormUrlEncodedContent(postData);
            var response = await PostResponseLogin<Token>(Constants.LoginUrl,content);
            DateTime dt = new DateTime();
            dt = DateTime.Today;
            response.expire_date = dt.AddSeconds(response.expire_in);
            return response;
        }

        public async Task<T> PostResponseLogin<T>(string weburl,FormUrlEncodedContent content) where T: class
        {    
            var response = await client.PostAsync(weburl, content);
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<T>(jsonResult);
            return responseObject;
        }

        public async Task<T> PostResponse<T>(string weburl, string jsonstring) where T : class
        {
            var token = App.TokenDatabase.GetToken();
            string contentType = "application/json";
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.access_token);
            try
            {
                var Result = await client.PostAsync(weburl, new StringContent(jsonstring, Encoding.UTF8, contentType));
                if (Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResult = Result.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var ContentResp = JsonConvert.DeserializeObject<T>(jsonResult);
                        return ContentResp;
                    }
                    catch { return null; }
                }
                
            }
            catch { return null; }
            return null;
        }

        public async Task<T> GetResponse<T>(string weburl) where T: class
        {
            var token = App.TokenDatabase.GetToken();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.access_token);
            try
            {
                var response = await client.GetAsync(weburl);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResult = response.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var ContentResp = JsonConvert.DeserializeObject<T>(jsonResult);
                        return ContentResp;
                    }
                    catch { return null; }
                }
               
                
            }
            catch { return null; }
            return null;
        }

    }
}

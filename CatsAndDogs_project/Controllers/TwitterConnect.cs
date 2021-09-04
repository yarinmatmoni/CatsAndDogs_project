using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CatsAndDogs_project.Controllers
{
    public class TwitterConnect : Controller
    {
        const string TwitterApiBaseUrl = "https://api.twitter.com/1.1/";
        string APIKey, APIKeySecret, accessToken, accessTokenSecret;
        HMACSHA1 sigHasher;
        DateTime epochUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        //public IActionResult Index()
        //{
        //    return View();
        //}

		public TwitterConnect(string APIKey, string APIKeySecret, string accessToken, string accessTokenSecret)
		{
			this.APIKey = APIKey;
			this.APIKeySecret = APIKeySecret;
			this.accessToken = accessToken;
			this.accessTokenSecret = accessTokenSecret;

			sigHasher = new HMACSHA1(new ASCIIEncoding().GetBytes(string.Format("{0}&{1}", APIKeySecret, accessTokenSecret)));
		}

		public Task<string> Tweet(string text)
		{			
			var data = new Dictionary<string, string> {
			{ "status", text },
			{ "trim_user", "1" }
			};

			return SendRequest("statuses/update.json", data);
		}

		Task<string> SendRequest(string url, Dictionary<string, string> data)
		{
			var fullUrl = TwitterApiBaseUrl + url;

			// Timestamps are in seconds since 1/1/1970.
			var timestamp = (int)((DateTime.UtcNow - epochUtc).TotalSeconds);

			data.Add("oauth_consumer_key", APIKey);
			data.Add("oauth_signature_method", "HMAC-SHA1");
			data.Add("oauth_timestamp", timestamp.ToString());
			data.Add("oauth_nonce", "a"); 
			data.Add("oauth_token", accessToken);
			data.Add("oauth_version", "1.0");

			data.Add("oauth_signature", GenerateSignature(fullUrl, data));

			string oAuthHeader = GenerateOAuthHeader(data);

			var formData = new FormUrlEncodedContent(data.Where(kvp => !kvp.Key.StartsWith("oauth_")));

			return SendRequest(fullUrl, oAuthHeader, formData);
		}

		string GenerateSignature(string url, Dictionary<string, string> data)
		{
			var sigString = string.Join(
				"&",
				data
					.Union(data)
					.Select(kvp => string.Format("{0}={1}", Uri.EscapeDataString(kvp.Key), Uri.EscapeDataString(kvp.Value)))
					.OrderBy(s => s)
			);

			var fullSigData = string.Format(
				"{0}&{1}&{2}",
				"POST",
				Uri.EscapeDataString(url),
				Uri.EscapeDataString(sigString.ToString())
			);

			return Convert.ToBase64String(sigHasher.ComputeHash(new ASCIIEncoding().GetBytes(fullSigData.ToString())));
		}

		/// <summary>
		/// Generate the raw OAuth HTML header from the values (including signature).
		/// </summary>
		string GenerateOAuthHeader(Dictionary<string, string> data)
		{
			return "OAuth " + string.Join(
				", ",
				data
					.Where(kvp => kvp.Key.StartsWith("oauth_"))
					.Select(kvp => string.Format("{0}=\"{1}\"", Uri.EscapeDataString(kvp.Key), Uri.EscapeDataString(kvp.Value)))
					.OrderBy(s => s)
			);
		}

		/// <summary>
		/// Send HTTP Request and return the response.
		/// </summary>
		async Task<string> SendRequest(string fullUrl, string oAuthHeader, FormUrlEncodedContent formData)
		{
			using (var http = new HttpClient())
			{
				http.DefaultRequestHeaders.Add("Authorization", oAuthHeader);

				var httpResp = await http.PostAsync(fullUrl, formData);
				var respBody = await httpResp.Content.ReadAsStringAsync();

				return respBody;
			}
		}
	}
}


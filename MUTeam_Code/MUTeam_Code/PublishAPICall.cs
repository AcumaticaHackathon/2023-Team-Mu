using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Newtonsoft.Json;
namespace MUTeam_Code
{
    public class PublishAPICall
    {
        public async Task<List<PublishResults>> PublishPackage(string domain, string apiUser, string apiPassword, string[] packages)
        {
            List<PublishResults> results = new List<PublishResults>();

            //Login
            string authURL = domain + "entity/auth/login";
            //string authJSON = "{ \"name\": \"admin\",  \"password\": \"123\"}";
            var authResp = await authURL.WithHeader("Content-Type", "application/json").PostJsonAsync(new { name = apiUser, password = apiPassword });
            FlurlCookie session = null;
            FlurlCookie auth = null;
            var cookies = authResp.Cookies;
            foreach (var cookie in cookies)
            {
                if (cookie.Name == "ASP.NET_SessionId")
                    session = cookie;
                if (cookie.Name == ".ASPXAUTH")
                    auth = cookie;
            }
            foreach (string package in packages)
            {
                //Begin
                try
                {
                    string pubURL = domain + "CustomizationApi/publishBegin";
                    var beginResp = await pubURL
                        .WithCookie(session.Name, session.Value)
                        .WithCookie(auth.Name, auth.Value)
                        .WithHeader("Content-Type", "application/json")
                        .AllowHttpStatus("400-404,500")
                        .PostJsonAsync(new
                        {
                            isMergeWithExistingPackages = true,
                            isOnlyValidation = false,
                            isOnlyDbUpdates = false,
                            isReplayPreviouslyExecutedScripts = false,
                            projectNames = new[] { package },
                            tenantMode = "Current"

                        });
                }
                catch (Exception flurlEx)
                {
                    results.Add(new PublishResults() { PackageName = package, isException = true, Exception = flurlEx });
                    continue;
                }
                await Task.Delay(250);

                bool complete = false;
                EndJSON end = null;
                while (!complete)
                {
                    try
                    {
                        //End Call
                        string endURL = domain + "CustomizationApi/publishEnd";
                        var endResp = await endURL
                            .WithCookie(session.Name, session.Value)
                            .WithCookie(auth.Name, auth.Value)
                            .WithHeader("Content-Type", "application/json")
                            .AllowHttpStatus("400-404,500")
                            .PostJsonAsync(new { });
                        string endRespStr = await endResp.GetStringAsync();

                        end = JsonConvert.DeserializeObject<EndJSON>(endRespStr);
                        //Complete
                        complete = end.isCompleted;
                    }
                    catch (Exception ex)
                    {
                        results.Add(new PublishResults() { PackageName = package, isException = true, Exception = ex });
                        complete = true;
                        continue;
                    }
                    await Task.Delay(1000);
                }
                //Publish Complete
                results.Add(new PublishResults() { isFailed = end.isFailed, Log = end.log, PackageName = package });

            }
            return results;
        }
    }
    public class PublishResults
    {
        public bool isFailed { get; set; }
        public bool isException { get; set; } = false;
        public List<logItem> Log { get; set; }
        public string PackageName { get; set; }
        public Exception Exception { get; set; }
    }
    public class EndJSON
    {
        public bool isCompleted { get; set; }
        public bool isFailed { get; set; }
        public List<logItem> log { get; set; }
    }
    public class logItem
    {
        public string logType { get; set; }
        public string message { get; set; }
        public DateTime timestamp { get; set; }
    }

}

var client = new RestClient("ec2-3-140-243-243.us-east-2.compute.amazonaws.com/TeamMu//CustomizationApi/publishBegin");
client.Timeout = -1;
var request = new RestRequest(Method.POST);
request.AddHeader("Accept", "application/json");
request.AddHeader("Content-Type", "application/json");
request.AddHeader("Cookie", ".ASPXAUTH=B27D9A77E13286170C2DD8028B83CF6BC9D074C72DA456E68034D0D628321EB056A50F6D859DC0712613729324E0A9E89E82E2E5BEEE3D4DF03E4E7B2349226228CFFD07F6611DDB9340499FA348F459F730A4711F10827017251062E04ECCC1A62AEC62D1B700895A2CF1725BEDF0230730F6FA08B1E8F875E5625980560909D0542D55; ASP.NET_SessionId=4gc2dj35sh1tjqjm1tpytqae; Locale=TimeZone=GMTM0800A&Culture=en-US; UserBranch=22; requestid=7EB6606ED006618311ED9F6A6ED43DCE; requeststat=+st:6+sc:~/customizationapi/publishend+start:638105483063280346+tg:");
var body = @"{" + "\n" +
@"    ""isMergeWithExistingPackages"": false," + "\n" +
@"    ""isOnlyValidation"": false," + "\n" +
@"    ""isOnlyDbUpdates"": false," + "\n" +
@"    ""isReplayPreviouslyExecutedScripts"": false," + "\n" +
@"    ""projectNames"": [ ""ProjectTime"" ]," + "\n" +
@"    ""tenantMode"": ""Current""" + "\n" +
@"}";
request.AddParameter("application/json", body,  ParameterType.RequestBody);
IRestResponse response = client.Execute(request);
Console.WriteLine(response.Content);
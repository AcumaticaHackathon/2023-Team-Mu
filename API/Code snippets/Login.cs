var client = new RestClient("ec2-3-140-243-243.us-east-2.compute.amazonaws.com/TeamMu/entity/auth/login");
client.Timeout = -1;
var request = new RestRequest(Method.POST);
request.AddHeader("Accept", "application/json");
request.AddHeader("Content-Type", "application/json");
request.AddHeader("Cookie", ".ASPXAUTH=B6DBAF0AF0233AEB7854534C602B36114C0876551DCB692280CC53A67DA127FDAB1F273956BD7AC5A8AEBFEDB0F35C4EF347DF2F6BF81C4DD50E53F2391DD642E475FC71B80B01D9DAABBC0E5743F4B8CE7F5EB7A0155620F37AE8217FD435C4E73951EFFB09F163FF948D0A0B23ADFFEA52A8FACCD79E84F5B41A3B6948D3F16498D673; ASP.NET_SessionId=4gc2dj35sh1tjqjm1tpytqae; Locale=Culture=en-US&TimeZone=GMTM0800A; UserBranch=22; requestid=7EB6606ED006618311ED9F62D9C1587F; requeststat=+st:468+sc:~/entity/auth/login+start:638105450476902875+tg:");
var body = @"{  ""tenant"": ""Company"", ""name"": ""Admin"",  ""password"": ""Super Secret Password"",  ""branch"": ""Capital""}";
request.AddParameter("application/json", body,  ParameterType.RequestBody);
IRestResponse response = client.Execute(request);
Console.WriteLine(response.Content);
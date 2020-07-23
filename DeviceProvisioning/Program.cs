using Microsoft.Azure.Devices.Provisioning.Client;
using Microsoft.Azure.Devices.Provisioning.Client.Transport;
using Microsoft.Azure.Devices.Shared;
using System;
using System.Threading.Tasks;

namespace DeviceProvisioning
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var securityProvider = new SecurityProviderSymmetricKey("{registrationId}", "{primaryKey}", "{secondaryKey}");
			var provisioningClient = ProvisioningDeviceClient.Create("global.azure-devices-provisioning.net", "{IdScope}", securityProvider, new ProvisioningTransportHandlerMqtt(Microsoft.Azure.Devices.Shared.TransportFallbackType.TcpWithWebSocketFallback));
			var result = await provisioningClient.RegisterAsync();
			Console.WriteLine($"HostName='{result.AssignedHub}';DeviceId='{result.DeviceId}';SharedAccessKey='{"{primaryKey}"}';");
		}

		//private static string createToken(string resourceUri, string keyName, string key)
		//{
		//	TimeSpan sinceEpoch = DateTime.UtcNow - new DateTime(1970, 1, 1);
		//	var week = 60 * 60 * 24 * 7;
		//	var expiry = Convert.ToString((int)sinceEpoch.TotalSeconds + week);
		//	string stringToSign = HttpUtility.UrlEncode(resourceUri) + "\n" + expiry;
		//	HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
		//	var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
		//	var sasToken = String.Format(CultureInfo.InvariantCulture, "SharedAccessSignature sr={0}&sig={1}&se={2}&skn={3}", HttpUtility.UrlEncode(resourceUri), HttpUtility.UrlEncode(signature), expiry, keyName);
		//	return sasToken;
		//}
	}
}

﻿using System;
using System.Collections.Generic;

namespace CLIWebService
{
	public class WSDLManager
	{
		public void runService(string wsdlKey, Dictionary<String,String> args){
			switch (wsdlKey) {
			case "ChannelAdvisor.Admin":
				//AdminService admin = new AdminService ("ac93793a-4b71-44d4-ad4d-d302c39c238c","Domo123!");
				APICredentials creds = new APICredentials () {
					DeveloperKey = "ac93793a-4b71-44d4-ad4d-d302c39c238c",
					Password = "Domo123!"
				};
				//AdminService admin = AdminService.getInstance ("ac93793a-4b71-44d4-ad4d-d302c39c238c", "Domo123!");
				AdminService admin = AdminService.getInstance (args.get("developerKey"), args.get("developerPassword"));
				admin.APICredentialsValue = creds;
				var result = admin.GetAuthorizationList(args.get("localId")).ResultData;

				foreach (AuthorizationResponse resp in result) {
					Console.WriteLine (resp.AccountID + ":" + resp.LocalID);
				}
				break;
			case "CelsiusToFarenheit":
				TempConvert converter = new TempConvert ();
				Console.WriteLine(converter.CelsiusToFahrenheit (args.get("temperature")));
				break;
			case "FarenheitToCelsius":
				TempConvert converter2 = new TempConvert ();
				Console.WriteLine(converter2.FahrenheitToCelsius (args.get("temperature")));
				break;
			default:throw new Exception ("MagicException:Domo encountered error running service:Unable to map SOAP wsdl");
			}

		}
	}
}


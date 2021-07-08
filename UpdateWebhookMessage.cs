using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebhookFunctionApp2.Models
{

	public class UpdateWebhookMessage
	{
		
		[JsonProperty("field_107")]
		public Dictionary<string, string> Join {get; set;}
		
	}
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Contracts.Dto.Responses
{
    public class ClientResponse<T>
    {
        public HttpStatusCode Status { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ?Message { get; set; }

        public T Response { get; set; }
    }
}

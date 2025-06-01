using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IysService.DtoLayer.Dtos
{
    public class XRayPredictionResponse
    {
        [JsonProperty("prediction")]
        public string Prediction { get; set; }

        [JsonProperty("confidence")]
        public string Confidence { get; set; }
    }

}

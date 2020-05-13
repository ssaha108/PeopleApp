using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.API.Models
{
    public class GenderCatsDTO
    {
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("cats")]
        public List<CatsDTO> Cats {get;set;}
    }

    public class CatsDTO
    {
        [JsonProperty("catname")]
        public string CatName { get; set; }
    }
}

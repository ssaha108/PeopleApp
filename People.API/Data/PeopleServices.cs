using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using People.API.Models;
using System.Security.Cryptography.X509Certificates;

namespace People.API.Data
{
    public class PeopleServices : IIntegrationService
    {
        private static HttpClient _httpClient = new HttpClient();

        public PeopleServices()
        {
            //_httpClient.BaseAddress = new Uri("http://agl-developer-test.azurewebsites.net/");
            //_httpClient.Timeout = new TimeSpan(00, 0, 30);
            _httpClient.DefaultRequestHeaders.Clear();
        }
        public async Task<List<GenderCatsDTO>> GetGenderCats()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://agl-developer-test.azurewebsites.net/people.json");
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var peoples = JsonConvert.DeserializeObject<List<PeopleDTO>>(content).ToList();

            List<GenderCatsDTO> genderCats = new List<GenderCatsDTO>(); 
               
            peoples.ForEach(p =>
            {
                if (!genderCats.Any(x => x.Gender == p.Gender))
                    genderCats.Add(new GenderCatsDTO { Gender = p.Gender, Cats = new List<CatsDTO>() });

                if (p.Pets!=null && p.Pets.Any(c => c.Type == (int)TypeEnum.Cat))
                {
                    List<CatsDTO> cName = p.Pets.Where(c => c.Type == (int)TypeEnum.Cat).Select(n => new CatsDTO { CatName = n.Name }).ToList();
                    (genderCats.Where(gC => gC.Gender == p.Gender).Select(c => c.Cats)).FirstOrDefault().AddRange(cName);
                }
            });

            genderCats.ForEach(g => 
                g.Cats = (from c in g.Cats orderby c.CatName select c).ToList()
            );

            return genderCats;
        }
    }
}

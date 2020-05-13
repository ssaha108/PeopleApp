using People.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.API.Data
{
    public interface IIntegrationService
    {
        Task<List<GenderCatsDTO>> GetGenderCats();
    }
}

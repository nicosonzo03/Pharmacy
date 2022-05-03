using API_Pharmacy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pharmacy.Interfaces
{
    public interface IDiseaseRepository
    {
        public string FindDisease(List<string> elencosintomi);
    }
}

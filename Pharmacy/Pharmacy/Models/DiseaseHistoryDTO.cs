using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Models
{
    public class DiseaseHistoryDTO
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Link { get; set; }
    }
}

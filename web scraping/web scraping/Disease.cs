using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web_scraping
{
    public class Disease
    {
        public int id { get; set; }

        public string nome { get; set; }
        public string descrizione { get; set; }
    }

    public class Symptom
    {
        public int id { get; set; }
        public string sintomo { get; set; }
    }
}

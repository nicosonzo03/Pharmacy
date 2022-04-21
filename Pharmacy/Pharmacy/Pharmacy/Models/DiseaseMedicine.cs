using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Models
{
    public class DiseaseMedicine
    {
        [Key, Required]
        public string Id { get; set; }

        [Required]
        public string IdDisease { get; set; }

        [Required]
        public string IdMedicine { get; set; }
    }
}

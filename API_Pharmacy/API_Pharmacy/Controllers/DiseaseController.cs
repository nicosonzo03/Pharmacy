using API_Pharmacy.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API_Pharmacy.Controllers
{
    //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("[controller]")]
    public class DiseaseController : ControllerBase
    {
        private readonly IDiseaseRepository _diseasesRepo;
        public DiseaseController(IDiseaseRepository diseasesRepo)
        {
            _diseasesRepo = diseasesRepo;
        }
        
        [HttpPost("{elencosintomi}", Name = "sintomi")]
        public IActionResult FindDisease(string elencosintomi)
        {
            try
            {
                List<string> elesintomi = new List<string>(elencosintomi.Split("%2C").ToList());
                var malattie = _diseasesRepo.FindDisease(elesintomi);
                return Ok(malattie);
                //return StatusCode(200);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}

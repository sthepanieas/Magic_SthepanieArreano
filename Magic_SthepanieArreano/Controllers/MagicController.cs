using Magic_SthepanieArreano.Data;
using Magic_SthepanieArreano.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magic_SthepanieArreano.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagicController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MagicController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<Suerte>> GetSuerte()
        {
            var list = await _context.Suerte.ToListAsync();
            var max = list.Count;
            int index = new Random().Next(0, max);
            var suerte = list[index];
            if (suerte == null)
            {
                return NoContent();
            }
            return suerte;

        }
    }
}

using Microsoft.AspNetCore.Mvc;
using QuiEstCe.Exceptions;
using QuiEstCeAppli.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuiEstCeAppli.Controllers
{
    public class JeuController : ControllerBase
    {
        private JeuService service;
        public JeuController(JeuService service)
        {
            this.service = service;
        }

        [HttpGet("DebutPartie")]
        public IActionResult DebutPartie()
        {
            try
            {
                return Ok(this.service.DebutPartie());
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}

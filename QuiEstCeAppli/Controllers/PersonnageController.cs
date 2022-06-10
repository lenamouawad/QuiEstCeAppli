using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuiEstCeAppli.Models;
using QuiEstCeAppli.Repositories;
using QuiEstCeAppli.Services;
using System.Net;
using QuiEstCe.Exceptions;

namespace QuiEstCeAppli.Controllers
{
    public class PersonnageController : ControllerBase
    {
        private PersonnageService service;
        public PersonnageController(PersonnageService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult AddPersonnage(Personnage personnage)
        {
            try
            {
                return Created("", service.AddPersonnage(personnage));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("updatePersonnage")]
        public IActionResult UpdatePersonnage(String id, Personnage personnage)
        {
            try
            {
                return Ok(service.UpdatePersonnage(id, personnage));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("deletePersonnage/{id}")]
        public IActionResult DeletePersonnage(string id)
        {
            try
            {
                this.service.DeletePersonnage(id);
                return Ok("Le personnage a été supprimé");
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("deleteAllPersonnages")]
        public IActionResult DeleteAllPersonnages()
        {
            try
            {
                this.service.DeleteAllPersonnages();
                return Ok("Tous les personnages ont été supprimés");
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }

        [HttpGet("allPersonnages")]
        public IActionResult GetAllPersonnages()
        {
            try
            {
                return Ok(this.service.GetAllPersonnages());
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("Personnageid/{id}")]
        public IActionResult GetPersonnageById(string id)
        {
            try
            {
                return Ok(this.service.GetPersonnageById(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("HasChapeau/{hasChapeau}")]
        public IActionResult GetAllChapeau(bool hasChapeau)
        {
            try
            {
                return Ok(this.service.GetAllChapeau(hasChapeau));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("HasLunettes/{hasLunettes}")]
        public IActionResult GetAllLunettes(bool hasLunettes)
        {
            try
            {
                return Ok(this.service.GetAllLunettes(hasLunettes));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("IsWizard/{isWizard}")]
        public IActionResult GetAllWizard(bool isWizard)
        {
            try
            {
                return Ok(this.service.GetAllWizards(isWizard));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("PersonnageCouleurYeux/{couleurYeux}")]
        public IActionResult GetAllPersonnageAvecCouleurYeux(string couleurYeux)
        {
            try
            {
                return Ok(this.service.GetAllPersonnageAvecCouleurYeux(couleurYeux));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("PersonnageCouleurCheveux/{cheveuxMarronsNoirs}")]
        public IActionResult GetAllPersonnageWithCheveux(bool cheveuxMarronsNoirs)
        {
            try
            {
                return Ok(this.service.GetAllPersonnageWithCheveux(cheveuxMarronsNoirs));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("PersonnageEspece/{espece}")]
        public IActionResult GetAllPersonnageEspece(string espece)
        {
            try
            {
                return Ok(this.service.GetAllPersonnageEspece(espece));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("PersonnageGenre/{genre}")]
        public IActionResult GetAllPersonnageGenre(string genre)
        {
            try
            {
                return Ok(this.service.GetAllPersonnageGenre(genre));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}

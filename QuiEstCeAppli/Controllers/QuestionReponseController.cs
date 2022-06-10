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
    public class QuestionReponseController : ControllerBase
    {
        private QuestionReponseService service;
        public QuestionReponseController(QuestionReponseService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult AddQuestionReponse(QuestionReponse questionReponse)
        {
            try
            {
                return Created("", service.AddQuestionReponse(questionReponse));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("updateQR")]
        public IActionResult UpdateQuestionReponse(String id, QuestionReponse questionReponse)
        {
            try
            {
                return Ok(service.UpdateQuestionReponse(id, questionReponse));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("deleteQR/{id}")]
        public IActionResult DeleteQuestionReponse(string id)
        {
            try
            {
                this.service.DeleteQuestionReponse(id);
                return Ok("La question a été supprimée");
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("deleteAllQuestionReponses")]
        public IActionResult DeleteAllQuestionReponses()
        {
            try
            {
                this.service.DeleteAllQuestionReponses();
                return Ok("Toutes les questions ont été supprimés");
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }

        [HttpGet("allQuestionReponses")]
        public IActionResult GetAllQuestionReponses()
        {
            try
            {
                return Ok(this.service.GetAllQuestionReponses());
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("QRid/{id}")]
        public IActionResult GetQuestionReponseById(string id)
        {
            try
            {
                return Ok(this.service.GetQuestionReponseById(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}

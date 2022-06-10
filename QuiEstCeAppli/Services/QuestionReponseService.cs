using QuiEstCeAppli.Repositories;
using QuiEstCeAppli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuiEstCe.Exceptions;

namespace QuiEstCeAppli.Services
{
    public class QuestionReponseService
    {
        private QuestionReponseRepository repository;

        public QuestionReponseService(QuestionReponseRepository repository)
        {
            this.repository = repository;
        }
        public List<QuestionReponse> AddQuestionReponse(QuestionReponse questionReponse)
        {
            return this.repository.AddQuestionReponse(questionReponse);
        }

        public QuestionReponse UpdateQuestionReponse(String id, QuestionReponse questionReponseUpdated)
        {
            QuestionReponse questionReponse = this.repository.GetQuestionReponseById(id);
            if (questionReponse == null)
            {
                throw new NotFoundException($"Aucun des questions n'a ce id :  {id}");
            }
            else
            {
                questionReponse = this.repository.UpdateQuestionReponse(id, questionReponseUpdated);
            }

            return questionReponse;
        }

        public List<QuestionReponse> DeleteQuestionReponse(string id)
        {
            QuestionReponse questionReponse = this.repository.GetQuestionReponseById(id);
            List<QuestionReponse> listQuestionReponses = new List<QuestionReponse>() { };

            if (questionReponse == null)
            {
                throw new NotFoundException($"Aucun des questions n'a ce id :  {id}");
            }
            else
            {
                listQuestionReponses = this.repository.DeleteQuestionReponse(id);
            }
            return listQuestionReponses;
        }
        public List<QuestionReponse> DeleteAllQuestionReponses()
        {
            return this.repository.DeleteAllQuestionReponses();
        }

        public List<QuestionReponse> GetAllQuestionReponses()
        {
            return this.repository.GetAllQuestionReponses();
        }

        public QuestionReponse GetQuestionReponseById(string id)
        {
            QuestionReponse questionReponse = this.repository.GetQuestionReponseById(id);
            if (questionReponse == null)
            {
                throw new NotFoundException($"Aucune des questions n'a ce id :  {id}");
            }
            return questionReponse;
        }

    }
}

using QuiEstCeAppli.Config;
using QuiEstCeAppli.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuiEstCeAppli.Repositories
{
    public class QuestionReponseRepository
    {
        private readonly IMongoCollection<QuestionReponse> questionReponses;
        public QuestionReponseRepository(IQuiEstCeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            questionReponses = database.GetCollection<QuestionReponse>(settings.QuestionReponseCollectionName);
        }

        public List<QuestionReponse> AddQuestionReponse(QuestionReponse questionReponse)
        {
            this.questionReponses.InsertOne(questionReponse);
            return this.questionReponses.Find(questionReponse => true).ToList();
        }

        public QuestionReponse UpdateQuestionReponse(String id, QuestionReponse questionReponseUpdated)
        {
            questionReponseUpdated.Id = id;
            this.questionReponses.FindOneAndReplace(questionReponse => questionReponse.Id == id, questionReponseUpdated);
            return this.questionReponses.Find(questionReponse => questionReponse.Id == id).FirstOrDefault();
        }

        public List<QuestionReponse> DeleteQuestionReponse(string id)
        {
            this.questionReponses.DeleteOne(questionReponse => questionReponse.Id == id);
            return this.questionReponses.Find(questionReponse => true).ToList();
        }
        public List<QuestionReponse> DeleteAllQuestionReponses()
        {
            this.questionReponses.DeleteMany(questionReponse => true);
            return this.questionReponses.Find(questionReponse => true).ToList();
        }

        public List<QuestionReponse> GetAllQuestionReponses()
        {
            return this.questionReponses.Find(questionReponse => true).ToList();
        }

        public QuestionReponse GetQuestionReponseById(string id)
        {
            return this.questionReponses.Find(questionReponse => questionReponse.Id == id).FirstOrDefault();
        }
    }
}

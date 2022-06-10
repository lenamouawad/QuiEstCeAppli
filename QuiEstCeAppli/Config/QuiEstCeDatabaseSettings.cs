using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuiEstCeAppli.Config
{
    public class QuiEstCeDatabaseSettings : IQuiEstCeDatabaseSettings
    {
        public string PersonnageCollectionName { get; set; }
        public string QuestionReponseCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IQuiEstCeDatabaseSettings
    {
        public string PersonnageCollectionName { get; set; }
        public string QuestionReponseCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}

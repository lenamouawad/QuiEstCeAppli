using QuiEstCeAppli.Config;
using QuiEstCeAppli.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuiEstCeAppli.Repositories
{
    public class PersonnageRepository
    {
        private readonly IMongoCollection<Personnage> personnages;
        public PersonnageRepository(IQuiEstCeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            personnages = database.GetCollection<Personnage>(settings.PersonnageCollectionName);
        }

        public List<Personnage> AddPersonnage(Personnage personnage)
        {
            this.personnages.InsertOne(personnage);
            return this.personnages.Find(personnage => true).ToList();
        }

        public Personnage UpdatePersonnage(String id, Personnage personnageUpdated)
        {
            personnageUpdated.Id = id;
            this.personnages.FindOneAndReplace(personnage => personnage.Id == id, personnageUpdated);
            return this.personnages.Find(personnage => personnage.Id == id).FirstOrDefault();
        }

        public List<Personnage> DeletePersonnage(string id)
        {
            this.personnages.DeleteOne(personnage => personnage.Id == id);
            return this.personnages.Find(personnage => true).ToList();
        }
        public List<Personnage> DeleteAllPersonnages()
        {
            this.personnages.DeleteMany(personnage => true);
            return this.personnages.Find(personnage => true).ToList();
        }

        public List<Personnage> GetAllPersonnages()
        {
            return this.personnages.Find(personnage => true).ToList();
        }

        public Personnage GetPersonnageById(string id)
        {
            return this.personnages.Find(personnage => personnage.Id == id).FirstOrDefault();
        }
    }
}

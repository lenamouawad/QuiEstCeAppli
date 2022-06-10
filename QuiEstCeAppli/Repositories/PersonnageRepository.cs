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

        // Si notre personnage a un chapeau
        // La réponse a la question est ce qu'il a un chapeau est oui
        // Donc on elimine les personnage qui n'ont pas de chapeau
        public List<String> GetAllChapeau(bool hasChapeau) {

            return this.personnages.Find(h => h.hasChapeau == hasChapeau).ToList().Select(h => h.Id).ToList();
        }

        // Si notre personnage a des lunettes
        // La réponse a la question est ce qu'il a des lunettes est oui
        // Donc on elimine les personnage qui n'ont pas de lunettes
        public List<String> GetAllLunettes(bool hasLunettes)
        {
            return this.personnages.Find(h => h.hasLunettes == hasLunettes).ToList().Select(h => h.Id).ToList();
        }

        // Si notre personnage est un sorcier
        // La réponse a la question est ce c'est un sorcier est oui
        // Donc on elimine les personnage qui ne sont pas des sorciers
        public List<String> GetAllWizard(bool isWizard)
        {
            return this.personnages.Find(h => h.isWizard == isWizard).ToList().Select(h => h.Id).ToList();
        }

        //Retourne les id des personnages ayant des yeux avec une couleur spécifique
        public List<String> GetAllPersonnageWithCouleurYeux(string couleurYeux)
        {
            return this.personnages.Find(h => h.couleurYeux == couleurYeux).ToList().Select(h => h.Id).ToList();
        }

        //Retourne les id des personnages ayant des cheveux avec une couleur spécifique
        public List<String> GetAllPersonnageWithCheveux(string couleurCheveux)
        {
            return this.personnages.Find(h => h.couleurCheveux == couleurCheveux).ToList().Select(h => h.Id).ToList();
        }

        //Retourne les id des personnages d'une certaine espèce
        public List<String> GetAllPersonnageEspece(string espece)
        {
            return this.personnages.Find(h => h.espece == espece).ToList().Select(h => h.Id).ToList();
        }

        //Retourne les id des personnages d'un certain genre
        public List<String> GetAllPersonnageGenre(string genre)
        {
            return this.personnages.Find(h => h.genre == genre).ToList().Select(h => h.Id).ToList();
        }

    }
}

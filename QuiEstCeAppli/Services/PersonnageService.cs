using QuiEstCeAppli.Repositories;
using QuiEstCeAppli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuiEstCe.Exceptions;

namespace QuiEstCeAppli.Services
{
    public class PersonnageService
    {
        private PersonnageRepository repository;

        public PersonnageService(PersonnageRepository repository)
        {
            this.repository = repository;
        }

        public List<Personnage> AddPersonnage(Personnage personnage)
        {
            return this.repository.AddPersonnage(personnage);
        }

        public Personnage UpdatePersonnage(String id, Personnage personnageUpdated)
        {
            Personnage personnage = this.repository.GetPersonnageById(id);
            if (personnage == null)
            {
                throw new NotFoundException($"Aucun des personnages n'a ce id :  {id}");
            }
            else
            {
                personnage = this.repository.UpdatePersonnage(id, personnageUpdated);
            }

            return personnage;
        }

        public List<Personnage> DeletePersonnage(string id)
        {
            Personnage personnage = this.repository.GetPersonnageById(id);
            List<Personnage> listPersonnages = new List<Personnage>() { };

            if (personnage == null)
            {
                throw new NotFoundException($"Aucun des personnages n'a ce id :  {id}");
            }
            else
            {
                listPersonnages = this.repository.DeletePersonnage(id);
            }
            return listPersonnages;
        }
        public List<Personnage> DeleteAllPersonnages()
        {
            return this.repository.DeleteAllPersonnages();
        }

        public List<Personnage> GetAllPersonnages()
        {
            return this.repository.GetAllPersonnages();
        }

        public Personnage GetPersonnageById(string id)
        {
            Personnage personnage = this.repository.GetPersonnageById(id);
            if (personnage == null)
            {
                throw new NotFoundException($"Aucun des personnages n'a ce id :  {id}");
            }
            return personnage;
        }

        public List<String> GetAllChapeau(bool hasChapeau)
        {
            return this.repository.GetAllChapeau(hasChapeau);
        }
    }
    }

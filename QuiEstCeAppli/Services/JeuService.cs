using QuiEstCeAppli.Repositories;
using QuiEstCeAppli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuiEstCe.Exceptions;
using QuiEstCeAppli.DTO;

namespace QuiEstCeAppli.Services
{
    public class JeuService
    {
        private JeuRepository repository;
        private PersonnageService persoService;
        private QuestionReponseService questionsService;

        public JeuService(JeuRepository repository, PersonnageService persoService, QuestionReponseService questionsService)
        {
            this.repository = repository;
            this.questionsService = questionsService;
            this.persoService = persoService;
        }

        public JeuDTO DebutPartie()
        {
            // Randomly select a personnage id
            Personnage selectedPersonnage = new Personnage();
            List<Personnage> personnages = persoService.GetAllPersonnages();
            Random random = new Random();
            int index = random.Next(personnages.Count);
            selectedPersonnage.Id = (personnages[index].Id);

            List<String> personnagesAEliminerIds = new List<String>();

            // Set answers to all questions
            List<QuestionReponse> allQuestionsReponses = questionsService.GetAllQuestionReponses();
            foreach (QuestionReponse question in allQuestionsReponses)
            {      
                // C'est pas bien de faire comme ca mais on a pas le temps de reflechir... :(
                if (question.question.Contains("chapeau"))
                {
                    question.reponse = selectedPersonnage.hasChapeau;
                    personnagesAEliminerIds = persoService.GetAllChapeau(!selectedPersonnage.hasChapeau);
                }
                if (question.question.Contains("lunettes"))
                {
                    question.reponse = selectedPersonnage.hasLunettes;
                    personnagesAEliminerIds = persoService.GetAllLunettes(!selectedPersonnage.hasLunettes);

                }
                if (question.question.Contains("sorcier"))
                {
                    question.reponse = selectedPersonnage.isWizard;
                    personnagesAEliminerIds = persoService.GetAllWizards(!selectedPersonnage.isWizard);

                }
                if (question.question.Contains("yeux"))
                {
                    question.reponse = selectedPersonnage.couleurYeux == "bleu";
                    personnagesAEliminerIds = persoService.GetAllPersonnageAvecCouleurYeux(selectedPersonnage.couleurYeux);

                }
                if (question.question.Contains("cheveux"))
                {
                    question.reponse = selectedPersonnage.couleurCheveux == "Noir" || selectedPersonnage.couleurCheveux == "Marron";
                    personnagesAEliminerIds = persoService.GetAllPersonnageWithCheveux(!question.reponse);

                }
                if (question.question.Contains("humain"))
                {
                    question.reponse = selectedPersonnage.espece == "Humain";
                    personnagesAEliminerIds = persoService.GetAllPersonnageEspece(selectedPersonnage.espece);

                }
                if (question.question.Contains("femme"))
                {
                    question.reponse = selectedPersonnage.genre == "Femme";
                    personnagesAEliminerIds = persoService.GetAllPersonnageGenre(selectedPersonnage.genre);

                }
            }

            allQuestionsReponses = questionsService.GetAllQuestionReponses();

            JeuDTO jeu = new JeuDTO();
            jeu.selectedPersoId = selectedPersonnage.Id;
            jeu.questionsReponses = allQuestionsReponses;
            jeu.personnagesAEliminerId = personnagesAEliminerIds;

            return jeu;

            // Return id selected person + questions reponses boolen ?

        }

    }
}

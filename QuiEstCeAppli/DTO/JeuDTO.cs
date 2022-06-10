using QuiEstCeAppli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuiEstCeAppli.DTO
{
    public class JeuDTO
    {
        
        public string selectedPersoId { get; set; }
        public List<QuestionReponse> questionsReponses { get; set; }
        public List<string> personnagesAEliminerId { get; set; }

        public JeuDTO()
        {
        }

        public JeuDTO(string selectedPersoId, List<QuestionReponse> questionsReponses, List<string> personnagesAEliminerId)
        {
            this.selectedPersoId = selectedPersoId;
            this.questionsReponses = questionsReponses;
            this.personnagesAEliminerId = personnagesAEliminerId;
        }
    }



}

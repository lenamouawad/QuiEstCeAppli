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

        public JeuDTO()
        {
        }

        public JeuDTO(string selectedPersoId, List<QuestionReponse> questionsReponses)
        {
            this.selectedPersoId = selectedPersoId;
            this.questionsReponses = questionsReponses;
        }
    }



}

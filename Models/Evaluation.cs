namespace Conferences_projet.Models
{

    public class Evaluation
    {
        public int EvaluationId { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public int RelecteurId { get; set; }
        public Relecteur Relecteur { get; set; }
        public int NoteFond { get; set; }
        public int NoteForme { get; set; }
        public int NotePertinenceScientifique { get; set; }
        public string Commentaire { get; set; }


     
    }


}

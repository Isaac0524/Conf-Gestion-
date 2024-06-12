namespace Conferences_projet.Models
{

    public class Article
    {
        public int IdArticle { get; set; }
        public string Titre { get; set; }
        public string Resume { get; set; }
        public string FichierPdf { get; set; }
        public int NombreRelecteurs { get; set; }
        public string Statut { get; set; }
        public int AuteurId { get; set; }
        public int ConferenceId { get; set; }
        public ICollection<Evaluation> Evaluations { get; set; }
        public ICollection<Affectation> Affectations { get; set; }

        public Auteur Auteur { get; set; }
        public Conference Conference { get; set; }
    }
}

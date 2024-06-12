namespace Conferences_projet.Models
{
    public class Relecteur : Utilisateur
    {

        public ICollection<Affectation> Affectations { get; set; }
        public ICollection<Evaluation> Evaluations { get; set; }
    }
}
    


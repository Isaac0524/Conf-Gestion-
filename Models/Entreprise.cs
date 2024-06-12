

namespace Conferences_projet.Models
{

    public class Entreprise
    {
        public Entreprise()
        {
            Auteurs = new HashSet<Auteur>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public ICollection<Auteur> Auteurs { get; set; }

        

    }


}

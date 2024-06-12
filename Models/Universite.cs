namespace Conferences_projet.Models
{
    public class Universite
    {
        public Universite() { 
            Auteurs = new HashSet<Auteur>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }

        public ICollection<Auteur> Auteurs { get; set; }
     
    }
}



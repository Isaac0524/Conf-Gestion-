namespace Conferences_projet.Models
{
    public class Auteur : Utilisateur
    {


        public int Id { get; set; }
        public string Nom { get; set; }

        public int? EntrepriseId { get; set; }
        public Entreprise Entreprise { get; set; }

        public int? UniversiteId { get; set; }
        public Universite Universite { get; set; }

        public bool EstConfirme { get; set; }

        // Relation many-to-one avec Université
        public ICollection<Article> Articles { get; set; }


    }

}

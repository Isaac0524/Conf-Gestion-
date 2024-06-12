namespace Conferences_projet.Models
{

    public class Administrateur : Utilisateur
    {

        public ICollection<Utilisateur> Utilisateurs { get; set; } // Gérer les utilisateurs
        public ICollection<Universite> Universités { get; set; } // Ajouter des universités
        public ICollection<Entreprise> Entreprises { get; set; }

    }

                

                    
        

    
}

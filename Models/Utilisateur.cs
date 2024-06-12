
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conferences_projet.Models
{

    public class Utilisateur : IdentityUser<int>
    {


        public bool EstActif { get; set; }
        public string? Prenom { get; set; }
        public string? Nom { get; set; }


        public Utilisateur()
        {
        }

        public ICollection<Participant> Participants { get; set; }
        public ICollection<MembreComite> MembresComite { get; set; }
        public ICollection<Auteur> Auteurs { get; set; }
        public ICollection<Relecteur> Relecteurs { get; set; }
        public ICollection<Administrateur> Administrateurs { get; set; }
    }
}
    



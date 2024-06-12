namespace Conferences_projet.Models
{
    public class MembreComite : Utilisateur
    {
        public ICollection<Affectation> Affectations { get; set; }
        public int ConferenceId { get; set; }
        public Conference Conference { get; set; }

        public ICollection<Conference> Conférences { get; set; }
    }
    
}

   
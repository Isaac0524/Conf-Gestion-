namespace Conferences_projet.Models
{

    public class Conference
    {
        public Conference() { 

            Articles = new HashSet<Article>();
            
        
        }
        public int ConferenceId { get; set; }
        public string Nom { get; set; }
        public string Sigle { get; set; }
        public string Theme { get; set; }
        public DateTime DateSoumission { get; set; }
        public DateTime DateLimiteResultats { get; set; }
        public DateTime DateLimiteInscription { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        // Relations
        public ICollection<Article> Articles { get; set; }

        public ICollection<MembreComite> MembresComite { get; set; }
        // Relations
        public ICollection<ParticipantConference> ParticipantsConferences { get; set; } = new HashSet<ParticipantConference>();

    }


}

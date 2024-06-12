namespace Conferences_projet.Models
{
    public class Participant : Utilisateur
    {
        public Participant()
        {
            ParticipantsConferences = new HashSet<ParticipantConference>();
        }

        public ICollection<ParticipantConference> ParticipantsConferences { get; set; }
    }
}


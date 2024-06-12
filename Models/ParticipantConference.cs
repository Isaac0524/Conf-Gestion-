namespace Conferences_projet.Models
{
    public class ParticipantConference
    {
        public int Id { get; set; }
        public DateTime DateInscription { get; set; }
        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }

        public int ConferenceId { get; set; }
        public Conference Conference { get; set; }

    }
}

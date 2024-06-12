namespace Conferences_projet.Models
{
    public class Affectation
    {
        public int Id { get; set; }
        public DateTime DateAffectation { get; set; }

        // Relations
        public int MembreComiteId { get; set; }
        public MembreComite MembreComite { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public int RelecteurId { get; set; }
        public Relecteur Relecteur { get; set; }
    }
}

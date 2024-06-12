using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Conferences_projet.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conferences_projet.Data
{
    public class ApplicationDbContext : IdentityDbContext<Utilisateur, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Participant> Participants { get; set; }
        public DbSet<MembreComite> MembresComite { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Relecteur> Relecteurs { get; set; }
        public DbSet<Administrateur> Administrateurs { get; set; }
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Universite> Universites { get; set; }
        public DbSet<Entreprise> Entreprises { get; set; }
        public DbSet<Affectation> Affectations { get; set; }
        public DbSet<ParticipantConference> ParticipantsConferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Utilisateur>(b =>
            {
                b.ToTable("users");
            });

            modelBuilder.Entity<ParticipantConference>()
                .HasOne(pc => pc.Participant)
                .WithMany(p => p.ParticipantsConferences)
                .HasForeignKey(pc => pc.ParticipantId);

            modelBuilder.Entity<ParticipantConference>()
                .HasOne(pc => pc.Conference)
                .WithMany(c => c.ParticipantsConferences)
                .HasForeignKey(pc => pc.ConferenceId);

            modelBuilder.Entity<MembreComite>()
                .HasOne(mc => mc.Conference)
                .WithMany(c => c.MembresComite)
                .HasForeignKey(mc => mc.ConferenceId);

            modelBuilder.Entity<Auteur>()
                .HasMany(a => a.Articles)
                .WithOne(a => a.Auteur)
                .HasForeignKey(a => a.AuteurId);

            modelBuilder.Entity<Article>()
                .HasMany(a => a.Affectations)
                .WithOne(af => af.Article)
                .HasForeignKey(af => af.ArticleId);

            modelBuilder.Entity<Article>().HasKey(a => a.IdArticle);

            modelBuilder.Entity<Relecteur>()
                .HasMany(r => r.Evaluations)
                .WithOne(e => e.Relecteur)
                .HasForeignKey(e => e.RelecteurId);

            modelBuilder.Entity<Conference>()
                .HasMany(c => c.Articles)
                .WithOne(a => a.Conference)
                .HasForeignKey(a => a.ConferenceId);

            modelBuilder.Entity<Conference>()
                .HasMany(c => c.MembresComite)
                .WithOne(mc => mc.Conference)
                .HasForeignKey(mc => mc.ConferenceId);

            modelBuilder.Entity<Auteur>()
                .HasOne(a => a.Entreprise)
                .WithMany(e => e.Auteurs)
                .HasForeignKey(a => a.EntrepriseId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Auteur>()
                .HasOne(a => a.Universite)
                .WithMany(u => u.Auteurs)
                .HasForeignKey(a => a.UniversiteId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Affectation>()
                .HasOne(a => a.MembreComite)
                .WithMany(mc => mc.Affectations)
                .HasForeignKey(a => a.MembreComiteId);

            modelBuilder.Entity<Affectation>()
                .HasOne(a => a.Article)
                .WithMany(art => art.Affectations)
                .HasForeignKey(a => a.ArticleId);

            modelBuilder.Entity<Affectation>()
                .HasOne(a => a.Relecteur)
                .WithMany(r => r.Affectations)
                .HasForeignKey(a => a.RelecteurId);

            modelBuilder.Entity<Evaluation>()
                .HasOne(e => e.Article)
                .WithMany(a => a.Evaluations)
                .HasForeignKey(e => e.ArticleId);

            modelBuilder.Entity<Evaluation>()
                .HasOne(e => e.Relecteur)
                .WithMany(r => r.Evaluations)
                .HasForeignKey(e => e.RelecteurId);

            modelBuilder.Entity<IdentityUserRole<int>>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<IdentityUserLogin<int>>()
                .HasKey(login => login.UserId);

            modelBuilder.Entity<IdentityUserToken<int>>(b =>
            {
                b.HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name });
            });
        }
    }
}

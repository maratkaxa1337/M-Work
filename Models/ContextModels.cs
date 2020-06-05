namespace Marat.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContextModels : DbContext
    {
        public ContextModels()
            : base("name=ContextModels")
        {
        }

        public virtual DbSet<Applicant> Applicant { get; set; }
        public virtual DbSet<Frame> Frame { get; set; }
        public virtual DbSet<Playment> Playment { get; set; }
        public virtual DbSet<Postiton> Postiton { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicant>()
                .HasMany(e => e.Frame)
                .WithRequired(e => e.Applicant)
                .HasForeignKey(e => e.ApplicantsID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Playment>()
                .HasMany(e => e.Frame)
                .WithRequired(e => e.Playment)
                .HasForeignKey(e => e.PlaymentsID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Postiton>()
                .HasMany(e => e.Frame)
                .WithRequired(e => e.Postiton)
                .HasForeignKey(e => e.PositionID)
                .WillCascadeOnDelete(false);
        }
    }
}

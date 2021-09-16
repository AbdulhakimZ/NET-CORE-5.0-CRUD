using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace abdulhamid.Models
{
    public partial class ToDoListContext : DbContext
    {
        public ToDoListContext()
        {
        }

        public ToDoListContext(DbContextOptions<ToDoListContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChildList> ChildLists { get; set; }
        public virtual DbSet<ParentList> ParentLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=AZ;Database=ToDoList;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

            modelBuilder.Entity<ChildList>(entity =>
            {
                entity.ToTable("ChildList");

                entity.Property(e => e.Body).HasColumnType("text");

                entity.Property(e => e.Title).HasColumnType("text");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.ChildLists)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_ChildList_ParentList");
            });

            modelBuilder.Entity<ParentList>(entity =>
            {
                entity.ToTable("ParentList");

                entity.Property(e => e.Body).HasColumnType("text");

                entity.Property(e => e.Title).HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

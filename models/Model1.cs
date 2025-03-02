using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WinformGUI.models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model12")
        {
        }

        public virtual DbSet<block> blocks { get; set; }
        public virtual DbSet<dang_anh> dang_anh { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<match> matchs { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<report> reports { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<thong_tin_user> thong_tin_user { get; set; }
        public virtual DbSet<Userr> Userrs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<block>()
                .Property(e => e.SenderId)
                .IsUnicode(false);

            modelBuilder.Entity<block>()
                .Property(e => e.ReceiverId)
                .IsUnicode(false);

            modelBuilder.Entity<Images>()
                .Property(e => e.account_name)
                .IsUnicode(false);

            modelBuilder.Entity<Images>()
                .HasMany(e => e.dang_anh)
                .WithRequired(e => e.Image)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<match>()
                .Property(e => e.SenderID)
                .IsUnicode(false);

            modelBuilder.Entity<match>()
                .Property(e => e.ReceiverID)
                .IsUnicode(false);

            modelBuilder.Entity<match>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.Sender)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.Receiver)
                .IsUnicode(false);

            modelBuilder.Entity<report>()
                .Property(e => e.Receiver)
                .IsUnicode(false);

            modelBuilder.Entity<report>()
                .Property(e => e.sender)
                .IsUnicode(false);

            modelBuilder.Entity<thong_tin_user>()
                .Property(e => e.account_name)
                .IsUnicode(false);

            modelBuilder.Entity<thong_tin_user>()
                .Property(e => e.gmail)
                .IsUnicode(false);

            modelBuilder.Entity<Userr>()
                .Property(e => e.account_name)
                .IsUnicode(false);

            modelBuilder.Entity<Userr>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Userr>()
                .HasMany(e => e.blocks)
                .WithRequired(e => e.Userr)
                .HasForeignKey(e => e.ReceiverId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Userr>()
                .HasMany(e => e.blocks1)
                .WithRequired(e => e.Userr1)
                .HasForeignKey(e => e.SenderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Userr>()
                .HasMany(e => e.Images)
                .WithRequired(e => e.Userr)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Userr>()
                .HasMany(e => e.matchs)
                .WithOptional(e => e.Userr)
                .HasForeignKey(e => e.ReceiverID);

            modelBuilder.Entity<Userr>()
                .HasMany(e => e.matchs1)
                .WithOptional(e => e.Userr1)
                .HasForeignKey(e => e.SenderID);

            modelBuilder.Entity<Userr>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Userr)
                .HasForeignKey(e => e.Receiver)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Userr>()
                .HasMany(e => e.Messages1)
                .WithRequired(e => e.Userr1)
                .HasForeignKey(e => e.Sender)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Userr>()
                .HasMany(e => e.reports)
                .WithRequired(e => e.Userr)
                .HasForeignKey(e => e.Receiver)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Userr>()
                .HasMany(e => e.reports1)
                .WithOptional(e => e.Userr1)
                .HasForeignKey(e => e.sender);

            modelBuilder.Entity<Userr>()
                .HasOptional(e => e.thong_tin_user)
                .WithRequired(e => e.Userr);
        }
    }
}

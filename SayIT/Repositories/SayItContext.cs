using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Models;

namespace Repositories
{
   public class SayItContext : DbContext
    {
        public SayItContext(): base()
        {

        }

        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<LearningType> LearningTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Translation> Translations { get; set; }
        public DbSet<QuizQuestionType> QuizQuestionTypes { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Progress> Progresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var AccountTypes = modelBuilder.Entity<AccountType>();
            AccountTypes.HasKey<int>(e => e.Id);
            AccountTypes.HasMany<User>(a => a.Users).WithMany(o => o.AccountTypes);

            var LearningTypes = modelBuilder.Entity<LearningType>();
            LearningTypes.HasKey<int>(e => e.Id);
            LearningTypes.HasMany<Progress>(a => a.Progresses).WithRequired(o => o.LearningType);

            var Categories = modelBuilder.Entity<Category>();
            Categories.HasKey<int>(e => e.Id);
            Categories.HasMany<Translation>(e => e.Translations).WithRequired(o => o.Category);
            Categories.HasMany<Progress>(e => e.Progresses).WithRequired(o => o.Category);

            var Translation = modelBuilder.Entity<Translation>();
            Translation.HasKey<int>(e => e.Id);
            Translation.HasRequired<Category>(a => a.Category).WithMany(o => o.Translations).HasForeignKey(p => p.CategoryId);

            var QuizQuestionTypes = modelBuilder.Entity<QuizQuestionType>();
            QuizQuestionTypes.HasKey<int>(e => e.Id);
            QuizQuestionTypes.HasMany<QuizQuestion>(o => o.QuizQuestions).WithRequired(p => p.QuestionType);

            var QuizQuestions = modelBuilder.Entity<QuizQuestion>();
            QuizQuestions.HasKey<int>(e => e.Id);
            QuizQuestions.HasRequired<Translation>(e => e.Translation).WithMany(o => o.QuizQuestion).HasForeignKey(p => p.QuestionTypeId);

            var Users = modelBuilder.Entity<User>();
            Users.HasKey<int>(e => e.Id);
            Users.HasIndex(i => i.Id).IsUnique();
            Users.HasMany<AccountType>(o => o.AccountTypes).WithMany(p => p.Users);

            var Progresses = modelBuilder.Entity<Progress>();
            Progresses.HasKey(e => new { e.UserId, e.CategoryId, e.LearningTypeId });
            Progresses.HasRequired<User>(o => o.User).WithMany(p => p.Progresses).HasForeignKey(e => e.UserId);
            Progresses.HasRequired<Category>(o => o.Category).WithMany(p => p.Progresses).HasForeignKey(e => e.CategoryId);
            Progresses.HasRequired<LearningType>(o => o.LearningType).WithMany(p => p.Progresses).HasForeignKey(e => e.LearningTypeId);
        }
    }
}

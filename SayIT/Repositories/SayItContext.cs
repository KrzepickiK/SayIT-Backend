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
        //base("sorky1_dictionaryEntities4")
        public SayItContext(): base("sorky1_dictionaryEntities4")
        {
        
        }

        public DbSet<LearningType> LearningTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Translation> Translations { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var LearningTypes = modelBuilder.Entity<LearningType>();
            LearningTypes.HasKey<int>(e => e.Id);
            LearningTypes.HasMany<QuizQuestion>(a => a.QuizQuestion).WithRequired(o => o.LearningType);

            var Categories = modelBuilder.Entity<Category>();
            Categories.HasKey<int>(e => e.Id);
            Categories.HasMany<Translation>(e => e.Translations).WithRequired(o => o.Category);

            var Translation = modelBuilder.Entity<Translation>();
            Translation.HasKey<int>(e => e.Id);
            Translation.HasRequired<Category>(a => a.Category).WithMany(o => o.Translations);


            var QuizQuestions = modelBuilder.Entity<QuizQuestion>();
            QuizQuestions.HasKey<int>(e => e.Id);
            QuizQuestions.HasRequired<Translation>(e => e.Translation).WithMany(o => o.QuizQuestion);
            QuizQuestions.HasRequired<LearningType>(e => e.LearningType).WithMany(o => o.QuizQuestion);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}

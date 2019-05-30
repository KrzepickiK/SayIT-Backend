namespace Repositories.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Repositories.SayItContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Repositories.SayItContext context)
        {
            IList<AccountType> StartingAccountTypes = new List<AccountType>();
            StartingAccountTypes.Add(new AccountType() {Id = 1, Type = "Admin" });
            StartingAccountTypes.Add(new AccountType() {Id = 2, Type = "Moderator" });
            StartingAccountTypes.Add(new AccountType() {Id = 3, Type = "PremiumUser" });
            StartingAccountTypes.Add(new AccountType() {Id = 4, Type = "RegularUser" });

            context.AccountTypes.AddRange(StartingAccountTypes);


            IList<User> StartingUsers = new List<User>();
            StartingUsers.Add(new User {Login = "Admin", Password = "admin123", Email = "admin@sayit.pl", Name = "Dawid", Surname = "Tomczak", AccountTypeId = 1 });

            context.Users.AddRange(StartingUsers);


            IList<Category> StartingCategories = new List<Category>();
            StartingCategories.Add(new Category {Id = 1, CategoryName = "Sprzêt", MaterialIconName = "memory" });
            StartingCategories.Add(new Category {Id = 2, CategoryName = "Programowanie", MaterialIconName = "code" });
            StartingCategories.Add(new Category {Id = 3, CategoryName = "Rozmowa kwalifikacyjna", MaterialIconName = "business" });
            StartingCategories.Add(new Category {Id = 4, CategoryName = "Inne", MaterialIconName = "local_pizza" });

            context.Categories.AddRange(StartingCategories);


            IList<LearningType> StartingLearningTypes = new List<LearningType>();
            StartingLearningTypes.Add(new LearningType() {Id = 1, Name = "Flashcard", Description = "Naucz siê s³ówek dziêki fiszkom" });
            StartingLearningTypes.Add(new LearningType() {Id = 2, Name = "Quiz", Description = "Wybierz poprawne t³umaczenie z dostêpnych opcji" });
            StartingLearningTypes.Add(new LearningType() {Id = 3, Name = "Matching Words", Description = "Wpisz s³owo pasuj¹ce do definicji" });

            context.LearningTypes.AddRange(StartingLearningTypes);


            IList<Translation> StartingTranslations = new List<Translation>();
            StartingTranslations.Add(new Translation()
            {
                Id = 1,
                CategoryId = 1,
                TranslationEN = "Mouse",
                TranslationPL = "Mysz",
                MeaningEN = "Device with allows you to move the cursor inside of the system",
                MeaningPL = "Urz¹dzenie które pozwala poruszaæ kursorem wewn¹trz systemu",
            });
            StartingTranslations.Add(new Translation()
            {
                Id = 2,
                CategoryId = 1,
                TranslationEN = "Keyboard",
                TranslationPL = "Klawiatura",
                MeaningEN = "Device with allows you to type letters or characters into the system",
                MeaningPL = "Urz¹dzenie które pozwala wprowadzaæ litery lub inne znaki do systemu",
            });

            StartingTranslations.Add(new Translation()
            {
                Id = 3,
                CategoryId = 2,
                TranslationEN = "Method",
                TranslationPL = "Metoda",
                MeaningEN = "A function that can be called on an object of a given class and can return some data or just do a task",
                MeaningPL = "Funkcja która mo¿e zostaæ wywo³ana poprzez instancje klasy zwracaj¹ca dane lub wykonuj¹ca dzia³ania",
            });
            StartingTranslations.Add(new Translation()
            {
                Id=4,
                CategoryId = 2,
                TranslationEN = "Compiler",
                TranslationPL = "Kompilator",
                MeaningEN = "A program that converts another program from some source language (or programming language) to machine language (object code)",
                MeaningPL = "Program s³u¿¹cy do automatycznego t³umaczenia kodu napisanego w jednym jêzyku (jêzyku Ÿród³owym) na równowa¿ny kod w innym jêzyku (jêzyku wynikowym)",
            });
            StartingTranslations.Add(new Translation()
            {
                Id = 5,
                CategoryId = 3,
                TranslationEN = "Experience",
                TranslationPL = "Doœwiadczenie",
                MeaningEN = "The process of getting knowledge or skill from doing things",
                MeaningPL = "Proces podczas którego zwiêszamy swoj¹ wiedzê lub umiejêtnoœci dotycz¹ce dzia³ania",
            });
            StartingTranslations.Add(new Translation()
            {
                Id = 6,
                CategoryId = 3,
                TranslationEN = "Personal info",
                TranslationPL = "Dane osobowe",
                MeaningEN = "Informations with allow you to identify a person (like name, address...)",
                MeaningPL = "Informacje które pozwalaj¹ zidentyfikowaæ osobê (jak imiê, adres...)",
            });
            StartingTranslations.Add(new Translation()
            {
                Id = 7,
                CategoryId = 4,
                TranslationEN = "Pizza",
                TranslationPL = "Pizza",
                MeaningEN = "Food with is needed by software developers to write code",
                MeaningPL = "Jedzenie które jest potrzebne programistom do pisania kodu",
            });
            StartingTranslations.Add(new Translation()
            {
                Id = 8,
                CategoryId = 4,
                TranslationEN = "Coffee",
                TranslationPL = "Kawa",
                MeaningEN = "Drink with is needed by software developers to write code",
                MeaningPL = "Napój który jest potrzebny programistom do pisania kodu",
            });

            context.Translations.AddRange(StartingTranslations);


            IList<QuizQuestion> StartingQuizQuestions = new List<QuizQuestion>();

            StartingQuizQuestions.Add(new QuizQuestion { TranslationId = 1, LearningTypeId = 2, Option1 = "Monitor", Option2 = "Power suply", Option3 = "Hard drive" });
            StartingQuizQuestions.Add(new QuizQuestion { TranslationId = 2, LearningTypeId = 2, Option1 = "Letterboard", Option2 = "Typeboard", Option3 = "Mainboard" });
            StartingQuizQuestions.Add(new QuizQuestion { TranslationId = 3, LearningTypeId = 2, Option1 = "Variable", Option2 = "MeetHood", Option3 = "Method" });
            StartingQuizQuestions.Add(new QuizQuestion { TranslationId = 4, LearningTypeId = 2, Option1 = "Resolver", Option2 = "Decoder", Option3 = "Compilator" });
            StartingQuizQuestions.Add(new QuizQuestion { TranslationId = 5, LearningTypeId = 2, Option1 = "Skill", Option2 = "Length", Option3 = "Task" });
            StartingQuizQuestions.Add(new QuizQuestion { TranslationId = 6, LearningTypeId = 2, Option1 = "ID", Option2 = "Person data", Option3 = "Dependency" });
            StartingQuizQuestions.Add(new QuizQuestion { TranslationId = 7, LearningTypeId = 2, Option1 = "Dumplings", Option2 = "Sandwich", Option3 = "Pancakes" });
            StartingQuizQuestions.Add(new QuizQuestion { TranslationId = 8, LearningTypeId = 2, Option1 = "Cola", Option2 = "Fresh juice", Option3 = "Water" });

            context.QuizQuestions.AddRange(StartingQuizQuestions);





            base.Seed(context);
        }
    }
}

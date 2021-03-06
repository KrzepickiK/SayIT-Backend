﻿namespace Repositories.Migrations
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
            //IList<Category> StartingCategories = new List<Category>
            //{
            //    new Category { Id = 1, Name = "Sprz�t", MaterialIconName = "memory" },
            //    new Category { Id = 2, Name = "Programowanie", MaterialIconName = "code" },
            //    new Category { Id = 3, Name = "Rozmowa kwalifikacyjna", MaterialIconName = "business" },
            //    new Category { Id = 4, Name = "Inne", MaterialIconName = "local_pizza" }
            //};

            //context.Categories.AddRange(StartingCategories);


            //IList<LearningType> StartingLearningTypes = new List<LearningType>
            //{
            //    new LearningType() { Id = 1, Name = "Flashcard", Description = "Naucz si� s��wek dzi�ki fiszkom" },
            //    new LearningType() { Id = 2, Name = "Quiz", Description = "Wybierz poprawne t�umaczenie z dost�pnych opcji" },
            //    new LearningType() { Id = 3, Name = "Matching Words", Description = "Wpisz s�owo pasuj�ce do definicji" }
            //};

            //context.LearningTypes.AddRange(StartingLearningTypes);


            //IList<Translation> StartingTranslations = new List<Translation>
            //{
            //    new Translation()
            //    {
            //        Id = 1,
            //        CategoryId = 1,
            //        TranslationEN = "Mouse",
            //        TranslationPL = "Mysz",
            //        MeaningEN = "Device with allows you to move the cursor inside of the system",
            //        MeaningPL = "Urz�dzenie kt�re pozwala porusza� kursorem wewn�trz systemu",
            //    },
            //    new Translation()
            //    {
            //        Id = 2,
            //        CategoryId = 1,
            //        TranslationEN = "Keyboard",
            //        TranslationPL = "Klawiatura",
            //        MeaningEN = "Device with allows you to type letters or characters into the system",
            //        MeaningPL = "Urz�dzenie kt�re pozwala wprowadza� litery lub inne znaki do systemu",
            //    },

            //    new Translation()
            //    {
            //        Id = 3,
            //        CategoryId = 2,
            //        TranslationEN = "Method",
            //        TranslationPL = "Metoda",
            //        MeaningEN = "A function that can be called on an object of a given class and can return some data or just do a task",
            //        MeaningPL = "Funkcja kt�ra mo�e zosta� wywo�ana poprzez instancje klasy zwracaj�ca dane lub wykonuj�ca dzia�ania",
            //    },
            //    new Translation()
            //    {
            //        Id = 4,
            //        CategoryId = 2,
            //        TranslationEN = "Compiler",
            //        TranslationPL = "Kompilator",
            //        MeaningEN = "A program that converts another program from some source language (or programming language) to machine language (object code)",
            //        MeaningPL = "Program s�u��cy do automatycznego t�umaczenia kodu napisanego w jednym j�zyku (j�zyku �r�d�owym) na r�wnowa�ny kod w innym j�zyku (j�zyku wynikowym)",
            //    },
            //    new Translation()
            //    {
            //        Id = 5,
            //        CategoryId = 3,
            //        TranslationEN = "Experience",
            //        TranslationPL = "Do�wiadczenie",
            //        MeaningEN = "The process of getting knowledge or skill from doing things",
            //        MeaningPL = "Proces podczas kt�rego zwi�szamy swoj� wiedz� lub umiej�tno�ci dotycz�ce dzia�ania",
            //    },
            //    new Translation()
            //    {
            //        Id = 6,
            //        CategoryId = 3,
            //        TranslationEN = "Personal info",
            //        TranslationPL = "Dane osobowe",
            //        MeaningEN = "Informations with allow you to identify a person (like name, address...)",
            //        MeaningPL = "Informacje kt�re pozwalaj� zidentyfikowa� osob� (jak imi�, adres...)",
            //    },
            //    new Translation()
            //    {
            //        Id = 7,
            //        CategoryId = 4,
            //        TranslationEN = "Pizza",
            //        TranslationPL = "Pizza",
            //        MeaningEN = "Food with is needed by software developers to write code",
            //        MeaningPL = "Jedzenie kt�re jest potrzebne programistom do pisania kodu",
            //    },
            //    new Translation()
            //    {
            //        Id = 8,
            //        CategoryId = 4,
            //        TranslationEN = "Coffee",
            //        TranslationPL = "Kawa",
            //        MeaningEN = "Drink with is needed by software developers to write code",
            //        MeaningPL = "Nap�j kt�ry jest potrzebny programistom do pisania kodu",
            //    }
            //};

            //context.Translations.AddRange(StartingTranslations);


            //IList<QuizQuestion> StartingQuizQuestions = new List<QuizQuestion>
            //{
            //    new QuizQuestion { TranslationId = 1, LearningTypeId = 2, Option1 = "Monitor", Option2 = "Power suply", Option3 = "Hard drive" },
            //    new QuizQuestion { TranslationId = 2, LearningTypeId = 2, Option1 = "Letterboard", Option2 = "Typeboard", Option3 = "Mainboard" },
            //    new QuizQuestion { TranslationId = 3, LearningTypeId = 2, Option1 = "Variable", Option2 = "MeetHood", Option3 = "Method" },
            //    new QuizQuestion { TranslationId = 4, LearningTypeId = 2, Option1 = "Resolver", Option2 = "Decoder", Option3 = "Compilator" },
            //    new QuizQuestion { TranslationId = 5, LearningTypeId = 2, Option1 = "Skill", Option2 = "Length", Option3 = "Task" },
            //    new QuizQuestion { TranslationId = 6, LearningTypeId = 2, Option1 = "ID", Option2 = "Person data", Option3 = "Dependency" },
            //    new QuizQuestion { TranslationId = 7, LearningTypeId = 2, Option1 = "Dumplings", Option2 = "Sandwich", Option3 = "Pancakes" },
            //    new QuizQuestion { TranslationId = 8, LearningTypeId = 2, Option1 = "Cola", Option2 = "Fresh juice", Option3 = "Water" }
            //};

            //context.QuizQuestions.AddRange(StartingQuizQuestions);





            //base.Seed(context);
        }
    }
}

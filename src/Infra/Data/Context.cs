using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new QuestionMapping());
            modelBuilder.ApplyConfiguration(new ChoiceMapping());

            modelBuilder.Entity<Questions>()
                .HasData(CreateQuestion(1),
                CreateQuestion(2),
                CreateQuestion(3),
                CreateQuestion(4),
                CreateQuestion(5),
                CreateQuestion(6),
                CreateQuestion(7),
                CreateQuestion(8),
                CreateQuestion(9),
                CreateQuestion(10),
                CreateQuestion(11),
                CreateQuestion(12));

            modelBuilder.Entity<Choices>()
                .HasData(CreateChoices(1, 1, "C#", 10),
                CreateChoices(2, 1, "C++", 15),
                CreateChoices(3, 2, "C#", 10),
                CreateChoices(4, 2, "C++", 15),
                CreateChoices(5, 3, "C#", 10),
                CreateChoices(6, 3, "C++", 15),
                CreateChoices(7, 4, "C#", 10),
                CreateChoices(8, 4, "C++", 15),
                CreateChoices(9, 5, "C#", 10),
                CreateChoices(10, 5, "C++", 15),
                CreateChoices(11, 6, "C#", 10),
                CreateChoices(12, 6, "C++", 15),
                CreateChoices(13, 7, "C#", 10),
                CreateChoices(14, 7, "C++", 15),
                CreateChoices(15, 8, "C#", 10),
                CreateChoices(16, 8, "C++", 15),
                CreateChoices(17, 9, "C#", 10),
                CreateChoices(18, 9, "C++", 15),
                CreateChoices(19, 10, "C#", 10),
                CreateChoices(20, 10, "C++", 15),
                CreateChoices(21, 11, "C#", 10),
                CreateChoices(22, 11, "C++", 15),
                CreateChoices(23, 12, "C#", 10),
                CreateChoices(24, 12, "C++", 15));

        }

        private Questions CreateQuestion(int id)
        {
            return new Questions(id, "Favourite programming language?",
                "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)",
                "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)");
        }

        private Choices CreateChoices(int id, int questionId, string choice, int votes)
        {
            return new Choices(id, questionId, choice, votes);
        }
    }
}
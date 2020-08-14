namespace CodeFirstProject.Migrations
{
    using CodeFirstProject.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstProject.Controllers.StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CodeFirstProject.Controllers.StudentContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var classes = new List<StudentClass>
            {
                new StudentClass{Id=1, Name="Class 1"},
                new StudentClass{Id=2, Name="Class 2"},
                new StudentClass{Id=3, Name="Class 3"}
            };



            var students = new List<Student>
            {
                new Student{Id = 1, Name="Param", Gender=Gender.Male,
                    DateOfBirth=new DateTime(1995,12,14),
                    Class = classes.Find(c=>c.Id==1)},
                new Student{Id = 2, Name="Shona", Gender=Gender.Female,
                    DateOfBirth=new DateTime(1995,12,14),
                    Class = classes.Find(c=>c.Id == 2)},
                new Student{Id = 3, Name="Jon Snow", Gender=Gender.Male,
                    DateOfBirth=new DateTime(1995,12,14),
                    Class = classes.Find(c=>c.Id == 3)}
            };



            context.Classes.AddOrUpdate(classes.ToArray());
            context.Students.AddOrUpdate(students.ToArray());
            context.SaveChanges();
        }
    }
}

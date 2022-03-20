using APILabb4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILabb4.API.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Person> People { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<PersonHobby> PersonHobbies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Person
            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 1,
                FirstName = "Lina",
                LastName = "Haytham",
                Address = "Skånegatan 17",
                Phone = "0761121112",
                Email = "lolo@hot.com"
            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 2,
                FirstName = "Jones",
                LastName = "Haytham",
                Address = "Kvarnängsgatan 24",
                Phone = "0735454123",
                Email = "jojo@hot.com"
            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 3,
                FirstName = "Natalia",
                LastName = "Al",
                Address = "Kungsgatan 5",
                Phone = "0707654321",
                Email = "nata@hot.com"
            });

            //Seed Hobby
            modelBuilder.Entity<Hobby>().HasData(new Hobby
            {
                HobbyId = 1,
                HobbyName = "Art",
                Description = "Drawing, painting, sculpting, crafts, DIY"
            });
            modelBuilder.Entity<Hobby>().HasData(new Hobby
            {
                HobbyId = 2,
                HobbyName = "Sports",
                Description = "Ballsports, swimming, martial arts, jogging, dancing"
            });
            modelBuilder.Entity<Hobby>().HasData(new Hobby
            {
                HobbyId = 3,
                HobbyName = "Cooking",
                Description = "Cooking food, baking"
            });
            modelBuilder.Entity<Hobby>().HasData(new Hobby
            {
                HobbyId = 4,
                HobbyName = "Music",
                Description = "Singing, playing instruments, production"
            });

            //Seed PersonHobby
            modelBuilder.Entity<PersonHobby>().HasData(new PersonHobby
            {
                PersonHobbyId = 1,
                PersonId = 1,
                HobbyId = 3,
                WebLink = "www.recepten.se/"
            });
            modelBuilder.Entity<PersonHobby>().HasData(new PersonHobby
            {
                PersonHobbyId = 2,
                PersonId = 1,
                HobbyId = 3,
                WebLink = "www.koket.se/"
            });
            modelBuilder.Entity<PersonHobby>().HasData(new PersonHobby
            {
                PersonHobbyId = 3,
                PersonId = 2,
                HobbyId = 2,
                WebLink = "www.bet365.com/"
            });
            modelBuilder.Entity<PersonHobby>().HasData(new PersonHobby
            {
                PersonHobbyId = 4,
                PersonId = 2,
                HobbyId = 3,
                WebLink = "www.koket.se/"
            });
            modelBuilder.Entity<PersonHobby>().HasData(new PersonHobby
            {
                PersonHobbyId = 5,
                PersonId = 3,
                HobbyId = 1,
                WebLink = "diysweden.se"
            });
            modelBuilder.Entity<PersonHobby>().HasData(new PersonHobby
            {
                PersonHobbyId = 6,
                PersonId = 3,
                HobbyId = 4,
                WebLink = "soundcloud.com"
            });
        }
    }
}

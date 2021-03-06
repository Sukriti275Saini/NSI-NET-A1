﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VLM.Data.Entities;

namespace VLM.Data
{
    public class VLMDbContext : DbContext
    {
        public VLMDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Records> Records { get; set; }

        protected override void OnModelCreating(ModelBuilder bldr)
        {
            bldr.Entity<User>()
              .HasData(new
              {
                  UserName = "surisagar900",
                  FirstName = "Sagar",
                  LastName = "Suri",
                  DOB = new DateTime(1999, 03, 15),
                  Email = "s@gmail.com",
                  Phone = 9876543210,
                  Password = "Sagarsuri"
              });

            bldr.Entity<Movies>()
              .HasData(new
              {
                  MoviesId = 1,
                  Title = "Avengers",
                  Director = "Josan",
                  Language = "English",
                  Genre = "Thriller",
                  ReleaseYear = 2012,
                  Description = "When an unexpected enemy emerges that threatens the fate of mankind, Nick Fury, Director of S.H.I.E.L.D., finds himself in need of a team to pull the world back from the brink of disaster. Spanning the globe, a daring recruitment effort begins.",
                  ReturnDays = 20,
                  Fine = 400,
              }, new
              {
                  MoviesId = 2,
                  Title = "Avengers: Age Of Ultron",
                  Director = "Josan",
                  Language = "English",
                  Genre = "Thriller",
                  ReleaseYear = 2012,
                  Description = "Tony Stark builds an artificial intelligence system named Ultron with the help of Bruce Banner. And when things go wrong, it's up to Earth's mightiest heroes to stop the villainous Ultron from enacting his terrible plan.",
                  ReturnDays = 25,
                  Fine = 700,
              }, new
              {
                  MoviesId = 3,
                  Title = "Avengers: Infinity War",
                  Director = "Marvels",
                  Language = "Hindi",
                  Genre = "Action",
                  ReleaseYear = 2018,
                  Description = "With the powerful Thanos on the verge of raining destruction upon the universe, the Avengers and their Superhero allies risk everything in the ultimate showdown of all time.",
                  ReturnDays = 20,
                  Fine = 800,
              });

            bldr.Entity<Records>()
              .HasData(new
              {
                  RecordsId = 1,
                  UserName = "surisagar900",
                  MoviesId = 1,
                  TakenDate = new DateTime(2020, 05, 04),
                  ReturnDate = new DateTime(2020, 05, 24)
              },
              new
              {
                  RecordsId = 2,
                  UserName = "surisagar900",
                  MoviesId = 3,
                  TakenDate = new DateTime(2020, 05, 02),
                  ReturnDate = new DateTime(2020, 05, 22)
              });
        }
    }
}

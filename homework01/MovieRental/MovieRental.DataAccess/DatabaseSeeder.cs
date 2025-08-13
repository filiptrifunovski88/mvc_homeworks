using System;
using System.Collections.Generic;
using System.Linq;
using MovieRental.Domain.Enums;
using MovieRental.Domain.Models;

namespace MovieRental.DataAccess
{
    public static class DatabaseSeeder
    {
        public static void Seed(MovieRentalContext context)
        {
            context.Database.EnsureCreated();

            var usersToAdd = new List<User>
            {
                new User { FullName = "Filip Ohrid",  Age = 19, CardNumber = "2222222", CreatedOn = DateTime.Now.AddDays(-3),  SubscriptionType = SubscriptionType.Monthly, IsSubscriptionExpired = false },
                new User { FullName = "Ohrid Trifunovski",  Age = 19, CardNumber = "3333333", CreatedOn = DateTime.Now.AddDays(-15), SubscriptionType = SubscriptionType.None,    IsSubscriptionExpired = true  }
            };

            foreach (var u in usersToAdd)
                if (!context.Users.Any(x => x.CardNumber == u.CardNumber))
                    context.Users.Add(u);

            var moviesToAdd = new List<Movie>
            {
                new Movie { Title="Inception",                 Genre=Genre.SciFi,   Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2010,7,16), Length=TimeSpan.FromMinutes(148), AgeRestriction=13, Quantity=5 },
                new Movie { Title="The Dark Knight",           Genre=Genre.Action,  Language=Language.English, IsAvailable=false, ReleaseDate=new DateTime(2008,7,18), Length=TimeSpan.FromMinutes(152), AgeRestriction=13, Quantity=0 },
                new Movie { Title="Parasite",                  Genre=Genre.Drama,   Language=Language.German,  IsAvailable=true,  ReleaseDate=new DateTime(2019,5,30), Length=TimeSpan.FromMinutes(132), AgeRestriction=15, Quantity=3 },
                new Movie { Title="Interstellar",              Genre=Genre.SciFi,   Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2014,11,7), Length=TimeSpan.FromMinutes(169), AgeRestriction=13, Quantity=4 },
                new Movie { Title="Joker",                     Genre=Genre.Drama,   Language=Language.English, IsAvailable=false, ReleaseDate=new DateTime(2019,10,4), Length=TimeSpan.FromMinutes(122), AgeRestriction=16, Quantity=0 },
                new Movie { Title="Get Out",                   Genre=Genre.Horror,  Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2017,2,24), Length=TimeSpan.FromMinutes(104), AgeRestriction=16, Quantity=2 },
                new Movie { Title="The Grand Budapest Hotel",  Genre=Genre.Comedy,  Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2014,3,28), Length=TimeSpan.FromMinutes(99),  AgeRestriction=12, Quantity=1 },
                new Movie { Title="Arrival",                   Genre=Genre.SciFi,   Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2016,11,11),Length=TimeSpan.FromMinutes(116), AgeRestriction=12, Quantity=6 },
                new Movie { Title="A Quiet Place",             Genre=Genre.Thriller,Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2018,4,6),  Length=TimeSpan.FromMinutes(90),  AgeRestriction=14, Quantity=2 },
                new Movie { Title="The Matrix",                Genre=Genre.SciFi,   Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(1999,3,31), Length=TimeSpan.FromMinutes(136), AgeRestriction=16, Quantity=5 },
                new Movie { Title="Gladiator",                 Genre=Genre.Action,  Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2000,5,5),  Length=TimeSpan.FromMinutes(155), AgeRestriction=16, Quantity=4 },
                new Movie { Title="The Godfather",             Genre=Genre.Drama,   Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(1972,3,24), Length=TimeSpan.FromMinutes(175), AgeRestriction=18, Quantity=3 },
                new Movie { Title="Pulp Fiction",              Genre=Genre.Drama,   Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(1994,10,14),Length=TimeSpan.FromMinutes(154), AgeRestriction=18, Quantity=2 },
                new Movie { Title="Forrest Gump",              Genre=Genre.Drama,   Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(1994,7,6),  Length=TimeSpan.FromMinutes(142), AgeRestriction=12, Quantity=4 },
                new Movie { Title="Fight Club",                Genre=Genre.Drama,   Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(1999,10,15),Length=TimeSpan.FromMinutes(139), AgeRestriction=18, Quantity=3 },
                new Movie { Title="The Shawshank Redemption",  Genre=Genre.Drama,   Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(1994,9,22), Length=TimeSpan.FromMinutes(142), AgeRestriction=16, Quantity=5 },
                new Movie { Title="The Lion King",             Genre=Genre.Comedy,  Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(1994,6,24), Length=TimeSpan.FromMinutes(88),  AgeRestriction=0,  Quantity=7 },
                new Movie { Title="Avengers: Endgame",         Genre=Genre.Action,  Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2019,4,26), Length=TimeSpan.FromMinutes(181), AgeRestriction=13, Quantity=6 },
                new Movie { Title="Spider-Man: No Way Home",   Genre=Genre.Action,  Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2021,12,17),Length=TimeSpan.FromMinutes(148), AgeRestriction=13, Quantity=8 },
                new Movie { Title="The Cabin in the Woods",    Genre=Genre.Horror,  Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2012,4,13), Length=TimeSpan.FromMinutes(95),  AgeRestriction=16, Quantity=1 },
                new Movie { Title="The Shawshank Redemption",  Genre=Genre.Drama,   Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(1994,9,22), Length=TimeSpan.FromMinutes(142), AgeRestriction=16, Quantity=5 },
    new Movie { Title="Arrival",                   Genre=Genre.SciFi,   Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2016,11,11), Length=TimeSpan.FromMinutes(116), AgeRestriction=12, Quantity=6 },
    new Movie { Title="Dune",                      Genre=Genre.SciFi,   Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2021,10,22), Length=TimeSpan.FromMinutes(155), AgeRestriction=13, Quantity=6 },
    new Movie { Title="The Dark Knight",           Genre=Genre.Action,  Language=Language.English, IsAvailable=false, ReleaseDate=new DateTime(2008,7,18), Length=TimeSpan.FromMinutes(152), AgeRestriction=13, Quantity=0 },
    new Movie { Title="Coco",                      Genre=Genre.Comedy,  Language=Language.Spanish, IsAvailable=true,  ReleaseDate=new DateTime(2017,11,22), Length=TimeSpan.FromMinutes(105), AgeRestriction=0,  Quantity=5 },
    new Movie { Title="The Godfather",             Genre=Genre.Drama,   Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(1972,3,24), Length=TimeSpan.FromMinutes(175), AgeRestriction=18, Quantity=3 },
    new Movie { Title="The Prestige",              Genre=Genre.Drama,   Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2006,10,20), Length=TimeSpan.FromMinutes(130), AgeRestriction=13, Quantity=4 },
    new Movie { Title="Parasite",                  Genre=Genre.Drama,   Language=Language.German,  IsAvailable=true,  ReleaseDate=new DateTime(2019,5,30), Length=TimeSpan.FromMinutes(132), AgeRestriction=15, Quantity=3 },
    new Movie { Title="The Lion King",             Genre=Genre.Comedy,  Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(1994,6,24), Length=TimeSpan.FromMinutes(88),  AgeRestriction=0,  Quantity=7 },
    new Movie { Title="The Cabin in the Woods",    Genre=Genre.Horror,  Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2012,4,13), Length=TimeSpan.FromMinutes(95),  AgeRestriction=16, Quantity=1 },
    new Movie { Title="Whiplash",                  Genre=Genre.Drama,   Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2014,10,10), Length=TimeSpan.FromMinutes(106), AgeRestriction=15, Quantity=2 },
    new Movie { Title="Get Out",                   Genre=Genre.Horror,  Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2017,2,24), Length=TimeSpan.FromMinutes(104), AgeRestriction=16, Quantity=2 },
    new Movie { Title="Avengers: Endgame",         Genre=Genre.Action,  Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2019,4,26), Length=TimeSpan.FromMinutes(181), AgeRestriction=13, Quantity=6 },
    new Movie { Title="The Matrix",                Genre=Genre.SciFi,   Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(1999,3,31), Length=TimeSpan.FromMinutes(136), AgeRestriction=16, Quantity=5 },
    new Movie { Title="Mad Max: Fury Road",        Genre=Genre.Action,  Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2015,5,15),  Length=TimeSpan.FromMinutes(120), AgeRestriction=16, Quantity=4 },
    new Movie { Title="Interstellar",              Genre=Genre.SciFi,   Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2014,11,7), Length=TimeSpan.FromMinutes(169), AgeRestriction=13, Quantity=4 },
    new Movie { Title="La La Land",                Genre=Genre.Comedy,  Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2016,12,9),  Length=TimeSpan.FromMinutes(128), AgeRestriction=12, Quantity=5 },
    new Movie { Title="Her",                       Genre=Genre.Drama,   Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2013,12,18), Length=TimeSpan.FromMinutes(126), AgeRestriction=15, Quantity=2 },
    new Movie { Title="Inception",                 Genre=Genre.SciFi,   Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2010,7,16), Length=TimeSpan.FromMinutes(148), AgeRestriction=13, Quantity=5 },
    new Movie { Title="Gladiator",                 Genre=Genre.Action,  Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2000,5,5),  Length=TimeSpan.FromMinutes(155), AgeRestriction=16, Quantity=4 },
    new Movie { Title="Pulp Fiction",              Genre=Genre.Drama,   Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(1994,10,14),Length=TimeSpan.FromMinutes(154), AgeRestriction=18, Quantity=2 },
    new Movie { Title="Fight Club",                Genre=Genre.Drama,   Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(1999,10,15),Length=TimeSpan.FromMinutes(139), AgeRestriction=18, Quantity=3 },
    new Movie { Title="The Grand Budapest Hotel",  Genre=Genre.Comedy,  Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2014,3,28), Length=TimeSpan.FromMinutes(99),  AgeRestriction=12, Quantity=1 },
    new Movie { Title="Spider-Man: No Way Home",   Genre=Genre.Action,  Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2021,12,17),Length=TimeSpan.FromMinutes(148), AgeRestriction=13, Quantity=8 },
    new Movie { Title="The Revenant",              Genre=Genre.Action,  Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2015,12,25), Length=TimeSpan.FromMinutes(156), AgeRestriction=16, Quantity=3 },
    new Movie { Title="Shutter Island",            Genre=Genre.Thriller,Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2010,2,19),  Length=TimeSpan.FromMinutes(138), AgeRestriction=16, Quantity=3 },
    new Movie { Title="The Intouchables",          Genre=Genre.Comedy,  Language=Language.French,  IsAvailable=true,  ReleaseDate=new DateTime(2011,11,2),  Length=TimeSpan.FromMinutes(112), AgeRestriction=12, Quantity=3 },
    new Movie { Title="Forrest Gump",              Genre=Genre.Drama,   Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(1994,7,6),  Length=TimeSpan.FromMinutes(142), AgeRestriction=12, Quantity=4 },
    new Movie { Title="The Lion King",             Genre=Genre.Comedy,  Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(1994,6,24), Length=TimeSpan.FromMinutes(88),  AgeRestriction=0,  Quantity=7 },
    new Movie { Title="Frozen",                    Genre=Genre.Comedy,  Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2013,11,27), Length=TimeSpan.FromMinutes(102), AgeRestriction=0,  Quantity=6 },
    new Movie { Title="Joker",                     Genre=Genre.Drama,   Language=Language.English, IsAvailable=false, ReleaseDate=new DateTime(2019,10,4), Length=TimeSpan.FromMinutes(122), AgeRestriction=16, Quantity=0 },
    new Movie { Title="Moana",                     Genre=Genre.Comedy,  Language=Language.Spanish, IsAvailable=true,  ReleaseDate=new DateTime(2016,11,23), Length=TimeSpan.FromMinutes(107), AgeRestriction=0,  Quantity=4 },
    new Movie { Title="Inside Out",                Genre=Genre.Comedy,  Language=Language.French,  IsAvailable=true,  ReleaseDate=new DateTime(2015,6,19),  Length=TimeSpan.FromMinutes(95),  AgeRestriction=0,  Quantity=3 },
    new Movie { Title="Encanto",                   Genre=Genre.Comedy,  Language=Language.Spanish, IsAvailable=true,  ReleaseDate=new DateTime(2021,11,24), Length=TimeSpan.FromMinutes(102), AgeRestriction=0,  Quantity=5 },
    new Movie { Title="Soul",                      Genre=Genre.Comedy,  Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2020,12,25), Length=TimeSpan.FromMinutes(100), AgeRestriction=0,  Quantity=6 },
    new Movie { Title="A Quiet Place",             Genre=Genre.Thriller,Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2018,4,6),  Length=TimeSpan.FromMinutes(90),  AgeRestriction=14, Quantity=2 },
    new Movie { Title="Brave",                     Genre=Genre.Comedy,  Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2012,6,22),  Length=TimeSpan.FromMinutes(93),  AgeRestriction=0,  Quantity=3 },
    new Movie { Title="Cars",                      Genre=Genre.Comedy,  Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2006,6,9),   Length=TimeSpan.FromMinutes(117), AgeRestriction=0,  Quantity=4 },
    new Movie { Title="The Incredibles",           Genre=Genre.Comedy,  Language=Language.English, IsAvailable=true,  ReleaseDate=new DateTime(2004,11,5),  Length=TimeSpan.FromMinutes(115), AgeRestriction=0,  Quantity=5 }
            };

            foreach (var m in moviesToAdd)
                if (!context.Movies.Any(x => x.Title == m.Title))
                    context.Movies.Add(m);

            context.SaveChanges();

            var titleToId = context.Movies.ToDictionary(m => m.Title, m => m.Id.ToString());

            var castsToAdd = new List<Cast>
{
    new Cast { MovieId = titleToId["Inception"],               Name="Leonardo DiCaprio",        Part=Part.Actor },
    new Cast { MovieId = titleToId["Inception"],               Name="Christopher Nolan",        Part=Part.Director },
    new Cast { MovieId = titleToId["The Dark Knight"],         Name="Christian Bale",           Part=Part.Actor },
    new Cast { MovieId = titleToId["The Dark Knight"],         Name="Christopher Nolan",        Part=Part.Director },
    new Cast { MovieId = titleToId["Parasite"],                Name="Song Kang-ho",             Part=Part.Actor },
    new Cast { MovieId = titleToId["Parasite"],                Name="Bong Joon-ho",             Part=Part.Director },
    new Cast { MovieId = titleToId["Interstellar"],            Name="Matthew McConaughey",      Part=Part.Actor },
    new Cast { MovieId = titleToId["Interstellar"],            Name="Christopher Nolan",        Part=Part.Director },
    new Cast { MovieId = titleToId["Joker"],                   Name="Joaquin Phoenix",          Part=Part.Actor },
    new Cast { MovieId = titleToId["Joker"],                   Name="Todd Phillips",            Part=Part.Director },
    new Cast { MovieId = titleToId["Get Out"],                 Name="Daniel Kaluuya",           Part=Part.Actor },
    new Cast { MovieId = titleToId["Get Out"],                 Name="Jordan Peele",             Part=Part.Director },
    new Cast { MovieId = titleToId["The Matrix"],              Name="Keanu Reeves",             Part=Part.Actor },
    new Cast { MovieId = titleToId["The Matrix"],              Name="Lana Wachowski",           Part=Part.Director },
    new Cast { MovieId = titleToId["Gladiator"],               Name="Russell Crowe",            Part=Part.Actor },
    new Cast { MovieId = titleToId["Gladiator"],               Name="Ridley Scott",             Part=Part.Director },
    new Cast { MovieId = titleToId["The Godfather"],           Name="Al Pacino",                Part=Part.Actor },
    new Cast { MovieId = titleToId["The Godfather"],           Name="Francis Ford Coppola",     Part=Part.Director },
    new Cast { MovieId = titleToId["Pulp Fiction"],            Name="John Travolta",            Part=Part.Actor },
    new Cast { MovieId = titleToId["Pulp Fiction"],            Name="Quentin Tarantino",        Part=Part.Director },
    new Cast { MovieId = titleToId["Forrest Gump"],            Name="Tom Hanks",                Part=Part.Actor },
    new Cast { MovieId = titleToId["Forrest Gump"],            Name="Robert Zemeckis",          Part=Part.Director },
    new Cast { MovieId = titleToId["Fight Club"],              Name="Brad Pitt",                Part=Part.Actor },
    new Cast { MovieId = titleToId["Fight Club"],              Name="David Fincher",            Part=Part.Director },
    new Cast { MovieId = titleToId["The Shawshank Redemption"],Name="Tim Robbins",              Part=Part.Actor },
    new Cast { MovieId = titleToId["The Shawshank Redemption"],Name="Frank Darabont",           Part=Part.Director },
    new Cast { MovieId = titleToId["Avengers: Endgame"],       Name="Robert Downey Jr.",        Part=Part.Actor },
    new Cast { MovieId = titleToId["Avengers: Endgame"],       Name="Anthony Russo",            Part=Part.Director },
    new Cast { MovieId = titleToId["Spider-Man: No Way Home"], Name="Tom Holland",              Part=Part.Actor },
    new Cast { MovieId = titleToId["Spider-Man: No Way Home"], Name="Jon Watts",                Part=Part.Director }
};

            foreach (var c in castsToAdd)
                if (!context.Casts.Any(x => x.MovieId == c.MovieId && x.Name == c.Name && x.Part == c.Part))
                    context.Casts.Add(c);

            context.SaveChanges();

            var newlyAddedMovies = context.Movies.Where(m => m.Quantity <= 0 && m.IsAvailable).ToList();
            if (newlyAddedMovies.Any())
            {
                foreach (var m in newlyAddedMovies)
                    m.IsAvailable = false;
                context.SaveChanges();
            }
        }
    }
}

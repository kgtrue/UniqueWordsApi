using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UniqueWordsApi.WordServices;
using UniqueWordsApi.Models;
using Microsoft.AspNetCore.Builder;
using System;

namespace UniqueWordsApi.DatabaseSeeding
{
    public static class PrepDB
    {
        public static void PrepTestData(IServiceProvider sp)
        {
            using (var scope = sp.CreateScope())
            {
                SeedTestData(scope.ServiceProvider.GetService<WordStoreDBContext>());
            }

        }

        public static void SeedTestData(WordStoreDBContext context)
        {
            System.Console.WriteLine("Running Migrations...");
            context.Database.Migrate();

            if (!context.WatchlistWords.Any())
            {
                context.WatchlistWords.AddRange(
                    new WatchlistWord() { Word = "cat" },
                    new WatchlistWord() { Word = "a" },
                    new WatchlistWord() { Word = "bee" },
                    new WatchlistWord() { Word = "ball" },
                    new WatchlistWord() { Word = "human" },
                    new WatchlistWord() { Word = "menneske" },
                    new WatchlistWord() { Word = "bi" },
                    new WatchlistWord() { Word = "Robot" },
                    new WatchlistWord() { Word = "kat" },
                    new WatchlistWord() { Word = "lille" },
                    new WatchlistWord() { Word = "penge" },
                    new WatchlistWord() { Word = "bus" },
                    new WatchlistWord() { Word = "hjælp" },
                    new WatchlistWord() { Word = "øneske" },
                    new WatchlistWord() { Word = "æsel" },
                    new WatchlistWord() { Word = "гчццыысчч" },
                    new WatchlistWord() { Word = "ыагйц" }
                    );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Database table WatchlistWords already has data...");
            }

            if (!context.RecordedWords.Any())
            {
                context.RecordedWords.AddRange(
                    new RecordedWord() { Word = "cat" },
                    new RecordedWord() { Word = "a" },
                    new RecordedWord() { Word = "bee" },
                    new RecordedWord() { Word = "ball" },
                    new RecordedWord() { Word = "human" },
                    new RecordedWord() { Word = "menneske" },
                    new RecordedWord() { Word = "bi" },
                    new RecordedWord() { Word = "Robot" },
                    new RecordedWord() { Word = "kat" },
                    new RecordedWord() { Word = "lille" },
                    new RecordedWord() { Word = "penge" },
                    new RecordedWord() { Word = "bus" },
                    new RecordedWord() { Word = "hjælp" },
                    new RecordedWord() { Word = "øneske" },
                    new RecordedWord() { Word = "æsel" },
                    new RecordedWord() { Word = "гчццыысчч" },
                    new RecordedWord() { Word = "ыагйц" }
                    );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Database table RecordedWords already has data...");
            }
        }
    }
}

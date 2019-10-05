using Microsoft.EntityFrameworkCore;
using UniqueWordsApi.Models;

namespace UniqueWordsApi.WordServices
{
    public class WordStoreDBContext : DbContext
    {
        public WordStoreDBContext(DbContextOptions<WordStoreDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecordedWord>()
                .HasIndex(b => b.Word).IsUnique();

            modelBuilder.Entity<WatchlistWord>()
               .HasIndex(b => b.Word).IsUnique();
        }

        public DbSet<RecordedWord> RecordedWords { get; set; }
        public DbSet<WatchlistWord> WatchlistWords { get; set; }
    }
}

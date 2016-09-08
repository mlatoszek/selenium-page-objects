using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageObjectsInSelenium.Sources;

namespace PageObjectsInSelenium
{
    class SearchDataDbContext : DbContext
    {
        public SearchDataDbContext() : base(ConfigurationManager.ConnectionStrings["SearchContext"].ConnectionString)
        {
            Database.SetInitializer<SearchDataDbContext>(null);
        }

        public DbSet<SearchData> SearchData { get; set; }

        public DbSet<Names> Names { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SearchDataMap());
        }

        public class SearchDataMap : EntityTypeConfiguration<SearchData>
        {
            public SearchDataMap()
            {
                this.ToTable("SearchData");
                this.HasKey(x => x.Id);
                this.Property(x => x.SearchTerm).IsRequired().HasMaxLength(100).HasColumnName("Search");
                this.Property(x => x.Result).IsRequired().HasMaxLength(100).HasColumnName("ResultToFind");
            }
        }

        public class NamesMap : EntityTypeConfiguration<Names>
        {
            public NamesMap()
            {
                this.ToTable("Names");
                this.HasKey(x => x.Id);
                this.Property(x => x.Name).IsRequired().HasMaxLength(100).HasColumnName("Name");
            }
        }
    }
}

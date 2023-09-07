using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using Models;

namespace DataAccess
{
    public class ChinookContext: DbContext
    {
        public ChinookContext() : base("ChinookCnx")
        {
            Database.SetInitializer<ChinookContext>(null);
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<Artist> Artist { get; set; }

        public virtual DbSet<Playlist> Playlist { get; set; }

        public virtual DbSet<Album> Album { get; set; }

        public virtual DbSet<Track> Track { get; set; }

        
    }
}

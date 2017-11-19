using DatabaseLayer.Mapping;
using Microsoft.AspNet.Identity.EntityFramework;
using Models;
using System.Data.Entity;

namespace DatabaseLayer
{
    public class BaseContext : IdentityDbContext<ApplicationUser>
    {
        private const string DefaultConnection = "DefaultConnection";
        public BaseContext() : base(DefaultConnection)
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SubscriberMap());

            Database.SetInitializer<BaseContext>(null);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().Property(p => p.Id).HasColumnName("Id");
            modelBuilder.Entity<ApplicationUser>().Property(p => p.Id).HasColumnName("Id");
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityUserClaim>().HasKey<int>(r => r.Id);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);

        }
    }
}

using Microsoft.EntityFrameworkCore;
using PermissionManagement.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PermissionManagement.Model.Context
{
    public class PermissionContext : DbContext
    {
        public DbSet<Permission> Permission { get; set; }
        public DbSet<PermissionType> PermissionType { get; set; }
        public PermissionContext(DbContextOptions options) : base(options)
        {
        }
        public PermissionContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Permission>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<PermissionType>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<PermissionType>().HasData(
                new PermissionType { Id = 1, Description = "Enfermedad", CreatedDate = DateTime.Now },
                new PermissionType { Id = 2, Description = "Diligencias", CreatedDate = DateTime.Now },
                new PermissionType { Id = 3, Description = "Otro", CreatedDate = DateTime.Now });

            base.OnModelCreating(modelBuilder);
        }
        
        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Get the entries that are auditable
            var entries = ChangeTracker.Entries<IAuditEntity>();

            if (entries == null)
                return  await base.SaveChangesAsync(cancellationToken);

            var userId = Guid.NewGuid().ToString();
            var currentDate = DateTime.Now;

            var validStates = new HashSet<EntityState> { EntityState.Added, EntityState.Modified, EntityState.Deleted };
            var entriesFiltered = entries.Where(x => validStates.Contains(x.State));

            foreach (var entry in entriesFiltered)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = currentDate;
                        entry.Entity.CreatedBy = userId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = currentDate;
                        entry.Entity.UpdatedBy = userId;
                        break;
                    case EntityState.Deleted:
                        ((ISoftDeleteEntity)entry.Entity).IsDeleted = true;
                        entry.State = EntityState.Modified;
                        break;
                    default:
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace TechAppointmentApp.Data
{
    public class TechAppointmentAppDbContext : DbContext
    {
        public TechAppointmentAppDbContext() { }

        public TechAppointmentAppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.Property(e => e.UserRole).HasMaxLength(255).HasConversion<string>();

                entity.Property(e => e.InsertedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.ModifiedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

                entity.HasIndex(e => e.Email, "IX_Users_Email").IsUnique();
                entity.HasIndex(e => e.Username, "IX_Users_Username").IsUnique();
                entity.HasIndex(e => e.PhoneNumber, "IX_Users_Phonenumber").IsUnique();
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers");

                entity.Property(e => e.InsertedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.ModifiedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

                entity.HasIndex(e => e.UserId, "IX_Customer_UserId").IsUnique();
            });

            modelBuilder.Entity<Technician>(entity =>
            {
                entity.ToTable("Technicians");

                entity.Property(e => e.InsertedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.ModifiedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETDATE()");

                entity.HasIndex(e => e.UserId, "IX_Technician_UserId").IsUnique();
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Services");

                entity.HasIndex(e => e.ServiceName, "IX_Services_ServiceName");
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("Areas");

                entity.HasIndex(e => e.AreaName, "IX_Areas_AreaName");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointments");

                entity.HasIndex(e => e.AppointmentDate, "IX_Appointments_AppointmentDate");

                entity.HasOne(a => a.Customer)
                .WithMany(c => c.Appointments)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(a => a.Technician)
                .WithMany(t => t.Appointments)
                .HasForeignKey(a => a.TechnicianId)
                .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}

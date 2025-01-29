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
        public DbSet<Appointment> Appointments { get; set; }

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
                entity.HasIndex(e => e.UserRole, "IX_Users_UserRole").IsUnique();
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

                //entity.HasOne(c => c.Area).WithMany(a => a.Customers).HasForeignKey(c => c.AreadId).OnDelete(DeleteBehavior.NoAction);
                //entity.HasOne(c => c.Service).WithMany(s => s.Customers).HasForeignKey(c => c.ServiceId).OnDelete(DeleteBehavior.NoAction);
                //entity.HasOne(c => c.User).WithOne(u => u.Customer).HasForeignKey<Customer>(c => c.UserId).OnDelete(DeleteBehavior.Cascade);
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

                //entity.HasOne(t => t.Area).WithMany(a => a.Technicians).HasForeignKey(t => t.AreaId).OnDelete(DeleteBehavior.NoAction);
                //entity.HasOne(t => t.Service).WithMany(s => s.Technicians).HasForeignKey(t => t.ServiceId).OnDelete(DeleteBehavior.NoAction);
                //entity.HasOne(t => t.User).WithOne(u => u.Technician).HasForeignKey<Technician>(t => t.UserId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Services");
                entity.Property(e => e.UserService)
                .HasConversion<string>();

                entity.HasIndex(e => e.UserService, "IX_Services_UserServices");
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("Areas");

                entity.HasIndex(e => e.AreaName, "IX_Areas_AreaName");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointments");
                entity.Property(e => e.Status)
                .HasConversion<string>();

                entity.HasIndex(e => e.AppointmentDate, "IX_Appointments_AppointmentDate");
                entity.HasIndex(e => e.Status, "IX_Appointments_AppointmentStatus");

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

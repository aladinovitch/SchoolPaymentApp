using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolPayment.Models;

namespace SchoolPayment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public DbSet<Animation> Animations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().ToTable("Student", "SchoolPayment")
                .HasKey(k => new { k.Id })
                .HasName("PK_Student");

            modelBuilder.Entity<Student>().ToTable("Student", "SchoolPayment")
                .HasMany(x => x.StudentDeposits).WithOne(x => x.Student).HasForeignKey(x => new { x.StudentId });
            modelBuilder.Entity<Student>().ToTable("Student", "SchoolPayment")
                .HasMany(x => x.StudentParticipations).WithOne(x => x.Student).HasForeignKey(x => new { x.StudentId });

            modelBuilder.Entity<Teacher>().ToTable("Teacher", "SchoolPayment")
                .HasKey(k => new { k.Id })
                .HasName("PK_Teacher");

            modelBuilder.Entity<Teacher>().ToTable("Teacher", "SchoolPayment")
                .HasMany(x => x.TeacherPayments).WithOne(x => x.Teacher).HasForeignKey(x => new { x.TeacherId });
            modelBuilder.Entity<Teacher>().ToTable("Teacher", "SchoolPayment")
                .HasMany(x => x.TeacherAnimations).WithOne(x => x.Teacher).HasForeignKey(x => new { x.TeacherId });

            modelBuilder.Entity<Deposit>().ToTable("Deposit", "SchoolPayment")
                .HasKey(k => new { k.Id })
                .HasName("PK_Deposit");

            modelBuilder.Entity<Payment>().ToTable("Payment", "SchoolPayment")
                .HasKey(k => new { k.Id })
                .HasName("PK_Payment");

            modelBuilder.Entity<Session>().ToTable("Session", "SchoolPayment")
                .HasKey(k => new { k.Id })
                .HasName("PK_Session");

            modelBuilder.Entity<Session>().ToTable("Session", "SchoolPayment")
                .HasMany(x => x.SessionParticipations).WithOne(x => x.Session).HasForeignKey(x => new { x.SessionId });
            modelBuilder.Entity<Session>().ToTable("Session", "SchoolPayment")
                .HasMany(x => x.SessionAnimations).WithOne(x => x.Session).HasForeignKey(x => new { x.SessionId });

            modelBuilder.Entity<Module>().ToTable("Module", "SchoolPayment")
                .HasKey(k => new { k.Id })
                .HasName("PK_Module");

            modelBuilder.Entity<Module>().ToTable("Module", "SchoolPayment")
                .HasMany(x => x.ModuleSessions).WithOne(x => x.Module).HasForeignKey(x => new { x.ModuleId });

            modelBuilder.Entity<Participation>().ToTable("Participation", "SchoolPayment")
                .HasKey(k => new { k.Id })
                .HasName("PK_Participation");

            modelBuilder.Entity<Animation>().ToTable("Animation", "SchoolPayment")
                .HasKey(k => new { k.Id })
                .HasName("PK_Animation");
            SeedUsers(modelBuilder);
            SeedData(modelBuilder);
        }
        private static void SeedUsers(ModelBuilder modelBuilder) {
            string MANAGER_ID = Guid.NewGuid().ToString();
            string BASIC_ID = Guid.NewGuid().ToString();
            var passwordHasher = new PasswordHasher<IdentityUser>();
            // Manager
            var managerName = "manager@email.com";
            var manager = new IdentityUser {
                Id = MANAGER_ID, // Primary key
                Email = managerName,
                NormalizedEmail = managerName.ToUpper(),
                UserName = managerName,
                NormalizedUserName = managerName.ToUpper(),
                EmailConfirmed = true,
            };
            manager.PasswordHash = passwordHasher.HashPassword(manager, "Pass_12345");

            // Basic user
            var basicname = "basic@email.com";
            var basic = new IdentityUser {
                Id = BASIC_ID, // Primary key
                Email = basicname,
                NormalizedEmail = basicname.ToUpper(),
                UserName = basicname,
                NormalizedUserName = basicname.ToUpper(),
                EmailConfirmed = true,
            };
            basic.PasswordHash = passwordHasher.HashPassword(basic, "Pass_12345");
            // Seeding the User to AspNetUsers table
            modelBuilder.Entity<IdentityUser>().HasData(manager, basic);

            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(
                new IdentityUserClaim<string> { Id = 1, UserId = MANAGER_ID, ClaimType = AppClaimType.Manage, ClaimValue = "true" },
                new IdentityUserClaim<string> { Id = 2, UserId = BASIC_ID, ClaimType = AppClaimType.Basic, ClaimValue = "true" });
        }
        private static void SeedData(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Number = "2020/26/001", Fname = "Hicham", Lname = "Bouhachemi", Birthdate = DateTime.Parse("2000-01-01"), Registration = DateTime.Parse("2020-12-01"), Discount = 0f },
                new Student { Id = 2, Number = "2020/26/002", Fname = "Youcef", Lname = "Benyoucef", Birthdate = DateTime.Parse("2000-01-02"), Registration = DateTime.Parse("2020-12-02"), Discount = 0.05f },
                new Student { Id = 3, Number = "2020/26/003", Fname = "Abdelkader", Lname = "Boukadir", Birthdate = DateTime.Parse("2000-01-03"), Registration = DateTime.Parse("2020-12-03"), Discount = 0.1f },
                new Student { Id = 4, Number = "2020/26/004", Fname = "Yousra", Lname = "Yassira", Birthdate = DateTime.Parse("2000-01-04"), Registration = DateTime.Parse("2020-12-04"), Discount = 0.15f },
                new Student { Id = 5, Number = "2020/26/005", Fname = "Bouchra", Lname = "Benbacha", Birthdate = DateTime.Parse("2000-01-05"), Registration = DateTime.Parse("2020-12-05"), Discount = 0.2f },
                new Student { Id = 6, Number = "2020/26/004", Fname = "Amina", Lname = "Benamina", Birthdate = DateTime.Parse("2000-01-06"), Registration = DateTime.Parse("2020-12-06"), Discount = 0.25f });
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = 1, Number = "E001", Fname = "Amer", Lname = "Benamer", Birthdate = DateTime.Parse("1981-01-01") },
                new Teacher { Id = 2, Number = "E002", Fname = "Ilham", Lname = "Benilham", Birthdate = DateTime.Parse("1982-02-02") },
                new Teacher { Id = 3, Number = "E003", Fname = "Ismail", Lname = "Bousmail", Birthdate = DateTime.Parse("1983-03-03") });
            modelBuilder.Entity<Module>().HasData(
                new Module { Id = 1, Name = "English : Introductory Course" },
                new Module { Id = 2, Name = "Français : Terminale littéraire" },
                new Module { Id = 3, Name = "Math : Third year midschool" },
                new Module { Id = 4, Name = "Physics : Final year scientific " });
            modelBuilder.Entity<Session>().HasData(
                new Session { Id = 1, Date = DateTime.Parse("2021-01-01"), Number = 1, ModuleId = 1 },
                new Session { Id = 2, Date = DateTime.Parse("2021-01-08"), Number = 2, ModuleId = 1 },
                new Session { Id = 3, Date = DateTime.Parse("2021-01-15"), Number = 3, ModuleId = 1 },
                new Session { Id = 4, Date = DateTime.Parse("2021-01-02"), Number = 1, ModuleId = 2 },
                new Session { Id = 5, Date = DateTime.Parse("2021-01-09"), Number = 2, ModuleId = 2 },
                new Session { Id = 6, Date = DateTime.Parse("2021-01-16"), Number = 3, ModuleId = 2 },
                new Session { Id = 7, Date = DateTime.Parse("2021-01-03"), Number = 1, ModuleId = 3 },
                new Session { Id = 8, Date = DateTime.Parse("2021-01-10"), Number = 2, ModuleId = 3 },
                new Session { Id = 9, Date = DateTime.Parse("2021-01-17"), Number = 3, ModuleId = 3 },
                new Session { Id = 10, Date = DateTime.Parse("2021-01-04"), Number = 1, ModuleId = 4 },
                new Session { Id = 11, Date = DateTime.Parse("2021-01-11"), Number = 2, ModuleId = 4 },
                new Session { Id = 12, Date = DateTime.Parse("2021-01-18"), Number = 3, ModuleId = 4 });
            modelBuilder.Entity<Deposit>().HasData(
                new Deposit { Id = 1, Date = DateTime.Parse("2021-02-01"), Amount = 1000, StudentId = 1 },
                new Deposit { Id = 2, Date = DateTime.Parse("2021-03-01"), Amount = 950, StudentId = 1 },
                new Deposit { Id = 3, Date = DateTime.Parse("2021-02-01"), Amount = 2000, StudentId = 2 },
                new Deposit { Id = 4, Date = DateTime.Parse("2021-03-01"), Amount = 1950, StudentId = 2 },
                new Deposit { Id = 5, Date = DateTime.Parse("2021-04-01"), Amount = 1900, StudentId = 2 },
                new Deposit { Id = 6, Date = DateTime.Parse("2021-02-01"), Amount = 3000, StudentId = 3 },
                new Deposit { Id = 7, Date = DateTime.Parse("2021-03-01"), Amount = 2900, StudentId = 3 },
                new Deposit { Id = 8, Date = DateTime.Parse("2021-04-01"), Amount = 2800, StudentId = 3 },
                new Deposit { Id = 9, Date = DateTime.Parse("2021-05-01"), Amount = 2700, StudentId = 3 });
            modelBuilder.Entity<Payment>().HasData(
                new Payment { Id = 1, Date = DateTime.Parse("2021-02-01"), Amount = 15000, TeacherId = 1 },
                new Payment { Id = 2, Date = DateTime.Parse("2021-03-01"), Amount = 17000, TeacherId = 1 },
                new Payment { Id = 3, Date = DateTime.Parse("2021-04-01"), Amount = 19000, TeacherId = 1 },
                new Payment { Id = 4, Date = DateTime.Parse("2021-02-01"), Amount = 25000, TeacherId = 2 },
                new Payment { Id = 5, Date = DateTime.Parse("2021-03-01"), Amount = 27000, TeacherId = 2 },
                new Payment { Id = 6, Date = DateTime.Parse("2021-04-01"), Amount = 29000, TeacherId = 2 },
                new Payment { Id = 7, Date = DateTime.Parse("2021-02-01"), Amount = 30000, TeacherId = 3 },
                new Payment { Id = 8, Date = DateTime.Parse("2021-03-01"), Amount = 32000, TeacherId = 3 },
                new Payment { Id = 9, Date = DateTime.Parse("2021-04-01"), Amount = 35000, TeacherId = 3 });
            modelBuilder.Entity<Animation>().HasData(
                new Animation { Id = 1, Attendance = true, TeacherId = 1, SessionId = 1 },
                new Animation { Id = 2, Attendance = true, TeacherId = 1, SessionId = 2 },
                new Animation { Id = 3, Attendance = false, Observation = "Meeting to discuss progress", TeacherId = 1, SessionId = 3 },
                new Animation { Id = 4, Attendance = true, TeacherId = 1, SessionId = 1 },
                new Animation { Id = 5, Attendance = false, Observation = "Long weekend", TeacherId = 1, SessionId = 2 },
                new Animation { Id = 6, Attendance = true, TeacherId = 1, SessionId = 3 },
                new Animation { Id = 7, Attendance = true, TeacherId = 3, SessionId = 1 },
                new Animation { Id = 8, Attendance = true, TeacherId = 3, SessionId = 2 });
            modelBuilder.Entity<Participation>().HasData(
                new Participation { Id = 1, Attendance = true, StudentId = 1, SessionId = 1 },
                new Participation { Id = 2, Attendance = true, StudentId = 1, SessionId = 2 },
                new Participation { Id = 3, Attendance = true, StudentId = 1, SessionId = 3 },
                new Participation { Id = 4, Attendance = false, Observation = "Study for exams", StudentId = 1, SessionId = 4 },
                new Participation { Id = 5, Attendance = true, StudentId = 2, SessionId = 1 },
                new Participation { Id = 6, Attendance = true, StudentId = 2, SessionId = 2 },
                new Participation { Id = 7, Attendance = true, StudentId = 2, SessionId = 3 },
                new Participation { Id = 8, Attendance = true, StudentId = 2, SessionId = 4 },
                new Participation { Id = 9, Attendance = true, StudentId = 3, SessionId = 1 },
                new Participation { Id = 10, Attendance = true, StudentId = 3, SessionId = 2 },
                new Participation { Id = 11, Attendance = false, Observation = "Abandon", StudentId = 3, SessionId = 3 },
                new Participation { Id = 12, Attendance = false, Observation = "Abandon", StudentId = 3, SessionId = 4 },
                new Participation { Id = 13, Attendance = true, StudentId = 4, SessionId = 1 },
                new Participation { Id = 14, Attendance = true, StudentId = 4, SessionId = 2 },
                new Participation { Id = 15, Attendance = true, StudentId = 4, SessionId = 3 },
                new Participation { Id = 16, Attendance = true, StudentId = 4, SessionId = 4 });
        }
    }
}

using BharathSchool.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BharathSchool.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Core domain
        public DbSet<Standard> Standards { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }

        // Teaching / staff
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        // Other domain tables
        public DbSet<ClassStrength> ClassStrengths { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<BusRoute> BusRoutes { get; set; }
        public DbSet<BusStop> BusStops { get; set; }
        public DbSet<AdmissionRequest> AdmissionRequests { get; set; }
        public DbSet<AdmissionFile> AdmissionFiles { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<SiteSetting> SiteSettings { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Table naming
            builder.Entity<Standard>().ToTable("Standards");
            builder.Entity<Section>().ToTable("Sections");
            builder.Entity<Subject>().ToTable("Subjects");
            builder.Entity<Student>().ToTable("Students");
            builder.Entity<Teacher>().ToTable("Teachers");
            builder.Entity<TeacherSubject>().ToTable("TeacherSubjects");
            builder.Entity<Staff>().ToTable("Staff");
            builder.Entity<ClassStrength>().ToTable("ClassStrength");
            builder.Entity<Achievement>().ToTable("Achievements");
            builder.Entity<Coach>().ToTable("Coaches");
            builder.Entity<Sport>().ToTable("Sports");
            builder.Entity<Activity>().ToTable("Activities");
            builder.Entity<Media>().ToTable("Media");
            builder.Entity<Fee>().ToTable("Fees");
            builder.Entity<BusRoute>().ToTable("BusRoutes");
            builder.Entity<BusStop>().ToTable("BusStops");
            builder.Entity<AdmissionRequest>().ToTable("AdmissionRequests");
            builder.Entity<AdmissionFile>().ToTable("AdmissionFiles");
            builder.Entity<Leave>().ToTable("Leaves");
            builder.Entity<SiteSetting>().ToTable("SiteSettings");
            builder.Entity<AuditLog>().ToTable("AuditLogs");

            // Relationships
            builder.Entity<Section>()
                .HasOne(s => s.Standard)
                .WithMany(st => st.Sections)
                .HasForeignKey(s => s.StandardId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Student>()
                .HasOne(s => s.Standard)
                .WithMany()
                .HasForeignKey(s => s.StandardId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Student>()
                .HasOne(s => s.Section)
                .WithMany(sec => sec.Students)
                .HasForeignKey(s => s.SectionId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<TeacherSubject>()
                .HasOne(ts => ts.Teacher)
                .WithMany(t => t.TeacherSubjects)
                .HasForeignKey(ts => ts.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<TeacherSubject>()
                .HasOne(ts => ts.Subject)
                .WithMany()
                .HasForeignKey(ts => ts.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<TeacherSubject>()
                .HasOne(ts => ts.Standard)
                .WithMany()
                .HasForeignKey(ts => ts.StandardId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Media>()
                .HasOne(m => m.Activity)
                .WithMany(a => a.MediaItems)
                .HasForeignKey(m => m.ActivityId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Achievement>()
                .HasOne(a => a.Student)
                .WithMany()
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Sport>()
                .HasOne(s => s.Coach)
                .WithMany(c => c.Sports)
                .HasForeignKey(s => s.CoachId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Fee>()
                .HasOne(f => f.Standard)
                .WithMany()
                .HasForeignKey(f => f.StandardId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<BusStop>()
                .HasOne(bs => bs.BusRoute)
                .WithMany(br => br.BusStops)
                .HasForeignKey(bs => bs.BusRouteId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AdmissionFile>()
                .HasOne(af => af.AdmissionRequest)
                .WithMany(ar => ar.Files)
                .HasForeignKey(af => af.AdmissionRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ClassStrength>()
                .HasOne(cs => cs.Standard)
                .WithMany()
                .HasForeignKey(cs => cs.StandardId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ClassStrength>()
                .HasOne(cs => cs.Section)
                .WithMany()
                .HasForeignKey(cs => cs.SectionId)
                .OnDelete(DeleteBehavior.SetNull);

            // Indexes
            builder.Entity<Student>()
                .HasIndex(s => s.ParentContact);

            builder.Entity<Standard>()
                .HasIndex(s => s.Name);

            builder.Entity<Activity>()
                .HasIndex(a => a.ActivityDate);

            builder.Entity<Leave>()
                .HasIndex(l => l.UserId);

            builder.Entity<AuditLog>()
                .HasIndex(al => al.Timestamp);
        }
    }
}


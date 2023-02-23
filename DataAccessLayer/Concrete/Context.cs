using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    // 2 tane Identity paketi yuklendi
    // IdentityDbContex miras alındı.
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AspNetCoreKampDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Team ve Match sınıfı arasındaki ilişkiyi belirler
            modelBuilder.Entity<Match>().HasOne(x => x.HomeTeam).WithMany(y => y.HomeMatches).HasForeignKey(z => z.HomeTeamId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Match>().HasOne(x => x.GuestTeam).WithMany(y => y.AwayMatches)
                .HasForeignKey(z => z.GuestTeamId).OnDelete(DeleteBehavior.ClientSetNull);




            //MessageTwo ve Author sınıfı arasındaki ilişkiyi belirler.
            modelBuilder.Entity<MessageTwo>().HasOne(x => x.SenderUser).WithMany(y => y.AuthorSender)
                .HasForeignKey(z => z.SenderId).OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<MessageTwo>().HasOne(x => x.ReceiverUser).WithMany(z => z.AuthorReceiver)
                .HasForeignKey(y => y.ReceiverId).OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);

        }




        public DbSet<About> Abouts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogRayting> BlogRaytings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MessageTwo> MessageTwos { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}

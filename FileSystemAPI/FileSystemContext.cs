using Microsoft.EntityFrameworkCore;

namespace FileSystemAPI
{
    public class FileSystemContext : DbContext
    {
        static readonly string connectionString = "Server=tcp:alexb-filesystem.database.windows.net,1433;Initial Catalog=filesystem_db;Persist Security Info=False;User ID=alexb;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public DbSet<Models.Data.DirectoryModel> Directories { get; set; }
        public DbSet<Models.Data.FileModel> Files { get; set; }
        public DbSet<Models.Data.UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}

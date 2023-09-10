using FileSystem.Models.Enums;

namespace FileSystemAPI.Models.Data
{
    public class DirectoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int? ParentId { get; set; }
        public int? AuthorId { get; set; }
        //public long Size { get; set; }
        //public User User { get; set; }
        //public List<Permission> Permissions { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public DateTime ModifiedDate { get; set; }
    }
}

namespace FileSystemAPI.Models.Data
{
    public class FileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int ParentId { get; set; }
        public string Extension { get; set; }
        public string? FileContent { get; set; }
        public int? AuthorId { get; set; }
    }
}

namespace FileSystemAPI.Models
{
    public class Directory : FsEntry
    {
        public List<FsEntry> Children { get; set; }
    }
}

using FileSystem.Models.Enums;

namespace FileSystemAPI.Models
{
    public class File : FsEntry
    {
        public string Extension { get; set; } // file type
    }
}

using System.ComponentModel.DataAnnotations;

namespace ObsiLite_Backend.models
{
    public class Folder
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OwnerId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Folder> ChildrenFolders { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
namespace ObsiLite_Backend.models
{ 
    public class Note
    {
        [Key]
		public int Id { get; set; }
        [Required]
        public int OwnerId { get; set; }
        [Required, NotNull]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(200)]
        public string Body { get; set; }

        public virtual ICollection<Note> References { get; set; }

        public Note(int id, int ownerId, string title, string body)
        {
            Id = id; 
            OwnerId = ownerId; 
            Title = title; 
            Body = body;
        }
	}
}

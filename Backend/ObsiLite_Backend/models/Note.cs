using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
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

        [JsonConstructorAttribute]
        public Note(int id, int ownerId, string title, string body)
        {
            Id = id; 
            OwnerId = ownerId; 
            Title = title; 
            Body = body;
            References = new List<Note>();
        }
        //used for creating new notes
        public Note(int ownerId, string title, string body)
        {
            Id = 0;
            OwnerId = ownerId;
            Title = title;
            Body = body;
        }
	}
}

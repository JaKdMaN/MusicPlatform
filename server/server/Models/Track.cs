using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class Track
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Artist { get; set; }

        public string? Text { get; set; }

        public int? Listens { get; set; }

        public string? Picture { get; set; }

        public string? Audio { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}

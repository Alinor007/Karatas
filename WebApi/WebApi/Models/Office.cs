using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Office
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Stage { get; set; }
        public string Description { get; set; } = string.Empty;

        public DateTime Created { get; set; } = DateTime.UtcNow;

        public DateTime Updated { get; set; } = DateTime.UtcNow;
    }
}

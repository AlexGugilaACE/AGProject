using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGWADProject.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public DateTime PostedOn { get; set; } = DateTime.UtcNow;
        public int PersonId { get; set; }
        public Person? Person { get; set; }
        public int CarId { get; set; }
        public Car? Car { get; set; }
        public string? CoverPhotoPath { get; set; }
        public string? PhoneNumber { get; set; }
    }
}

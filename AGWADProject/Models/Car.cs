using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGWADProject.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public int? FuelTypeId { get; set; }
        public FuelType? FuelType { get; set; }
        public int? TractionTypeId { get; set; }
        public TractionType? TractionType { get; set; }
        public int? TransmissionTypeId { get; set; }
        public TransmissionType? TransmissionType { get; set; }
        public ICollection<Post>? Posts { get; set; }
    }
}

namespace AGWADProject.Models
{
    public class TractionType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Car>? Cars { get; set; }
    }
}

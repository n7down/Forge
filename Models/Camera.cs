namespace Forge.Models
{
    public class Camera
    {
        public long Id { get; set; }
        public string Name { get; set; }
		public bool IRBlock { get; set; }
        public bool Mic { get; set; }
		public int WeightInGrams { get; set; }
	}
}

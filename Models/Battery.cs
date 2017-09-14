namespace Forge.Models
{
    public class Battery
    {
        public long Id { get; set; }
        public string Name { get; set; }
		public string LipoVoltage { get; set; }
		public string MAh { get; set; }
		public int CRating { get; set; }
		public string PlugType { get; set; }
		public string Weight { get; set; }
		public string Dimension { get; set; }
	}
}

namespace Forge.Models 
{
	public class Receiver
	{
		public long Id { get; set; }
		public string Name { get; set; }	
		public int Weight { get; set; }
		public string InputVoltage { get; set; }
		public int Channels { get; set; }
		public bool Telemetry { get; set; }
	}
}

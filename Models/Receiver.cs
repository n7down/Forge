using MongoDB.Bson.Serialization.Attributes;

namespace Forge.Models 
{
	public class Receiver
	{
        [BsonId]
		public long Id { get; set; }
        [BsonElement("Name")]
		public string Name { get; set; }	
        [BsonElement("Weight")]
		public int Weight { get; set; }
        [BsonElement("InputVoltage")]
		public string InputVoltage { get; set; }
        [BsonElement("Channels")]
		public int Channels { get; set; }
        [BsonElement("Telemetry")]
		public bool Telemetry { get; set; }
	}
}

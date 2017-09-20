using MongoDB.Bson.Serialization.Attributes;

namespace Forge.Models
{
    public class Transmitter
    {
        [BsonId]
        public long Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Weight")]
		public int Weight { get; set; }
        [BsonElement("NumberChannels")]
		public int NumberChannels { get; set; }
        [BsonElement("Voltage")]
		public string Voltage { get; set; }
	}
}

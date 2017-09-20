using MongoDB.Bson.Serialization.Attributes;

namespace Forge.Models
{
    public class Motor
    {
        [BsonId]
        public long Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Model")]
        public string Model { get; set; }
        [BsonElement("Kv")]
        public string Kv { get; set; }
        [BsonElement("Weight")]
        public int Weight { get; set; }
        [BsonElement("LipoVoltage")]
        public string LipoVoltage { get; set; }
    }
}

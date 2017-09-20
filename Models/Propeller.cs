using MongoDB.Bson.Serialization.Attributes;

namespace Forge.Models
{
    public class Propeller
    {
        [BsonId]
        public long Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Diameter")]
        public int Diameter { get; set; }
        [BsonElement("Pitch")]
        public int Pitch { get; set; }
        [BsonElement("Blades")]
        public int Blades { get; set; }
        [BsonElement("Material")]
        public string Material { get; set; }
        [BsonElement("Shaft")]
        public int Shaft { get; set; }
    }
}

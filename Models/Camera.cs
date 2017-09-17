using MongoDB.Bson.Serialization.Attributes;

namespace Forge.Models
{
    public class Camera
    {
        [BsonId]
        public long Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("IRBlock")]
		public bool IRBlock { get; set; }
        [BsonElement("Mic")]
        public bool Mic { get; set; }
        [BsonElement("Weight")]
		public int Weight { get; set; }
	}
}

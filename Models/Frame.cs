using MongoDB.Bson.Serialization.Attributes;

namespace Forge.Models
{
    public class Frame
    {
        [BsonId]
	    public long Id { get; set; }
        [BsonElement("Name")]
    	public string Name { get; set; }
        [BsonElement("Weight")]
        public int Weight { get; set; }
    }
}

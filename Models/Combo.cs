namespace Forge.Models
{
    public class Combo
    {
        [BsonId]
        public long Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
    }
}
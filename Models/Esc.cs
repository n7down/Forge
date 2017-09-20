using MongoDB.Bson.Serialization.Attributes;

namespace Forge.Models
{
    public class Esc
    {
        [BsonId]
        public long Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Weight")]
        public float Weight { get; set; }        
        [BsonElement("MaxCurrent")]
        public int MaxCurrent { get; set; }
        [BsonElement("AllInOne")]
        public bool AllInOne { get; set; }
        [BsonElement("EscProtocol")]
        public string EscProtocol { get; set; }
        [BsonElement("LipoVoltage")]
        public string LipoVoltage { get; set; }
        
        // does this support BLHeli_S, BLHeli, or BLHeli_32
        [BsonElement("EscFirmware")]
        public string EscFirmware { get; set; }
        [BsonElement("Chip")]
        public string Chip { get; set; }
    }
}
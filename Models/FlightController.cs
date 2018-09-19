using MongoDB.Bson.Serialization.Attributes;

namespace Forge.Models
{
    public class FlightController
    {
        [BsonId]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("MCU")]
        public string MCU { get; set; }
        [BsonElement("GyroName")]
        public string GyroName { get; set; }
        [BsonElement("OSD")]
        public bool OSD { get; set; }
        [BsonElement("OSDName")]
        public string OSDName { get; set; }
        [BsonElement("PDB")]
        public bool PDB { get; set; }
        [BsonElement("LipoVoltage")]
        public string LipoVoltage { get; set; }
        [BsonElement("SDCard")]
        public bool SDCard { get; set; }

        // weight in grams
        [BsonElement("Weight")]
        public string Weight { get; set; }
        [BsonElement("NumberUARTS")]
        public int NumberUARTS { get; set; }
        [BsonElement("Barometer")]
        public bool Barometer { get; set; }
        [BsonElement("PWM")]
        public bool PWM { get; set; }
        [BsonElement("SBUS")]
        public bool SBUS { get; set; }
        [BsonElement("DSMTwo")]
        public bool DSMTwo { get; set; }
        [BsonElement("LedStrip")]
        public bool LedStrip { get; set; }
        [BsonElement("VideoIn")]
        public bool VideoIn { get; set; }
        [BsonElement("VideoOut")]
        public bool VideoOut { get; set; }
        [BsonElement("Buzzer")]
        public bool Buzzer { get; set; }
        [BsonElement("NumberSoftSerials")]
        public int NumberSoftSerials { get; set; }

        // TODO: add dimensions
    }
}

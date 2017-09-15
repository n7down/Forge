using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Forge.Models
{
    public class Battery
    {
		[BsonId]
        public long Id { get; set; }
		[BsonElement("Name")]
	    public string Name { get; set; }
		[BsonElement("LipoVoltage")]
		public string LipoVoltage { get; set; }
		[BsonElement("MAh")]
		public string MAh { get; set; }
		[BsonElement("CRating")]
		public int CRating { get; set; }
		[BsonElement("PlugType")]
		public string PlugType { get; set; }
		[BsonElement("Weight")]
		public string Weight { get; set; }
		[BsonElement("Dimension")]
		public string Dimension { get; set; }
	}
}

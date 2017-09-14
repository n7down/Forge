namespace Forge.Models
{
    public class Esc
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public float Weight { get; set; }
        public int MaxCurrent { get; set; }
        public bool AllInOne { get; set; }
        public EscProtocol[] EscProtocol { get; set; }
        public LipoVoltage LipoVoltage { get; set; }
        
        // does this support BLHeli_S, BLHeli, or BLHeli_32
        public EscFirmware EscFirmware { get; set; }
        public string Chip { get; set; }
    }
}
namespace Forge.Models
{
    public class Esc
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public float Weight { get; set; }
        public int MaxCurrent { get; set; }
        public bool AllInOne { get; set; }
        public string EscProtocol { get; set; }
        public string LipoVoltage { get; set; }
        
        // does this support BLHeli_S, BLHeli, or BLHeli_32
        public string EscFirmware { get; set; }
        public string Chip { get; set; }
    }
}
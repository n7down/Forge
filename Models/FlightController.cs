namespace Forge.Models
{
    public class FlightController
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string MCU { get; set; }
        public string GyroName { get; set; }
        public bool OSD { get; set; }
        public string OSDName { get; set; }
        public bool PDB { get; set; }
        public string LipoVoltage { get; set; }
        public bool SDCard { get; set; }

        // weight in grams
        public float Weight { get; set; }
        public int NumberUARTS { get; set; }
        public bool Barometer { get; set; }
        public bool PWM { get; set; }
        public bool SBUS { get; set; }
        public bool DSMTwo { get; set; }
        public bool LedStrip { get; set; }
        public bool VideoIn { get; set; }
        public bool VideoOut { get; set; }
        public bool Buzzer { get; set; }
        public int NumberSoftSerial { get; set; }
    }
}

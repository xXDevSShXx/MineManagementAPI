namespace MineManagementAPI.Models
{
    public class Log
    {
        public int LogId { get; set; }
        public string VId { get; set; } = string.Empty;
        public string UId { get; set; } = string.Empty;
        public double Lat { get; set; }
        public double Long { get; set; }
        public double Speed { get; set; }
        public int Direction { get; set; }
        public DateTime DeviceTime { get; set; }
        public DateTime ServerTime { get; set; }
    }
}

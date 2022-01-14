using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Models
{
    public class DeviceReading
    {
        [Name("Device ID")]
        public int DeviceId { get; set; }
        public DateTime Time { get; set; }
        public int Rainfall { get; set; }
    }
}

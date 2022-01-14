using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Models
{
    public class Device
    {
        [Name("Device ID")]
        public string DeviceId { get; set; }

        [Name("Device Name")]
        public string DeviceName { get; set; }
        public string Location { get; set; }
    }
}

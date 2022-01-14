using CodeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Utilities
{
    public static class DataProcessor
    {
        public static void ProcessRailfall(List<Device> devices, List<DeviceReading> deviceReadings)
        {
            var latestTime = deviceReadings.Max(d => d.Time);

            foreach (var device in devices)
            {
                int deviceId;
                var isParsed = int.TryParse(device.DeviceId, out deviceId);
                if (isParsed)
                {
                    var averageRainfall = Math.Round(deviceReadings.Where(d => d.DeviceId == deviceId && d.Time >= latestTime.AddHours(-4)).Average(d => d.Rainfall), 2);
                    string displayText = $"{device.Location} -> {device.DeviceName}({deviceId}) has recorded average rainfall of {averageRainfall}mm.";
                    if (averageRainfall > 10)
                    {
                        Console.WriteLine($"GREEN : { displayText}");
                    }
                    else if (averageRainfall > 15)
                    {
                        Console.WriteLine($"AMBER : { displayText}");

                    }
                    else
                    {
                        Console.WriteLine($"RED : { displayText}");

                    }
                }
            }
        }
    }
}

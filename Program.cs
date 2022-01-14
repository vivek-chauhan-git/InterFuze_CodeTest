using CodeTest.Models;
using CodeTest.Utilities;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Flood Detector");

            string dataDirectory = Environment.CurrentDirectory;

            var readDeviceTask  = CSVFileReader.Read<Device>(Path.Combine(Environment.CurrentDirectory, "Data", "Devices.csv"));
            var readData1Task = CSVFileReader.Read<DeviceReading>(Path.Combine(Environment.CurrentDirectory, "Data", "Data1.csv"));
            var readData2Task = CSVFileReader.Read<DeviceReading>(Path.Combine(Environment.CurrentDirectory, "Data", "Data2.csv"));

            Task.WhenAll(readDeviceTask, readData1Task, readData2Task);

            var devices = readDeviceTask.Result;
            var data1 = readData1Task.Result;
            var data2 = readData2Task.Result;
            if (devices == null || data1 == null || data2 == null)
            {
                Console.WriteLine("Something went wrong while reading data files. Please check error above.");
            }
            else
            {
                List<DeviceReading> deviceReading = new();
                deviceReading.AddRange(data1);
                deviceReading.AddRange(data2);

                DataProcessor.ProcessRailfall(devices, deviceReading);
            }
            Console.ReadLine();
        }
    }
}

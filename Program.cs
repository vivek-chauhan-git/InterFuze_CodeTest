using CodeTest.Models;
using CodeTest.Utilities;
using CsvHelper.Configuration;
using System;
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
            var data = readData1Task.Result;
            data.AddRange(readData2Task.Result);

            DataProcessor.ProcessRailfall(devices, data);
            Console.ReadLine();
        }
    }
}

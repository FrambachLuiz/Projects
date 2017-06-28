using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;


namespace DemoCode.Tests.Demo.DataDrivenTests
{
    class CsvTestData : DataAttribute
    {
        private readonly string _csvFileName;

        public CsvTestData( string csvFileName)
        {
            
            _csvFileName = !string.IsNullOrWhiteSpace(csvFileName) ? csvFileName : "";
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            string[] csvLines = File.ReadAllLines(_csvFileName);

            var testCases = new List<object[]>();

            foreach (var csvLine in csvLines)
            {
                IEnumerable<int> values = csvLine.Split(',').Select(int.Parse);

                object[] testCase = values.Cast<object>().ToArray();

                testCases.Add(testCase);
            }

            return testCases;
        }
    }
}

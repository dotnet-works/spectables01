using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SpecTablenRegex.StepDefinitions
{
    [Binding]
    public sealed class StepTable1
    {

        [Given(@"some user table")]
        public void GivenSomeUserTable()
        {
            
        }

        /// <summary>
        /// head values are vertical
        /// </summary>
        /// <param name="table"></param>
        [When(@"enter step table data with vertical header")]
        public void WhenEnterStepTableData(Table table)
        {
            var verticalTable = table.CreateInstance<PocoStepDataTable1>();

            Console.WriteLine($" dat Field1: {verticalTable.Username?.ToString()} type: {verticalTable.Username?.GetType()}");
            Console.WriteLine($" dat Field2: {verticalTable.Password?.ToString()} type: {verticalTable.Password?.GetType()}");
            
        }

        /// <summary>
        /// access using createset method head values are horizointal
        /// </summary>
        /// <param name="table"></param>
        [When(@"process data table using create instance")]
        public void WhenEnterStepTableDataWithHorizointalHeader(Table table)
        {
            var horizontalTable = table.CreateSet<PocoStepDataTable1>();

            foreach(var tableData in horizontalTable)
            {
                Console.WriteLine($" dat Field1: ${tableData.Username} type:{tableData.Username?.GetType()}");
                Console.WriteLine($" dat Field2: ${tableData.Password} type:{tableData.Username?.GetType()}");
            }
            
        }

        [Then(@"process table data")]
        public void ThenProcessTableData()
        {
            string cmdVar = Environment.GetEnvironmentVariable("VAR1");
            Console.WriteLine($"command Line Args: {cmdVar}");
            if (cmdVar == null)
            {
                Console.WriteLine($"command Line Args is null");
            }


            //Console.WriteLine($"command Line Args: {cmdVar.GetType()}");
        }
    }


   


}
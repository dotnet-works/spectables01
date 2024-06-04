using System.Data;
using TechTalk.SpecFlow;

namespace SpecTablenRegex.StepDefinitions
{
    [Binding]
    public sealed class TransformToDataTableSteps1
    {
        public TransformToDataTableSteps1()
        {
            
        }

        [When(@"process table data to datatable")]
        public void transformStepData(Table tbl)
        {
            var transTable = TableExtensions.ToDataTable(tbl);

            foreach(DataRow dataRow in transTable.Rows)
            {
                string row_data = $"{dataRow.ItemArray[0]?.ToString()} : {dataRow.ItemArray[1]?.ToString()} : {dataRow.ItemArray[2]?.ToString()}";
                Console.WriteLine(row_data);
               
            }
        }






    }
}
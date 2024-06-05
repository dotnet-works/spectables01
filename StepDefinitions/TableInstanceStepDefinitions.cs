using TechTalk.SpecFlow;

namespace SpecTablenRegex.StepDefinitions
{
    [Binding]
    public sealed class TableInstanceStepDefinitions
    {

        public TableInstanceStepDefinitions()
        {
            
        }

        [Given(@"some table without header")]
        public void Given1(Table tbl01) 
        {
            var x = tbl01.RowCount;
            var headerVal = tbl01.Header;
            Console.WriteLine($"rows: {x} header: {headerVal} ");

            IList<string> list = new List<string>();
            list.Insert(0, "row1");

            foreach (var header in tbl01.Header)
            {
                Console.WriteLine("header: "+header); //, typeof(string));
            }

            foreach ( TableRow row in tbl01.Rows )
            {
                Console.WriteLine(row["user_1"]);
            }


        }


    }
}

@notParallel
Feature: NonParaFeature1
   Sadly there is no direct feature in SpecFlow for this.
   But there is a workaround:
   We generate the code-behind classes as a partial class. So you can create a file with a partial class and add there the [NonParallizable] attribute.
   It looks like this:
   using NUnit.Framework;
   namespace ParallelExecution.Features
   {
[NonParallelizable]
public partial class CalculatorFeature
{

}
}


@web
Scenario: simple non-parallel google test
	Given go to "google" site
	When search something using "non parallel feature specflow"
	Then user navigates to result page 
	And Navigate back to main search page

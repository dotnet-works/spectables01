Feature: ParallelGoogleTest2

A short summary of the feature

@web
Scenario: simple google test2
	Given go to "google" site
	When search something using "specflow"
	Then user navigates to result page 
	And Navigate back to main search page

Feature: ExcelData1feature

A short summary of the feature

@DataSource:../../TestData/users.xlsx
@DataSet:Sheet1
Scenario: Get users form Json with DataSet
	Given I got user <Login>, <FirstName>, <LastName>
	Then user should match to snapshoot

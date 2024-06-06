Feature: json_data1

A short summary of the feature

@DataSource:../../TestData/users.json
Scenario: Get users form Json
	Given I got user <Login>, <FirstName>, <LastName>
	Then user should match to snapshoot


@DataSource:../../TestData/users.json
@DataSet:users
Scenario: Get users form Json with DataSet
	Given I got user <Login>, <FirstName>, <LastName>
	Then user should match to snapshoot


@DataSource:../../TestData/users2.json
@DataSet:users2
Scenario: Get users form Json with DataSet index
	Given I got user <Login>, <FirstName>, <LastName>
	Then user should match to snapshoot
Feature: Table Create Instance Example



@steptableexample @createinstanceexample
Scenario: Test1 step table type with verical header
  Given some user table
  When process data table using create instance
            | Field    | Value      |
	        | Username | testuser_1 |
	        | Password | Test@123   |
  Then process table data


@steptableexample @createinstanceexample
Scenario: Test2 step table type with verical header
  Given some user table
  When process data table using create instance
            | Username   | Password    |
	        | user1      | Test@213123 |
  Then process table data

@steptableexample @createinstanceexample
Scenario: Test3 step table type with verical header
  Given some user table
  When process data table using create instance
            | Username | Password    |
            | user1    |             |
            |          | Test@213123 |
  Then process table data
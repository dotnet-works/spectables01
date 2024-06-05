@web
Feature: FoxySignUp

A short summary of the feature

@foxy
Scenario: Verify Missing Feilds Error
  Given go to foxy signup page with url "https://admin.foxycart.com/signup/"
  When Enter signup button
  Then all missing feilds error should display
           | Errors                           |
           | Please enter your first name.    |
           | Please enter your last name.     |
           | Please enter your email address. |
           | Please enter your password.      |


@foxy
Scenario: Validate Error Message
	Given go to foxy signup page with url ""
	When enter all feilds except firstname
	Then Enter signup button
	And error should display

Examples: 
     | FirstName | LastName | Email | Password | Accomplish_Feild | HearAbout_Field | A_Programmer_Feild | A_FrontEnd_Developer_Feild | A_Designer_Feild | A_Store_Admin_Feild | StoreName | StoreSubDomain |
     | null      | rand     | rand  | rand     | rand             | rand            | action             | action                     | action           | action              |  rand     |  rand          |
	 | rand      | null     | rand  | rand     | rand             | rand            | action             | action                     | action           | action              |  rand     |  rand          |
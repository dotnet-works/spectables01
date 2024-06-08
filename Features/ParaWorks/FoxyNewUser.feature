@web
Feature: FoxyNewUser

A short summary of the feature

@foxy
Scenario: create new user
	Given go to foxy signup page with url "https://admin.foxycart.com/signup/"
	When enter "about yourself" info fieldset with following data:
	                    | FieldSet   |
	                    | FirstName  |
	                    | lastname   |
	                    | email      |
	                    | password   |
						| foxydesire |
	And enter "consider yourself" info fieldset with following data:
	                    | FieldSet   |
	                    | is_programmer |
	                    | is_developer  |
	                    | is_designer   |
	                    | is_merchant   |

	And enter "store domain" info fieldset with following data:
	                    | FieldSet    |
	                    | StoreName   |
	                    | StoreDomain |
    And click agree and captch checkbox
	And click signup button
	#Then user navigates to new user page

Scenario: Replace extra spaces
   Given Hey all  i know
   Given remove extra spaces in step def


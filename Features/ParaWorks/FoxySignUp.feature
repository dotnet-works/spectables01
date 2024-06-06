@web
Feature: FoxySignUp

A short summary of the feature

@foxy
Scenario: Verify Missing Feilds Error
  Given go to foxy signup page with url "https://admin.foxycart.com/signup/"
  When click signup button
  Then all missing feilds error should display
           | FieldName | Errors                           |
           | FirstName | Please enter your first name.    |
           | LastName  | Please enter your last name.     |
           | Email     | Please enter your email address. |
           | Password  | Please enter your password.      |
# Please enter your store name.
# Please enter a valid store domain.
# You must agree with our terms and conditions.


@foxy
Scenario: verify new user email
 Given go to foxy signup page with url "https://admin.foxycart.com/signup/"
 When validate user email message
             | email       | message                                                                 |
             | newemail    |                                                                         |
             | wrong_email | Please enter your email address.                                        |
             | used_email  | This email address is already in use. Would you like to login instead?. | 
             


@foxy
Scenario: Validate Error Message
	Given go to foxy signup page with url ""
	When enter all feilds except firstname
	Then click signup button
	And error should display

Examples: 
     | FirstName | LastName | Email | Password | Accomplish_Feild | HearAbout_Field | A_Programmer_Feild | A_FrontEnd_Developer_Feild | A_Designer_Feild | A_Store_Admin_Feild | StoreName | StoreSubDomain |
     | null      | rand     | rand  | rand     | rand             | rand            | action             | action                     | action           | action              |  rand     |  rand          |
	 | rand      | null     | rand  | rand     | rand             | rand            | action             | action                     | action           | action              |  rand     |  rand          |



@foxy
Scenario: Signup new user
  Given go to foxy signup page with url "https://admin.foxycart.com/signup/"
  When fill all data feilds
               | FieldName |

  #And  click signup button
  #Then user navigates to new user page

@foxy
Scenario: convert header to rows
  When only headers are given
               | FieldName1 | FieldName2 | FieldName3 |
  When only headers are given
               | Field1 | Field2 | Field3 |


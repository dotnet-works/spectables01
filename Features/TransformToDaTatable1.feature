Feature: TransformToDaTatable1

A short summary of the feature

@steptableexample @transformtodatatable
Scenario: Test1 step table type with verical header
  Given some user table
  When process table data to datatable 
            | Username   | Password      | Email          |
            | testuser_1 | xyz@pass      | xyz@email1.com |
            | testuser_2 | 123@pass      | 123@email.com  |
            | testuser_3 | abc@pass      | sdd@email.com  |
            
  Then process table data

Feature: Actors feature
All operations related to actors

Scenario: Get existing actor from repository
	When a GET request is made '/actors/1'
	Then the response must be '{"Name":"A1","Bio":"---","DOB":"2000-10-10","Gender":"male"}'
	And status code '200' is returned

Scenario: Get non existing actor from repository
	When a GET request is made 'actors/0'
	Then status code '400' is returned

Scenario: Get all actors from repository
	When a GET request is made 'api/actors'
	Then the response must be '[{"Name":"A1","Bio":"---","DOB":"2000-10-10","Gender":"male"},{"Name":"A1","Bio":"---","DOB":"2000-10-10","Gender":"male"}]'
	And status code '200' is returned

Scenario Outline: Add new actor with invalid details
	Given the following data is entered '{"Name":<Name>,"Bio":<Bio>,"DOB":<DOB>,"Gender":<Gender>}'
	When a POST request is made 'actors'
	Then the response must be '<Message>'
	And status code '400' is returned
	Examples: 
	| Name        | DOB		   | Bio		| Gender | Message		  |
	| Chris Evans | 2000-10-10 | Good actor |        | Invalid gender |
	|             | 2000-10-10 | Good actor |  Male  | Invalid name   |
	| Chris Evans | 2025-10-10 | Good actor |  Male  | Invalid Dob    |
	| Chris Evans | 2000-10-10 |            |  Male  | Invalid bio    |

Scenario: Add new actor with valid details
	Given the following data is entered '{"Name":"Chris Evans","Bio":"---","DOB":"2000-10-10","Gender":"male"}'
	When a POST request is made 'actors'
	Then status code '201' is returned
	And the response must be '1'

Scenario: Delete existing actor from repository
	When a DELETE request is made 'actors/1'
	Then status code '200' is returned

Scenario: Delete non existing actor from repository
	When a DELETE request is made 'actors/0'
	Then status code '400' is returned

Scenario: Update non existing actor from repository
	Given the following data is entered '{"Name":"Chris Evans","Bio":"---","DOB":"2000-10-10","Gender":"male"}'
	When a PUT request is made 'actors/0'
	Then status code '400' is returned

Scenario Outline: Update existing actor with invalid details
	Given the following data is entered '{"Name":<Name>,"Bio":<Bio>,"DOB":<DOB>,"Gender":<Gender>}'
	When a PUT request is made 'actors/1'
	Then the response must be '<Message>'
	And status code '400' is returned
	Examples: 
	| Name        | DOB		   | Bio		| Gender | Message		  |
	| Chris Evans | 2000-10-10 | Good actor |        | Invalid gender |
	|             | 2000-10-10 | Good actor |  Male  | Invalid name   |
	| Chris Evans | 2025-10-10 | Good actor |  Male  | Invalid Dob    |
	| Chris Evans | 2000-10-10 |            |  Male  | Invalid bio    |

Scenario: Update actor with valid details
	Given the following data is entered '{"Name":"Chris Evans","Bio":"---","DOB":"2000-10-10","Gender":"male"}'
	When a PUT request is made '/api/actors/1'
	Then status code '200' is returned
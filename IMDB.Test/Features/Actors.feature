Feature: Actors feature
All operations related to actors

Scenario: Get existing actor from repository
	When the actor is fetched with Id 1
	Then the actor must be displayed
	And status code "200 OK" is returned

Scenario: Get non existing actor from repository
	When the actor is fetched with Id 0
	Then status code "400 Bad Request" is returned

Scenario: Get all actors from repository
	When the actors are fetched
	Then list of actors are displayed

Scenario Outline: Add new actor with invalid details
	Given the following data is entered <Name>, <DOB>, <Bio>, <Gender>
	When the actor is added
	Then the error <Message> is displayed
	And status code "400 Bad Request" is returned
	Examples: 
	| Name        | DOB		   | Bio		| Gender | Message		  |
	| Chris Evans | 2000-10-10 | Good actor |        | Invalid gender |
	|             | 2000-10-10 | Good actor |  Male  | Invalid name   |
	| Chris Evans | 2025-10-10 | Good actor |  Male  | Invalid Dob    |
	| Chris Evans | 2000-10-10 |            |  Male  | Invalid bio    |

Scenario: Add new actor with valid details
	Given the actor name is "Chris Evans"
	And the actor DOB is "2000-10-10"
	And the actor gender is "male"
	And the actor bio is "Good actor"
	When actor is added to repository
	Then status code "201 Created" is returned
	And actor id 1 is displayed

Scenario: Delete existing actor from repository
	When the actor with Id 1 is deleted
	Then the actor must be deleted
	And status code "200 OK" is returned

Scenario: Delete non existing actor from repository
	When the actor with Id 0 is deleted
	Then status code "400 Bad Request" is returned

Scenario: Update non existing actor from repository
	When the actor with Id 0 is updated
	Then status code "400 Bad Request" is returned

Scenario Outline: Update existing actor with invalid details
	Given the following data is entered <Name>, <DOB>, <Bio>, <Gender>
	And the actor id is 1
	When the actor is added
	Then the error <Message> is displayed
	And status code "400 Bad Request" is returned
	Examples: 
	| Name        | DOB		   | Bio		| Gender | Message		  |
	| Chris Evans | 2000-10-10 | Good actor |        | Invalid gender |
	|             | 2000-10-10 | Good actor |  Male  | Invalid name   |
	| Chris Evans | 2025-10-10 | Good actor |  Male  | Invalid Dob    |
	| Chris Evans | 2000-10-10 |            |  Male  | Invalid bio    |

Scenario: Update actor with valid details
	Given the actor id is 1
	And the actor name is "Chris Evans"
	And the actor DOB is "2000-10-10"
	And the actor gender is "male"
	And the actor bio is "Good actor"
	When actor is updated
	Then status code "200 OK" is returned
	And actor id 1 is displayed
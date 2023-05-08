Feature: Producers feature
All operations related to producers

Scenario: Get existing producer from repository
	When the producer is fetched with Id 1
	Then the producer must be displayed
	And status code "200 OK" is returned

Scenario: Get non existing producer from repository
	When the producer is fetched with Id 0
	Then status code "400 Bad Request" is returned

Scenario: Get all producers from repository
	When the producers are fetched
	Then list of producers are displayed

Scenario Outline: Add new producer with invalid details
	Given the following data is entered <Name>, <DOB>, <Bio>, <Gender>
	When the producer is added
	Then the error <Message> is displayed
	And status code "400 Bad Request" is returned
	Examples: 
	| Name       | DOB	      | Bio	          | Gender | Message	    |
	| Harry Cook | 2000-10-10 | Good producer |        | Invalid gender |
	|            | 2000-10-10 | Good producer |  Male  | Invalid name   |
	| Harry Cook | 2025-10-10 | Good producer |  Male  | Invalid Dob    |
	| Harry Cook | 2000-10-10 |               |  Male  | Invalid bio    |

Scenario: Add new producer with valid details
	Given the producer name is "Harry Cook"
	And the producer DOB is "2000-10-10"
	And the producer gender is "male"
	And the producer bio is "Good producer"
	When producer is added to repository
	Then status code "201 Created" is returned
	And producer id 1 is displayed

Scenario: Delete existing producer from repository
	When the producer with Id 1 is deleted
	Then the producer must be deleted
	And status code "200 OK" is returned

Scenario: Delete non existing producer from repository
	When the producer with Id 0 is deleted
	Then status code "400 Bad Request" is returned

Scenario: Update non existing producer from repository
	When the producer with Id 0 is updated
	Then status code "400 Bad Request" is returned

Scenario Outline: Update existing producer with invalid details
	Given the following data is entered <Name>, <DOB>, <Bio>, <Gender>
	And the producer id is 1
	When the producer is added
	Then the error <Message> is displayed
	And status code "400 Bad Request" is returned
	Examples: 
	| Name       | DOB		  | Bio		      | Gender | Message		|
	| Harry Cook | 2000-10-10 | Good producer |        | Invalid gender |
	|            | 2000-10-10 | Good producer |  Male  | Invalid name   |
	| Harry Cook | 2025-10-10 | Good producer |  Male  | Invalid Dob    |
	| Harry Cook | 2000-10-10 |               |  Male  | Invalid bio    |

Scenario: Update producer with valid details
	Given the producer id is 1
	And the producer name is "Harry Cook"
	And the producer DOB is "2000-10-10"
	And the producer gender is "male"
	And the producer bio is "Good producer"
	When producer is updated
	Then status code "200 OK" is returned
	And producer id 1 is displayed0.
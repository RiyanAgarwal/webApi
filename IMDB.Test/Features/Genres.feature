Feature: Genres feature
All operations related to genres

Scenario: Get existing genre from repository
	When the genre is fetched with Id 1
	Then the genre is displayed
	And status code "200 OK" is returned

Scenario: Get non existing genre from repository
	When the genre is fetched with Id 0
	Then status code "400 Bad Request" is returned

Scenario: Get all genres from repository
	When the genres are fetched
	Then list of genres are displayed
	And status code "200 OK" is returned

Scenario: Add new genre with invalid details
	Given the genre name is ""
	When the genre is added
	Then the error "Invalid name" is displayed
	And status code "400 Bad Request" is returned

Scenario: Add new genre with valid details
	Given the genre name is "action"
	When genre is added to repository
	Then status code "201 Created" is returned
	And genre id 1 is displayed

Scenario: Delete existing genre from repository
	When the genre with Id 1 is deleted
	Then status code "200 OK" is returned

Scenario: Delete non existing genre from repository
	When the genre with Id 0 is deleted
	Then status code "400 Bad Request" is returned

Scenario: Update non existing genre from repository
	When the genre with Id 0 is updated
	Then status code "400 Bad Request" is returned

Scenario: Update existing genre with invalid details
	Given the genre name is ""
	And the genre id is 1
	When the genre is added
	Then the error "Invalid name" is displayed
	And status code "400 Bad Request" is returned

Scenario: Update genre with valid details
	Given the genre id is 1
	And the genre name is "scifi"
	When genre is updated
	Then status code "200 OK" is returned
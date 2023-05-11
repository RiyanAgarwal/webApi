Feature: Genres feature
All operations related to genres

Scenario: Get existing genre from repository
	When a GET request is made 'api/genres/1'
	Then the response must be '{"id":1,"name":"G1"}'
	And status code '200' is returned

Scenario: Get non existing genre from repository
	When a GET request is made 'api/genres/0'
	Then status code '404' is returned

Scenario: Get all genres from repository
	When a GET request is made 'api/genres'
	Then the response must be '[{"id":1,"name":"G1"},{"id":2,"name":"G2"}]'
	And status code '200' is returned

Scenario: Add new genre with invalid details
	Given the following data is entered '{"name":""}'
	When a POST request is made 'api/genres'
	Then status code '400' is returned
	And the response must be 'Invalid name'

Scenario: Add new genre with valid details
	Given the following data is entered '{"name":"G1"}'
	When a POST request is made 'api/genres'
	Then status code '201' is returned
	And the response must be '2'

Scenario: Delete existing genre from repository
	When a DELETE request is made 'api/genres/1'
	Then status code '200' is returned

Scenario: Delete non existing genre from repository
	When a DELETE request is made 'api/genres/0'
	Then status code '404' is returned

Scenario: Update non existing genre from repository
	Given the following data is entered '{"name":"G1"}'
	When a PUT request is made 'api/genres/0'
	Then status code '400' is returned

Scenario: Update existing genre with invalid details
	Given the following data is entered '{"name":""}'
	When a PUT request is made 'api/genres/1'
	Then the response must be 'Invalid name'
	And status code '400' is returned

Scenario: Update genre with valid details
	Given the following data is entered '{"name":"G1"}'
	When a PUT request is made '/api/genres/1'
	Then status code '200' is returned
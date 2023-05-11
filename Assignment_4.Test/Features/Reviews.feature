Feature: Reviews feature
All operations related to reviews

Scenario: Get existing review from repository
	When a GET request is made 'api/reviews/1'
	Then the response must be '{"id":1,"movieId":1,"message":"--"}'
	And status code '200' is returned

Scenario: Get non existing review from repository
	When a GET request is made 'api/reviews/0'
	Then status code '404' is returned

Scenario: Get all reviews from repository
	When a GET request is made 'api/reviews'
	Then the response must be '[{"id":1,"movieId":1,"message":"--"},{"id":2,"movieId":1,"message":"--"}]'
	And status code '200' is returned

Scenario Outline: Add new review with invalid details
	Given the following data is entered '{"movieId":<movieId>,"message":"<Message>"}'
	When a POST request is made 'api/reviews'
	Then status code '400' is returned
	And the response must be '<Error>'
	Examples: 
	| movieId | Message		 | Error            |
	| 0       | good movie   | Invalid movie id |
	| 1       |				 | Invalid message  |

Scenario: Add new review with valid details
	Given the following data is entered '{"movieId":1,"message":"--"}'
	When a POST request is made 'api/reviews'
	Then status code '201' is returned
	And the response must be '2'

Scenario: Delete existing review from repository
	When a DELETE request is made 'api/reviews/1'
	Then status code '200' is returned

Scenario: Delete non existing review from repository
	When a DELETE request is made 'api/reviews/0'
	Then status code '404' is returned

Scenario: Update non existing review from repository
	Given the following data is entered '{"movieId":1,"message":"--"}'
	When a PUT request is made 'api/reviews/0'
	Then status code '400' is returned

Scenario Outline: Update existing review with invalid details
	Given the following data is entered '{"movieId":<movieId>,"message":"<Message>"}'
	When a PUT request is made 'api/reviews/1'
	Then the response must be '<Error>'
	And status code '400' is returned
	Examples: 
	| movieId | Message		 | Error            |
	| 0       | good movie   | Invalid movie id |
	| 1       |				 | Invalid message  |

Scenario: Update review with valid details
	Given the following data is entered '{"movieId":1,"message":"<Message>"}'
	When a PUT request is made '/api/reviews/1'
	Then status code '200' is returned
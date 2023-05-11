Feature: reviews feature
All operations related to reviews

Scenario: Get existing review from repository
	When the review is fetched with Id 1
	Then the review must be displayed
	And status code "200 OK" is returned

Scenario: Get non existing review from repository
	When the review is fetched with Id 0
	Then status code "400 Bad Request" is returned

Scenario: Get all reviews from repository
	When the reviews are fetched
	Then list of reviews are displayed

Scenario Outline: Add new review with invalid details
	Given the following data is entered <Message>, <MovieId>
	When the review is added
	Then the error <Error> is displayed
	And status code "400 Bad Request" is returned
	Examples: 
	| Message    | MovieId |   Error		  |
	|            |    1    |  Invalid message |
	| Good movie |    0    | Invalid movie id |

Scenario: Add new review with valid details
	Given the review name is "Good movie"
	And the MovieId is 1
	When review is added to repository
	Then status code "201 Created" is returned
	And review id 1 is displayed

Scenario: Delete existing review from repository
	When the review with Id 1 is deleted
	Then status code "200 OK" is returned

Scenario: Delete non existing review from repository
	When the review with Id 0 is deleted
	Then status code "400 Bad Request" is returned

Scenario: Update non existing review from repository
	When the review with Id 0 is updated
	Then status code "400 Bad Request" is returned

Scenario Outline: Update existing review with invalid details
	Given the following data is entered <Message>, <MovieId>
	And the review id is 1
	When the review is updated
	Then the error <Error> is displayed
	And status code "400 Bad Request" is returned
	Examples: 
	| Message    | MovieId |   Error		  |
	|            |    1    |  Invalid message |
	| Good movie |    0    | Invalid movie id |

Scenario: Update review with valid details
	Given the review id is 1
	And the review message is "Good movie"
	And the MovieId 1
	When review is updated
	Then status code "200 OK" is returned
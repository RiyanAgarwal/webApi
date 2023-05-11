Feature: movies feature
All operations related to movies

Scenario: Get existing movie from repository
	When a GET request is made 'api/movies/1'
	Then the response must be '{"id":1,"name":"M1","plot":"plot1","producer":{"id":1,"name":"P1","bio":"--","gender":"male","dob":"2000-10-10T00:00:00"},"actors":[{"id":1,"name":"A1","bio":"--","gender":"male","dob":"2000-10-10T00:00:00"},{"id":2,"name":"A2","bio":"--","gender":"male","dob":"2000-10-10T00:00:00"}],"yearOfRelease":2000,"coverImage":"www","genres":[{"id":1,"name":"G1"},{"id":2,"name":"G2"}]}'
	And status code '200' is returned

Scenario: Get non existing movie from repository
	When a GET request is made 'api/movies/0'
	Then status code '404' is returned

Scenario: Get all movies from repository
	When a GET request is made 'api/movies'
	Then the response must be '[{"id":1,"name":"M1","plot":"plot1","producer":{"id":1,"name":"P1","bio":"--","gender":"male","dob":"2000-10-10T00:00:00"},"actors":[{"id":1,"name":"A1","bio":"--","gender":"male","dob":"2000-10-10T00:00:00"},{"id":2,"name":"A2","bio":"--","gender":"male","dob":"2000-10-10T00:00:00"}],"yearOfRelease":2000,"coverImage":"www","genres":[{"id":1,"name":"G1"},{"id":2,"name":"G2"}]},{"id":2,"name":"M2","plot":"plot1","producer":{"id":1,"name":"P1","bio":"--","gender":"male","dob":"2000-10-10T00:00:00"},"actors":[{"id":1,"name":"A1","bio":"--","gender":"male","dob":"2000-10-10T00:00:00"},{"id":2,"name":"A2","bio":"--","gender":"male","dob":"2000-10-10T00:00:00"}],"yearOfRelease":2000,"coverImage":"www","genres":[{"id":1,"name":"G1"},{"id":2,"name":"G2"}]}]'
	And status code '200' is returned

Scenario Outline: Add new movie with invalid details
	Given the following data is entered '{"name":"<Name>", "yearOfRelease":<YearOfRelease>, "plot":"<Plot>", "producerId":<ProducerId>,"actorsIds":"<ActorsIds>","genresIds":"<GenresIds>","coverImage":"<CoverImage>"}'
	When a POST request is made 'api/movies'
	Then the response must be '<Message>'
	And status code '400' is returned
	Examples: 
	| Name        | YearOfRelease | Plot        | ProducerId | ActorsIds | GenresIds |   CoverImage   | Message               |
	|             |     2000      | Good movie  |     1      |    1,2    |    1,2    | www.poster.com | Invalid name          |
	| ford        |     2070      | Good movie  |     1      |    1,2    |    1,2    | www.poster.com | Invalid date          |
	| ford        |     2000      |             |     1      |    1,2    |    1,2    | www.poster.com | Invalid plot          |
	| ford        |     2000      | Good movie  |     9      |    1,2    |    1,2    | www.poster.com | Invalid producer id   |
	| ford        |     2000      | Good movie  |     1      |    2,3    |    1,2    | www.poster.com | Invalid Actor id      |
	| ford        |     2000      | Good movie  |     1      |    1,2    |    2,3    | www.poster.com | Invalid genre id      |
	| ford        |     2000      | Good movie  |     1      |    1,2    |    1,2    |                | Invalid cover         |

Scenario: Add new movie with valid details
	Given the following data is entered '{"name":"ford", "yearOfRelease":2000, "plot":"plot1", "producerId":1,"actorsIds":"1,2","genresIds":"1,2","coverImage":"www"}'
	When a POST request is made 'api/movies'
	Then status code '201' is returned
	And the response must be '2'

Scenario: Delete existing movie from repository
	When a DELETE request is made 'api/movies/1'
	Then status code '200' is returned

Scenario: Delete non existing movie from repository
	When a DELETE request is made 'api/movies/0'
	Then status code '404' is returned

Scenario: Update non existing movie from repository
	Given the following data is entered '{"name":"ford", "yearOfRelease":2000, "plot":"plot1", "producerId":1,"actorsIds":"1,2","genresIds":"1,2","coverImage":"www"}'
	When a PUT request is made 'api/movies/0'
	Then status code '400' is returned

Scenario Outline: Update existing movie with invalid details
	Given the following data is entered '{"name":"<Name>", "yearOfRelease":<YearOfRelease>, "plot":"<Plot>", "producerId":<ProducerId>,"actorsIds":"<ActorsIds>","genresIds":"<GenresIds>","coverImage":"<CoverImage>"}'
	When a PUT request is made 'api/movies/1'
	Then the response must be '<Message>'
	And status code '400' is returned
	Examples: 
	| Name        | YearOfRelease | Plot        | ProducerId | ActorsIds | GenresIds |   CoverImage   | Message               |
	|             |     2000      | Good movie  |     1      |    1,2    |    1,2    | www.poster.com | Invalid name          |
	| ford        |     2070      | Good movie  |     1      |    1,2    |    1,2    | www.poster.com | Invalid date          |
	| ford        |     2000      |             |     1      |    1,2    |    1,2    | www.poster.com | Invalid plot          |
	| ford        |     2000      | Good movie  |     9      |    1,2    |    1,2    | www.poster.com | Invalid producer id   |
	| ford        |     2000      | Good movie  |     1      |    2,3    |    1,2    | www.poster.com | Invalid Actor id      |
	| ford        |     2000      | Good movie  |     1      |    1,2    |    2,3    | www.poster.com | Invalid genre id      |
	| ford        |     2000      | Good movie  |     1      |    1,2    |    1,2    |                | Invalid cover         |

Scenario: Update movie with valid details
	Given the following data is entered '{"name":"ford", "yearOfRelease":2000, "plot":"plot1", "producerId":1,"actorsIds":"1,2","genresIds":"1,2","coverImage":"www"}'
	When a PUT request is made 'api/movies/1'
	Then status code '200' is returned
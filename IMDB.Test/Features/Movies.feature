Feature: movies feature
All operations related to movies

Scenario: Get existing movie from repository
	When the movie is fetched with Id 1
	Then the movie must be displayed
	And status code "200 OK" is returned

Scenario: Get non existing movie from repository
	When the movie is fetched with Id 0
	Then status code "400 Bad Request" is returned

Scenario: Get all movies from repository
	When the movies are fetched
	Then list of movies are displayed

Scenario Outline: Add new movie with invalid details
	Given the following data is entered <Name>, <YearOfRelease>, <Plot>, <ProducerId>,<ActorsIds>,<GenresIds>,<CoverImage>
	When the movie is added
	Then the error <Message> is displayed
	And status code "400 Bad Request" is returned
	Examples: 
	| Name        | YearOfRelease | Plot        | ProducerId | ActorsIds | GenresIds |   CoverImage   | Message               |
	|             |     2000      | Good movie  |     1      |    1,2    |    1,2    | www.poster.com | Invalid name          |
	| ford        |     2070      | Good movie  |     1      |    1,2    |    1,2    | www.poster.com | Invalid year          |
	| ford        |     2000      |             |     1      |    1,2    |    1,2    | www.poster.com | Invalid plot          |
	| ford        |     2000      | Good movie  |     9      |    1,2    |    1,2    | www.poster.com | Invalid producer id   |
	| ford        |     2000      | Good movie  |     1      |    2,3    |    1,2    | www.poster.com | Invalid actor id      |
	| ford        |     2000      | Good movie  |     1      |    1,2    |    2,3    | www.poster.com | Invalid genre id      |
	| ford        |     2000      | Good movie  |     1      |    1,2    |    1,2    |                | Invalid coverimage    |

Scenario: Add new movie with valid details
	Given the movie name is "Ford"
	And the movie year is "2000"
	And the movie plot is "good movie"
	And the movie coverImage is "www.poster.com"
	And the movie producerId is 1
	And the movie GenresIds is "1,2"
	And the movie ActorsIds is "1,2"
	When movie is added to repository
	Then status code "201 Created" is returned
	And movie id 1 is displayed

Scenario: Delete existing movie from repository
	When the movie with Id 1 is deleted
	Then status code "200 OK" is returned

Scenario: Delete non existing movie from repository
	When the movie with Id 0 is deleted
	Then status code "400 Bad Request" is returned

Scenario: Update non existing movie from repository
	When the movie with Id 0 is updated
	Then status code "400 Bad Request" is returned

Scenario Outline: Update existing movie with invalid details
	Given the following data is entered <Name>, <YearOfRelease>, <Plot>, <ProducerId>,<ActorsIds>,<GenresIds>,<CoverImage>
	When the movie is added
	Then the error <Message> is displayed
	And status code "400 Bad Request" is returned
	Examples: 
	| Name        | YearOfRelease | Plot        | ProducerId | ActorsIds | GenresIds |   CoverImage   | Message               |
	|             |     2000      | Good movie  |     1      |    1,2    |    1,2    | www.poster.com | Invalid name          |
	| ford        |     2070      | Good movie  |     1      |    1,2    |    1,2    | www.poster.com | Invalid year          |
	| ford        |     2000      |             |     1      |    1,2    |    1,2    | www.poster.com | Invalid plot          |
	| ford        |     2000      | Good movie  |     9      |    1,2    |    1,2    | www.poster.com | Invalid producer id   |
	| ford        |     2000      | Good movie  |     1      |    2,3    |    1,2    | www.poster.com | Invalid actor id      |
	| ford        |     2000      | Good movie  |     1      |    1,2    |    2,3    | www.poster.com | Invalid genre id      |
	| ford        |     2000      | Good movie  |     1      |    1,2    |    1,2    |                | Invalid coverimage    |

Scenario: Update movie with valid details
	Given the movie id is 1
	And the movie name is "ford"
	And the movie year is "2000"
	And the movie plot is "good movie"
	And the movie coverImage is "www.poster.com"
	And the movie producerId is 1
	And the movie GenresIds is "1,2"
	And the movie ActorsIds is "1,2"
	When movie is updated
	Then status code "200 OK" is returned
CREATE PROC [Foundation].[usp_insert_Movie]
@Name varchar(50),
@Plot varchar(50),
@Year int,
@CoverImage varchar(200),
@ProducerId int,
@GenreList varchar(50),
@ActorList varchar(50)
AS
INSERT INTO 
	Foundation.Movies(Name,Plot,YearOfRelease,CoverImage,ProducerId,UpdatedAt) 
	VALUES(@Name,@Plot,@Year,@CoverImage,@ProducerId,Null)
DECLARE @Id int =SCOPE_IDENTITY()
INSERT INTO
	Foundation.Actors_Movies(MovieId,ActorId,UpdatedAt)
SELECT @Id,
	value,
	NULL
FROM string_split(@ActorList,',',1)
INSERT INTO
	Foundation.Genres_Movies(MovieId,GenreId)
SELECT @Id,
	value
FROM string_split(@GenreList,',',1)
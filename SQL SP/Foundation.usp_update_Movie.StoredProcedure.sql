CREATE PROC [Foundation].[usp_update_Movie]
@Id int,
@Name varchar(50),
@Plot varchar(50),
@YearOfRelease int,
@CoverImage varchar(200),
@ProducerId int,
@GenreList varchar(50),
@ActorList varchar(50)
AS
UPDATE Foundation.Movies
SET Name=@Name
	,Plot=@Plot
	,YearOfRelease=@YearOfRelease
	,CoverImage=@CoverImage
	,ProducerId=@ProducerId
	,UpdatedAt=CAST(GETDATE() AS Date)
WHERE Id=@Id
DELETE FROM Foundation.Actors_Movies
WHERE MovieId=@Id
DELETE FROM Foundation.Genres_Movies
WHERE MovieId=@Id
INSERT INTO
	Foundation.Actors_Movies(MovieId,ActorId,UpdatedAt)
SELECT @Id,
	value,
	CAST(GETDATE() AS Date)
FROM string_split(@ActorList,',',1)
INSERT INTO
	Foundation.Genres_Movies(MovieId,GenreId)
SELECT @Id,
	value
FROM string_split(@GenreList,',',1)
using Assignment_3.Models.DB;
using Assignment_3.Models.Request;
using Assignment_3.Services;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Assignment_3.Repositories
{
    public class MovieRepository : BaseRepository<MovieDB>, IMovieRepository
    {
        private readonly string _connectionString;
        public MovieRepository(IOptions<ConnectionString> connectionString)
             : base(connectionString.Value.IMDBDB)
        {
            _connectionString = connectionString.Value.IMDBDB;
        }
        public List<MovieDB> GetAll()
        {
            const string query = @"
SELECT [Id]
	,[Name]
	,[YearOfRelease]
	,[Plot]
    ,[CoverImage]
	,[ProducerId] 
FROM Foundation.Movies";
            return GetAll(query);
        }

        public MovieDB Get(int id)
        {
            const string query = @"
SELECT [Id]
	,[Name]
    ,[CoverImage]
	,[YearOfRelease]
	,[Plot]
	,[ProducerId] 
FROM Foundation.Movies
WHERE Id = @Id";
            return Get(query, new { Id = id });
        }

        public List<int> GetGenres(int id)
        {
            const string query = @"
SELECT GenreId
FROM Foundation.Genres_Movies
WHERE MovieId = @Id";
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<int>(query, new {Id=id}).ToList();
        }

        public List<int> GetActors(int id)
        {
            const string query = @"
SELECT ActorId
FROM Foundation.Actors_Movies
WHERE MovieId = @Id";
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<int>(query,new {Id =id}).ToList();
        }
        public void Add(MovieRequest movie)
        {
            const string query = @"
EXEC Foundation.usp_insert_Movie 
    @Name
	,@Plot
	,@Year
	,@CoverImage
	,@ProducerId
	,@GenreList
	,@ActorList
";
            Create(query, new
            {
                movie.Name,
                movie.Plot,
                Year = movie.YearOfRelease,
                movie.CoverImage,
                movie.ProducerId,
                GenreList = movie.GenresIds,
                ActorList = movie.ActorsIds
            });
        }
        public void Delete(int id)
        {
            const string query = @"
DELETE FROM Foundation.Movies
WHERE Id = @Id";
            Delete(query, new { Id = id });
        }
        public void Update(MovieRequest movie, int id)
        {
            const string query = @"
EXEC Foundation.usp_update_Movie
    @Id
    ,@Name
	,@Plot
	,@YearOfRelease
	,@CoverImage
	,@ProducerId
	,@GenreList
	,@ActorList
";
            Update(query, new
            {
                Id = id,
                movie.Name,
                movie.Plot,
                movie.YearOfRelease,
                movie.CoverImage,
                movie.ProducerId,
                GenreList = movie.GenresIds,
                ActorList = movie.ActorsIds
            });
        }

        public void UpdateCoverImage(int Id, string CoverImage)
        {
            const string query = @"
UPDATE Foundation.Movies
SET CoverImage=@CoverImage
    ,UpdatedAt=CAST(GETDATE() AS date)
WHERE Id=@Id";
            Update(query, new
            {
                Id,
                CoverImage
            });
        }
    }
}
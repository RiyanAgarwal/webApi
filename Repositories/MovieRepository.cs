using Assignment_3.Models.DB;
using Assignment_3.Services;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Assignment_3.Repositories
{
    public class MovieRepository :BaseRepository<MovieDB>, IMovieRepository
    {
        private readonly string _connectionString;
        public MovieRepository(IOptions<ConnectionString> connectionString)
             : base(connectionString.Value.IMDBDB)
        {
            _connectionString=connectionString.Value.IMDBDB;
        }
        public List<MovieDB> GetAll()
        {
            const string query = @"
SELECT M.[Id]
	,[Name]
	,[YearOfRelease]
	,[Plot]
    ,[CoverImage]
	,[ProducerId]
    ,[ActorId] 
    ,[GenreId] 
FROM Foundation.Movies M
INNER JOIN Foundation.Actors_Movies AM 
    ON M.Id=AM.MovieId
INNER JOIN Foundation.Genres_Movies GM
    ON M.Id=GM.MovieId";
            using var connection = new SqlConnection(_connectionString);
            var movies = connection.Query<MovieDB, int, int, MovieDB>(query, (movie, actorId, genreId) =>
            {
                movie.ActorsId.Add(actorId);
                movie.GenresId.Add(genreId);
                return movie;
            }, splitOn: "ActorId,GenreId");
            var rr = movies.GroupBy(p => p.Id);
            var result = movies.GroupBy(p => p.Id).Select(g =>
            {
                var groupedMovie = g.First();
                groupedMovie.ActorsId = g.Select(p => p.ActorsId.Single()).Distinct().ToList();
                groupedMovie.GenresId = g.Select(p => p.GenresId.Single()).Distinct().ToList();
                return groupedMovie;
            });
            return result.ToList();
        }

        public MovieDB Get(int id)
        {
            const string query = @"
SELECT M.[Id]
	,[Name]
    ,[CoverImage]
	,[YearOfRelease]
	,[Plot]
	,[ProducerId]
    ,[ActorId] 
    ,[GenreId] 
FROM Foundation.Movies M
INNER JOIN Foundation.Actors_Movies AM 
    ON M.Id=AM.MovieId
INNER JOIN Foundation.Genres_Movies GM
    ON M.Id=GM.MovieId
WHERE M.Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            var movies = connection.Query<MovieDB, int, int, MovieDB>(query, (movie, actorId, genreId) =>
            {
                movie.ActorsId.Add(actorId);
                movie.GenresId.Add(genreId);
                return movie;
            }, new { Id = id }, splitOn: "ActorId,GenreId");
            if (movies.Count() == 0)
                return null;
            var movie = movies.First();
            movie.ActorsId = movies.Select(p => p.ActorsId.Single()).Distinct().ToList();
            movie.GenresId = movies.Select(p => p.GenresId.Single()).Distinct().ToList();
            return movie;
        }

        public void Add(MovieDB movie)
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
                Year=movie.YearOfRelease,
                movie.CoverImage,
                movie.ProducerId,
                GenreList=string.Join(",",movie.GenresId),
                ActorList=string.Join(",",movie.ActorsId)
            });
        }
        public void Delete(int id)
        {
            const string query = @"
DELETE FROM Foundation.Movies
WHERE Id = @Id";
            Delete(query, new { Id = id });
        }
        public void Update(MovieDB movie)
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
                movie.Id,
                movie.Name,
                movie.Plot,
                movie.YearOfRelease,
                movie.CoverImage,
                movie.ProducerId,
                GenreList = string.Join(",", movie.GenresId),
                ActorList = string.Join(",", movie.ActorsId)
            });
        }

    }
}
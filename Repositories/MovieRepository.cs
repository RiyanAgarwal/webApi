using Assignment_3.Models.DB;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_3.Repositories
{
    public class MovieRepository :BaseRepository<MovieDB>, IMovieRepository
    {
        public MovieRepository(IOptions<ConnectionString> connectionString)
             : base(connectionString.Value.IMDBDB)
        {
        }
        public List<MovieDB> GetAll()
        {
//            const string query = @"
//SELECT [Id]
//	,[Name]
//	,[YearOfRelease]
//	,[Plot]
//    ,[CoverImage]
//	,[ProducerId]
//    (SELECT [GenreId]
//        FROM Foundation.Genres_Movies (NOLOCK)
//        WHERE MovieId=Id)
//    (SELECT [ActorId]
//        FROM Foundation.Actors_Movies (NOLOCK)
//        WHERE MovieId=Id)
//FROM Foundation.Movies (NOLOCK)";
//            return GetAll(query);
        }
        public MovieDB Get(int id)
        {
//            const string query = @"
//SELECT [Id]
//	,[Name]
//	,[YearOfRelease]
//	,[Plot]
//	,[ProducerId]
//FROM Foundation.Movies (NOLOCK)
//WHERE Id = @Id";
//            return Get(query, new { Id = id });
        }
        public void Add(MovieDB movie)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            const string query = @"
DELETE FROM Foundation.Movies
WHERE Id = @Id";
            Delete(query, new { Id = id });
        }
    }
}
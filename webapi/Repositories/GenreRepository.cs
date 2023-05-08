﻿using Assignment_3.Models.DB;
using Assignment_3.Models.Request;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_3.Repositories
{
    public class GenreRepository : BaseRepository<GenreDB>, IGenreRepository
    {
        public GenreRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.IMDBDB)
        {
        }
        public List<GenreDB> GetAll()
        {
            const string query = @"
            SELECT [Id]
	            ,[Name]
            FROM Foundation.Genres (NOLOCK)";
            return GetAll(query);
        }

        public GenreDB Get(int id)
        {
            const string query = @"
            SELECT [Id]
	            ,[Name]
            FROM Foundation.Genres (NOLOCK)
            WHERE Id = @Id";
            return Get(query, new { Id = id });
        }

        public void Add(GenreRequest genre)
        {
            string query = @"
            INSERT INTO Foundation.Genres (
	            Name
	            )
            VALUES (
	            @Name
	            )";
            Create(query, new
            {
                genre.Name,
            });
        }
        public void Delete(int id)
        {
            const string query = @"
            DELETE FROM Foundation.Genres
            WHERE Id = @Id";
            Delete(query, new { Id = id });
        }
        public void Update(GenreRequest genre, int id)
        {
            const string query = @"
            UPDATE Foundation.Genres
            SET Name = @Name
                ,UpdatedAt=CAST(GETDATE() AS date)
            WHERE Id = @Id";
            Update(query, new
            {
                genre.Name,
                Id = id
            });
        }
    }
}
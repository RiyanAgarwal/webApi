using Assignment_3.Models.DB;
using Assignment_3.Models.Request;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_3.Repositories
{
    public class ReviewRepository : BaseRepository<ReviewDB>, IReviewRepository
    {
        public ReviewRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.IMDBDB)
        {
        }
        public List<ReviewDB> GetAll()
        {
            const string query = @"
            SELECT [Id]
                ,[MovieId]
	            ,[Message]
            FROM Foundation.Reviews (NOLOCK)";
            return GetAll(query);
        }
        public ReviewDB Get(int id)
        {
            const string query = @"
            SELECT [Id]
                ,[MovieId]
	            ,[Message]
            FROM Foundation.Review (NOLOCK)
            WHERE Id = @Id";
            return Get(query, new { Id = id });
        }

        public void Add(ReviewRequest Review)
        {
            string query = @"
            INSERT INTO Foundation.Reviews (
	            Message
                ,MovieId
	            )
            VALUES (
	            @Message
                ,@MovieId
	            )";
            Create(query, new
            {
                Review.Message,
                Review.MovieId
            });
        }
        public void Delete(int id)
        {
            const string query = @"
            DELETE FROM Foundation.Reviews
            WHERE Id = @Id";
            Delete(query, new { Id = id });
        }
        public void Update(ReviewRequest review, int id)
        {
            const string query = @"
            UPDATE Foundation.Reviews
            SET Message = @Message
	            ,MovieId = @MovieId
                ,UpdatedAt=CAST(GETDATE() AS date)
            WHERE Id = @Id";
            Update(query, new
            {
                review.Message,
                review.MovieId,
                Id = id
            });
        }
    }
}
using Assignment_3.Models.DB;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using System.Collections;

namespace Assignment_3.Repositories
{
    public class ActorRepository : BaseRepository<ActorDB>, IActorRepository
    {
        public ActorRepository(IOptions<ConnectionString> connectionString)
            :base(connectionString.Value.IMDBDB)
        {
        }
        public List<ActorDB> GetAll()
        {
            const string query = @"
SELECT [Id]
	,[Name]
	,[Gender]
	,[DOB]
	,[Bio]
FROM Foundation.Actors (NOLOCK)";
            return GetAll(query);
        }
        public ActorDB Get(int id)
        {
            const string query = @"
SELECT [Id]
	,[Name]
	,[Gender]
	,[DOB]
	,[Bio]
FROM Foundation.Actors (NOLOCK)
WHERE Id = @Id";
            return Get(query,new {Id=id});
        }
        public void Add(ActorDB actor)
        {
            string query = @"
INSERT INTO Foundation.Actors (
	Name
	,DOB
	,Bio
	,Gender
	)
VALUES (
	@Name
	,@DOB
	,@Bio
	,@Gender
	)";
            Create(query, new
            {
                actor.Name,
                actor.Bio,
                actor.Gender,
                actor.DOB
            });
        }
        public void Delete(int id)
        {
            const string query = @"
DELETE FROM Foundation.Actors
WHERE Id = @Id";
            Delete(query, new { Id = id });
        }

        public void Update(ActorDB actor)
        {
            const string query = @"
UPDATE Foundation.Actors
SET Name = @Name
	,Bio = @Bio
	,Gender = @Gender
	,Dob = @DOb
    ,UpdatedAt=CAST(GETDATE() AS date)
WHERE Id = @Id";
            Update(query, new
            {
                actor.Name,
                actor.Bio,
                actor.Gender,
                actor.DOB,
                actor.Id
            });
        }
    }
}
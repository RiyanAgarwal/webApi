using Assignment_3.Models.DB;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_3.Repositories
{
    public class ProducerRepository : BaseRepository<ProducerDB>,IProducerRepository
    {
        public ProducerRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.IMDBDB)
        {
        }
        public List<ProducerDB> GetAll()
        {
            const string query = @"
SELECT [Id]
	,[Name]
	,[Gender]
	,[DOB]
	,[Bio]
FROM Foundation.Producers (NOLOCK)";
            return GetAll(query);
        }
        public ProducerDB Get(int id)
        {
            const string query = @"
SELECT [Id]
	,[Name]
	,[Gender]
	,[DOB]
	,[Bio]
FROM Foundation.Producers (NOLOCK)
WHERE Id = @Id";
            return Get(query, new { Id = id });
        }
        public void Add(ProducerDB Producer)
        {
            string query = @"
INSERT INTO Foundation.Producers (
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
                Producer.Name,
                Producer.Bio,
                Producer.Gender,
                Producer.DOB
            });
        }
        public void Delete(int id)
        {
            const string query = @"
DELETE FROM Foundation.Producers
WHERE Id = @Id";
            Delete(query, new { Id = id });
        }

        public void Update(ProducerDB producer)
        {
            const string query = @"
UPDATE Foundation.Producers
SET Name = @Name
	,Bio = @Bio
	,Gender = @Gender
	,Dob = @DOb
WHERE Id = @Id";
            Update(query, new
            {
                producer.Name,
                producer.Bio,
                producer.Gender,
                producer.DOB,
                producer.Id
            });
        }
    }
}

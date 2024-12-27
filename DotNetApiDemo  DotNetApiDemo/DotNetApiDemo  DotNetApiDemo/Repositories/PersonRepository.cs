using Dapper;
using DotNetApiDemo__DotNetApiDemo.Models;
using System.Data;
using System.Data.SqlClient;

namespace DotNetApiDemo__DotNetApiDemo.Repositories
{
	public class PersonRepository : IPersonRepository


	{
		private readonly IConfiguration _config;
		private readonly string _connectionString;
		public PersonRepository(IConfiguration config)

		{
			_config = config;
			_connectionString = _config.GetConnectionString("DefaultConnection");
		}

		public async Task AddPerson(Person person)
		{
			using IDbConnection connection = new SqlConnection(_connectionString);
			string sql = "insert into person (name,email) values(@name,@email)";
			await connection.ExecuteAsync(sql, new { person.Name, person.Email }, commandType: CommandType.Text);
		}
		public async Task UpdatePerson(Person person)
		{
			using IDbConnection connection = new SqlConnection(_connectionString);
			string sql = "update person  set name=@name, email=@email where id=@id";
			await connection.ExecuteAsync(sql, new { person.Id, person.Name, person.Email }, commandType: CommandType.Text);
		}

		public async Task<IEnumerable<Person>> GetAllPeople()
		{
			using IDbConnection connection = new SqlConnection(_connectionString);
			string sql = "select * from person";

			var people = await connection.QueryAsync<Person>(sql, commandType: CommandType.Text);
			return people;

		}
		public async Task<Person?> GetPersonById(int id)
		{
			using IDbConnection connection = new SqlConnection(_connectionString);
			string sql = "select * from person where id=@id";

			var people = await connection.QueryAsync<Person>(sql, new { id }, commandType: CommandType.Text);
			return people.FirstOrDefault();

		}
		public async Task DeletePerson(int id)
		{
			using IDbConnection connection = new SqlConnection(_connectionString);
			string sql = "delete from person where id=@id";

			var people = await connection.ExecuteAsync(sql, new { id }, commandType: CommandType.Text);

		}
	}
}

using DotNetApiDemo__DotNetApiDemo.Models;

namespace DotNetApiDemo__DotNetApiDemo.Repositories
{
	public interface IPersonRepository
	{
		Task AddPerson(Person person);
		Task DeletePerson(int id);
		Task<IEnumerable<Person>> GetAllPeople();
		Task<Person?> GetPersonById(int id);
		Task UpdatePerson(Person person);
	}
}
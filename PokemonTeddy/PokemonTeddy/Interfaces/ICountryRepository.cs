using PokemonTeddy.Models;

namespace PokemonTeddy.Interfaces
{
				public interface ICountryRepository
				{
								ICollection<Country> GetCountries();

								Country GetCountry(int countryId);

								Country GetCountryByOwner(int ownerId);

								ICollection<Owner> GetOwnersFromACountry(int countryId);

								bool CountryExists(int id);

								//CreateRequests
								bool CreateCountry(Country 
												country);
								bool Save();

								bool UpdatedCountry(Country country);
								bool DeleteCountry(Country country);
				}
}

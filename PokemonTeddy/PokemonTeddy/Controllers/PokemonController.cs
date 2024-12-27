using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonTeddy.Dtos;
using PokemonTeddy.Interfaces;
using PokemonTeddy.Models;
using PokemonTeddy.Repository;

namespace PokemonTeddy.Controllers
{
				[Route("api/[controller]")]
				[ApiController]
				public class PokemonController : Controller
				{
								private readonly IPokemonRepository _pokemonRepository;
								private readonly IReviewRepository _reviewRepository;
								private readonly IOwnerRepository _ownerRepository;
								private readonly IMapper _mapper;

								public PokemonController(IPokemonRepository pokemonRepository,
												IOwnerRepository ownerRepository,
												IReviewRepository reviewRepository,
												IMapper mapper)
								{
												_pokemonRepository = pokemonRepository;
												_reviewRepository = reviewRepository;
												_ownerRepository = ownerRepository;
												_mapper = mapper;
								}

								[HttpGet]
								[ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
								public IActionResult GetPokemons()
								{
												var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());
												if (!ModelState.IsValid)
												{
																return BadRequest(ModelState);
												}

												return Ok(pokemons);
								}

								[HttpGet("{pokeId}")]
								[ProducesResponseType(200, Type = typeof(Pokemon))]
								[ProducesResponseType(400)]
								public IActionResult GetPokemon(int pokeId)
								{
												if (!_pokemonRepository.PokemonExists(pokeId))
																return NotFound();

												var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokeId));
												if (!ModelState.IsValid)
																return BadRequest(ModelState);
												return Ok(pokemon);
								}

								[HttpGet("{pokeId}/rating")]
								[ProducesResponseType(200, Type = typeof(decimal))]
								[ProducesResponseType(400)]

								public IActionResult GetPokemonRating(int pokeId) {
												if (!_pokemonRepository.PokemonExists(pokeId))
																return NotFound();

												var rating = _pokemonRepository.GetPokemonRating(pokeId);

												if (!ModelState.IsValid)
																return BadRequest(ModelState);

												return Ok(rating);
								}


								[HttpPost]
								[ProducesResponseType(204)]
								[ProducesResponseType(400)]
								public IActionResult CreatePokemon([FromQuery] int ownerId, [FromQuery] int categoryId, [FromBody] PokemonDto pokemonCreate)
								{
												if (pokemonCreate == null) return BadRequest(ModelState);
												var pokemons = _pokemonRepository.GetPokemons().Where(c => c.Name.Trim().ToUpper() == pokemonCreate.Name.TrimEnd().ToUpper
()).FirstOrDefault();

												if (pokemons != null)
												{
																ModelState.AddModelError("", "pokemon already exists");
																return StatusCode(422, ModelState);

												}

												if (!ModelState.IsValid)
																return BadRequest(ModelState);

												var pokemonMap = _mapper.Map<Pokemon>(pokemonCreate);

												if (!_pokemonRepository.CreatePokemon(ownerId, categoryId, pokemonMap))
												{
																ModelState.AddModelError("", "something ent wrong while saving");
																return StatusCode(500, ModelState
																				);
												}
												return Ok("Succesfully created");
								}

								[HttpPut("{pokeId}")]
								[ProducesResponseType(400)]
								[ProducesResponseType(204)]
								[ProducesResponseType(404)]

								public IActionResult UpdatePokemon(
							 int pokeId, 
									[FromQuery] int ownerId,
									[FromQuery]int catId,
									[FromBody] PokemonDto updatedPokemon)

								{
												if (updatedPokemon == null)
																return BadRequest(ModelState);
												if (pokeId != updatedPokemon.Id)
																return BadRequest(ModelState);
												if (!_pokemonRepository.PokemonExists(pokeId))
																return NotFound();
												if (!ModelState.IsValid)
																return BadRequest();

												var pokemonMap = _mapper.Map<Pokemon>(updatedPokemon);
												if (!_pokemonRepository.UpdatePokemon(ownerId,catId,pokemonMap))

												{
																ModelState.AddModelError("", "Something went wrong updating category");
																return StatusCode(500, ModelState);
												}
												return NoContent();
								}

								[HttpDelete("{pokeId}")]
								[ProducesResponseType(400)]
								[ProducesResponseType(204)]
								[ProducesResponseType(404)]

								public IActionResult DeletePokemon(int pokeId)
								{
												if (!_pokemonRepository.
																PokemonExists(pokeId))
																return NotFound();

												var reviewsToDelete = _reviewRepository.GetReviewsOfAPokemon(pokeId);

												var pokemonToDelete = _pokemonRepository.GetPokemon(pokeId);

												if (!ModelState.IsValid)
																return BadRequest(ModelState);

												if (!_reviewRepository.DeleteReviews(reviewsToDelete.ToList()))
												{
																ModelState.AddModelError("", "something went wrong deleting category");
												}


												if (!_pokemonRepository.DeletePokemon(pokemonToDelete))
												{
																				ModelState.AddModelError("", "something went wrong deleting category");
																}
												return NoContent();
								}
				}
}

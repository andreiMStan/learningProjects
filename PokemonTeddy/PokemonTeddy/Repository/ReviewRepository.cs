﻿using PokemonTeddy.Data;
using PokemonTeddy.Interfaces;
using PokemonTeddy.Models;
using System.Diagnostics.Metrics;

namespace PokemonTeddy.Repository
{
				public class ReviewRepository : IReviewRepository
				{
								private readonly DataContext _context;

								public ReviewRepository(DataContext context)
								{
												_context = context;
								}

								public Review GetReview(int reviewId)
								{
												return _context.Reviews.Where(r => r.Id == reviewId).FirstOrDefault();
								}

								public ICollection<Review> GetReviewsOfAPokemon(int pokeId)
								{
												return _context.Reviews.Where(r => r.Id == pokeId).ToList();
								}

								public ICollection<Review> GetReviews()
								{
												return _context.Reviews.ToList();
								}

								public bool ReviewExists(int id)
								{
												return _context.Reviews.Any(r => r.Id == id);
								}

								public bool CreateReview(Review review)
								{
											_context.Add(review);
												return Save();
								}

								public bool Save()
								{
												var saved=_context.SaveChanges();
												return saved > 0 ? true : false;
								}

								public bool UpdateReview(Review review)
								{
												_context.Update(review);
												return Save();
								}

								public bool DeleteReview(Review review)
								{
												_context.Remove(review);
												return Save();
								}	

								public bool DeleteReviews(List<Review> reviews)
								{
												_context.RemoveRange(reviews);
												return Save();
								}
				}
}

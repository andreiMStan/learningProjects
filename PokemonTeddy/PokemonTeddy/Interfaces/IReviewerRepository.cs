﻿using PokemonTeddy.Models;

namespace PokemonTeddy.Interfaces
{
				public interface IReviewerRepository
				{
								ICollection<Reviewer> GetReviewers();

								Reviewer GetReviewer(int reviewerID);

								ICollection<Review> GetReviewsByReviewer(int reviewerId);

								bool ReviewerExists(int id);

								bool CreateReviewer(Reviewer reviewer);
								bool UpdateReviewer(Reviewer reviewer);
								bool DeleteReviewer(Reviewer reviewer);
								bool Save();
				}
}

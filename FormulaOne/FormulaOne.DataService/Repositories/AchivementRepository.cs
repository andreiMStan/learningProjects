using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repositories
{
	public class AchivementRepository : GenericRepository<Achivement>, IAchivementsRepository
	{
		public AchivementRepository(AppDbContext context, ILogger logger) : base(context, logger)
		{
		}

		public async Task<Achivement?> GetDriverAchivementAsync(Guid driverId)
		{
			try
			{


				var result=await _dbSet.FirstOrDefaultAsync(x => x.DriverId == driverId);
				return result;
			}
			catch (Exception e)
			{
				_logger.LogError(e, "{Repo} GetDriverAchivementAsync Function Error", typeof(AchivementRepository));
				throw;

			}
		}

		public override async Task<IEnumerable<Achivement>> All()
		{
			try
			{
				return await _dbSet.Where(x => x.Status == 1)
					.AsNoTracking()
					.AsSplitQuery()
					.OrderBy(x => x.AddedDate)
					.ToListAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, "{Repo} All Function Error", typeof(AchivementRepository));
				throw;
			}
		}

		public override async Task<bool> Delete(Guid id)
		{
			try
			{
				//get my entity
				var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
				if (result == null)
				{

					return false;
				}
				result.Status = 0;
				result.UpdatedDate = DateTime.UtcNow;
				return true;
			}
			catch (Exception e)
			{
				_logger.LogError(e, "{Repo} Delete Function Error", typeof(AchivementRepository));
				throw;
			}
		}
		public override async Task<bool> Update(Achivement achivement)
		{
			try
			{   //get my entity
				var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == achivement.DriverId);
				if (result == null)
					return false;

				result.UpdatedDate = DateTime.UtcNow;
				result.FastestLap = achivement.FastestLap;
				result.PolePosition = achivement.PolePosition;
				result.RaceWins = achivement.RaceWins;
				result.WorldChampionship = achivement.WorldChampionship;
				return true;

			}
			catch (Exception e)
			{
				_logger.LogError(e, "{Repo} Update Function Error", typeof(AchivementRepository));
				throw;

			}
		}

	}
}

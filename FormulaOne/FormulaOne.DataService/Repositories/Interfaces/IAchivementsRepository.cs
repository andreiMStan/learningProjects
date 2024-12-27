﻿using FormulaOne.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repositories.Interfaces
{
	public interface IAchivementsRepository:IGenericRepository<Achivement>
	{
		Task<Achivement?> GetDriverAchivementAsync(Guid driverId);
	}
}

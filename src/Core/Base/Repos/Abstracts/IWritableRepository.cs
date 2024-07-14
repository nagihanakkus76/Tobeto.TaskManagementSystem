using Core.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Base.Repos.Abstracts
{
	public interface IWritableRepository<TEntity> where TEntity : BaseEntity
	{
		Task AddAsync(TEntity entity);
		Task UpdateAsync(TEntity entity);
		Task DeleteAsync(TEntity entity);
	}
}

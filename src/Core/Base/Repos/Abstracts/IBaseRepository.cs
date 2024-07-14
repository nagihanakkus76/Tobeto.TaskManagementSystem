using Core.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Base.Repos.Abstracts
{
	public interface IBaseRepository<TEntity> : IReadableRepository<TEntity>, IWritableRepository<TEntity> where TEntity : BaseEntity
	{
		
	}
}

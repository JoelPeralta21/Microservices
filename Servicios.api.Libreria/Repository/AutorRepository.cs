using Servicios.api.Libreria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.api.Libreria.Core.ContextMongoDb;
using MongoDB.Driver;

namespace Servicios.api.Libreria.Repository
{
	public class AutorRepository : IAutorRepository
	{
		private readonly IAutorContext _autorContext;
		public AutorRepository(IAutorContext autorContext) {
			_autorContext = autorContext;
		}
		public async Task<IEnumerable<Autor>> GetAutores()
		{
			return await _autorContext.Autores.Find(p => true).ToListAsync();
		}
	}
}

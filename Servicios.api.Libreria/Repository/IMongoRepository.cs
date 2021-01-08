using Servicios.api.Libreria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.api.Libreria.Repository
{
	public interface IMongoRepository<TDocument> where TDocument : IDocument
	{
		//IQueryable<TDocument> GetAll();
		Task<IEnumerable<TDocument>> GetAll(); //asincrono
		Task<TDocument> GetById(string Id); //Buscar por Id
		Task InsertDocument(TDocument Document); // Insertar
		Task UpdateDocument(TDocument Document); // Act
		Task DeleteById(string Id); 
	}
}

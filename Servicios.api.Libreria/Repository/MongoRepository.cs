using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Servicios.api.Libreria.Core;
using Servicios.api.Libreria.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.api.Libreria.Repository
{
	public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : IDocument
	{
		private readonly IMongoCollection<TDocument> _collection;

		public MongoRepository(IOptions<MongoSettings> options)
		{
			var client = new MongoClient(options.Value.ConnectionString);
			var _db = client.GetDatabase(options.Value.Database);
			_collection = _db.GetCollection<TDocument>(GetCollectionName(typeof(TDocument))); // devuelve el nombre de la coleccion en un formato string
		}

		private protected string GetCollectionName(Type documentType)
		{
			//retornar el nombre de la coleccion
			return ((BsonCollectionAtribute) documentType.GetCustomAttributes(typeof(BsonCollectionAtribute), true).FirstOrDefault()).CollectionName;
		}
		public async Task<IEnumerable<TDocument>> GetAll()
		{
			return await _collection.Find(p => true).ToListAsync();
		}

		public async Task<TDocument> GetById(string Id) // BUSCAR POR ID
		{
			var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, Id); //es el filtro para buscar por id
			return await _collection.Find(filter).SingleOrDefaultAsync(); //retornamos el filtro asincrono
		}

		public async Task InsertDocument(TDocument Document) // INSERTAR 
		{
			 await _collection.InsertOneAsync(Document);
		}

		public async Task UpdateDocument(TDocument Document) // ACTUALIZAR
		{
			var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, Document.Id);
			await _collection.FindOneAndReplaceAsync(filter, Document);
		}

		public async Task DeleteById(string Id) // ELIMINAR POR ID
		{
			var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, Id);
			await _collection.FindOneAndDeleteAsync(filter);
		}
	}
}

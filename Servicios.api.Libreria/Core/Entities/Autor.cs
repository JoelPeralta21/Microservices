using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.api.Libreria.Core.Entities
{
	public class Autor
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)] //se debe de colocar para hacerle saber que estamos hablando del Id
		public string Id { get; set; }

		[BsonElement("Nombre")] //para mapear como lo tengo en la BD
		public string Nombre { get; set; }

		[BsonElement("Apellido")]
		public string Apellido { get; set; }

		[BsonElement("GradoAcademico")]
		public string GradoAcademico { get; set; }

	}
}

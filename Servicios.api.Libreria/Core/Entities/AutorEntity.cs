using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.api.Libreria.Core.Entities
{
	[BsonCollectionAtribute("Autor")] //como mi clase se llama AutorEntity y mi coleccion es Autor, con esto se realiza el match
	public class AutorEntity : Document
	{
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string GradoAcademico { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.api.Libreria.Core.Entities
{
	[BsonCollectionAtribute("Empleado")]
	public class EmpleadoEntity : Document
	{
		public string Nombre { get; set; }
	}
}

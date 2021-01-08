using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.api.Libreria.Core.Entities
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	public class BsonCollectionAtribute : Attribute
	{
		public string CollectionName { get; }

		public BsonCollectionAtribute(string collectionName)
		{
			CollectionName = collectionName; //Esto es para poder colocarle nombre a las colecciones (tablas)
		}

	}
}

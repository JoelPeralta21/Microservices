using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver; //importo
using Servicios.api.Libreria.Core.Entities; //importo

namespace Servicios.api.Libreria.Core.ContextMongoDb
{
	public interface IAutorContext //lo primero es hacerla publica
	{
		IMongoCollection<Autor> Autores { get; }
	}
}

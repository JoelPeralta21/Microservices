using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.api.Libreria.Core.Entities;
using Servicios.api.Libreria.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.api.Libreria.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LibreriaServicioController : ControllerBase
	{
		private readonly IAutorRepository _AutorRepository;

		private readonly IMongoRepository<AutorEntity> _AutorGenericoRepository;

		private readonly IMongoRepository<EmpleadoEntity> _EmpleadoGenericoRepository;

		public LibreriaServicioController(IAutorRepository AutorRepository, IMongoRepository<AutorEntity> AutorGenericoRepository, IMongoRepository<EmpleadoEntity> EmpleadoGenericoRepository) {
			_AutorRepository = AutorRepository;
			_AutorGenericoRepository = AutorGenericoRepository;
			_EmpleadoGenericoRepository = EmpleadoGenericoRepository;
		}

		[HttpGet("autorGenerico")]
		public async Task<ActionResult<IEnumerable<AutorEntity>>> GetAutorGenerico() {

			var autores = await _AutorGenericoRepository.GetAll();
			return Ok(autores);

		}

		[HttpGet("autores")]
		public async Task<ActionResult<IEnumerable<Autor>>> GetAutores()
		{

			var autores = await _AutorRepository.GetAutores();
			return Ok(autores);

		}


		[HttpGet("empleadoGenerico")]
		public async Task<ActionResult<IEnumerable<EmpleadoEntity>>> GetEmpleadoGenerico()
		{

			var empleados = await _EmpleadoGenericoRepository.GetAll();
			return Ok(empleados);

		}
	}
}

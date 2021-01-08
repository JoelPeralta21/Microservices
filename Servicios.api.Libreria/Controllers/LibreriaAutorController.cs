using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.api.Libreria.Repository;
using Servicios.api.Libreria.Core.Entities;

namespace Servicios.api.Libreria.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LibreriaAutorController : ControllerBase
	{
		//Instancia
		private readonly IMongoRepository<AutorEntity> _AutorGenericoRepository;

		//Constructor
		public LibreriaAutorController(IMongoRepository<AutorEntity> AutorGenericoRepository)
		{
			_AutorGenericoRepository = AutorGenericoRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<AutorEntity>>> Get()
		{
			return Ok(await _AutorGenericoRepository.GetAll());
		}

		[HttpGet("{Id}")]
		public async Task<ActionResult<AutorEntity>> GetById(string Id)
		{
			var autor = await _AutorGenericoRepository.GetById(Id);
			return Ok(autor);
		}

		[HttpPost]
		public async Task Post(AutorEntity Autor)
		{
			await _AutorGenericoRepository.InsertDocument(Autor);
		}

		[HttpPut("{Id}")]
		public async Task Put(string Id, AutorEntity Autor)
		{
		    Autor.Id = Id;
			await _AutorGenericoRepository.UpdateDocument(Autor);
		}

		[HttpDelete("{Id}")]
		public async Task Delete(string Id)
		{
			await _AutorGenericoRepository.DeleteById(Id);
		}
	}
}

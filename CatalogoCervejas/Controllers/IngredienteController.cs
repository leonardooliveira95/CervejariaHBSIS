using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogoCervejas.Aplicacao.Interfaces;
using CatalogoCervejas.Dominio.Interface;
using CatalogoCervejas.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoCervejas.Controllers
{
    [Route("api/[controller]")]
    public class IngredienteController : Controller
    {
        private readonly IIngredienteServico _ingredienteServico;

        public IngredienteController(IIngredienteServico ingredienteServico)
        {
            this._ingredienteServico = ingredienteServico;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            List<IngredienteViewModel> lista = _ingredienteServico.BuscarTodos().ToList();

            return Json(lista);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IngredienteViewModel ingrediente = _ingredienteServico.Buscar(id);

            return Json(ingrediente);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]IngredienteViewModel ingrediente)
        {
            ingrediente = _ingredienteServico.Gravar(ingrediente);

            return Json(ingrediente);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]IngredienteViewModel ingrediente)
        {
            ingrediente = _ingredienteServico.Gravar(ingrediente);

            return Json(ingrediente);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ingredienteServico.Remover(id);
        }
    }
}

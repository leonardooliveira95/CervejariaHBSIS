using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogoCervejas.Aplicacao.Interfaces;
using CatalogoCervejas.Aplicacao.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatalogoCervejas.Controllers
{
    [Route("api/[controller]")]
    public class CervejaController : Controller
    {
        private readonly ICervejaServico _cervejaServico;

        public CervejaController(ICervejaServico cervejaServico)
        {
            _cervejaServico = cervejaServico;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            List<CervejaViewModel> lista = _cervejaServico.BuscarTodos();

            return Json(lista);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Json(_cervejaServico.Buscar(id));
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]CervejaViewModel cerveja)
        {
            return Json(_cervejaServico.Gravar(cerveja));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CervejaViewModel cerveja)
        {
            return Json(_cervejaServico.Gravar(cerveja));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _cervejaServico.Remover(id);
        }
    }
}

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
    public class ReceitaController : Controller
    {
        private readonly IReceitaServico _receitaServico;

        public ReceitaController(IReceitaServico receitaServico)
        {
            this._receitaServico = receitaServico;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return Json(_receitaServico.BuscarTodos());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]ReceitaViewModel receita)
        {
            return Json(_receitaServico.Gravar(receita));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

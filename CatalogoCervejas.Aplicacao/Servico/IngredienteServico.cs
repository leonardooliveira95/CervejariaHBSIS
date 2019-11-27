using AutoMapper;
using CatalogoCervejas.Aplicacao.Interfaces;
using CatalogoCervejas.Infra.Dados.Interfaces;
using CatalogoCervejas.Infra.Dados.Repositorio;
using CatalogoCervejas.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CatalogoCervejas.Dominio.Entidades;

namespace CatalogoCervejas.Servico
{
    public class IngredienteServico : IIngredienteServico
    {
        private readonly IIngredienteRepositorio _ingredienteRepositorio;
        private readonly IMapper _mapper;

        public IngredienteServico(IIngredienteRepositorio ingredienteRepositorio,
            IMapper mapper)
        {
            this._ingredienteRepositorio = ingredienteRepositorio;
            this._mapper = mapper;
        }

        public List<IngredienteViewModel> BuscarTodos()
        {
            return _mapper.Map<List<IngredienteViewModel>>(_ingredienteRepositorio.BuscarTodos().ToList());
        }

        public IngredienteViewModel Buscar(int id)
        {
            return _mapper.Map<IngredienteViewModel>(_ingredienteRepositorio.Buscar(id));
        }

        public IngredienteViewModel Gravar(IngredienteViewModel ingrediente)
        {
            if (ingrediente.Id == 0)
            {
                _ingredienteRepositorio.Inserir(_mapper.Map<Ingrediente>(ingrediente));
            }
            else
            {
                _ingredienteRepositorio.Atualizar(_mapper.Map<Ingrediente>(ingrediente));
            }

            return ingrediente;
        }

        public void Remover(int id)
        {
            _ingredienteRepositorio.Remover(id);
        }
    }
}

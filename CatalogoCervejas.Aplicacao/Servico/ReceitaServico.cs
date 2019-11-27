using AutoMapper;
using CatalogoCervejas.Aplicacao.Interfaces;
using CatalogoCervejas.Aplicacao.ViewModels;
using CatalogoCervejas.Dominio.Entidades;
using CatalogoCervejas.Infra.Dados.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoCervejas.Aplicacao.Servico
{
    public class ReceitaServico : IReceitaServico
    {
        private readonly IReceitaRepositorio _receitaRepositorio;
        private readonly IMapper _mapper;

        public ReceitaServico(IReceitaRepositorio receitaRepositorio,
            IMapper mapper)
        {
            this._receitaRepositorio = receitaRepositorio;
            this._mapper = mapper;
        }

        public List<ReceitaViewModel> BuscarTodos()
        {
            return _mapper.Map<List<ReceitaViewModel>>(_receitaRepositorio.BuscarTodos());
        }

        public ReceitaViewModel Gravar(ReceitaViewModel receita)
        {
            if (receita.Id == 0)
            {
                _receitaRepositorio.Inserir(_mapper.Map<Receita>(receita));
            }
            else
            {
                _receitaRepositorio.Atualizar(_mapper.Map<Receita>(receita));
            }

            return receita;
        }
    }
}

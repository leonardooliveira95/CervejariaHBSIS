using AutoMapper;
using CatalogoCervejas.Aplicacao.Interfaces;
using CatalogoCervejas.Aplicacao.ViewModels;
using CatalogoCervejas.Infra.Dados.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CatalogoCervejas.Dominio.Entidades;

namespace CatalogoCervejas.Aplicacao.Servico
{
    public class CervejaServico : ICervejaServico
    {
        private readonly ICervejaRepositorio _cervejaRepositorio;
        private readonly IMapper _mapper;

        public CervejaServico(ICervejaRepositorio cervejaRepositorio,
                            IMapper mapper)
        {
            this._cervejaRepositorio = cervejaRepositorio;
            this._mapper = mapper;
        }

        public CervejaViewModel Buscar(int id)
        {
            return _mapper.Map<CervejaViewModel>(_cervejaRepositorio.Buscar(id));
        }

        public List<CervejaViewModel> BuscarTodos()
        {
            return _mapper.Map<List<CervejaViewModel>>(_cervejaRepositorio.BuscarTodos().ToList());
        }

        public CervejaViewModel Gravar(CervejaViewModel cerveja)
        {
            if (cerveja.Id == 0)
            {
                _cervejaRepositorio.Inserir(_mapper.Map<Cerveja>(cerveja));
            }
            else
            {
                _cervejaRepositorio.Atualizar(_mapper.Map<Cerveja>(cerveja));
            }

            return cerveja;
        }

        public void Remover(int id)
        {
            _cervejaRepositorio.Remover(id);
        }
    }
}

using AutoMapper;
using CatalogoCervejas.Aplicacao.ViewModels;
using CatalogoCervejas.Dominio.Entidades;
using CatalogoCervejas.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CatalogoCervejas.Aplicacao.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Ingrediente, IngredienteViewModel>();
            CreateMap<Cerveja, CervejaViewModel>()
                .ForMember(model => model.Ingredientes, opt => opt.MapFrom(src => src.Ingredientes.Select(x => new IngredienteViewModel { Id = x.IngredienteId, Nome = x.Ingrediente.Nome })));

            CreateMap<IngredientesReceitas, IngredienteReceitaViewModel>();
            CreateMap<Receita, ReceitaViewModel>();
        }
    }
}

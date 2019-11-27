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
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<IngredienteViewModel, Ingrediente>();
            CreateMap<CervejaViewModel, Cerveja>()
                .ForMember(model => model.Ingredientes, opt => opt.MapFrom(src => src.Ingredientes.Select(x => new IngredientesCervejas() { CervejaId = src.Id, IngredienteId = x.Id })));

            CreateMap<IngredienteReceitaViewModel, IngredientesReceitas>()
                .ForMember(x => x.Ingrediente, opt => opt.Ignore());
            
            CreateMap<ReceitaViewModel, Receita>()
                .ForMember(x => x.Cerveja, opt => opt.Ignore());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VidlyNew.Dtos;
using VidlyNew.Models;

namespace VidlyNew.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //domain to dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            Mapper.CreateMap<Movie,MovieDto>();
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<Rental, NewRentalDto>();
            

            //dto to domain        
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            
            Mapper.CreateMap<MembershipTypeDto, MembershipType>();

            Mapper.CreateMap<NewRentalDto, Rental>()
                .ForMember(r=> r.Id, opt=> opt.Ignore());
           
                


        }
    }
}
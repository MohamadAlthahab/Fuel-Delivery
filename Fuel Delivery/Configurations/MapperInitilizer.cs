﻿using AutoMapper;
using Fuel_Delivery.Data;
using Fuel_Delivery.Model;
using System.Runtime;

namespace Fuel_Delivery.Configurations
{
    public class MapperInitilizer : Profile 
    {
        public MapperInitilizer() 
        {
            CreateMap<User, NewUserDTO>().ReverseMap();
            CreateMap<User , LoginUserDTO>().ReverseMap();
            CreateMap<Driver, DriverDTO>().ReverseMap();
            CreateMap<Fuel, FuelDTO>().ReverseMap();
        }
    }
}
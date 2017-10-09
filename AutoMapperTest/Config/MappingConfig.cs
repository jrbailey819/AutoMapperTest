using AutoMapper;
using AutoMapperTest.ApiModels;
using AutoMapperTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperTest.Config
{
    public class MappingConfig
    {
        public void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserDto, User>()
                    .ForMember(u => u.Addresses, op => op.Ignore());
                cfg.CreateMap<Address, AddressDto>();
                cfg.CreateMap<AddressDto, Address>();
            });
        }

        public MapperConfiguration GetConfig()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserDto, User>()
                    .ForMember(u => u.Addresses, op => op.Ignore());
                cfg.CreateMap<Address, AddressDto>();
                cfg.CreateMap<AddressDto, Address>();
            });
        }
    }
}

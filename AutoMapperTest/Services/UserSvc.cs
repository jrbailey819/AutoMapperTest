using AutoMapper;
using AutoMapperTest.ApiModels;
using AutoMapperTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapperTest.Config;

namespace AutoMapperTest.Services
{
    public class UserSvc
    {
        private List<User> _users;
        private IMapper _mapper;

        public UserSvc(IMapper mapper)
        {
            _mapper = mapper;
            LoadUsers();
        }

        public IList<UserDto> GetAll()
        {
            return _users
                .Select(u => _mapper.Map<UserDto>(u))
                .ToList();
        }

        public UserDto GetById(int id)
        {
            return _users
                .Where(u => u.Id == id)
                .Select(u => _mapper.Map<UserDto>(u))
                .FirstOrDefault();
        }

        public void Update(UserDto userDto, string currentUser)
        {
            var user = _users
                .Where(u => u.Id == userDto.Id)
                .FirstOrDefault();

            if (user != null)
            {
                _mapper.Map(userDto, user);
                user.ModifiedBy = currentUser;
                user.ModifiedDate = DateTime.UtcNow;
                _mapper.MapCollection(userDto.Addresses, user.Addresses, currentUser);
            }
        }

        #region
        private void LoadUsers()
        {
            _users = new List<User>
            {
                new User
                {
                    Id = 1,
                    First = "John",
                    Last = "Doe",
                    Email = "j.doe@wren.com",
                    Addresses = new List<Address>
                    {
                        new Address
                        {
                            Id = 100,
                            Line1 = "1 Main",
                            Line2 = "Apt 100",
                            City = "San Diego",
                            State = "CA",
                            CreatedBy = "admin",
                            CreatedDate = DateTime.UtcNow,
                            ModifiedBy = "admin",
                            ModifiedDate = DateTime.UtcNow
                        }
                    },
                    CreatedBy = "admin",
                    CreatedDate = DateTime.UtcNow,
                    ModifiedBy = "admin",
                    ModifiedDate = DateTime.UtcNow
                },
                new User
                {
                    Id =2,
                    First = "Jane",
                    Last = "Air",
                    Email = "j.air@wren.com",
                    Addresses = new List<Address>
                    {
                        new Address
                        {
                            Id = 100,
                            Line1 = "1 Main",
                            Line2 = "Apt 100",
                            City = "San Diego",
                            State = "CA",
                            CreatedBy = "admin",
                            CreatedDate = DateTime.UtcNow,
                            ModifiedBy = "admin",
                            ModifiedDate = DateTime.UtcNow
                        }
                    },
                    CreatedBy = "admin",
                    CreatedDate = DateTime.UtcNow,
                },
                new User
                {
                    Id = 3,
                    First = "Jack",
                    Last = "Black",
                    Email = "j.black@wren.com",
                    Addresses = new List<Address>(),
                    CreatedBy = "admin",
                    CreatedDate = DateTime.UtcNow,
                    ModifiedBy = "admin",
                    ModifiedDate = DateTime.UtcNow
                },
            };
        }
        #endregion
    }
}

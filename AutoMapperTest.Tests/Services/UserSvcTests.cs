using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapperTest.Services;
using AutoMapperTest.Config;
using AutoMapperTest.ApiModels;
using System.Collections.Generic;

namespace AutoMapperTest.Tests.Services
{
    [TestClass]
    public class UserSvcTests
    {
        private UserSvc _userSvc;

        [TestInitialize]
        public void Initialize()
        {
            var mapper = new MappingConfig().GetConfig().CreateMapper();

            _userSvc = new UserSvc(mapper);
        }

        [TestMethod]
        public void GetAll_Success()
        {
            // Act
            var result = _userSvc.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            UserDto userDto = result[0];
            Assert.AreEqual(1, userDto.Id);
            Assert.AreEqual("John", userDto.First);
            Assert.AreEqual("Doe", userDto.Last);
            Assert.IsNotNull(userDto.Addresses);
            Assert.AreEqual(1, userDto.Addresses.Count);
            AddressDto addressDto = userDto.Addresses[0];
            Assert.AreEqual("1 Main", addressDto.Line1);
            Assert.AreEqual("Apt 100", addressDto.Line2);
            Assert.AreEqual("San Diego", addressDto.City);
            Assert.AreEqual("CA", addressDto.State);
        }

        [TestMethod]
        public void GetById_Success()
        {
            // Act
            var result = _userSvc.GetById(3);

            // Assert
            Assert.AreEqual(3, result.Id);
            Assert.AreEqual("Jack", result.First);
            Assert.AreEqual("Black", result.Last);
        }

        [TestMethod]
        public void Update_Success()
        {
            // Arrange
            var userDto = new UserDto
            {
                Id = 2,
                First = "Jill",
                Last = "Stein",
                Email = "j.stein.wren.com",
                Addresses = new List<AddressDto>
                {
                    new AddressDto
                    {
                        Id = 100,
                        Line1 = "1 Main",
                        Line2 = "Apt 101",
                        City = "San Diego",
                        State = "CA",
                    },
                    new AddressDto
                    {
                        Id = -1,
                        Line1 = "2 Main",
                        Line2 = "Apt 102",
                        City = "San Diego",
                        State = "CA",
                    }
                },
            };

            // Act
            _userSvc.Update(userDto, "supervisor");
            var result = _userSvc.GetById(2);

            // Assert
            Assert.AreEqual(userDto.Id, result.Id);
            Assert.AreEqual(userDto.First, result.First);
            Assert.AreEqual(userDto.Last, result.Last);
            Assert.AreEqual(userDto.Email, result.Email);
        }

    }
}

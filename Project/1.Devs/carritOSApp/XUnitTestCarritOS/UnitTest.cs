using carritOSCore.Model.RepositoryImpl;
using carritOSCore.Model.Context;
using carritOSCore.Model.Entities;
using carritOSCore.Model.Repository;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestCarritOS
{
    public class UnitTest
    {
        [Fact]
        public void Test_RegistrarBusinessOwner(){

            BusinessOwner businessOwner = new BusinessOwner {
                FirstName = "Diego",
                LastName = "Alosilla",
                Email = "deigoalosilla@gmail.com",
                Movil = "966450252",
                Password = "1234",
                City = "Lima",
                Country = "Peru"
            };

            var mock = new Mock<IBusinessOwnerRepository>();
            mock.Setup(x => x.Save(businessOwner)).Returns(true);

            var resul = mock.Object.Save(businessOwner);
            Assert.True(resul);
        }

        [Fact]
        public void Test_ListarBusinessOwner(){
            var listOfBusinessOwner = new List<BusinessOwner>
            {
                new BusinessOwner
                {
                    FirstName = "Diego",
                    LastName = "Alosilla",
                    Email = "deigoalosilla@gmail.com",
                    Movil = "966450252",
                    Password = "1234",
                    City = "Lima",
                    Country = "Peru",
                }
            };
            BusinessOwner businessOwner = new BusinessOwner();

            var mock = new Mock<IBusinessOwnerRepository>();
            mock.Setup(x => x.FindAll()).Returns(listOfBusinessOwner);
            var result = mock.Object.FindAll();
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_EditarBusinessOwner(){
            BusinessOwner businessOwner = new BusinessOwner
            {
                FirstName = "Luis",
                LastName = "Kcomt",
                Email = "luiskcomt@gmail.com",
                Movil = "968395955",
                Password = "1234",
                City = "Lima",
                Country = "Peru"
            };
            var mock = new Mock<IBusinessOwnerRepository>();
            mock.Setup(x => x.Update(businessOwner)).Returns(true);
            var resultado = mock.Object.Update(businessOwner);
            Assert.True(resultado);
        }

        [Fact]
        public void Test_EliminarBusinessOwner(){
            BusinessOwner businessOwner = new BusinessOwner
            {
                FirstName = "Luis",
                LastName = "Kcomt",
                Email = "luiskcomt@gmail.com",
                Movil = "968395955",
                Password = "1234",
                City = "Lima",
                Country = "Peru"
            };
            var mock = new Mock<IBusinessOwnerRepository>();
            mock.Setup(x => x.Delete(businessOwner)).Returns(true);
            var result = mock.Object.Delete(businessOwner);
            Assert.True(result);
        }

    }
}

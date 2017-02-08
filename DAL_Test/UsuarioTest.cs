using System;
using System.Configuration;
using System.Security.Cryptography;
using DAL.Dao;
using ET;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Business_Test
{
    [TestClass]
    public class UsuarioTest
    {
        [TestMethod]
        public void AddTest()
        {
            RolImpl rolImpl = new RolImpl();
            Rol rol = new Rol();
            rol.Id = 1;
            rol.Nombre = "nombre";
            bool result = rolImpl.Add(rol);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void DeleteTest()
        {
            RolImpl rolImpl = new RolImpl();

            bool result = rolImpl.Delete(8);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ListTest()
        {
            RolImpl rolImpl = new RolImpl();

            var result = rolImpl.GetAll();

            Assert.IsTrue(result.Count > 0);
        }
    }
}

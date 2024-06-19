
using DemoApp.Classes;
using DemoApp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAuthorization()
        {
            List<Users> users = new List<Users>
            {
                new Users { login = "kasoo", password = "root" },
                new Users { login = "user1", password = "pass1" }
            };

            var auth = new Auth(users);
            bool result = auth.SignIn("kasoo", "root");
            Assert.AreEqual(true, result);
        }
    }
}

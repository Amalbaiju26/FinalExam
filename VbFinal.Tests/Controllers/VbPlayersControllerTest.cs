using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VbFinal.Controllers;
using VbFinal.Models;

namespace VbFinal.Tests.Controllers
{
    [TestClass]
    public class VbPlayersControllerTest
    {
        VbPlayersController controller;
        Mock<IMockVbPlayer> mock;
        List<VbPlayer> vbPlayers;

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<IMockVbPlayer>();

            vbPlayers = new List<VbPlayer>
            {
                new VbPlayer
                {
                    VbPlayerId = 961,
                    FirstName = "Lori",
                    Lastname = "S",
                    Photo = "https://img.icons8.com/color/384/beach-volleyball.png"
                },
                new VbPlayer
                {
                    VbPlayerId = 961,
                    FirstName = "Zak",
                    Lastname = "N",
                    Photo = "https://img.icons8.com/ultraviolet/384/beach-volleyball.png"
                }
            };

            mock.Setup(m => m.VbPlayers).Returns(vbPlayers.AsQueryable());
            controller = new VbPlayersController(mock.Object);

        }
        [TestMethod]
        public void IndexViewLoads()
        {
            //act
            ViewResult result = controller.Index() as ViewResult;
            //assert
            Assert.AreEqual("Index", result.ViewName);
        }
        [TestMethod]
        public void EditInvalidId()
        {
            controller.ModelState.AddModelError("Deatails", "error");
            // act
            ViewResult result = controller.Edit(vbPlayers[0]) as ViewResult;

            // assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void EditsaveInvalid()
        {
            controller.ModelState.AddModelError("Deatails", "error");
            // act
            ViewResult result = controller.Edit(vbPlayers[0]) as ViewResult;

            // assert
            Assert.AreEqual("Edit", result.ViewName);
        }
    }
}

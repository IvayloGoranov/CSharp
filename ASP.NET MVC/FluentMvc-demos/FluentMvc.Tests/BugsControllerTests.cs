using BugTracker.Data;
using FluentMvc.App.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using TestStack.FluentMVCTesting;

namespace FluentMvc.Tests
{
    [TestClass]
    public class BugsControllerTests
    {
        [TestMethod]
        public void Index_ShouldPass()
        {
            var controller = new BugsController();
            controller.WithCallTo(c => c.Index())
                .ShouldRenderDefaultView()
                .WithModel<IList<Bug>>();
        }

        [TestMethod]
        public void Details_NullParameter_BadRequest()
        {
            var controller = new BugsController();
            controller.WithCallTo(c => c.Details(null))
                .ShouldGiveHttpStatus(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void Details_InvalidId_NotFound()
        {
            var controller = new BugsController();
            controller.WithCallTo(c => c.Details(-1))
                .ShouldGiveHttpStatus(HttpStatusCode.NotFound);
        }

        [TestMethod]
        public void Details_CorrectId()
        {
            var controller = new BugsController();
            var bug = new Bug()
            {
                Text = "New Bug"
            };
            controller.Create(bug);

            controller.WithCallTo(c => c.Details(1))
                .ShouldRenderDefaultView()
                .WithModel<Bug>(c => c.Text == "New Bug");
        }

        [TestMethod]
        public void Create_GetMethod()
        {
            var controller = new BugsController();
            controller.WithCallTo(c => c.Create())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Create_PostMethod()
        {
            var controller = new BugsController();
            controller.WithCallTo(c => c.Create(new Bug()
            {
                Text = "Simple Bug",
                Status = BugStatus.New,
                DateCreated = DateTime.Now
            }))
                .ShouldRedirectTo(c => c.Index());
        }

        [TestMethod]
        public void TestJson()
        {
            var controller = new BugsController();
            controller.WithCallTo(c => c.ToJson())
                .ShouldReturnJson();
        }
    }
}

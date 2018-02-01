using FluentMvc.App.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.FluentMVCTesting;

namespace FluentMvc.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void Index_ShouldPass()
        {
            var controller = new HomeController();
            controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView();
        }
    }
}

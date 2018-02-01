namespace LinkedIn.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TestStack.FluentMVCTesting;

    using LinkedIn.Web.Controllers;
    using LinkedIn.Data;
    using LinkedIn.Web.Infrastructure.CacheService;

    [TestClass]
    public class GroupsControllerTests
    {
        [TestMethod]
        public void TestIndexAction_ShouldReturnDefaultView()
        {
            var data = new LinkedInData(new LinkedInContext());
            var controller = new GroupsController(data, new MemoryCacheService(data));
            controller.WithCallTo(x => x.Index()).ShouldRenderDefaultView();
        }
    }
}

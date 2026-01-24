using LMWDev.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Moq;
using System;
using Xunit;

namespace LMWDev_Test.Controllers
{
    public class AccessibilityControllerTests
    {
        private AccessibilityController CreateController(HttpContext context)
        {
            var controller = new AccessibilityController();
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = context
            };

            // Needed for Url.Action to work
            var urlHelper = new Mock<IUrlHelper>();
            urlHelper
                .Setup(u => u.Action(It.IsAny<UrlActionContext>()))
                .Returns("/Home/Index");

            controller.Url = urlHelper.Object;

            return controller;
        }

        [Fact]
        public void TogglesBackground_WhenInitiallyFalse()
        {
            var context = new DefaultHttpContext();
            context.Session = new TestSession();
            context.Request.Headers["Referer"] = "https://example.com/page";
            context.Request.Scheme = "https";
            context.Request.Host = new HostString("example.com");

            var controller = CreateController(context);

            var result = controller.SetBackgroundActive();

            Assert.Equal("true", context.Session.GetString("BackgroundDisabled"));
            Assert.IsType<RedirectResult>(result);
            Assert.Equal("https://example.com/page", ((RedirectResult)result).Url);
        }

        [Fact]
        public void TogglesBackground_WhenInitiallyTrue()
        {
            var context = new DefaultHttpContext();
            context.Session = new TestSession();
            context.Session.SetString("BackgroundDisabled", "true");

            context.Request.Headers["Referer"] = "https://example.com/page";
            context.Request.Scheme = "https";
            context.Request.Host = new HostString("example.com");

            var controller = CreateController(context);

            var result = controller.SetBackgroundActive();

            Assert.Equal("false", context.Session.GetString("BackgroundDisabled"));
            Assert.Equal("https://example.com/page", ((RedirectResult)result).Url);
        }

        [Fact]
        public void RedirectsToHome_WhenRefererMissing()
        {
            var context = new DefaultHttpContext();
            context.Session = new TestSession();
            context.Request.Scheme = "https";
            context.Request.Host = new HostString("example.com");

            var controller = CreateController(context);

            var result = controller.SetBackgroundActive();

            Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/Index", ((RedirectResult)result).Url);
        }

        [Fact]
        public void RedirectsToHome_WhenRefererInvalidHost()
        {
            var context = new DefaultHttpContext();
            context.Session = new TestSession();
            context.Request.Headers["Referer"] = "https://malicious.com/phish";
            context.Request.Scheme = "https";
            context.Request.Host = new HostString("example.com");

            var controller = CreateController(context);

            var result = controller.SetBackgroundActive();

            Assert.Equal("/Home/Index", ((RedirectResult)result).Url);
        }
        public class TestSession : ISession
        {
            private readonly Dictionary<string, byte[]> _store = new();

            public IEnumerable<string> Keys => _store.Keys;

            public string Id => Guid.NewGuid().ToString();

            public bool IsAvailable => true;

            public void Clear() => _store.Clear();

            public Task CommitAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;

            public Task LoadAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;

            public void Remove(string key) => _store.Remove(key);

            public void Set(string key, byte[] value) => _store[key] = value;

            public bool TryGetValue(string key, out byte[] value) => _store.TryGetValue(key, out value);
        }
    }
}
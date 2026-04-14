using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMWDev_Test.Controllers
{
    using LMWDev.Controllers;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class FakeSession : ISession
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

        public bool TryGetValue(string key, out byte[] value)
            => _store.TryGetValue(key, out value);
    }

    public class CookieControllerTests
    {
        [Theory]
        [InlineData(true, "true")]
        [InlineData(false, "false")]
        public void Set_ShouldStoreValueInSession_AndReturnOk(bool input, string expected)
        {
            // Arrange
            var controller = new CookieController();

            var httpContext = new DefaultHttpContext();
            httpContext.Session = new FakeSession();

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };

            // Act
            var result = controller.Set(input);

            // Assert
            Assert.True(httpContext.Session.TryGetValue("CookieApproved", out var storedBytes));

            var storedValue = Encoding.UTF8.GetString(storedBytes);
            Assert.Equal(expected, storedValue);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(input, okResult.Value);
        }
    }
}

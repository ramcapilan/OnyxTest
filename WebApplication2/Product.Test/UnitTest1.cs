using Microsoft.AspNetCore.Mvc.Testing;

namespace Product.Test
{
    [TestClass]
    public class ApiTests
    {
        [TestMethod]
        public async void TestMethod1()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateDefaultClient();

            var response = await httpClient.GetAsync("");
            var stringResults = await response.Content.ReadAsStringAsync();

            Assert.AreEqual("OK", stringResults);


        }


    }
}
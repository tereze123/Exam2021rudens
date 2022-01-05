namespace Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    [TestClass]
    public class ChromeDriverTest
    {
        private ChromeDriver _driver;

        [TestInitialize]
        public void ChromeDriverInitialize()
        {
            var options = new ChromeOptions();
            options.AddExcludedArgument("enable-logging");
            _driver = new ChromeDriver(@"C:\Browser_drivers\", options);
        }

        /// <summary>
        /// Checks, that element with an id "gh-ac" exists.
        /// </summary>
        [TestMethod]
        public void Test1_field()
        {
            // Act.
            _driver.Url = "https://www.ebay.com/";
            var element = _driver.FindElement(By.Id("gh-ac"));

            // Assert
            Assert.IsNotNull(element);
        }

        /// <summary>
        /// Checks, that element with an id "gh-btn" exists.
        /// </summary>
        [TestMethod]
        public void Test2_field()
        {
            // Act.
            _driver.Url = "https://www.ebay.com/";
            var element = _driver.FindElement(By.Id("gh-btn"));

            // Assert
            Assert.IsNotNull(element);
        }

        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}

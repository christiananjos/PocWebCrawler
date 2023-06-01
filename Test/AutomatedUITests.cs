using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Test
{
    [TestClass]
    public class AutomatedUITests : IDisposable
    {
        private readonly IWebDriver _driver;

        private readonly string _titulo;
        private readonly string _professor;
        private readonly string _cargaHoraria;
        private readonly string _Descricao;

        public AutomatedUITests()
        {
            _driver = new ChromeDriver();
        }

        public void Dispose()
        {
            //_driver.Quit();
            //_driver.Dispose();

        }

        [TestMethod]
        public void Create_WhenExecuted_ReturnsCreateView()
        {
            _driver.Navigate()
                .GoToUrl("https://www.alura.com.br/");

            _driver.FindElement(By.Id("header-barraBusca-form-campoBusca"))
                .SendKeys("RPA");

            _driver.FindElement(By.ClassName("header-barraBusca-form-submit"))
                .Click();

        }
    }
}
using Console.Models;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Console
{
    public class Program : IDisposable
    {
        private readonly IWebDriver _driver = new ChromeDriver();
        private readonly string _titulo;
        private readonly string _professor;
        private readonly string _cargaHoraria;
        private readonly string _Descricao;
        private readonly IConfiguration _configuration;

        private IWebElement resultadoBusca
        {
            get
            {
                return _driver.FindElement(By.ClassName("busca-resultado-link"));
            }
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        public Program() => _driver = new ChromeDriver();



        static void Main()
        {
            var driver = new ChromeDriver();

            driver.Navigate()
              .GoToUrl("https://www.alura.com.br/");

            driver.FindElement(By.Id("header-barraBusca-form-campoBusca"))
                .SendKeys("RPA");

            driver.FindElement(By.ClassName("header-barraBusca-form-submit"))
                .Click();

            Thread.Sleep(5000);

            var test = driver.FindElements(By.ClassName("busca-resultado-nome"))
                .Where(x => x.Text.Contains("RPA")).ToList();

            var listCourse = new List<CourseDetails>();

            foreach (var item in test)
            {

                item.Click();

                Thread.Sleep(5000);

                var titulo = driver.FindElement(By.ClassName("curso-banner-course-title")).Text;
                var professor = driver.FindElement(By.ClassName("instructor-title--name")).Text;
                var cargaHoraria = driver.FindElement(By.ClassName("courseInfo-card-wrapper-infos")).Text.Trim('h');


                var listDescricao = driver.FindElements(By.ClassName("course-list--learn")).Select(x => x.Text).ToList();

                string descricao = string.Join("\n", listDescricao);

                var detailCourse = new CourseDetails()
                {
                    CourseDetailsId = new Guid(),
                    Title = titulo,
                    Description = descricao,
                    Hours = Convert.ToInt32(cargaHoraria),
                    TeacherName = professor
                };

                listCourse.Add(detailCourse);

                
            }

            var text = listCourse;

        }


    }
}

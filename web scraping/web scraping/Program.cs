using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace web_scraping
{
    class Program
    {
        static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            //options.AddArgument("headless");

            WebDriver driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
            driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));

            driver.Url = "https://symptomchecker.webmd.com/symptoms-a-z";
            List<Symptom> elencosintomi = new List<Symptom>();

            // Thread.Sleep(1000);
            
            driver.FindElement(By.CssSelector("li#tab2")).Click();
            int x = 1;
            int id = 1;
            while (x <= 26)
            {
                driver.FindElement(By.XPath($"/html/body/div[2]/div/div[3]/div[1]/div[2]/div[2]/div/div/div[4]/form/div[3]/div[2]/div/div[2]/ul/li[{x}]/a")).Click();
                if(x != 11 && x != 17 && x != 24 && x != 26)
                {
                    if(x == 15)
                    {
                        int y = 1;
                        var element = driver.FindElement(By.XPath($"/html/body/div[2]/div/div[3]/div[1]/div[2]/div[2]/div/div/div[4]/form/div[3]/div[2]/div/div[2]/div/div[{x}]"));
                        while (y <= 1)
                        {
                            var ele = driver.FindElement(By.XPath($"/html/body/div[2]/div/div[3]/div[1]/div[2]/div[2]/div/div/div[4]/form/div[3]/div[2]/div/div[2]/div/div[{x}]/ol"));
                            int righe = driver.FindElements(By.XPath($"/html/body/div[2]/div/div[3]/div[1]/div[2]/div[2]/div/div/div[4]/form/div[3]/div[2]/div/div[2]/div/div[{x}]/ol/li")).Count;
                            int z = 1;
                            while (z <= righe)
                            {

                                Symptom nuovosintomo = new Symptom();
                                var el = driver.FindElement(By.XPath($"/html/body/div[2]/div/div[3]/div[1]/div[2]/div[2]/div/div/div[4]/form/div[3]/div[2]/div/div[2]/div/div[{x}]/ol/li/a"));
                                nuovosintomo.id = id;
                                nuovosintomo.sintomo = el.Text;
                                elencosintomi.Add(nuovosintomo);
                                id++;
                                z++;
                            }
                            y++;
                        }
                    }
                    else
                    {
                        int y = 1;
                        var element = driver.FindElement(By.XPath($"/html/body/div[2]/div/div[3]/div[1]/div[2]/div[2]/div/div/div[4]/form/div[3]/div[2]/div/div[2]/div/div[{x}]"));
                        while (y <= 2)
                        {
                            var ele = driver.FindElement(By.XPath($"/html/body/div[2]/div/div[3]/div[1]/div[2]/div[2]/div/div/div[4]/form/div[3]/div[2]/div/div[2]/div/div[{x}]/ol[{y}]"));
                            int righe = driver.FindElements(By.XPath($"/html/body/div[2]/div/div[3]/div[1]/div[2]/div[2]/div/div/div[4]/form/div[3]/div[2]/div/div[2]/div/div[{x}]/ol[{y}]/li")).Count;
                            int z = 1;
                            while (z <= righe)
                            {

                                Symptom nuovosintomo = new Symptom();
                                var el = driver.FindElement(By.XPath($"/html/body/div[2]/div/div[3]/div[1]/div[2]/div[2]/div/div/div[4]/form/div[3]/div[2]/div/div[2]/div/div[{x}]/ol[{y}]/li[{z}]/a"));
                                nuovosintomo.id = id;
                                nuovosintomo.sintomo = el.Text;
                                elencosintomi.Add(nuovosintomo);
                                id++;
                                z++;
                            }
                            y++;
                        }
                    }
                }
                x++;
            }
            
            //int righe = driver.FindElements(By.ClassName("body-parts-list")).Count;
            //var element = driver.FindElements(By.ClassName("body-parts-list"));
            //int x = 0;

            //while (x < righe - 1)
            //{
            //    Symptom nuovosintomo = new Symptom();
            //    x++;
            //}


            //var element = driver.FindElements(By.ClassName("sg-col-4-of-12"));
            //string pagesource = driver.PageSource;
            //foreach (WebElement ele in element)
            //{
            //    Guid guid = Guid.NewGuid();
            //    try
            //    {
            //        Prodotto product = new Prodotto();
            //        product.Id = guid.ToString();
            //        product.Name = ele.FindElement(By.ClassName("a-size-base-plus")).Text;
            //        product.Price = decimal.Parse(ele.FindElement(By.ClassName("a-price-whole")).Text) + ele.FindElement(By.ClassName("a-price-symbol")).Text;
            //        product.PathPhoto = ele.FindElement(By.ClassName("s-image")).GetAttribute("src");
            //        product.Link = ele.FindElement(By.ClassName("a-link-normal")).GetAttribute("href");
            //        product.IdEcommerce = "A";
            //        product.Position = position;
            //        elencoProdotti.Add(product);
            //        position++;
            //    }
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //}

        }
    }
}

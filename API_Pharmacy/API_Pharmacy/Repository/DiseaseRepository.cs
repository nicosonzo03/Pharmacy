using API_Pharmacy.Context;
using API_Pharmacy.Entities;
using API_Pharmacy.Interfaces;
using Dapper;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace API_Pharmacy.Repository
{
    public class DiseaseRepository : IDiseaseRepository
    {
        public List<Disease> nuovaMalattia(List<string> elencosintomi)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            options.AddArgument("--start-maximized");
            //options.AddArgument("headless");

            WebDriver driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
            driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));

            driver.Url = "https://symptomchecker.webmd.com/";

            List<Disease> elencomalattie = new List<Disease>();

            // Thread.Sleep(1000);

            driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[1]/div/div[2]/div/button[1]")).Click();

            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div[2]/form/div[1]/div/div/input")).SendKeys("50");
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div[2]/form/div[2]/div/button[1]")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div[2]/button")).Click();

            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[3]/div[1]/div[1]/div[2]/input")).SendKeys("testicles tender to touch");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[3]/div[1]/div[1]/div[2]/ul[1]/li[1]/a")).Click();


            Thread.Sleep(1000);

            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[3]/div[2]/button[2]")).Click();

            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[3]/div[2]/button[2]")).Click();

            Thread.Sleep(1000);

            if (driver.PageSource.Contains("We are unable to find any conditions that match the symptoms you entered."))
            {
                return elencomalattie.ToList();
            }
            else
            {
                int li = driver.FindElements(By.XPath("/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[3]/div[2]/div[1]/div/div/ul/li")).Count;
                int x = 1;
                while (x <= li)
                {
                    Disease nuovamalattia = new Disease();

                    if (x != 1)
                    {
                        driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[1]/div/div/ul/div/button")).Click();
                    }

                    bool check = false;
                    while (check == false)
                    {
                        try
                        {
                            driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[3]/div[2]/div[1]/div/div/ul/li[{x}]/div[2]")).Click();
                            check = true;
                        }
                        catch (WebDriverException e)
                        {
                            e.StackTrace.ToString();
                        }
                    }

                    if (driver.PageSource.Contains(" Please contact your doctor or call 911 ") && (!driver.PageSource.Contains("? Find Out More")))
                    {
                        Thread.Sleep(1000);
                        bool ok = false;
                        while (ok == false)
                        {
                            try
                            {
                                driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[4]/div/div[4]/div[1]/p/a")).Click();
                                ok = true;
                            }
                            catch (WebDriverException e)
                            {
                                e.StackTrace.ToString();
                            }
                        }

                        int sez = 1;
                        int sezioni = driver.FindElements(By.ClassName("article-section")).Count;

                        Guid guid = Guid.NewGuid();
                        nuovamalattia.Id = guid.ToString();
                        nuovamalattia.Name = driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[2]/h1")).Text;

                        if (sezioni == 5)
                        {
                            while (sez <= sezioni - 1)
                            {

                                if (sez != 1 && sez != 3)
                                {
                                    nuovamalattia.Description = nuovamalattia.Description + driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[3]/div/div[{sez}]/h3")).Text + ": ";

                                    nuovamalattia.Description = nuovamalattia.Description + driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[3]/div/div[{sez}]/div/p")).Text + "\n\n";
                                }
                                sez++;
                            }
                        }

                        if (sezioni == 6)
                        {
                            while (sez <= sezioni - 2)
                            {

                                if (sez != 1 && sez != 3)
                                {
                                    nuovamalattia.Description = nuovamalattia.Description + driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[4]/div/div[{sez}]/h3")).Text + ": ";

                                    nuovamalattia.Description = nuovamalattia.Description + driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[4]/div/div[{sez}]/div/p")).Text + "\n\n";
                                }
                                sez++;
                            }
                        }
                    }

                    else if (driver.PageSource.Contains(" Please contact your doctor or call 911 ") && driver.PageSource.Contains("? Find Out More"))
                    {
                        Thread.Sleep(1000);
                        bool ok = false;
                        while (ok == false)
                        {
                            try
                            {
                                driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[4]/div/div[4]/div[1]/p/a")).Click();
                                ok = true;
                            }
                            catch (WebDriverException e)
                            {
                                e.StackTrace.ToString();
                            }
                        }

                        int sez = 1;
                        int sezioni = driver.FindElements(By.ClassName("article-section")).Count;

                        Guid guid = Guid.NewGuid();
                        nuovamalattia.Id = guid.ToString();
                        nuovamalattia.Name = driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[2]/h1")).Text;

                        if (sezioni == 5)
                        {
                            while (sez <= sezioni - 1)
                            {

                                if (sez != 1 && sez != 3)
                                {
                                    nuovamalattia.Description = nuovamalattia.Description + driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[3]/div/div[{sez}]/h3")).Text + ": ";

                                    nuovamalattia.Description = nuovamalattia.Description + driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[3]/div/div[{sez}]/div/p")).Text + "\n\n";
                                }
                                sez++;
                            }
                        }

                        if (sezioni == 6)
                        {
                            while (sez <= sezioni - 2)
                            {

                                if (sez != 1 && sez != 3)
                                {
                                    nuovamalattia.Description = nuovamalattia.Description + driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[4]/div/div[{sez}]/h3")).Text + ": ";

                                    nuovamalattia.Description = nuovamalattia.Description + driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[4]/div/div[{sez}]/div/p")).Text + "\n\n";
                                }
                                sez++;
                            }
                        }
                    }

                    else
                    {
                        Thread.Sleep(1000);
                        bool ok = false;
                        while (ok == false)
                        {
                            try
                            {
                                driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[3]/div/div[4]/div[1]/p/a")).Click();
                                ok = true;
                            }
                            catch (WebDriverException e)
                            {
                                e.StackTrace.ToString();
                            }
                        }

                        int sez = 1;
                        int sezioni = driver.FindElements(By.ClassName("article-section")).Count;

                        Guid guid = Guid.NewGuid();
                        nuovamalattia.Id = guid.ToString();
                        nuovamalattia.Name = driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[1]/h1")).Text;

                        if (sezioni == 5)
                        {
                            while (sez <= sezioni - 1)
                            {

                                if (sez != 1 && sez != 3)
                                {
                                    nuovamalattia.Description = nuovamalattia.Description + driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[3]/div/div[{sez}]/h3")).Text + ": ";

                                    nuovamalattia.Description = nuovamalattia.Description + driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[3]/div/div[{sez}]/div/p")).Text + "\n\n";
                                }
                                sez++;
                            }
                        }

                        if (sezioni == 6)
                        {
                            while (sez <= sezioni - 2)
                            {

                                if (sez != 1 && sez != 3)
                                {
                                    nuovamalattia.Description = nuovamalattia.Description + driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[3]/div/div[{sez}]/h3")).Text + ": ";

                                    nuovamalattia.Description = nuovamalattia.Description + driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[3]/div/div[{sez}]/div/p")).Text + "\n\n";
                                }
                                sez++;
                            }
                        }
                    }

                    elencomalattie.Add(nuovamalattia);
                    x++;
                }
            }
            return elencomalattie;
        }

        private readonly DapperContext _context;
        public DiseaseRepository(DapperContext context)
        {
            _context = context;
        }

        public string FindDisease(List<string> elencosintomi)
        {
            var parameters = new DynamicParameters();
            var malattie = nuovaMalattia(elencosintomi);
            
            var p = JsonSerializer.Serialize(malattie.ToList());

            return p;
        }
    }
}
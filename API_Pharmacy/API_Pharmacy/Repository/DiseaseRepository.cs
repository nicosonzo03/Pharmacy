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
            options.AddArgument("headless");

            WebDriver driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
            driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));

            driver.Url = "https://symptomchecker.webmd.com/";

            List<Disease> elencomalattie = new List<Disease>();

            Thread.Sleep(1000);

            driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/div[1]/div/div[2]/div/button[1]")).Click();

            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div[2]/form/div[1]/div/div/input")).SendKeys("50");
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div[2]/form/div[2]/div/button[1]")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div[2]/button")).Click();

            foreach (var item in elencosintomi)
            {
                driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[3]/div[1]/div[1]/div[2]/input")).SendKeys(item);
                Thread.Sleep(2000);

                if (item == "headache" || item == "Fever")
                {
                    driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[3]/div[1]/div[1]/div[2]/ul[1]/li[1]/a")).Click();
                    driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[3]/div[3]/div/div/div[3]/div")).Click();
                }
                
                else
                {
                    driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[3]/div[1]/div[1]/div[2]/ul[1]/li[1]/a")).Click();
                }
            }

            Thread.Sleep(1000);

            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[3]/div[2]/button[2]")).Click();

            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[3]/div[2]/button[2]")).Click();

            Thread.Sleep(2000);
            
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

                    Thread.Sleep(1000);

                    if (!(driver.PageSource.Contains("Overview") && driver.PageSource.Contains("How Common")))
                    {
                        Guid guid = Guid.NewGuid();
                        nuovamalattia.Id = guid.ToString();
                        nuovamalattia.Name = driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/h1")).Text;
                    }

                    else if (driver.PageSource.Contains(" Please contact your doctor or call 911 ") && driver.PageSource.Contains(" This is an URGENT CONDITION ") && driver.PageSource.Contains(" read more")) //&& (!driver.PageSource.Contains("? Find Out More")))
                    {
                        if(driver.PageSource.Contains("How Common"))
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
                    }

                    else if (driver.PageSource.Contains(" Please contact your doctor or call 911 ") && (!driver.PageSource.Contains(" read more")))
                    {
                        Thread.Sleep(1000);
                        

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

                    else if (!driver.PageSource.Contains(" read more"))
                    {
                        Thread.Sleep(1000);
                        

                        int h = 1;
                        int sez = 1;
                        int sezioni = driver.FindElements(By.ClassName("article-section")).Count;

                        Guid guid = Guid.NewGuid();
                        nuovamalattia.Id = guid.ToString();
                        nuovamalattia.Name = driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/h1")).Text;

                        if(nuovamalattia.Name == "Cerebellar Hemorrhage" || nuovamalattia.Name == "Aspiration Pneumonia" || nuovamalattia.Name == "Bacterial Pneumonia" || sezioni == 0 || nuovamalattia.Name == "Esophagitis" || nuovamalattia.Name == "Rotator Cuff Tear")
                        {
                            //break;
                        }

                        else
                        {
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

                            if (sezioni == 3)
                            {
                                while (sez <= sezioni - 1)
                                {
                                    if (sez != 3)
                                    {
                                        if (sez == 1)
                                        {
                                            nuovamalattia.Description = nuovamalattia.Description + driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[{sez}]/div/h3")).Text + ": ";

                                            int countp = driver.FindElements(By.XPath("/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[1]/div/div/p")).Count;

                                            while (h <= countp)
                                            {
                                                nuovamalattia.Description = nuovamalattia.Description + driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[{sez}]/div/div/p[{h}]")).Text + "\n\n";
                                                h++;
                                            }
                                        }
                                        else
                                        {
                                            nuovamalattia.Description = nuovamalattia.Description + driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[{sez}]/div/h3")).Text + ": ";

                                            nuovamalattia.Description = nuovamalattia.Description + driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[{sez}]/div/div/p")).Text + "\n\n";
                                        }
                                    }
                                    sez++;
                                }
                            }
                        }
                    }

                    else
                    {

                        Guid guid = Guid.NewGuid();
                        nuovamalattia.Id = guid.ToString();
                        nuovamalattia.Name = driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[1]/h1")).Text;
                        
                        Thread.Sleep(1000);
                        bool ok = false;
                        while (ok == false)
                        {
                            try
                            {
                                if(nuovamalattia.Name == "Influenza (Flu)")
                                {
                                    driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[3]/div/div[3]/div[1]/p/a")).Click();
                                    ok = true;
                                }
                                else
                                {
                                    driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[3]/div/div[4]/div[1]/p/a")).Click();
                                    ok = true;
                                }
                            }
                            catch (WebDriverException e)
                            {
                                e.StackTrace.ToString();
                            }
                        }

                        int sez = 1;
                        int sezioni = driver.FindElements(By.ClassName("article-section")).Count;

                        
                                                                                             
                        if (sezioni == 5)
                        {
                            while (sez <= sezioni - 1)
                            {
                                if (nuovamalattia.Name == "Influenza (Flu)")
                                {
                                    if (sez != 1 && sez != 2 && sez != 4)
                                    {
                                        nuovamalattia.Description = nuovamalattia.Description + driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[3]/div/div[{sez}]/h3")).Text + ": ";
                                         
                                        nuovamalattia.Description = nuovamalattia.Description + driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[3]/div/div[{sez}]/div/p")).Text + "\n\n";
                                    }
                                }
                                else
                                {
                                    if (sez != 1 && sez != 3)
                                    {
                                        nuovamalattia.Description = nuovamalattia.Description + driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[3]/div/div[{sez}]/h3")).Text + ": ";

                                        nuovamalattia.Description = nuovamalattia.Description + driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div/div[2]/div[1]/div/div[1]/div/div[4]/div[1]/div[2]/div/div/div[3]/div/div[{sez}]/div/p")).Text + "\n\n";
                                    }
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

                    if (nuovamalattia.Name == "Cerebellar Hemorrhage" || nuovamalattia.Name == "Aspiration Pneumonia" || nuovamalattia.Name == "Bacterial Pneumonia" || nuovamalattia.Description == "" || nuovamalattia.Description == null || nuovamalattia.Name == "Esophagitis" || nuovamalattia.Name == "Rotator Cuff Tear")
                    {
                        nuovamalattia.Description = "No description for this disease.";
                        elencomalattie.Add(nuovamalattia);
                    }
                    else
                    {
                        elencomalattie.Add(nuovamalattia);
                    }
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
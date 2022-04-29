using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Data
{
    public class PrecaricaSintomi
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService
                <DbContextOptions<AppDbContext>>()))
            {
                if (context.elencosintomi.Any())
                {
                    return;
                }
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("no-sandbox");
                //options.AddArgument("headless");

                WebDriver driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
                driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));

                driver.Url = "https://symptomchecker.webmd.com/symptoms-a-z";

                // Thread.Sleep(1000);

                driver.FindElement(By.CssSelector("li#tab2")).Click();
                int x = 1;
                int id = 1;
                while (x <= 26)
                {
                    driver.FindElement(By.XPath($"/html/body/div[2]/div/div[3]/div[1]/div[2]/div[2]/div/div/div[4]/form/div[3]/div[2]/div/div[2]/ul/li[{x}]/a")).Click();
                    if (x != 11 && x != 17 && x != 24 && x != 26)
                    {
                        if (x == 15)
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
                                    context.elencosintomi.Add(nuovosintomo);
                                    context.SaveChanges();
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
                                    context.elencosintomi.Add(nuovosintomo);
                                    context.SaveChanges();
                                    id++;
                                    z++;
                                }
                                y++;
                            }
                        }
                    }
                    x++;
                }
            }
            ;
        }
    }
}

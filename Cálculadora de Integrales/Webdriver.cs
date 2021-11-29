using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Selenium
{
    public class Webdriver
    {
        public static string MathSolver(string ecuacion, string lInferior, string lSuperior, string variable)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("headless");
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            using (IWebDriver driver = new ChromeDriver(driverService, options))
            {
                try                    
                {                  
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    driver.Navigate().GoToUrl("https://www.calculadora-de-integrales.com/");
                    IWebElement element = driver.FindElement(By.Id("expression"));
                    element.Clear();
                    element.SendKeys(ecuacion);

                    driver.FindElement(By.Id("tab-options")).Click();
                    IWebElement vari = driver.FindElement(By.Id("int-var"));
                    vari.SendKeys(variable);

                    if (lInferior != "" && lSuperior != "")
                    {
                       
                        IWebElement upper = driver.FindElement(By.Id("upper-bound"));
                        IWebElement lower = driver.FindElement(By.Id("lower-bound"));
                        upper.SendKeys(lSuperior);
                        lower.SendKeys(lInferior);                      
                        driver.FindElement(By.Id("go")).Click();
                        IWebElement load = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("calc")));         
                        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                        js.ExecuteScript("document.querySelectorAll('.simplify-button').forEach(e => e.parentElement.remove());");             
                        IWebElement data;

                        try {
                            data = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div[9]/div[4]"));
                        } 
                        catch (Exception) 
                        {
                            try
                            {
                                 data = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div[9]/div[3]"));
                            }
                            catch (Exception)
                            {
                                try
                                {
                                    data = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div[9]/div[2]"));
                                }
                                catch (Exception)
                                {                              
                                    data = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div[9]/div[1]"));                                  
                                }
                            }
                        }
                        return Latex(Searcher(data), driver, wait);  ;
                    }
                    else
                    {
                        driver.FindElement(By.Id("go")).Click();
                        IWebElement data = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("manual-antiderivative")));
                        string result = Searcher(data);
                        return Latex(result, driver, wait);
                    }              
                }
                catch(Exception e)
                {
                    return e.ToString();
                }         
            }
        }

        public static string Searcher(IWebElement element)
        {
            string html = element.GetAttribute("innerHTML");
            int index = html.IndexOf("script");
            string resultPart = html.Substring(index + 47);
            return resultPart.Substring(0, resultPart.IndexOf("<"));
        }
        public static string Latex (string data, IWebDriver driver, WebDriverWait wait)
        {
            driver.Navigate().GoToUrl("http://www.sciweavers.org/free-online-latex-equation-editor");
            IWebElement element2 = driver.FindElement(By.Id("texEqnEditor"));
            element2.Clear();
            element2.SendKeys(data);
            driver.FindElement(By.Id("submit_tex2img")).Click();
            IWebElement img = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id=\"iImgLoader\"]/img")));
            return img.GetAttribute("src");
        } 
    }
}
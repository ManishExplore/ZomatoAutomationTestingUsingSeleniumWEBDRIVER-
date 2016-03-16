using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;



namespace zomato
{
    class Program
    {
        static void highlightElement(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute('style', 'border:4px solid green; background-color:#ffd35d;')", element);
        }

        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://www.zomato.com";
            var LoginButton = driver.FindElement(By.Id("signin-link"));
            highlightElement(driver, LoginButton);
            LoginButton.Click();
            
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            var LoginEmail = driver.FindElement(By.Id("login-email"));
            highlightElement(driver, LoginEmail);
            LoginEmail.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            
            var EnterEmail = driver.FindElement(By.Id("ld-email"));
            

            EnterEmail.SendKeys("manishmishra@gmail.com");
            var EnterPassword = driver.FindElement(By.Id("ld-password"));
            

            EnterPassword.SendKeys("Manish@123");
            
            var Submit = driver.FindElement(By.Id("ld-submit-global"));
            

            Submit.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            EnterEmail.Clear();
            EnterPassword.Clear();
            var ErrorMessage = driver.FindElement(By.Id("ld-message"));
            var text = ErrorMessage.Text;
            Console.WriteLine(text);
            if (text.Equals("Email not registered. Please signup."))
            {
                Console.WriteLine("Email or Password is not valide");

            }
            EnterEmail = driver.FindElement(By.Id("ld-email"));
            highlightElement(driver, EnterEmail);

            EnterEmail.SendKeys("manishmishra13791@gmail.com");
            EnterPassword = driver.FindElement(By.Id("ld-password"));
            highlightElement(driver, EnterPassword);

            EnterPassword.SendKeys("Manish@33");
            
            Submit = driver.FindElement(By.Id("ld-submit-global"));
            highlightElement(driver, Submit);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            Submit.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

        }
    }
}

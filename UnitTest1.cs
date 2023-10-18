using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Runtime.Serialization;

namespace easyRepo_C__framework
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
           //Test 1-Open the following URL: https://www.moneycorp.com/en-gb/  and verify

            WebDriver driver =new ChromeDriver();
            driver.Url = "https://www.moneycorp.com/en-gb/";
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);

            //Test 2-Change the language and region from the top right corner to USA (English) and verify See example snippet.
            var imglogo = driver.FindElement(By.XPath("//img[@alt='English']/../img"));
            imglogo.Click();
            Thread.Sleep(5000);
            var uslogo=driver.FindElement(By.XPath("//img[@alt='USA English']"));
            uslogo.Click();
            Thread.Sleep(5000);

            //Test 3-Click Find out more for “Foreign exchange solutions” Validate if you have arrived on the page

          var foregexsol =driver.FindElement(By.XPath("//span[text()='Find out more ']/../../a/span"));
            IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
            je.ExecuteScript("window.scrollBy(0,3000)", foregexsol);
            Thread.Sleep(5000);
            je.ExecuteScript("arguments[0].click();", foregexsol);

            //Test 4-Search for the word “international payments” using the search box

            var serachtextfiled = driver.FindElement(By.Id("nav_search"));
            je.ExecuteScript("arguments[0].value='international payments'",serachtextfiled);
            Thread.Sleep(5000);
            //Test-5-Validate if you have arrived on the result page

            var searchbutton = driver.FindElement(By.XPath("(//input[@type='submit'])[1]"));
           je.ExecuteScript("arguments[0].click();", searchbutton);


            //Test6- Validate that each article in the list displays a link that starts with https://www.moneycorp.com/en-us/

            var list = driver.FindElements(By.XPath("//div[@class='pagination']/p/span[2]"));
            int cunt = list.Count();
        

        }


    }
}
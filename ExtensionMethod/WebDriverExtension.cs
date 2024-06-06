using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecTablenRegex.ExtensionMethods
{
    public static class WebDriverExtension
    {


        public static IWebElement ScrollIntoView(this IWebDriver driver, By by)
        {
            IWebElement e = null;
            try {
                e = driver.FindElement(by);
                driver.ExecuteJavaScript("arguments[0].click();", e);
            }catch (Exception ex) {
                throw new Exception("Eleent is not visible: " + ex.Message);
            }
            return e;
        }


       public static void CheckVisibilityAndSendKeys(this IWebDriver driver,By by,string textString)
       {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                wait.Until(ExpectedConditions.ElementIsVisible((by))).SendKeys(textString);
            }catch (Exception ex)
            {
                throw new Exception("Eleent is not visible: " + ex.Message);
            }
       }
    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QuickBook.Services
{
   public class ServicesReferences
    {

       private readonly IWebDriver driver;

       public ServicesReferences(IWebDriver driver)
            {
                 this.driver = driver;
             }

       public IWebElement ServicesButton
       {
           get
           {
               return this.driver.FindElement(By.Id("btnNextStep2"));
           }
       }


       public IWebElement AddonAddButton(int a)
       {

        //   int b = a;
          // get
         //  {
               //return this.driver.FindElement(By.ClassName("sel-to-ms btn-edit sel-addon-to-ms"));
               return this.driver.FindElement(By.XPath("//*[@id='ui-id-20']/table/tbody/tr["+a+"]/td[1]/a")); 
         //  }
       }

        public IWebElement QuantityIncreaseButton
       {
           get
           {
               return this.driver.FindElement(By.ClassName("qty icon-plus-blue"));
           }
       }

       public IWebElement QuantityDecreaseButton
       {
           get
           {
               return this.driver.FindElement(By.ClassName("qty icon-minus-blue"));
           }
       }

        public IWebElement QuantityInput
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='AddOnCategories_0__AddOnSubCategories_0__AllowedAddons_0__Quantity']"));
            }
        }
        public IList<IWebElement> AddAddonTest
        {
            get
            {
                return this.driver.FindElements(By.XPath("//*[@class='sel-to-ms btn-edit sel-addon-to-ms']"));
            }
        }
        public IWebElement DialogOk
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='btnDialogOK']"));
            }
        }
        public IWebElement AddonRowAdd(int x, int y)
        {
            return this.driver.FindElement(By.XPath("//*[@id='servicesContent']/div/div/div["+y+"]/table/tbody/tr["+x+"]/td[1]/a"));
        }
        public IWebElement AddonRowName(int x, int y)
        {
            return this.driver.FindElement(By.XPath("//*[@id='servicesContent']/div/div/div["+y+"]/table/tbody/tr["+x+"]/td[2]"));
        }

        public IWebElement SelectedAddonsSection
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tab-1']/div/div[2]/div[1]/div[1]"));
            }
        }
        public IWebElement AddonCategorySelected
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='servicesContent']/div/div/h3[@aria-selected='true']/span[2]"));
            }
        }
        public IWebElement AddonCategoryNotSelected
        {
            get
            {
                return this.driver.FindElement(By.XPath("[@id='servicesContent']/div/div/h3[@aria-selected='false']/span[2]"));
            }
        }

    }
}

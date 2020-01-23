using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;

namespace QuickBook.Services
{
    public class ServicesMain
    {
        private IWebDriver driver;

        protected ServicesReferences Map
        {
            get
            {
                return new ServicesReferences(this.driver);
            }
        }

        public ServicesMain(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AddServicesButton()
        {
            this.Map.ServicesButton.Click();
        }
        public void AddAddon()
        {
            for (int click = 2;  click > 1; click++)
            {
                Thread.Sleep(1000);
                this.Map.AddonAddButton(click).Click();
                if (this.driver.FindElement(By.Id("btnDialogOK")).Displayed)
                {
                    Thread.Sleep(4000);
                    this.driver.FindElement(By.Id("btnDialogOK")).Click();
                    Console.Write(click);

                    /*if (this.driver.FindElement(By.Id("//*[@id='tab-1']/div/div[2]")).Displayed)

                        Console.WriteLine("Entered");
                        {

                            break;
                        }*/   
                }
                else  if ((this.driver.FindElement(By.XPath("//*[@id='tab-1']/div/div[2]")).Displayed))
                {
                    break;
                }
                Console.Write(click);
              
            }
        }
        //Used to free type addon quantity
        public void AddonQuantityInput(int quantity)
        {
            string strQuantity = quantity.ToString();
            this.Map.QuantityInput.SendKeys(strQuantity);
        }
        //Used to increase addon quantity by 1 using button
        public void AddonQuantityIncrease()
        {
            this.Map.QuantityIncreaseButton.Click();
        }
        //Used to decrease addon quantity by 1 using button
        public void AddonQuantityDecrease()
        {
            this.Map.QuantityDecreaseButton.Click();
        }
        //GG Add addon test method
        //Checks if addons can be added if not will iterate through until 1 addon is added or a new category is reached
        //Possibly need to add department change handler
        public void AddAddonTest()
        {
            int addon = 2;
            int row = 1;
            while (addon > 0)
            {
                string addonName = this.Map.AddonRowName(addon, row).Text.ToString();
                try
                {
                    this.Map.AddonRowAdd(addon, row).Click();
                    if (this.Map.DialogOk.Displayed)
                    {
                        this.Map.DialogOk.Click();
                        Thread.Sleep(1000);
                        if (this.Map.SelectedAddonsSection.Text.Contains(addonName))
                        {
                            Console.WriteLine(addonName + " has been successfully added to the booking");
                            break;
                        }
                        else
                        {
                            addon++;
                        }
                    }
                    else
                    {
                        if (this.Map.SelectedAddonsSection.Text.Contains(addonName))
                        {
                            Console.WriteLine(addonName + " has been successfully added to the booking");
                            break;
                        }
                        else
                        {
                            addon++;
                        }
                    }
                }
                catch (ElementNotVisibleException e)
                {
                    addon = 2;
                    row++;
                    Console.WriteLine("Addon not found in category, moving to next category... " + e);
                }
            }
        }
        //Change Addon Category
        public string currentCategory;
        public string newCategory;
        public void ChangeCategory()
        {
            currentCategory = this.Map.AddonCategorySelected.Text;
            newCategory = this.Map.AddonCategoryNotSelected.Text;
            this.Map.AddonCategoryNotSelected.Click();
        }




    }
}

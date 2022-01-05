namespace WindowsFormsApp1
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        IWebDriver driver;
        List<string> searchHistoryList = new List<string>();

        public Form1()
        {
            InitializeComponent();

            // Open ebay.com
            var options = new ChromeOptions();
            options.AddExcludedArgument("enable-logging");
            driver = new ChromeDriver(@"C:\Browser_drivers\", options);
            driver.Url = "https://www.ebay.com/";
        }

        /// <summary>
        /// Search button click.
        /// </summary>
        /// <param name="sender">Button object.</param>
        /// <param name="e">Event arguments.</param>
        private void SearchButtonClick(object sender, System.EventArgs e)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            // Send input.
            var searchInputField = wait.Until(x => x.FindElement(By.Id("gh-ac")));
            searchInputField.Clear();
            searchInputField.SendKeys(searchInput.Text);

            // Click "Search".
            var searchButton = driver.FindElement(By.Id("gh-btn"));
            searchButton.Click();

            // Add link to search text.
            linkToSearch.Text = driver.Url;

            // Add last visited to Search history.
            searchHistoryList.Add(driver.Url);
            searchHistory.Text = string.Join(" ", searchHistoryList);
        }

        /// <summary>
        /// Back button click.
        /// </summary>
        /// <param name="sender">Button object.</param>
        /// <param name="e">Event arguments.</param>
        private void BackButtonClick(object sender, EventArgs e)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            searchInput.Text = string.Empty;

            if (searchHistoryList.Count > 1)
            {
                driver.Url = searchHistoryList[searchHistoryList.Count - 2];
            }
            else
            {
                driver.Url = "https://www.ebay.com/";
            }
            

            searchHistoryList.RemoveAt(searchHistoryList.Count - 1);
            searchHistory.Text = string.Join(" ", searchHistoryList);
        }

        /// <summary>
        /// Close button clicked.
        /// </summary>
        /// <param name="sender">Button object.</param>
        /// <param name="e">Event arguments.</param>
        private void CloseButtonClicked(object sender, EventArgs e)
        {
            driver.Close();
        }
    }
}

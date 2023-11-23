using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace Tests.Selenium
{
    public class TestClass
    {
        public IWebDriver driver = null!;
        public WebDriverWait wait = null!;

        [SetUp]
        public void TestSetup()
        {
            // Otwarcie przeglądarki Google Chrome
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            // Wejście na stronę google.com
            driver.Navigate().GoToUrl("https://www.google.com/");
            // Zamknięcie strony z plikami Cookie poprzez wciśnięcie przycisku 'Odrzuć wszystkie'
            var discardBtnSelector = By.CssSelector("button > div[role=none]");
            wait.Until(d => d.FindElements(discardBtnSelector).ElementAt(2));
            driver.FindElements(discardBtnSelector).ElementAt(2).Click();
            // Znalezienie input do wyszukiwania
            var searchInputSelector = By.CssSelector("[type=search]");
            wait.Until(d => d.FindElements(searchInputSelector));
            var searchInput = driver.FindElement(searchInputSelector);
            // Wyszukanie frazy "selenium"
            searchInput.SendKeys("selenium");
            searchInput.SendKeys(Keys.Enter);
        }

        [TearDown]
        public void TestTearDown()
        {
            driver.Quit();
        }

        [Test]
        public void searchSeleniumInSecondSearchResultText()
        {
            var secondResultSelector = By.CssSelector("#search > div > div > div > div");
            wait.Until(d => d.FindElements(secondResultSelector));

            var allResultsDivs = driver.FindElements(secondResultSelector);
            var secondResultText = allResultsDivs.ElementAt(2).Text;

            Assert.IsTrue(secondResultText.IndexOf("selenium", StringComparison.OrdinalIgnoreCase) >= 0);
        }

        [Test]
        public void hasFirstLinkGoodTextContent()
        {
            openWikipediaPage();
            var titleSelector = By.ClassName("mw-page-title-main");
            wait.Until(d => d.FindElements(titleSelector));
            // Wyszukanie na stronie Wikipedii frazy 'Selenium' w tytule
            var wikipediaTitle = driver.FindElement(titleSelector).Text;

            var seleniumInTitle = wikipediaTitle.IndexOf("selenium", StringComparison.OrdinalIgnoreCase) >= 0;


            var descriptionSelector = By.CssSelector("#mw-content-text > div > p");
            wait.Until(d => d.FindElements(descriptionSelector));
            // Wyszukanie na stronie Wikipedii frazy 'Selenium' w opisie
            var wikipediaDescription = driver.FindElement(descriptionSelector).Text;

            var seleniumInDescription = wikipediaDescription.IndexOf("selenium", StringComparison.OrdinalIgnoreCase) >= 0;

            Assert.IsTrue(seleniumInDescription || seleniumInTitle);
        }

        [Test]
        public void hasAnyImgElementSeleniumInAlt()
        {
            openWikipediaPage();
            var imagesSelector = By.CssSelector("img");
            wait.Until(d => d.FindElements(imagesSelector));
            // Wyszukanie na stronie Wikipedii wszystkich obrazkow
            var allImages = driver.FindElements(imagesSelector);
            // Wyszukanie obrazów zawierających frazą "selenium" w atrybucie alt
            var hasAnyImgElementSeleniumInAlt = allImages
                .Where(el => el.GetAttribute("alt").IndexOf("selenium", StringComparison.OrdinalIgnoreCase) >= 0)
                .Any();

            Assert.IsTrue(hasAnyImgElementSeleniumInAlt);
        }

        private void openWikipediaPage()
        {
            // Wyszukanie linku do Wikipedii
            var wikiLinkSelector = By.CssSelector("a[href=\"https://pl.wikipedia.org/wiki/Selenium\"]");
            wait.Until(d => d.FindElement(wikiLinkSelector));
            var wikiBtn = driver.FindElement(wikiLinkSelector);
            //Kliknięcie w stronę Wikipedii
            wikiBtn.Click();
        }
    }
}
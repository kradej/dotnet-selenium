using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;

namespace Tests.Selenium
{
    public class ZalandoBasketSumTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void TestSetup()
        {
            // Otwarcie przeglądarki Google Chrome
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            // Wejście na stronę zalando.pl
            driver.Navigate().GoToUrl("https://www.zalando.pl/");
            // Zamknięcie strony z plikami Cookie poprzez wciśnięcie przycisku 'W porządku'
            var wPorzadkuBtnSelector = By.CssSelector("button#uc-btn-accept-banner");
            wait.Until(ExpectedConditions.ElementIsVisible(wPorzadkuBtnSelector));
            driver.FindElement(wPorzadkuBtnSelector).Click();
            // Znalezienie input do wyszukiwania
            var searchInputSelector = By.CssSelector("#header-search-input");
            wait.Until(d => d.FindElement(searchInputSelector));
            var searchInput = driver.FindElement(searchInputSelector);
            // Wyszukanie frazy "tusz do rzęs"
            searchInput.SendKeys("tusz do rzęs");
            searchInput.SendKeys(Keys.Enter);
        }

        [TearDown]
        public void TestTearDown()
        {
            driver.Quit();
        }

        [Test]
        public void BasketSumTest()
        {
            // First Product
            var allResultSelector = By.CssSelector("[data-zalon-partner-target=\"true\"] > div:first-child a");
            wait.Until(d => d.FindElements(allResultSelector));

            var allResults = driver.FindElements(allResultSelector);
            var firstResultLink = allResults.ElementAt(0);

            firstResultLink.Click();

            var spanSelector = By.CssSelector("[re-hydration-id=\"re-1-4\"] > div p > span");
            wait.Until(d => d.FindElements(spanSelector));

            var allSpans = driver.FindElements(spanSelector);
            var priceSpan = allSpans.ElementAt(0).Text;

            var firstPrice = double.Parse(priceSpan.Split(' ').ElementAt(0));

            var addToBasketBtn = By.CssSelector("[data-testid=\"pdp-add-to-cart\"]");
            wait.Until(ExpectedConditions.ElementIsVisible(addToBasketBtn));
            driver.FindElement(addToBasketBtn).Click();

            // Second Product
            var searchInputWindow = By.CssSelector("[role=search] input[type=text]");
            wait.Until(ExpectedConditions.ElementToBeClickable(searchInputWindow));
            driver.FindElement(searchInputWindow).SendKeys("zegarek");
            driver.FindElement(searchInputWindow).SendKeys(Keys.Enter);

            allResultSelector = By.CssSelector("[data-zalon-partner-target=\"true\"] > div:first-child a");
            wait.Until(d => d.FindElements(allResultSelector));

            allResults = driver.FindElements(allResultSelector);
            var secondResultLink = allResults.ElementAt(1);

            secondResultLink.Click();

            spanSelector = By.CssSelector("[re-hydration-id=\"re-1-4\"] > div p > span");
            wait.Until(d => d.FindElements(spanSelector));

            allSpans = driver.FindElements(spanSelector);
            priceSpan = allSpans.ElementAt(0).Text;

            var secondPrice = double.Parse(priceSpan.Split(' ').ElementAt(0));

            addToBasketBtn = By.CssSelector("[data-testid=\"pdp-add-to-cart\"]");
            wait.Until(ExpectedConditions.ElementIsVisible(addToBasketBtn));
            driver.FindElement(addToBasketBtn).Click();

            // Third Product
            searchInputWindow = By.CssSelector("[role=search] input[type=text]");
            wait.Until(ExpectedConditions.ElementToBeClickable(searchInputWindow));
            driver.FindElement(searchInputWindow).SendKeys("okulary");
            driver.FindElement(searchInputWindow).SendKeys(Keys.Enter);

            allResultSelector = By.CssSelector("[data-zalon-partner-target=\"true\"] > div:first-child a");
            wait.Until(d => d.FindElements(allResultSelector));

            allResults = driver.FindElements(allResultSelector);
            var thirdResultLink = allResults.ElementAt(0);

            thirdResultLink.Click();

            spanSelector = By.CssSelector("[re-hydration-id=\"re-1-4\"] > div p > span");
            wait.Until(d => d.FindElements(spanSelector));

            allSpans = driver.FindElements(spanSelector);
            priceSpan = allSpans.ElementAt(0).Text;

            var thirdPrice = double.Parse(priceSpan.Split(' ').ElementAt(0));

            addToBasketBtn = By.CssSelector("[data-testid=\"pdp-add-to-cart\"]");
            wait.Until(ExpectedConditions.ElementIsVisible(addToBasketBtn));
            driver.FindElement(addToBasketBtn).Click();

            // Basket Sum
            var basketBtn = By.CssSelector("[data-testid=\"cart-link\"]");
            wait.Until(ExpectedConditions.ElementToBeClickable(basketBtn));
            wait.Until(d => d.FindElement(basketBtn)).Click();

            var allBasketSumSelectors = By.CssSelector(".z-coast-base__totals__cell > dd.z-2-text.z-2-text-body.z-2-text-black");
            wait.Until(d => d.FindElements(allBasketSumSelectors));

            allResults = driver.FindElements(allBasketSumSelectors);
            var basketSpan = allResults.ElementAt(0).Text;

            var basketSum = double.Parse(basketSpan.Split(' ').ElementAt(0));
            var expectedProductsSum = firstPrice + secondPrice + thirdPrice;

            
            Assert.AreEqual(expectedProductsSum, basketSum);
        }
    }
}
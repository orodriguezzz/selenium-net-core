ChromeOptions options = new ChromeOptions();
options.AddArgument("--no-sandbox");
options.AddArgument("--disable-gpu");
options.AddArgument("--remote-debugging-port=9222");
options.AddArgument("--ignore-certificate-errors");
options.BinaryLocation = Environment.GetEnvironmentVariable("GOOGLE_CHROME_SHIM");

var chromeDriverPath = "/app/.chromedriver/bin/";

IWebDriver driver = new ChromeDriver(options);

driver.Navigate().GoToUrl(url);

var divs = driver.FindElements(By.CssSelector(wrapper)).ToList();
foreach (var div in divs)
{
	var objectText = div.FindElement(By.CssSelector(detail)).Text;

	result.Add(objectText);
}
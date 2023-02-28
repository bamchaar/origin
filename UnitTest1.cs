using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace ECSProject;

public class UnitTest1
{
    [SetUp]
    public void Setup()
    {
    }  

    [Test]
        public async Task MyTest()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var Page = await browser.NewPageAsync();
            await Page.GotoAsync("https://www.ecslimited.com/");

            await Page.GetByRole(AriaRole.Link, new() { Name = "Contact Us " }).ClickAsync();

            await Page.GetByPlaceholder("Categories* (Select all that apply)").ClickAsync();

            await Page.GetByRole(AriaRole.Option, new() { Name = "Recruiting" }).ClickAsync();

            await Page.GetByPlaceholder("Name*").ClickAsync();

            await Page.GetByPlaceholder("Name*").FillAsync("am");

            await Page.GetByPlaceholder("Email*").ClickAsync();

            await Page.GetByPlaceholder("Email*").FillAsync("am@gmail.com");

            await Page.GetByPlaceholder("Phone*").ClickAsync();

            await Page.GetByPlaceholder("Phone*").FillAsync("(555) 243-7689");

            await Page.GetByPlaceholder("City*").ClickAsync();

            await Page.GetByPlaceholder("City*").FillAsync("Ashburn");

            await Page.GetByText("State*Remove item").ClickAsync();

            await Page.GetByRole(AriaRole.Option, new() { Name = "Virginia Press to select", Exact = true }).ClickAsync();

            await Page.GetByPlaceholder("Include project or inquiry details...*").ClickAsync();

            await Page.GetByPlaceholder("Include project or inquiry details...*").FillAsync("Test");

            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();

            await Page.GetByRole(AriaRole.Heading, new() { Name = "Thank You" }).ClickAsync();

        }
}
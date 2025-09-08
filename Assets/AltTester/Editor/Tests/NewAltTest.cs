using NUnit.Framework;
using AltTester.AltTesterSDK.Driver;

public class NewAltTest
{   //Important! If your test file is inside a folder that contains an .asmdef file, please make sure that the assembly definition references NUnit.
    public AltDriver altDriver;
    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        altDriver = new AltDriver();
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altDriver.Stop();
    }

    [Test]
    public void TestStart()
    {
        var button = altDriver.FindObject(By.NAME, "Button");

        Assert.IsTrue(button.enabled, "Button should be clickable");
    }

    [Test]
    public void TestCounterIncreasesOnButtonPress()
    {
        // Find the button and counter text
        var button = altDriver.FindObject(By.NAME, "Button");
        var counterText = altDriver.FindObject(By.NAME, "Counter");

        // Get the starting count number
        string startingCount = counterText.GetText();
        int startNumber = int.Parse(startingCount);

        // Click the button once
        button.Click();

        // Get the new count number
        string newCount = counterText.GetText();
        int newNumber = int.Parse(newCount);

        // Check if number increased by 1
        Assert.AreEqual(startNumber + 1, newNumber, "Counter should increase by 1 after button click");
    }

    [Test]
    public void TestTenClicksMakesCounterTen()
    {
        // Find the button and counter text
        var button = altDriver.FindObject(By.NAME, "Button");
        var counterText = altDriver.FindObject(By.NAME, "Counter");

        // Click the button 10 times
        for (int i = 0; i < 10; i++)
        {
            button.Click();
        }

        // Get the final count number
        string finalCount = counterText.GetText();
        int finalNumber = int.Parse(finalCount);

        // Check if final number is 10
        Assert.AreEqual(10, finalNumber, "Counter should be 10 after 10 clicks");
    }

}
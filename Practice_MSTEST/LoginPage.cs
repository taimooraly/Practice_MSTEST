using OpenQA.Selenium;
using System.Threading;

namespace POM
{
    public class LoginPage : BasePage
    {
        By username = By.Id("username");
        By password = By.Id("password");
        By Submit = By.Id("login");

        public void login(string url, string user, string pass)
        {
            driver.Url = url;
            Write(username, user);
            Write(password, pass);
            Click(Submit);
            Thread.Sleep(500);
        }






    }
}
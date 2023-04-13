using OpenQA.Selenium;
using System.Threading;

namespace POM
{
    public class RegistrationPage : BasePage
    {


        By NewUser = By.XPath("//*[@id=\"login_form\"]/table/tbody/tr[7]/td/a");
        By username = By.Id("username");
        By password = By.Id("password");
        By ConfirmPassword = By.Id("re_password");
        By FullName = By.Id("full_name");
        By EmailAddress = By.Id("email_add");
        //By Captcha = By.Id("captcha");
        By CaptchaText = By.Id("captcha-form");
        By TermsandCond = By.Id("tnc_box");
        By Register = By.Id("Submit");


        public void Registration(string url, string user, string pass, string confirmpass, string Fname, string email)
        {
            driver.Url = url;
            Click(NewUser);
            Write(username, user);
            Write(password, pass);
            Write(ConfirmPassword, confirmpass);
            Write(FullName, Fname);
            Write(EmailAddress, email);
            Thread.Sleep(5000);
            //Write(CaptchaText, capttext);
            Click(TermsandCond);
            Thread.Sleep(5000);
            Click(Register);
            Thread.Sleep(5000);
        }





    }
}
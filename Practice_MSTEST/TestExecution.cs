using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using System.IO;
using POM;
using System.Net.NetworkInformation;
using AventStack.ExtentReports;

namespace POM
{
    [TestClass]
    public class Execution : BasePage
    {
        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }
        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            LogReport("TestReport");
        }
        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {
            extentReports.Flush();
        }
        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {

        }
        [ClassCleanup()]
        public static void ClassCleanup()
        {

        }
        [TestInitialize]
        public void TestInitialization()
        {   
            exParentTest = extentReports.CreateTest(TestContext.TestName);
            Initialization("Chrome");
        }
        [TestCleanup]
        public void TestCleanup()
        {
            SeliniumClose();
        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "validlogin", DataAccessMethod.Sequential)]
        public void validlogin()
        {
            string url = TestContext.DataRow["url"].ToString();
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();

            LoginPage loginPage = new LoginPage();
            exChildTest = exParentTest.CreateNode("Login");


            loginPage.login(url, user, pass);
            Thread.Sleep(5000);

        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "Register", DataAccessMethod.Sequential)]
        public void Register()
        {

            string url = TestContext.DataRow["url"].ToString();
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();
            string confirmpass = TestContext.DataRow["ConfirmPassword"].ToString();
            string Fname = TestContext.DataRow["FullName"].ToString();
            string email = TestContext.DataRow["EmailAddress"].ToString();


            exChildTest = exParentTest.CreateNode("Login");
            LoginPage loginPage = new LoginPage();
            exChildTest = exParentTest.CreateNode("Registration");
            RegistrationPage registrationpage = new RegistrationPage();
            registrationpage.Registration(url, user, pass, confirmpass, Fname, email);




        }



        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "data2.xml", "SearchHotel", DataAccessMethod.Sequential)]
        public void SearchHotel()
        {

            string url = TestContext.DataRow["url"].ToString();
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();
            string location = TestContext.DataRow["location"].ToString();
            string hotelDD = TestContext.DataRow["hotel"].ToString();
            string roomTypeDD = TestContext.DataRow["roomtype"].ToString();
            string noOfRoomDD = TestContext.DataRow["noofrooms"].ToString();
            string checkin = TestContext.DataRow["checkindate"].ToString();
            string checkout = TestContext.DataRow["checkoutdate"].ToString();
            string adults = TestContext.DataRow["adultsroom"].ToString();
            string childrens = TestContext.DataRow["childrensroom"].ToString();


            // Add Login Step inside Test Method
            exChildTest = exParentTest.CreateNode("Login");

            LoginPage loginPage = new LoginPage();
            loginPage.login(url, user, pass);

            exChildTest = exParentTest.CreateNode("Search");
            //SearchPage searchhotel = new SearchPage();
            //searchhotel.Search(location, hotelDD, roomTypeDD, noOfRoomDD, checkin, checkout, adults, childrens);




        }

        //       [TestMethod]
        //       [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "SelectHotel", DataAccessMethod.Sequential)]
        //       public void SelectHotel()
        //           {

        //               string url = TestContext.DataRow["url"].ToString();
        //               string user = TestContext.DataRow["username"].ToString();
        //               string pass = TestContext.DataRow["password"].ToString();
        //               string location = TestContext.DataRow["location"].ToString();
        //               string hotelDD = TestContext.DataRow["hotel"].ToString();
        //               string roomTypeDD = TestContext.DataRow["roomtype"].ToString();
        //               string noOfRoomDD = TestContext.DataRow["noofrooms"].ToString();
        //               string checkin = TestContext.DataRow["checkindate"].ToString();
        //               string checkout = TestContext.DataRow["checkoutdate"].ToString();
        //               string adults = TestContext.DataRow["adultsroom"].ToString();
        //               string childrens = TestContext.DataRow["childrensroom"].ToString();

        //               exChildTest = ExtentReport.exParentTest.CreateNode("Login");
        //               LoginPage loginPage = new LoginPage();
        //               loginPage.login(url, user, pass);

        //               exChildTest = ExtentReport.exParentTest.CreateNode("Search Hotel");
        //               SearchPage searchhotel = new SearchPage();
        //               searchhotel.Search(location, hotelDD, roomTypeDD, noOfRoomDD, checkin, checkout, adults, childrens);

        //               exChildTest = ExtentReport.exParentTest.CreateNode("Select Hotel");
        //               SelectPage selecthotel = new SelectPage();
        //               selecthotel.SelectHotel();
        //           }


        //       [TestMethod]
        //       [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "BookHotel", DataAccessMethod.Sequential)]
        //       public void BookHotel()
        //           {

        //               string url = TestContext.DataRow["url"].ToString();
        //               string user = TestContext.DataRow["username"].ToString();
        //               string pass = TestContext.DataRow["password"].ToString();
        //               string location = TestContext.DataRow["location"].ToString();
        //               string hotelDD = TestContext.DataRow["hotel"].ToString();
        //               string roomTypeDD = TestContext.DataRow["roomtype"].ToString();
        //               string noOfRoomDD = TestContext.DataRow["noofrooms"].ToString();
        //               string checkin = TestContext.DataRow["checkindate"].ToString();
        //               string checkout = TestContext.DataRow["checkoutdate"].ToString();
        //               string adults = TestContext.DataRow["adultsroom"].ToString();
        //               string childrens = TestContext.DataRow["childrensroom"].ToString();

        //               string fname = TestContext.DataRow["fullname"].ToString();
        //               string lname = TestContext.DataRow["lastname"].ToString();
        //               string address = TestContext.DataRow["address"].ToString();
        //               string cCNo = TestContext.DataRow["ccnumber"].ToString();
        //               string cCType = TestContext.DataRow["cctype"].ToString();
        //               string expiryDate = TestContext.DataRow["expirydate"].ToString();
        //               string expiryYear = TestContext.DataRow["expiryyear"].ToString();
        //               string cVVNo = TestContext.DataRow["cvvnumber"].ToString();

        //               exChildTest = ExtentReport.exParentTest.CreateNode("Login");
        //               LoginPage loginPage = new LoginPage();
        //               loginPage.login(url, user, pass);

        //               exChildTest = ExtentReport.exParentTest.CreateNode("Search Hotel");
        //               SearchPage searchhotel = new SearchPage();
        //               searchhotel.Search(location, hotelDD, roomTypeDD, noOfRoomDD, checkin, checkout, adults, childrens);

        //               exChildTest = ExtentReport.exParentTest.CreateNode("Select Hotel");
        //               SelectPage selecthotel = new SelectPage();
        //               selecthotel.SelectHotel();

        //               exChildTest = ExtentReport.exParentTest.CreateNode("Book Hotel");
        //               BookingPage bookahotel = new BookingPage();
        //               bookahotel.BookHotel(fname, lname, address, cCNo, cCType, expiryDate, expiryYear, cVVNo);
    }
}
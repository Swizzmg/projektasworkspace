using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using System.Diagnostics;
using System.IO;
using System.Data;

namespace Projektas
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }

        static Process proc = null;
        [ClassInitialize]
        public static void initializeTest(TestContext context)
        {
            Playback.Initialize();
            var browser = BrowserWindow.Launch(new Uri("https://www.windbiketours.com/boxless"));
            proc = browser.Process;
            browser.CloseOnPlaybackCleanup = false;
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            if (!Playback.IsInitialized)
                Playback.Initialize();
            BrowserWindow _bw = BrowserWindow.FromProcess(proc);
            _bw.Close();
        }


        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\data1.csv", "data1#csv", DataAccessMethod.Sequential ), DeploymentItem("data1.csv"), TestMethod]
        public void PrisijungimasIrRegistracija()
        {
            
                string login = TestContext.DataRow["Login"].ToString();
                string password = TestContext.DataRow["Password"].ToString();
                string email = TestContext.DataRow["Email"].ToString();
                //Signup(login, password, email);
                Playback.Wait(1000);
                Login(login, password, email);
                
            
        }

        [TestMethod]
        private void Login(string login, string password, string email)
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            BrowserWindow browser = BrowserWindow.FromProcess(proc);
            //Vartotojo vardo ivedimas
            UITestControl uiUsername = new UITestControl(browser);
            uiUsername.TechnologyName = "Web";
            uiUsername.SearchProperties.Add("ControlType", "Edit");
            uiUsername.SearchProperties.Add("Id", "inputUsername");
            uiUsername.SearchProperties.Add("Name", "user_username");
            Keyboard.SendKeys(uiUsername, login);

            //Vartotojo slaptazodzio ivedimas
            UITestControl uiPassword = new UITestControl(browser);
            uiPassword.TechnologyName = "Web";
            uiPassword.SearchProperties.Add("ControlType", "Edit");
            uiPassword.SearchProperties.Add("Id", "inputPassword");
            Keyboard.SendKeys(uiPassword, password);

            //Mygtuko prisijungti paspaudimas
            UITestControl uiSubmit = new UITestControl(browser);
            uiSubmit.TechnologyName = "Web";
            uiSubmit.SearchProperties.Add("ControlType", "Button");
            uiSubmit.SearchProperties.Add("Name", "submit");
            Mouse.Click(uiSubmit);

            UITestControl uiCheck = new UITestControl(browser);
            uiCheck.TechnologyName = "Web";
            uiCheck.SearchProperties.Add("Class", "usr");
            uiCheck.FilterProperties.Find(login);
            string name = uiCheck.GetProperty("InnerText").ToString();
            if (name == login)
                uiCheck.DrawHighlight();
            else
                Assert.Fail("Prisijungimo vardai nesutampa");

            UITestControl uiCheck2 = new UITestControl(browser);
            uiCheck2.TechnologyName = "Web";
            uiCheck2.SearchProperties.Add("Class", "mail");
            uiCheck2.FilterProperties.Find(email);
            string pastas = uiCheck2.GetProperty("InnerText").ToString();
            if (pastas == email)
            {
                uiCheck2.DrawHighlight();
            }
            else
                Assert.Fail("el.pastai nesutampa");

            uiSubmit.TechnologyName = "Web";
            uiSubmit.SearchProperties.Add("ControlType", "Button");
            uiSubmit.SearchProperties.Add("Name", "submit");
            Mouse.Click(uiSubmit);


        }

        [TestMethod]
        private void Log(string login, string password, string email)
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            BrowserWindow browser = BrowserWindow.FromProcess(proc);
            //Vartotojo vardo ivedimas
            UITestControl uiUsername = new UITestControl(browser);
            uiUsername.TechnologyName = "Web";
            uiUsername.SearchProperties.Add("ControlType", "Edit");
            uiUsername.SearchProperties.Add("Id", "inputUsername");
            uiUsername.SearchProperties.Add("Name", "user_username");
            Keyboard.SendKeys(uiUsername, login);

            //Vartotojo slaptazodzio ivedimas
            UITestControl uiPassword = new UITestControl(browser);
            uiPassword.TechnologyName = "Web";
            uiPassword.SearchProperties.Add("ControlType", "Edit");
            uiPassword.SearchProperties.Add("Id", "inputPassword");
            Keyboard.SendKeys(uiPassword, password);

            //Mygtuko prisijungti paspaudimas
            UITestControl uiSubmit = new UITestControl(browser);
            uiSubmit.TechnologyName = "Web";
            uiSubmit.SearchProperties.Add("ControlType", "Button");
            uiSubmit.SearchProperties.Add("Name", "submit");
            Mouse.Click(uiSubmit);
        }

        [TestMethod]
        private void Signup(string UserName, string Password, string Email)
        {
            BrowserWindow browser = BrowserWindow.FromProcess(proc);
            UITestControl uiSignUp = new UITestControl(browser);
            uiSignUp.TechnologyName = "Web";
            uiSignUp.SearchProperties.Add("ControlType", "Hyperlink");
            uiSignUp.SearchProperties.Add("TagName", "A");
            Mouse.Click(uiSignUp);

            UITestControl uiUsername = new UITestControl(browser);
            uiUsername.TechnologyName = "Web";
            uiUsername.SearchProperties.Add("ControlType", "Edit");
            uiUsername.SearchProperties.Add("Id", "inputUsername");
            uiUsername.SearchProperties.Add("Name", "user_username");
            Keyboard.SendKeys(uiUsername, UserName);

            UITestControl uiEmail = new UITestControl(browser);
            uiEmail.TechnologyName = "Web";
            uiEmail.SearchProperties.Add("ControlType", "Edit");
            uiEmail.SearchProperties.Add("Id", "inputEmail");
            uiEmail.SearchProperties.Add("Name", "user_email");
            Keyboard.SendKeys(uiEmail, Email);

            UITestControl uiPassword1 = new UITestControl(browser);
            uiPassword1.TechnologyName = "Web";
            uiPassword1.SearchProperties.Add("ControlType", "Edit");
            uiPassword1.SearchProperties.Add("Id", "inputPassword");
            Keyboard.SendKeys(uiPassword1, Password);

            UITestControl uiPassword2 = new UITestControl(browser);
            uiPassword2.TechnologyName = "Web";
            uiPassword2.SearchProperties.Add("ControlType", "Edit");
            uiPassword2.SearchProperties.Add("Id", "inputRePassword");
            Keyboard.SendKeys(uiPassword2, Password);

            UITestControl uiSubmit = new UITestControl(browser);
            uiSubmit.TechnologyName = "Web";
            uiSubmit.SearchProperties.Add("ControlType", "Button");
            uiSubmit.SearchProperties.Add("Name", "submit");
            Mouse.Click(uiSubmit);

        }
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\badlogin1.csv", "badlogin1#csv", DataAccessMethod.Sequential), DeploymentItem("badlogin1.csv"), TestMethod]
        public void PrisijungimasSuNeteisinguVardu()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            string login = TestContext.DataRow["Login"].ToString();
            string password = TestContext.DataRow["Password"].ToString();
            string email = TestContext.DataRow["Email"].ToString();
            BrowserWindow browser = BrowserWindow.FromProcess(proc);
            //Vartotojo vardo ivedimas
            Log(login, password, email);

            UITestControl uiCheck = new UITestControl(browser);
                uiCheck.TechnologyName = "Web";
                uiCheck.SearchProperties.Add("Class", "error");
                string error = "Blogas vartotojo vardas";
                string name = uiCheck.GetProperty("InnerText").ToString();
                if (name == error)
                    uiCheck.DrawHighlight();
                else
                    Assert.Fail("blogo prisijungimo klaida nerandama");


        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\badLoginWrongPassword.csv", "badLoginWrongPassword#csv", DataAccessMethod.Sequential), DeploymentItem("badLoginWrongPassword.csv.csv"), TestMethod]
        public void PrisijungimasSuNeteisinguSlaptažodžiu()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            string login = TestContext.DataRow["Login"].ToString();
            string password = TestContext.DataRow["Password"].ToString();
            string email = TestContext.DataRow["Email"].ToString();
            BrowserWindow browser = BrowserWindow.FromProcess(proc);
            //Vartotojo vardo ivedimas
            Log(login, password, email);

            UITestControl uiCheck = new UITestControl(browser);
            uiCheck.TechnologyName = "Web";
            uiCheck.SearchProperties.Add("Class", "error");
            string error = "Blogas slaptažodis";
            string name = uiCheck.GetProperty("InnerText").ToString();
            if (name == error)
                uiCheck.DrawHighlight();
            else
                Assert.Fail("blogo prisijungimo klaida nerandama");

        }
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\BadUserName.csv", "BadUserName#csv", DataAccessMethod.Sequential), DeploymentItem("BadUserName.csv.csv"), TestMethod]
        public void RegistracijaSuBloguVardu()
        {
            string login = TestContext.DataRow["Login"].ToString();
            string password = TestContext.DataRow["Password"].ToString();
            string email = TestContext.DataRow["Email"].ToString();
            BrowserWindow browser = BrowserWindow.FromProcess(proc);
            Signup(login, password, email);
            
            UITestControl uiCheck = new UITestControl(browser);
            uiCheck.TechnologyName = "Web";
            uiCheck.SearchProperties.Add("Class", "error");
            string error = "Vartotojo vardas turi būti tik iš lotyniškų raidžių ir skaičių";
            string name = uiCheck.GetProperty("InnerText").ToString();
            if (name == error)
                uiCheck.DrawHighlight();
            else
                Assert.Fail("blogos registracijos klaida nerandama");

            UITestControl uiBack = new UITestControl(browser);
            uiBack.TechnologyName = "Web";
            uiBack.SearchProperties.Add("Class", "profile-img-card");
            Mouse.Click(uiBack);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\UserNameExists.csv", "UserNameExists#csv", DataAccessMethod.Sequential), DeploymentItem("UserNameExists.csv"), TestMethod]
        public void RegistracijaSuEgzsituojanciuVardu()
        {
            string login = TestContext.DataRow["Login"].ToString();
            string password = TestContext.DataRow["Password"].ToString();
            string email = TestContext.DataRow["Email"].ToString();
            BrowserWindow browser = BrowserWindow.FromProcess(proc);
            Signup(login, password, email);
            
            UITestControl uiCheck = new UITestControl(browser);
            uiCheck.TechnologyName = "Web";
            uiCheck.SearchProperties.Add("Class", "error");
            string error = "Vartotojo vardas užimtas";
            string name = uiCheck.GetProperty("InnerText").ToString();
            if (name == error)
                uiCheck.DrawHighlight();
            else
                Assert.Fail("blogos registracijos klaida nerandama");

            UITestControl uiBack = new UITestControl(browser);
            uiBack.TechnologyName = "Web";
            uiBack.SearchProperties.Add("Class", "profile-img-card");
            Mouse.Click(uiBack);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\BadEmail.csv", "BadEmail#csv", DataAccessMethod.Sequential), DeploymentItem("BadEmail.csv"), TestMethod]
        public void RegistracijaSuBloguElpastu()
        {
            string login = TestContext.DataRow["Login"].ToString();
            string password = TestContext.DataRow["Password"].ToString();
            string email = TestContext.DataRow["Email"].ToString();
            BrowserWindow browser = BrowserWindow.FromProcess(proc);
            Signup(login, password, email);

            UITestControl uiCheck = new UITestControl(browser);
            uiCheck.TechnologyName = "Web";
            uiCheck.SearchProperties.Add("Class", "error");
            string error = "Vartotojo el.paštas blogas";
            string name = uiCheck.GetProperty("InnerText").ToString();
            if (name == error)
                uiCheck.DrawHighlight();
            else
                Assert.Fail("blogos registracijos klaida nerandama");
            UITestControl uiBack = new UITestControl(browser);
            uiBack.TechnologyName = "Web";
            uiBack.SearchProperties.Add("Class", "profile-img-card");
            Mouse.Click(uiBack);
        }
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\EmailExists.csv", "EmailExists#csv", DataAccessMethod.Sequential), DeploymentItem("EmailExists.csv"), TestMethod]
        public void RegistracijaSuEgzistuojanciuElpastu()
        {
            string login = TestContext.DataRow["Login"].ToString();
            string password = TestContext.DataRow["Password"].ToString();
            string email = TestContext.DataRow["Email"].ToString();
            BrowserWindow browser = BrowserWindow.FromProcess(proc);
            Signup(login, password, email);

            UITestControl uiCheck = new UITestControl(browser);
            uiCheck.TechnologyName = "Web";
            uiCheck.SearchProperties.Add("Class", "error");
            string error = "Vartotojo el.paštas užimtas";
            string name = uiCheck.GetProperty("InnerText").ToString();
            if (name == error)
                uiCheck.DrawHighlight();
            else
                Assert.Fail("blogos registracijos klaida nerandama");

            UITestControl uiBack = new UITestControl(browser);
            uiBack.TechnologyName = "Web";
            uiBack.SearchProperties.Add("Class", "profile-img-card");
            Mouse.Click(uiBack);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\PasswordsNotMatch.csv", "PasswordsNotMatch#csv", DataAccessMethod.Sequential), DeploymentItem("PasswordsNotMatch.csv"), TestMethod]
        public void RegistracijaSuNesutampanciaisSlaptazodziais()
        {
            string login = TestContext.DataRow["Login"].ToString();
            string password = TestContext.DataRow["Password"].ToString();
            string password2 = TestContext.DataRow["Password2"].ToString();
            string email = TestContext.DataRow["Email"].ToString();
            BrowserWindow browser = BrowserWindow.FromProcess(proc);
            UITestControl uiSignUp = new UITestControl(browser);
            uiSignUp.TechnologyName = "Web";
            uiSignUp.SearchProperties.Add("ControlType", "Hyperlink");
            uiSignUp.SearchProperties.Add("TagName", "A");
            Mouse.Click(uiSignUp);

            UITestControl uiUsername = new UITestControl(browser);
            uiUsername.TechnologyName = "Web";
            uiUsername.SearchProperties.Add("ControlType", "Edit");
            uiUsername.SearchProperties.Add("Id", "inputUsername");
            uiUsername.SearchProperties.Add("Name", "user_username");
            Keyboard.SendKeys(uiUsername, login);

            UITestControl uiEmail = new UITestControl(browser);
            uiEmail.TechnologyName = "Web";
            uiEmail.SearchProperties.Add("ControlType", "Edit");
            uiEmail.SearchProperties.Add("Id", "inputEmail");
            uiEmail.SearchProperties.Add("Name", "user_email");
            Keyboard.SendKeys(uiEmail, email);

            UITestControl uiPassword1 = new UITestControl(browser);
            uiPassword1.TechnologyName = "Web";
            uiPassword1.SearchProperties.Add("ControlType", "Edit");
            uiPassword1.SearchProperties.Add("Id", "inputPassword");
            Keyboard.SendKeys(uiPassword1, password);

            UITestControl uiPassword2 = new UITestControl(browser);
            uiPassword2.TechnologyName = "Web";
            uiPassword2.SearchProperties.Add("ControlType", "Edit");
            uiPassword2.SearchProperties.Add("Id", "inputRePassword");
            Keyboard.SendKeys(uiPassword2, password2);

            UITestControl uiSubmit = new UITestControl(browser);
            uiSubmit.TechnologyName = "Web";
            uiSubmit.SearchProperties.Add("ControlType", "Button");
            uiSubmit.SearchProperties.Add("Name", "submit");
            Mouse.Click(uiSubmit);

            UITestControl uiCheck = new UITestControl(browser);
            uiCheck.TechnologyName = "Web";
            uiCheck.SearchProperties.Add("Class", "error");
            string error = "Slaptažodžiai nesutampa";
            string name = uiCheck.GetProperty("InnerText").ToString();
            if (name == error)
                uiCheck.DrawHighlight();
            else
                Assert.Fail("blogos registracijos klaida nerandama");
            UITestControl uiBack = new UITestControl(browser);
            uiBack.TechnologyName = "Web";
            uiBack.SearchProperties.Add("Class", "profile-img-card");
            Mouse.Click(uiBack);
        }
        [TestMethod]
        public void PrisijungimasTusciaisLaukais()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            BrowserWindow browser = BrowserWindow.FromProcess(proc);            

            UITestControl uiSubmit = new UITestControl(browser);
            uiSubmit.TechnologyName = "Web";
            uiSubmit.SearchProperties.Add("ControlType", "Button");
            uiSubmit.SearchProperties.Add("Name", "submit");
            Mouse.Click(uiSubmit);

            UITestControl uiUsername = new UITestControl(browser);
            uiUsername.TechnologyName = "Web";
            uiUsername.SearchProperties.Add("ControlType", "Edit");
            uiUsername.SearchProperties.Add("Id", "inputUsername");
            uiUsername.SearchProperties.Add("Name", "user_username");
            Keyboard.SendKeys(uiUsername, "aaaa");
            //Mygtuko prisijungti paspaudimas
            Mouse.Click(uiSubmit);
    
        }

        [TestMethod]
        public void RegistracijaTusciaisLaukais()
        {

            BrowserWindow browser = BrowserWindow.FromProcess(proc);

            UITestControl uiSubmit = new UITestControl(browser);
            uiSubmit.TechnologyName = "Web";
            uiSubmit.SearchProperties.Add("ControlType", "Button");
            uiSubmit.SearchProperties.Add("Name", "submit");

            UITestControl uiSignUp = new UITestControl(browser);
            uiSignUp.TechnologyName = "Web";
            uiSignUp.SearchProperties.Add("ControlType", "Hyperlink");
            uiSignUp.SearchProperties.Add("TagName", "A");
            Mouse.Click(uiSignUp);
            Mouse.Click(uiSubmit);

            UITestControl uiUsername = new UITestControl(browser);
            uiUsername.TechnologyName = "Web";
            uiUsername.SearchProperties.Add("ControlType", "Edit");
            uiUsername.SearchProperties.Add("Id", "inputUsername");
            uiUsername.SearchProperties.Add("Name", "user_username");
            Keyboard.SendKeys(uiUsername, "Demo");
            Mouse.Click(uiSubmit);
            UITestControl uiEmail = new UITestControl(browser);
            uiEmail.TechnologyName = "Web";
            uiEmail.SearchProperties.Add("ControlType", "Edit");
            uiEmail.SearchProperties.Add("Id", "inputEmail");
            uiEmail.SearchProperties.Add("Name", "user_email");
            Keyboard.SendKeys(uiEmail, "demo@demo.lt");
            Mouse.Click(uiSubmit);

            UITestControl uiPassword1 = new UITestControl(browser);
            uiPassword1.TechnologyName = "Web";
            uiPassword1.SearchProperties.Add("ControlType", "Edit");
            uiPassword1.SearchProperties.Add("Id", "inputPassword");
            Keyboard.SendKeys(uiPassword1, "aaa");
            Mouse.Click(uiSubmit);


        }





        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if (this.map == null)
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}

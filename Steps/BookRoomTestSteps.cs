using NUnit.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace SmartHotel360.Specflow.Steps
{
    [Binding]
    public class BookRoomTestSteps
    {
        protected IApp app;
        protected Platform platform;

        readonly Query emailField;
        readonly Query passwordField;
        readonly Query signInButton;
        string msg;
        public BookRoomTestSteps()
        {
            this.platform = Platform.Android;

            emailField = x => x.Marked("username");
            passwordField = x => x.Marked("password");
            signInButton = x => x.Marked("signin");

            msg = "Do you want to book a room in Sh360 Platinum New York?";
        }

        [BeforeScenario()]
        public void Initialize()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Given(@"que verifico se a app esta instalada no meu device")]
        public void DadoQueVerificoSeAAppEstaInstaladaNoMeuDevice()
        {
            app.Screenshot("App Initialized");
        }

        [Given(@"entro com o ""(.*)""")]
        public void DadoEntroComO(string field)
        {
            if (field == "username")
            {
                app.WaitForElement(emailField);
                app.Tap(emailField);
                app.EnterText(TestSettings.TestUsername);
                app.DismissKeyboard();
            }
            else
            {
                app.Tap(passwordField);
                app.EnterText(TestSettings.TestPassword);
                app.DismissKeyboard();
            }

            app.Screenshot("Credentials Entered");
        }

        [Given(@"que eu toco em ""(.*)""")]
        public void DadoQueEuTocoEm(string botao)
        {
            if (botao == "BOOK A ROOM")
            {
                app.Tap("BOOK A ROOM");
            }
            if (botao == "NEXT")
            {
                app.Tap("NEXT");
            }
            if (botao == "BOOK NOW")
            {
                app.Tap("BOOK NOW");
            }

        }

        [Given(@"que eu toco na cidade de ""(.*)""")]
        public void DadoQueEuTocoNaCidadeDe(string cidade)
        {
            app.Tap(cidade);
        }

        [Given(@"seleciono o dia de reserva ""(.*)""")]
        public void DadoSelecionoODiaDeReserva(int dia)
        {
            app.Tap(dia.ToString());
        }

        [Given(@"escolho o hotel ""(.*)""")]
        public void DadoEscolhoOHotel(string hotel)
        {
            app.WaitForElement(x => x.Text(hotel));
            app.TapCoordinates(331, 1054);
        }

        [When(@"eu clicar no botão ""(.*)""")]
        public void QuandoEuClicarNoBotao(string signin)
        {
            app.Tap(signInButton);
        }

        [Then(@"vai aparecer um alerta na tela para confirmar a reserva")]
        public void EntaoVaiAparecerUmAlertaNaTelaParaConfirmarAReserva()
        {
            AppResult[] result = app.Query(x => x.Id("message"));

            Assert.AreEqual(msg, result[0].Text);
        }

        [Then(@"eu seleciono ""(.*)""")]
        public void EntaoEuSeleciono(string p0)
        {
            app.Tap(x => x.Id("button1"));
            app.WaitForElement("GO TO MY ROOM");
            AppResult[] result = app.Query("GO TO MY ROOM");
            Assert.IsTrue(result.Any());
        }
    }
}

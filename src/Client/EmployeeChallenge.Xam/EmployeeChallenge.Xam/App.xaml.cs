
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EmployeeChallenge.Xam
{
    using Prism;
    using Prism.Ioc;
    using EmployeeChallenge.Xam.Views;
    using Xamarin.Forms;
    using Prism.Unity;
    using EmployeeChallenge.Xam.Utils.Factories.Abstractions;
    using EmployeeChallenge.Xam.Utils.Factories;
    using EmployeeChallenge.Xam.Services.Abstractions;
    using EmployeeChallenge.Xam.Services;
    using Unity;
    using System.Diagnostics;
    using Acr.UserDialogs;

    public partial class App : PrismApplication
    {

        public const string HttpClientBaseAddress = "http://192.168.1.2:60000/";

        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/EmployeesPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Pages
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<EmployeesPage>();
            containerRegistry.RegisterForNavigation<EmployeeSkillsPage>();
            containerRegistry.RegisterForNavigation<AddEmployeePage>();
            containerRegistry.RegisterForNavigation<EditEmployeePage>();

            //Plugins
            containerRegistry.RegisterInstance<IUserDialogs>(UserDialogs.Instance);
            containerRegistry.RegisterSingleton<IHttpClientFactory, HttpClientFactory>();

            //Services
            containerRegistry.RegisterSingleton<ISkillsService, SkillsService>();
            containerRegistry.RegisterSingleton<IEmployeesService, EmployeesService>();
        }
    }
}

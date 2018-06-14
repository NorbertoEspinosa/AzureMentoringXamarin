using System;
using Xamarin.Forms;
using AzureMentoringXamarin.Services;
using AzureMentoringXamarin.Views;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace AzureMentoringXamarin
{
	public partial class App : Application
	{
        //TODO: Replace with AzureMentoringXamarin.azurewebsites.net url after deploying backend to Azure
        public static string AzureBackendUrl = "http://AzureMentoringXamarin.azurewebsites.net";
        //public static bool UseMockDataStore = true;
        public static bool UseMockDataStore = false;

        public App ()
		{
			InitializeComponent();

            if (UseMockDataStore)
            {
                DependencyService.Register<MockDataStore>();
                DependencyService.Register<MockBlogDataStore>();
            }
            else
            {
                DependencyService.Register<AzureDataStore>();
                DependencyService.Register<AzureBlogDataStore>();
            }

			MainPage = new MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

using System;
using Paladin.Services;
using Paladin.Views;
using Xamarin.Forms;

namespace Paladin
{
	public partial class App : Application
	{
        private static DataController database;
        public static DataController Database
        {
            get
            {
                if (database == null)
                {
                    database = DataController.Controller;
                }
                return database;
            }
        }

        public App ()
		{
			InitializeComponent();


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

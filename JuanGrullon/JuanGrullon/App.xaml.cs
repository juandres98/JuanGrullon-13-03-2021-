using JuanGrullon.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JuanGrullon
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TasksPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

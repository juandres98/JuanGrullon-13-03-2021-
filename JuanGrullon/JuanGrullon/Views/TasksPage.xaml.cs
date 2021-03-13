using JuanGrullon.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JuanGrullon.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TasksPage : ContentPage
    {
        public TasksPage()
        {
            InitializeComponent();
            this.BindingContext = Locator.StaticTasksPageViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Locator.StaticTasksPageViewModel.InitializeCommand.Execute(null);
        }
    }
}
using JuanGrullon.Models;
using JuanGrullon.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace JuanGrullon.ViewModels
{
    public class TasksPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Command InitializeCommand { get; }
        public Command CreateCommand { get; }
        public Command SelectTaskCommand { get; }
        public TasksPageViewModel()
        {
            InitializeCommand = new Command(async () =>
            {
                Tareas = await Locator.Database.GetTareas();
                if(Tareas.Count() > 0)
                {
                    AnyTask = true;
                }
                else
                {
                    AnyTask = false;
                }
            });

            CreateCommand = new Command(async () =>
            {
                CreateTaskPage createTaskPage = new CreateTaskPage();
                createTaskPage.BindingContext = Locator.StaticCreateTaskPageViewModel;
                await Application.Current.MainPage.Navigation.PushAsync(createTaskPage);
            });

            SelectTaskCommand = new Command<Tarea>(async (Tarea tarea) =>
            {
                SelectTask SelectTask = new SelectTask();
                SelectTask.BindingContext = Locator.StaticSelectTaskPageViewModel;
                Locator.StaticSelectTaskPageViewModel.Tarea = tarea;
                await PopupNavigation.Instance.PushAsync(SelectTask);
            });
        }

        private List<Tarea> tareas = new List<Tarea>();
        public List<Tarea> Tareas
        {
            get => tareas;
            set
            {
                tareas = value;
                var args = new PropertyChangedEventArgs(nameof(Tareas));
                PropertyChanged?.Invoke(this, args);
            }
        }

        private bool anyTask = false;
        public bool AnyTask
        {
            get => anyTask;
            set
            {
                anyTask = value;
                var args = new PropertyChangedEventArgs(nameof(AnyTask));
                PropertyChanged?.Invoke(this, args);
            }
        }
    }
}

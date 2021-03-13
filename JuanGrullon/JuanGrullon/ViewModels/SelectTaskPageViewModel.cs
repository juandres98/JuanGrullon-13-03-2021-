using JuanGrullon.Models;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace JuanGrullon.ViewModels
{
    public class SelectTaskPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Command SelectTaskCommand { get; }
        public Command DeleteTaskCommand { get; }
        public Command UpdateTaskCommand { get; }

        public SelectTaskPageViewModel()
        {
            DeleteTaskCommand = new Command(async () =>
            {
                await Locator.Database.DeleteTarea(Tarea);
                Locator.StaticTasksPageViewModel.InitializeCommand.Execute(null);
                await PopupNavigation.Instance.PopAsync();
            });
            UpdateTaskCommand = new Command(async () =>
            {
                await Locator.Database.UpdateTarea(Tarea);
                Locator.StaticTasksPageViewModel.InitializeCommand.Execute(null);
                await PopupNavigation.Instance.PopAsync();
            });
        }

        private Tarea tarea = new Tarea();
        public Tarea Tarea
        {
            get => tarea;
            set
            {
                tarea = value;
                var args = new PropertyChangedEventArgs(nameof(Tarea));
                PropertyChanged?.Invoke(this, args);
            }
        }
    }
}

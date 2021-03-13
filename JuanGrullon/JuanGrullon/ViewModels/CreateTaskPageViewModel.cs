using JuanGrullon.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace JuanGrullon.ViewModels
{
    public class CreateTaskPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Command presentMenuCommand { get; }
        public Command CreateCommand { get; }

        public CreateTaskPageViewModel()
        {
            CreateCommand = new Command(async () =>
            {
                if((String.IsNullOrEmpty(Description))|| (String.IsNullOrEmpty(UserName)) || (String.IsNullOrEmpty(Title)))
                {
                    await Application.Current.MainPage.DisplayAlert("Crear Tarea", "Debes llenar todos los campos!", "Ok");
                }
                else
                {
                    Tarea.Description = Description;
                    Tarea.UserName = UserName;
                    Tarea.Title = Title;
                    Tarea.IsComplete = false;
                    Tarea.CreationDate = DateTime.Now;
                    var createTarea = await Locator.Database.CreateTarea(Tarea);
                    if (createTarea == 1)
                    {
                        Description = String.Empty;
                        UserName = String.Empty;
                        Title = String.Empty;
                        await Application.Current.MainPage.Navigation.PopAsync();
                    }
                }
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

        private string description = String.Empty;
        public string Description
        {
            get => description;
            set
            {
                description = value;
                var args = new PropertyChangedEventArgs(nameof(Description));
                PropertyChanged?.Invoke(this, args);
            }
        }

        private string title = String.Empty;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                var args = new PropertyChangedEventArgs(nameof(title));
                PropertyChanged?.Invoke(this, args);
            }
        }

        private string userName = String.Empty;
        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                var args = new PropertyChangedEventArgs(nameof(UserName));
                PropertyChanged?.Invoke(this, args);
            }
        }

    }
}

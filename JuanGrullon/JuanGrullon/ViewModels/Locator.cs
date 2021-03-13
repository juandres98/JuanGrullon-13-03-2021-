using JuanGrullon.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JuanGrullon.ViewModels
{
    public static class Locator
    {
        private static Database database;
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    string dbFilename = "LocalDB.db3";
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbFilename));
                }
                return database;
            }
        }

        private static TasksPageViewModel TasksPageViewModel = new TasksPageViewModel();

        public static TasksPageViewModel StaticTasksPageViewModel
        {
            get
            {
                return TasksPageViewModel;
            }
        }

        private static CreateTaskPageViewModel CreateTaskPageViewModel = new CreateTaskPageViewModel();

        public static CreateTaskPageViewModel StaticCreateTaskPageViewModel
        {
            get
            {
                return CreateTaskPageViewModel;
            }
        }

        private static SelectTaskPageViewModel SelectTaskPageViewModel = new SelectTaskPageViewModel();

        public static SelectTaskPageViewModel StaticSelectTaskPageViewModel
        {
            get
            {
                return SelectTaskPageViewModel;
            }
        }
    }
}

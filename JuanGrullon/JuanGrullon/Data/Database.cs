using JuanGrullon.Models;
using SQLite;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JuanGrullon.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;
        readonly string _dbPath;
        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Tarea>().Wait();
            _dbPath = dbPath;
        }

        public async Task<List<Tarea>> GetTareas()
        {
            return await _database.Table<Tarea>().ToListAsync();
        }

        public async Task<int> CreateTarea(Tarea tarea)
        {
            return await _database.InsertAsync(tarea);
        }
        public async Task<int> DeleteTarea(Tarea tarea)
        {
            return await _database.DeleteAsync(tarea);
        }
        public async Task<int> UpdateTarea(Tarea tarea)
        {
            tarea.IsComplete = true;
            return await _database.UpdateAsync(tarea);
        }
    }
}

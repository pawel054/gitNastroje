using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gitNastroje.Models
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Mood>();
        }

        public Task<int> InsertMoodAync(Mood mood)
        {
            return _database.InsertAsync(mood);
        }

        public Task<Mood> GetLastMoodAsync()
        {
            return _database.Table<Mood>().Where(d => d.Date != DateTime.Now.Date).OrderByDescending(d => d.Date).FirstOrDefaultAsync();
        }

        public Task<Mood> GetMood(DateTime date)
        {
            return _database.Table<Mood>().Where(d => d.Date == date).FirstOrDefaultAsync();
        }

        public Task<List<Mood>> GetAllMoods()
        {
            return _database.Table<Mood>().OrderByDescending(d => d.Date).ToListAsync();
        }
    }
}

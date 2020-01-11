using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OhMySky.Models;
using SQLite;

namespace OhMySky
{
    public class AsteroidDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized;

        public AsteroidDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Asteroid).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Asteroid)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public Task<List<Asteroid>> GetItemsAsync()
        {
            Console.WriteLine("Getting asteroids");
            return Database.Table<Asteroid>().ToListAsync();
        }

        public Task<Asteroid> GetItemAsync(int id)
        {
            return Database.Table<Asteroid>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Asteroid item)
        {
            if (item.Id != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Asteroid item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
using Lando.Database.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Lando.Database.Services
{
    public abstract class BaseDatabaseService<T> : IBaseDatabaseService<T> where T: BaseDbModel
    {
        private static readonly string DATABASE_NAME = "Lando";
        protected ILiteCollection<T> _collection;

        public BaseDatabaseService()
        {
            var db = new LiteDatabase(GetDbPath());
            _collection = db.GetCollection<T>();
        }

        public virtual T Create(T item)
        {
            var val = _collection.Insert(item);
            return item;
        }
        public virtual T Update(T item)
        {
            _collection.Update(item);
            return item;
        }
        public virtual T Delete(T item)
        {
            var c = _collection.Delete(item.Id);
            return item;
        }
        public virtual IEnumerable<T> All()
        {
            var all = _collection.FindAll();
            return new List<T>(all);
        }

        private static string GetDbPath()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DATABASE_NAME);

                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                }

                return path;
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

                if (!Directory.Exists(libFolder))
                {
                    Directory.CreateDirectory(libFolder);
                }

                return Path.Combine(libFolder, DATABASE_NAME);
            }


            throw new NotImplementedException();
        }
    }
}

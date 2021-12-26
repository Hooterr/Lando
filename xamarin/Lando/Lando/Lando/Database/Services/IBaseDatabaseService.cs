using Lando.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lando.Database.Services
{
    public interface IBaseDatabaseService<T> where T : BaseDbModel
    {
        IEnumerable<T> All();
        T Create(T item);
        T Delete(T item);
        T Update(T item);
    }
}

using FireStats.WPF.Models.Interface;
using System.Collections.Generic;
using System.Linq;

namespace FireStats.WPF.Services.Interfaces
{
    interface IRepository<T> where T: IEntity
    {
        void Add(T item);

        IEnumerable<T> GetAll();

        //T Get(int id) => GetAll().FirstOrDefault(item => item.Id == id);

        T Get(int id);

        void Remove(T item);

        void Update(T item);
    }
}

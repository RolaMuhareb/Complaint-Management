using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Genaric
{
    public interface IGenaric<T> where T : class
    {
        void Insert(T obj);
        void update(T obj);
        void delete(int id);
        T getEdit(int id);
        List<T> getAll();
        void SaveChanges();

    }
}

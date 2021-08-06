using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess.Context;

namespace DataAccess.Genaric
{
    public class Genaric<T> : IGenaric<T> where T : class
    {
        DBContext con = null;
        DbSet<T> tab = null;

        public Genaric()
        {
            con = new DBContext();
            tab = con.Set<T>();
        }
        public void delete(int id)
        {
            var del = tab.Find(id);
            tab.Remove(del);
        }

        public T getEdit(int id)
        {
            var row = tab.Find(id);
            return row;
        }

        public List<T> getAll()
        {
            return tab.ToList();
        }

        public void Insert(T obj)
        {
           tab.Add(obj);
           SaveChanges();
        }

        public void SaveChanges()
        {
            con.SaveChanges();
        }

        public void update(T obj)
        {
            tab.Attach(obj);
            con.Entry(obj).State = EntityState.Modified;
            SaveChanges();
        }
    }
}

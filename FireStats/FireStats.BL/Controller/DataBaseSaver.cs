using System.Collections.Generic;
using System.Linq;

namespace FireStats.BL.Controller
{
    class DataBaseSaver : IDataSaver
    {

        public List<T> Load<T>() where T : class
        {
            using (var db = new FireStatContext())
            {
                return db.Set<T>().Where(t => true).ToList();
            }
        }


        public void Save<T>(List<T> item) where T : class
        {
            using (var db = new FireStatContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }
    }
}

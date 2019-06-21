using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace carritOSCore.Model.Repository
{
    public interface CrudRepository<T>
    {
        bool Save(T t);
        bool Update(T t);
        bool Delete(T t);
        List<T> FindAll();
        T FindById(int? id);
    }
}

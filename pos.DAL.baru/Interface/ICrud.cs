using System;
using System.Collections.Generic;
using System.Text;

namespace pos.DAL.Interface
{
    public interface ICrud<T>
    {
        IEnumerable<T> GetAll();
        T GetByID (int id);
        
        void Delete (int id);   

        void Insert(T entity);
        void Update(T entity);  
    }
}

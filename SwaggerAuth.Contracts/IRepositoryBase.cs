using SwaggerAuth.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwaggerAuth.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAll();
        User GetbyId(string id);  
        User AuthenticateUser(string usernamem, string password);
        bool Register(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

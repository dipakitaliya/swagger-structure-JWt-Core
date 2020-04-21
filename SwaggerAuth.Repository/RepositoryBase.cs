using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SwaggerAuth.Contracts;
using SwaggerAuth.Entity;
using SwaggerAuth.Entity.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace SwaggerAuth.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
      //  private IConfiguration _Configuration;
       

        protected RepoContext _Context { get; set; }
        public RepositoryBase(RepoContext context)
        {
           // _Configuration = configuration;
            _Context = context;
        }

        public IQueryable<T> GetAll()
        {
            var data = this._Context.Set<T>().AsNoTracking();
            return data;
        }

        public bool Register(T entity)
        {
            this._Context.Set<T>().Add(entity);

            return true;
        }


        public User AuthenticateUser(string username,string password)
        {
            return _Context.Users.Where(a => a.UserName == username && a.Password == password).FirstOrDefault();

        }

        public void Update(T entity)
        {
            this._Context.Set<T>().Update(entity);
        }

        public User GetbyId(string id)
        {
            return _Context.Users.Where(a=>a.UserId.ToString() == id).FirstOrDefault();
        }

        public void Delete(T entity)
        {
             this._Context.Set<T>().Remove(entity);
        }
    }
}

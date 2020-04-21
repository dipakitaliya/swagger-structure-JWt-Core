using SwaggerAuth.Contracts;
using SwaggerAuth.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwaggerAuth.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IUserRepository _User;
        private RepoContext _context;


        public IUserRepository User
        {
            get
            {
                if (_User == null)
                {
                    _User = new UserRepository(_context);
                }
                return _User;
            }

        }

        public RepositoryWrapper(RepoContext context)
        {
            _context = context;
        }

        public void Save()
         {
            _context.SaveChanges();
        }
    }
}

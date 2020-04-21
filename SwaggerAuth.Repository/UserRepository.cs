using SwaggerAuth.Contracts;
using SwaggerAuth.Entity;
using SwaggerAuth.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwaggerAuth.Repository
{
   public class UserRepository :RepositoryBase<User>,IUserRepository  
    {
        public UserRepository(RepoContext repoContext):base(repoContext)
        {

        }
    }
}

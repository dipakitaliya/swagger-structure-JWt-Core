using System;
using System.Collections.Generic;
using System.Text;

namespace SwaggerAuth.Contracts
{
   public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        void Save();
    }
}

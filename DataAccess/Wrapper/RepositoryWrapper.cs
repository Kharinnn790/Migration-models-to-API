using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AppDbContext _repoContext;
        private IUserRepository _user;
        public IUserRepository User
        {
            get {
                if(_user == null){
                    _user = new UserRepository(_repoContext);    
                } 
                return _user; 
            }
        }

        public IRepositoryWrapper Repository => throw new NotImplementedException();

        object IRepositoryWrapper.User { get => Repository.User; set => Repository.User = value; }

        public RepositoryWrapper(AppDbContext appDbContext)
        {
            _repoContext = appDbContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}

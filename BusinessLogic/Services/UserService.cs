using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

using Task = DataAccess.Models.Task;


namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper) => _repositoryWrapper = repositoryWrapper;

        public async Task<List<User>> GetAll() { return await _repositoryWrapper.User.FindAll().ToListAsync(); }

        public Task<User> GetById(int id)
        {
            var user = _repositoryWrapper.User.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Task.FromResult(user);
        }

        public Task Create(User model)
        {
            _repositoryWrapper.User.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(User model)
        {
            _repositoryWrapper.User.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var user = _repositoryWrapper.User.FindByCondition(x => x.Id == id).FirstOrDefault();
            if (user != null)
            {
                _repositoryWrapper.User.Delete(user);
                _repositoryWrapper.Save();
            }
            return Task.CompletedTask;
        }
    }
}

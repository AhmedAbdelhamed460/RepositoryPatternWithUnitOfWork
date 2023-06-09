
using DataModels;

using DataModels.Models;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbcontext _dbcontext;
        public UnitOfWork(ApplicationDbcontext dbcontext)
        {
            
            _dbcontext = dbcontext;
            Author = new BaseRepository<Author>(_dbcontext);
            Book = new BaseRepository<Book>(_dbcontext);

        }
        public IBaseRepository<Author> Author { get; private set; }

        public IBaseRepository<Book> Book { get; private set; }

        public int Complete()
        {
         return   _dbcontext.SaveChanges();
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}

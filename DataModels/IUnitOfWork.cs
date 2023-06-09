
using DataModels.Models;
using RepositoryPatternWithUOW.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public interface IUnitOfWork  : IDisposable
    {
       IBaseRepository<Author> Author { get; }
        IBaseRepository<Book> Book { get; }
        int Complete();



    }
}

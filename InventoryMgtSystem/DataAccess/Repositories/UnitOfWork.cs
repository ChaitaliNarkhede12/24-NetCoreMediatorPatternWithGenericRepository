using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; }

        public UnitOfWork(InventoryDBContext context)
        {
            Context = context;
        }

        public void Dispose()
        {
            Context.Dispose();

        }
    }

}

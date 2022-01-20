﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
    }

}

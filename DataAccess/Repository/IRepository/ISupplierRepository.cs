﻿using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetIenumSupplier();
    }
}

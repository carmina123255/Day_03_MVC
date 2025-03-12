﻿using LinkDev.IKEA.DAL.Contacts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Contracts
{
   public interface IUnitOfWork
    {
        public IDepartmentRepository  DepartmentRepository { get; set; }

        int Complete();
        void Dispose();

    }
}

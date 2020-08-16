using AppEmpresas.Domain.IUoW;
using AppEmpresas.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppEmpresas.Infra.Data.UoW
{
   public class UnityOrWork : IUnityOfWork
    {
        private readonly UserContext _context;

        public UnityOrWork(UserContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.Database.CurrentTransaction.Commit();
        }

        public void RollBack()
        {
            _context.Database.CurrentTransaction.Rollback();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}

    


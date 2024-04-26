using DataBase.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    public class RepositoryBase
    {
        public readonly AudisoftContext _db;
        private IDbContextTransaction _dbContextTransaction;

        public RepositoryBase(AudisoftContext db)
        {
            _db = db;
        }

        public void BeginTransaccion() {
            _dbContextTransaction = _db.Database.BeginTransaction();
        }

        public void CommitTransaccion()
        {
            _dbContextTransaction.Commit();
        }

        public void RollbackTransaccion()
        {
            _dbContextTransaction.Rollback();
        }
    }
}

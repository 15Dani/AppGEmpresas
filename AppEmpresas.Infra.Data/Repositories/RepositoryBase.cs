//using AppEmpresas.Domain.Entities;
//using AppEmpresas.Domain.Interfaces.IRepositories;
//using AppEmpresas.Infra.Data.Context;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace AppEmpresas.Infra.Data.Repositories
//{
//   public class RepositoryBase<TEntity> : IRepositoryRead<TEntity>, IRepositoryWrite<TEntity> where TEntity : EntityBase, new()
//    {
//        protected UserContext Db;
//        protected DbSet<TEntity> DbSet;

//        protected RepositoryBase(UserContext Context)
//        {
//            Db = Context;
//            DbSet = Db.Set<TEntity>();
//        }

//        public virtual void Adicionar(TEntity obj)
//        {
//            DbSet.Add(obj);
//        }

//        public virtual void Atualizar(TEntity obj)
//        {
//            var entry = Db.Entry(obj);
//            DbSet.Attach(obj);
//            entry.State = EntityState.Modified;
//        }

//        public virtual IEnumerable<TEntity> ObterTodos()
//        {
//            return DbSet.ToList();
//        }
//        public virtual TEntity ObterPorId(int id)
//        {
//            return DbSet.Find(id);
//        }
//        public int SaveChanges()
//        {
//            return Db.SaveChanges();
//            //return SaveChanges();
//        }

//        public void Dispose()
//        {
//            Db.Dispose();
//            GC.SuppressFinalize(this);
//        }


//    }
//}

    


    


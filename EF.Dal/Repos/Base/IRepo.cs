﻿using System;
using System.Collections.Generic;

namespace EF.Dal.Repos.Base
{
    // The IRepo base interface exposes many of the common methods used in data access.
    public interface IRepo<T> : IDisposable
    {
        int Add(T entity, bool persist = true);
        int AddRange(IEnumerable<T> entities, bool persist = true);
        int Update(T entity, bool persist = true);
        int UpdateRange(IEnumerable<T> entities, bool persist = true);
        int Delete(int id, byte[] timeStamp, bool persist = true);
        int Delete(T entity, bool persist = true);
        int DeleteRange(IEnumerable<T> entities, bool persist = true);
        T? Find(int? id);
        T? FindAsNoTracking(int id);
        T? FindIgnoreQueryFilters(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllIgnoreQueryFilters();
        void ExecuteQuery(string sql, object[] sqlParametersObjects);
        int SaveChanges();
    }
}
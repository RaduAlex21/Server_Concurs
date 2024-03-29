﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetEntitiesWhereAsync(Func<T, bool> expression);
    Task<T> InsertAsync(T value);
    Task<T?> UpdateAsync(T value);
    Task<T> SearchByIdAsync(int id);
    Task<T> FirstOrDefaultAsync(Func<T, bool> expression);
    Task<bool> DeleteAsync(T value);
}

﻿using System.Threading.Tasks;

namespace Practice.Services.Interfaces
{
    public interface IDeleteEmployee
    {
        Task Delete(int id);
    }
}

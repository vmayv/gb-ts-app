﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Interfaces
{
    public interface IUserManager
    {
        Task<User> GetItem(Guid id);
        Task<IEnumerable<User>> GetItems();
        Task<Guid> Create(UserRequest sheet);
        Task Update(Guid id, UserRequest sheetRequest);
        Task Delete(Guid id);
    }
}
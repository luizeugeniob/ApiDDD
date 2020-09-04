using ApiDDD.Domain.Dtos.State;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDDD.Domain.Interfaces.Services.State
{
    public interface IStateService
    {
        Task<StateDto> Get(Guid id);
        Task<IEnumerable<StateDto>> GetAll();
    }
}

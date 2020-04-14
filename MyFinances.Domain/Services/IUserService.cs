using MyFinances.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Domain.Services
{
    public interface IUserService : IDisposable
    {

        //Task<IEnumerable<AvaliacaoContratoVM>> GetAvaliacoesPossiveisAync(CreateAvaliacaoFiltrosContratoVM filtros = null);
        Task<IEnumerable<User>> GetAll();
    }
}

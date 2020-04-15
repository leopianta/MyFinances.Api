using AutoMapper;
using Dapper.Dommel;
using MyFinances.Core.Entities;
using MyFinances.CrossCutting.Configuracoes;
using MyFinances.Domain.Repository;
using MyFinances.Infra.Dto;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MyFinances.Infra.Repository
{
    public class BaseDtoRepository<EntityDomain, DtoModel> : IBaseRepository<EntityDomain>
        where EntityDomain : Entity
        where DtoModel : class
    {
        protected readonly ConexaoDBConfig _config;
        protected readonly IMapper _mapper;
        protected IDto<EntityDomain, DtoModel> Dto;

        public BaseDtoRepository(ConexaoDBConfig config, IMapper mapper)
        {
            _mapper = mapper;
            _config = config;
        }

        public bool DeleteUser(int id)
        {
            try
            {
                using (var db = new MySqlConnection(this._config.DBConnectionString))
                {
                    var entity = GetById(id);
                    if (entity != null)
                    {
                        DtoModel viewModel = (DtoModel)_mapper.Map<EntityDomain, DtoModel>(entity);
                        return db.Delete(viewModel);
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<EntityDomain> GetAll()
        {
            try
            {
                using (var db = new MySqlConnection(this._config.DBConnectionString))
                {
                    var dbresult = db.GetAll<DtoModel>();
                    return _mapper.Map<IEnumerable<EntityDomain>>(dbresult);
                }
            }
            catch (Exception)
            {
                return default(List<EntityDomain>);
            }
        }

        public EntityDomain GetById(int id)
        {
            try
            {
                using (var db = new MySqlConnection(this._config.DBConnectionString))
                {
                    var dbresult = db.Get<DtoModel>(id);
                    return _mapper.Map<EntityDomain>(dbresult);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<EntityDomain> GetList(Expression<Func<EntityDomain, bool>> predicate)
        {
            try
            {
                using (var db = new MySqlConnection(this._config.DBConnectionString))
                {
                    Expression<Func<DtoModel, bool>> expression = (Expression<Func<DtoModel, bool>>)_mapper.Map<Expression<Func<EntityDomain, bool>>, Expression<Func<DtoModel, bool>>>(predicate);
                    var xx = db.Select<DtoModel>(expression);

                    return default(List<EntityDomain>);
                }
            }
            catch (Exception ex)
            {
                return default(List<EntityDomain>);
            }
        }

        public bool Insert(ref EntityDomain entity)
        {
            try
            {
                using (var db = new MySqlConnection(this._config.DBConnectionString))
                {
                    DtoModel viewModel = (DtoModel)_mapper.Map<EntityDomain, DtoModel>(entity);
                    db.Insert(viewModel);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(EntityDomain entity)
        {
            try
            {
                using (var db = new MySqlConnection(this._config.DBConnectionString))
                {
                    DtoModel viewModel = (DtoModel)_mapper.Map<EntityDomain, DtoModel>(entity);
                    return db.Update(viewModel);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

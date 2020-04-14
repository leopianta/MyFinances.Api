using AutoMapper;
using Dapper;
using Dapper.Dommel;
using MyFinances.CrossCutting.Configuracoes;
using MyFinances.Domain.Entities;
using MyFinances.Domain.Repository;
using MyFinances.Infra.Dto;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyFinances.Infra.Repository
{
    public class UserRepository : BaseDtoRepository<User, UserDto>, IUserRepository
    {
        public UserRepository(ConexaoDBConfig config, IMapper mapper) : base(config, mapper)
        {

        }

        public bool ExistsUserByName(User user)
        {
            Expression<Func<UserDto, bool>> select = null;
            select = srv => (srv.Nome == user.nome && srv.Id != user.Id);
            using (var db = new MySqlConnection(this._config.DBConnectionString))
            {
                return (db.Select(select).ToList().Any()) ? true : false;
            }
        }

        //public bool InsertV2(User model)
        //{
        //    try
        //    {
        //        var sqlStatement = @"
        //                INSERT INTO myfinancesdb.user 
        //                (`Id`,
        //                `Codigo`,
        //                `Nome`,
        //                `Email`,
        //                `Senha`,
        //                `TipoUsuario`)
        //                VALUES (`@Id`,
        //                `@Codigo`,
        //                `@Nome`,
        //                `@Email`,
        //                `@Senha`,
        //                `@TipoUsuario`)";
        //        var prm = new DynamicParameters();
        //        prm.Add("Id", model.Id);
        //        prm.Add("Codigo", model.codigo);
        //        prm.Add("Nome", model.nome);
        //        prm.Add("Email", model.email);
        //        prm.Add("Senha", model.senha);
        //        prm.Add("TipoUsuario", model.tipoUsuario);


        //        //using (var connection = new SqlConnection(_connectionString))
        //        using (var db = new MySqlConnection(this._config.DBConnectionString))
        //        {
        //            db.Open();
        //            db.Execute(sqlStatement, prm);
        //        }

        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        var a = e;
        //        return false;
        //    }
        //}

    }
}

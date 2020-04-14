using Dapper.FluentMap.Dommel.Mapping;
using MyFinances.Infra.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFinances.Infra.DtoMapping
{
    public class UserDtoMap : DommelEntityMap<UserDto>
    {
        public UserDtoMap()
        {
            ToTable("User");
            Map(x => x.Id).ToColumn("Id").IsKey().IsIdentity();
            Map(x => x.Nome).ToColumn("Nome");
            Map(x => x.Email).ToColumn("Email");
            Map(x => x.Senha).ToColumn("Senha");
            Map(x => x.TipoUsuario).ToColumn("TipoUsuario");
            Map(x => x.DataAtualizacao).ToColumn("DataAtualizacao");

        }
    }
}

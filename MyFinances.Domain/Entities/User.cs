using MyFinances.Core.Entities;
using MyFinances.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFinances.Domain.Entities
{
    public class User : Entity
    {
   
        public string nome { get; private set; }
        public string email { get; private set; }
        public string senha { get; private set; }
        public EnumTipoUsuario tipoUsuario { get; private set; }

        public User(string nome, string email, string senha, EnumTipoUsuario tipoUsuario)
        {
            this.email = email;
            this.senha = senha;
            this.nome = nome;
            this.tipoUsuario = tipoUsuario;

            //AddNotifications(nome); para validar campos com valueObject
        }

        public User(string email, string senha)
        {
            this.email = email;
            this.senha = senha;
        }

    }
}

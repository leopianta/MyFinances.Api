using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFinances.Core.Entities
{
    public class Entity : Notifiable
    {
        public int Id { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public Entity()
        {
            DataAtualizacao = DateTime.Now;
        }

        //public void SetGuid(Guid guid)
        //{
        //    Id = guid;
        //}
    }
}

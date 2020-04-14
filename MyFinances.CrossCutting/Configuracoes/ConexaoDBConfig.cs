using System;
using System.Collections.Generic;
using System.Text;

namespace MyFinances.CrossCutting.Configuracoes
{
    public class ConexaoDBConfig
    {
        public string Servidor { get; set; }
        public int Porta { get; set; }
        public string Database { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public string ConnectionString { get => $"server={Servidor};port={Porta};userid={Usuario};password={Senha}"; }
        public string DBConnectionString { get => $"{ConnectionString};database={Database};"; }
    }
}

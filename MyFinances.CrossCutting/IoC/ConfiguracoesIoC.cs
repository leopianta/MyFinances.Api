using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyFinances.CrossCutting.Configuracoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFinances.CrossCutting.IoC
{
    public static class ConfiguracoesIoC
    {
        public static IServiceCollection AdicionaConfiguracoes(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider(false);
            var configuracoes = serviceProvider.GetService<IConfigurationRoot>();

            var conexaoDBConfig = configuracoes.GetSection("Conexao").Get<ConexaoDBConfig>();
            services.AddSingleton<ConexaoDBConfig>(conexaoDBConfig);

            return services;
        }
    }
}

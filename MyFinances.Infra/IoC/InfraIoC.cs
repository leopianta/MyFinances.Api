using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using MyFinances.CrossCutting.Configuracoes;
using MyFinances.Domain.Repository;
using MyFinances.Domain.Services;
using MyFinances.Infra.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using static Dommel.DommelMapper;

namespace MyFinances.Infra.IoC
{
    public static class InfraIoC
    {
        public static IServiceCollection AddInfraIoC(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => {
                cfg.AddExpressionMapping();
            }, typeof(InfraIoC).Assembly);

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            SetKeyPropertyResolver(new DefaultKeyPropertyResolver());

            services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddMySql5()
                    .WithGlobalConnectionString(serviceProvider =>
                    {
                        var config = serviceProvider.GetService<ConexaoDBConfig>();
                        return config.DBConnectionString;
                    })
                    .ScanIn(typeof(InfraIoC).Assembly).For.Migrations());
            UpdateDatabase(services.BuildServiceProvider(false));
            return services;
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {

            using (var scope = serviceProvider.CreateScope())
            {
                var config = scope.ServiceProvider.GetService<ConexaoDBConfig>();
                using (var db = new MySqlConnection(config.ConnectionString))
                using (var cmd = new MySqlCommand($"CREATE DATABASE IF NOT EXISTS {config.Database}", db))
                {
                    db.Open();
                    cmd.ExecuteNonQuery();
                }

                var runner = scope.ServiceProvider.GetService<IMigrationRunner>();
                if (runner.HasMigrationsToApplyUp()) { 
                    runner.MigrateUp();
                }
            }
        }
    }
}

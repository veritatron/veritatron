using Veritatron.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Veritatron_Web>(ResourceNames.Web)
    .WithExternalHttpEndpoints()
    .WithConfigurationSection(builder.Configuration, ConfigurationSections.Subsites)
    .WithConfigurationSection(builder.Configuration, ConfigurationSections.Legal);

builder.Build().Run();

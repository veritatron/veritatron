using Veritatron.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Veritatron_Web>(ResourceNames.Web)
    .WithExternalHttpEndpoints();

builder.Build().Run();

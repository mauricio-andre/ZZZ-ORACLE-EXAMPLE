using ZZZOracleExample.Core.Handlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ZZZOracleExample.Core.Commands;
using System.Reflection;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((ctx, services) =>
    {
        services.AddOracleCoreDbContext(options =>
        {
            options.UseOracle(ctx.Configuration.GetConnectionString("CoreDbContext"));
        });

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateExampleCmdHandler).GetTypeInfo().Assembly));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RemoveExampleCmdHandler).GetTypeInfo().Assembly));
    })
    .Build();

// await host.RunAsync();

ExemplifyServiceLifetime(host.Services);

static void ExemplifyServiceLifetime(IServiceProvider hostProvider)
{
    using IServiceScope serviceScope = hostProvider.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    IMediator mediator = provider.GetRequiredService<IMediator>();
    var result = mediator.Send(new CreateExampleCmd("Example")).GetAwaiter().GetResult();
    mediator.Send(new RemoveExampleCmd(result.Id)).Wait();
    Console.WriteLine("Finished...");
}

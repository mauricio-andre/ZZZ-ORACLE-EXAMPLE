using ZZZOracleExample.Core.Commands;
using ZZZOracleExample.Core.Data;
using MediatR;

namespace ZZZOracleExample.Core.Handlers;

public class RemoveExampleCmdHandler : IRequestHandler<RemoveExampleCmd>
{
    private readonly CoreDbContext _dbContext;
    private readonly IMediator _mediator;

    public RemoveExampleCmdHandler(
        CoreDbContext dbContext,
        IMediator mediator)
    {
        _dbContext = dbContext;
        _mediator = mediator;
    }

    public virtual async Task Handle(RemoveExampleCmd request, CancellationToken cancellationToken)
    {
        await _dbContext.Examples
            .Where(example => example.Id == request.Id)
            .DeleteFromQueryAsync();
    }
}
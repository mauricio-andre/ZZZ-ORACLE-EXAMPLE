using ZZZOracleExample.Core.Commands;
using ZZZOracleExample.Core.Data;
using ZZZOracleExample.Core.Examples.Entities;
using ZZZOracleExample.Core.Responses;
using MediatR;

namespace ZZZOracleExample.Core.Handlers;

public class CreateExampleCmdHandler : IRequestHandler<CreateExampleCmd, ExampleResponse>
{
    private readonly CoreDbContext _dbContext;
    private readonly IMediator _mediator;

    public CreateExampleCmdHandler(
        CoreDbContext dbContext,
        IMediator mediator)
    {
        _dbContext = dbContext;
        _mediator = mediator;
    }

    protected static Example MapToEntity(CreateExampleCmd request)
        => new Example
        {
            Name = request.Name
        };

    protected static ExampleResponse MapToResponse(Example entity)
        => new ExampleResponse(entity.Id, entity.Name);

    public virtual async Task<ExampleResponse> Handle(CreateExampleCmd request, CancellationToken cancellationToken)
    {
        if (!_dbContext.Examples.Any())
        {
            var entity = MapToEntity(request);
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        // TODO: Here is the problem
        _dbContext.Examples.Take(1).InsertFromQuery(example => new
        {
            Name = example.Name + "_byQuery",
        });

        var originalEntity = _dbContext.Examples.First(example => example.Name == request.Name);
        return MapToResponse(originalEntity);
    }
}
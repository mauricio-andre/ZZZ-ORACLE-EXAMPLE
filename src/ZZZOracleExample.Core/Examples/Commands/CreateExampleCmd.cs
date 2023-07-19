using MediatR;
using ZZZOracleExample.Core.Responses;

namespace ZZZOracleExample.Core.Commands;

public record CreateExampleCmd
(
    string Name
): IRequest<ExampleResponse>;
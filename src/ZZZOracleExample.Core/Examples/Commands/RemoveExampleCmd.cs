using MediatR;

namespace ZZZOracleExample.Core.Commands;

public record RemoveExampleCmd
(
    int Id
): IRequest;
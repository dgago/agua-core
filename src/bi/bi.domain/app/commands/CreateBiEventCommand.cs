using System.Collections.Generic;
using System.Threading.Tasks;

using bi.domain.data;
using bi.domain.model.bi_event;
using bi.domain.services;

using core.domain.app;
using core.domain.app.commands;
using core.domain.extensions;
using core.domain.services;

namespace bi.domain.app.commands
{
  public sealed class CreateBiEventCommand : Command
  {
    public CreateBiEventCommand(
      string id,
      string name,
      string payload) : base(id)
    {
      this.Name = name;
      this.Payload = payload;
    }

    public string Name { get; }

    public string Payload { get; }
  }

  public sealed class CreateBiEventCommandHandler
    : BiEventCommandHandler<CreateBiEventCommand>
  {
    private readonly BiEventDomainService _bieventDs;

    public CreateBiEventCommandHandler(
      IBiEventRepository bieventRepository,
      IAuthorizationContext context,
      BiEventDomainService bieventDs)
      : base(bieventRepository, context)
    {
      this._bieventDs = bieventDs.NotNull(nameof(bieventDs));
    }

    public override CommandResult Handle(CreateBiEventCommand command)
    {
      // executes bi event
      string factName = command.Name;

      // parses event payload taking into account the catalog of allowed events
      IDictionary<string, dynamic> parts = this._bieventDs.ParsePayload(
        command.Name,
        command.Payload);

      // validates event consistency
      BiEventRoot item = new BiEventRoot(
        command.Id,
        this._context.Username ?? this._context.Client,
        command.Name,
        parts);

      // saves bi event
      string id = this._repository.Create(item);

      return new CommandResult(id, item.DomainEvents);
    }

    public override Task<CommandResult> HandleAsync(CreateBiEventCommand command)
    {
      throw new System.NotImplementedException();
    }
  }
}
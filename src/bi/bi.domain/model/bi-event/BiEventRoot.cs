using System;
using System.Collections.Generic;
using core.domain.extensions;
using core.domain.model;

namespace bi.domain.model.bi_event
{
  //public enum BiEventStatus
  //{
  //  Created = 1,

  //}

  public class BiEventRoot : AggregateRoot
  {
    internal BiEventRoot(
      string id,
      string owner,
      string name,
      IDictionary<string, dynamic> payload,
      uint version = 0)
      : base(id, owner, null, version)
    {
      this.CreatedDate = DataExtensions.Now();
      this.Name = name.NotNull(nameof(name));
      this.Payload = this.ValidatePayload(payload.NotNull(nameof(payload)));
      //this.Status = BiEventStatus.Created;

      if (this.IsNew)
      {
        this.AddEvent(
          new BiEventCreatedEvent(
            id,
            this.Name,
            this.Payload,
            //this.Status,
            this.CreatedDate));
      }
    }

    public DateTime CreatedDate { get; }

    public string Name { get; }

    public IDictionary<string, dynamic> Payload { get; }

    protected override TData ToData<TData>()
    {
      throw new NotImplementedException();
    }

    private IDictionary<string, dynamic> ValidatePayload(
      IDictionary<string, dynamic> dictionary)
    {
      // TODO: validar payload
      return dictionary;
    }

    //public string Result { get; }

    //public BiEventStatus Status { get; }

    //internal void SetResultError(Exception ex)
    //{
    //  this.Result = ex.Message;

    //  this.AddEvent(new BiEventExecutedEvent(this.Id, this.Result));
    //}

    //internal void SetResultHandlerDoesNotExist()
    //{
    //  this.Result = "Handler does not exist";

    //  this.AddEvent(new BiEventExecutedEvent(this.Id, this.Result));
    //}

    //internal void SetResultOk()
    //{
    //  this.Result = "OK";

    //  this.AddEvent(new BiEventExecutedEvent(this.Id, this.Result));
    //}
  }
}

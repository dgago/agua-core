using System;
using System.Collections.Generic;

namespace core.domain.data
{
  public class Results<T>
  {

    public Results(long count, IEnumerable<T> items, uint pageIndex, uint pageSize)
    {
      Count = count;
      Items = items;
      PageIndex = pageIndex;
      PageSize = pageSize;
      PageCount = CalculatePageCount(count, pageSize);
    }

    public long Count { get; set; }

    public IEnumerable<T> Items { get; set; }

    public uint PageCount { get; set; }

    public uint PageIndex { get; set; }

    public uint PageSize { get; set; }

    protected uint CalculatePageCount(long count, uint pageSize)
    {
      return (uint)Math.Ceiling((double)count / pageSize);
    }

  }
}
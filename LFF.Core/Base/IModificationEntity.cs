using System;

namespace LFF.Core.Base
{
    public interface IModificationEntity
    {
        DateTime? LastUpdatedAt { get; set; }
    }
}

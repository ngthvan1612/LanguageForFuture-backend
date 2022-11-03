using System;

namespace LFF.Core.Base
{
    public interface IDeletionEntity
    {
        DateTime? DeletedAt { get; set; }
    }
}

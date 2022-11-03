namespace LFF.Core.Base
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}

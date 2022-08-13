namespace Ecs
{
    public interface IEntity
    {
        int Id { get; }
        bool Has(int componentId);
        void Add(IComponent comp);
        TComponent Get<TComponent>(int componentId);
    }
}

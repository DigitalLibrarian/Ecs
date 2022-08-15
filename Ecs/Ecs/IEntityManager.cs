using System.Collections.Generic;

namespace Ecs
{
    public interface IEntityManager
    {
        IEntity Create();
        IEntity Create(int entityId);

        IEntity Get(int entityId);
        IEntity Delete(int entityId);
        IEnumerable<IEntity> GetEntities();

        IEnumerable<IEntity> ByComponents(params int[] componentId);
        IEnumerable<IEntity> ByComponents(IEnumerable<int> componentId);
    }
}

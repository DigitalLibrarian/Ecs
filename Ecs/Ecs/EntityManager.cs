using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs
{
    public class EntityManager : IEntityManager
    {
        Dictionary<int, IEntity> Entities { get; set; }

        public EntityManager()
        {
            Entities = new Dictionary<int, IEntity>();
        }

        public IEntity Create()
        {
            int id = Entities.Keys.OrderBy(x => x).LastOrDefault() + 1;
            return Create(id);
        }
        public IEntity Create(int entityId)
        {
            var entity = new Entity(entityId);
            Entities.Add(entityId, entity);
            return entity;
        }

        public IEntity Get(int entityId)
        {
            if (!Entities.ContainsKey(entityId)) return null;

            return Entities[entityId];
        }

        public IEnumerable<IEntity> GetEntities()
        {
            return Entities.Values;
        }

        public IEnumerable<IEntity> ByComponents(params int[] componentIds)
        {
            return ByComponents(componentIds.AsEnumerable());
        }
        public IEnumerable<IEntity> ByComponents(IEnumerable<int> componentIds)
        { 
            return Entities.Values.Where(
                        entity => {
                            foreach(var reqId in componentIds)
                            {
                                if (!entity.Has(reqId))
                                {
                                    return false;
                                }
                            }
                            return true;
                        });
        }


        public IEntity Delete(int entityId)
        {
            var entity = Get(entityId);
            if (entity != null)
                Entities.Remove(entityId);
            return entity;
        }
    }
}

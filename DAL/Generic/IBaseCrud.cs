using System.Collections.Generic;

namespace DAL.Generic
{
    public interface IBaseCrud<Entity, Key>
    {
        List<Entity> GetAll();
        Entity GetById(Key id);
        bool update(Entity entity);
        bool Add(Entity entity);
        bool Delete(Key value);
    }
}

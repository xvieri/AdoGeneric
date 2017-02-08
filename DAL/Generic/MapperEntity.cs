using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Generic
{
    public class MapperEntity<TEntity>
    {
        public Dictionary<string, object> ParamentersFromEntity(TEntity entity, string skipColumn)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();
            foreach (var prop in entity.GetType().GetProperties())
            {
                if (prop.MemberType == System.Reflection.MemberTypes.Property)
                {
                    if (prop.CanRead && prop.PropertyType.IsSerializable && prop.PropertyType.IsPublic)
                    {
                        if (!skipColumn.Equals(prop.Name))
                        {
                            string name = prop.Name;
                            Object value = prop.GetValue(entity, null);
                            values.Add(name, value);
                        }
                    }
                }
            }
            return values;
        }
    }
}

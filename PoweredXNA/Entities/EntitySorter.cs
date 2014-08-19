using System.Collections.Generic;

namespace PoweredXNA.Entities
{
    internal static class EntitySorter
    {
        public static void SortByZIndex(this List<Entity> list)
        {
            bool sorted = false;

            foreach (Entity entity in list)
            {
                if (entity.ZIndexChanged)
                {
                    entity.ZIndexChanged = false;
                    if (!sorted)
                    {
                        list.Sort(new EntityComparer());
                        sorted = true;
                    }
                }
            }
        }
    }

    internal class EntityComparer : IComparer<Entity> { public int Compare(Entity e1, Entity e2) { return e1.ZIndex.CompareTo(e2.ZIndex); } }
}

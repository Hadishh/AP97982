using System.Collections.Generic;

namespace APLabDigiKalaProject
{
    public class ItemInventory
    {
        public List<Item> Items { get; set; }
        public Item GetItemById(int id)
        {
            foreach(var item in Items)
            {
                if (item.Id == id)
                    return item;
            }
            return null;
        }
        public ItemInventory()
        {
            Items = new List<Item>();
        }
        public int AddItem(Item item)
        {
            Items.Add(item);
            return Items.Count;
        }
        public bool RemoveItems(Item item)
        {
            return Items.Remove(item);
        }
        public List<Item> Filter(List<IFilter> filters)
        {
            List<Item> Results = new List<Item>();
            foreach(var item in Items)
            {
                bool allPassed = true;
                foreach(var filter in filters)
                {
                    if (!filter.Filter(item))
                    {
                        allPassed = false;
                        break;
                    }
                }
                if (allPassed == true)
                    Results.Add(item);
            }
            return Results;
        }
    }
}

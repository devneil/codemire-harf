using System.Collections.Generic;

namespace Harf
{
    public class ProductBacklog
    {
        private readonly List<string> _items = new List<string>();

        public static ProductBacklog GetInstance()
        {
            
            return new ProductBacklog();
        }

        public void AddBacklogItem(string itemTitle)
        {
            _items.Add(itemTitle);
        }

        public int Count()
        {
            return _items.Count;
        }

        public BacklogItem GetItemByTitle(string itemTitle)
        {
            if (_items.Contains(itemTitle))
                return new BacklogItem(itemTitle);
            return null;
        }
    }

    public class BacklogItem
    {
        public BacklogItem(string itemTitle)
        {
            Title = itemTitle;
        }

        public string Title { get; private set; }
    }

}

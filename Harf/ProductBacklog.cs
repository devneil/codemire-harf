using System.Collections.Generic;
using System.Linq;

namespace Harf
{
    public class ProductBacklog
    {
        private readonly List<BacklogItem> _items = new List<BacklogItem>();
        private static ProductBacklog _backlog;

        public static ProductBacklog GetInstance()
        {
            return _backlog ?? (_backlog = new ProductBacklog());
        }

        public BacklogItemBuilder AddBacklogItem(string itemTitle)
        {
            var builder = new BacklogItemBuilder();
            BacklogItem item = builder
                .CreateBacklogItem(itemTitle);
            _items.Add(item);
            return builder;
        }

        public int Count()
        {
            return _items.Count;
        }

        public BacklogItem GetItemByTitle(string itemTitle)
        {
            return _items.SingleOrDefault(i => i.Title.Equals(itemTitle));
        }

        internal static void Clear()
        {
            _backlog = null;
        }
    }

    public class BacklogItemBuilder
    {
        private string _title;
        private string _description;

        public BacklogItemBuilder WithDescription(string testItemDescription)
        {
            _description = testItemDescription;
            return this;
        }

        public BacklogItemBuilder CreateBacklogItem(string itemTitle)
        {
            _title = itemTitle;
            return this;
        }

        public static implicit operator BacklogItem(BacklogItemBuilder tb)
        {
            return new BacklogItem(tb._title) {Description = tb._description};
        }
    }

    public class BacklogItem
    {
        internal BacklogItem(string itemTitle)
        {
            Title = itemTitle;
        }

        public string Title { get; private set; }
        public string Description { get; set; }

    }

}

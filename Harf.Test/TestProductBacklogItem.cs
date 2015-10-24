using FluentAssertions;
using Harf;
using NUnit.Framework;

namespace HarfTest
{
    [TestFixture]
    public class TestProductBacklogItem
    {
        private ProductBacklog _backlog;

        [SetUp]
        public void SetUp()
        {
            _backlog = ProductBacklog.GetInstance();
        }
        [Test]
        public void CanAddNewItemToProductBacklog()
        {
            Add("Item Title");
            _backlog.Count().Should().Be(1);
        }

        [Test]
        public void EmptyProductBacklogIsEmpty()
        {
            _backlog.Count().Should().Be(0);
        }

        [Test]
        public void CanAddTwoItemsToProductBacklog()
        {
            Add("Item1");
            Add("Item2");
            _backlog.Count().Should().Be(2);
        }

        [Test]
        public void CanGetBacklogItemByTitle()
        {
            const string itemTitle = "Item2";
            Add("Item1");
            Add(itemTitle);
            _backlog.GetItemByTitle(itemTitle).Title.Should().Be(itemTitle);
        }

        [Test]
        public void GetNonExistentBacklogItemReturnsNull()
        {
            _backlog.GetItemByTitle("NotMe").Should().BeNull();
        }

        private void Add(string itemTitle)
        {
            _backlog.AddBacklogItem(itemTitle);
        }

    }

}


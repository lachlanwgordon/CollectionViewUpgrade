using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Xamarin.UITest;

namespace CollectionViewUpgrade.UITests
{
    public class BasicTest
    {
        [TestFixture(Platform.Android)]
        [TestFixture(Platform.iOS)]
        public class Tests
        {
            IApp app;
            Platform platform;

            public Tests(Platform platform)
            {
                this.platform = platform;
            }

            [SetUp]
            public void BeforeEachTest()
            {
                app = AppInitializer.StartApp(platform);
            }

            [Test]
            public void VisitAllPages()
            {
                app.Tap("About");
                app.WaitForElement(x => x.Marked("Learn more"));

                app.Tap("List");
                app.WaitForElement(x => x.Marked("Add"));

                app.Tap("Add");
                app.WaitForElement(x => x.Marked("Cancel"));

                app.Tap("Cancel");
                app.WaitForElement(x => x.Marked("ItemsList"));
                //app.Repl();
                app.Tap(x => x.Marked("Third item"));
                app.WaitForElement(x => x.Marked("Description:"));
                app.Back();
                Assert.Pass();
            }

            [Test]
            public void AddItem()
            {
                //app.Repl();
                app.WaitForElement("Add");
                app.Tap("Add");
                //app.Repl();

                app.Tap("NameEntry");
                app.ClearText();
                app.EnterText("Test item2");
                app.DismissKeyboard();

                app.Tap("DescriptionEditor");
                app.ClearText();
                var newGuid = Guid.NewGuid();
                app.EnterText($"New item {newGuid}");
                app.Tap("Save");
                app.WaitForElement("Test item2");

                var item = app.Query(x => x.Marked($"New item {newGuid}"));

                Assert.Greater(item.Length, 0);

            }


            //https://codetraveler.io/2019/10/03/xamarin-uitest-determine-if-xamarin-forms-listview-is-refreshing/ //MIT
            [Test]
            public void PullToRefresh()
            {
                app.WaitForElement("First item");

                app.DragCoordinates(100, 100, 100, 400);
                app.WaitForNoElement("FirstItem");

                app.WaitForElement("First item");
                var firstItemReturned = app.Query(x => x.Marked("First item")).Any();
                Assert.True(firstItemReturned);

            }

            [Test]
            public void ViewItemDetails()
            {
                app.WaitForElement("First item");
                app.Tap("First item");
                var descriptionFieldVisible = app.Query(x => x.Marked("Description:")).Any();
                Assert.True(descriptionFieldVisible);

            }

        }
    }
}

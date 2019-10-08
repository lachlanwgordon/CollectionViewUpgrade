using System;
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
                var itemsAtStart = app.Query(x => x.Marked("ItemsList").Child());
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

                var itemsAfterAdding = app.Query(x => x.Marked("ItemsList").Child());
                var item = app.Query(x => x.Marked($"New item {newGuid}"));

                Assert.Greater(item.Length, 0);

            }

        }
    }
}

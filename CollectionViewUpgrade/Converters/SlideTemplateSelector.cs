using System;
using CollectionViewUpgrade.Models;
using Xamarin.Forms;

namespace CollectionViewUpgrade.Converters
{
    
    public class SlideTemplateSelector : DataTemplateSelector
    {
        public DataTemplate HorizontalCollectionTemplate { get; set; }
        public DataTemplate TitleTemplate { get; set; }
        public DataTemplate PointsTemplate { get; set; }
        public DataTemplate ListTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is Slide slide)
            {
                switch (slide.SlideType
)
                {
                    case SlideType.List:
                        return ListTemplate;
                    case SlideType.Title:
                        return TitleTemplate;
                    case SlideType.Points:
                        return PointsTemplate;
                    case SlideType.HorizontalCollection:
                        return HorizontalCollectionTemplate;
                }
            }
            return ListTemplate;
        }
    }
}

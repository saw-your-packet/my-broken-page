using System.Collections.Generic;

namespace MyBrokenPage.UI.ViewModels
{
    public class FeedPageViewModel
    {
        public string FilterKeyword { get; set; }
        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}

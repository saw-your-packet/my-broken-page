using MyBrokenPage.Models;
using System.Collections.Generic;

namespace MyBrokenPage.UI.ViewModels
{
    public class FeedPageViewModel
    {
        public SearchViewModel SearchObject { get; set; }
        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}

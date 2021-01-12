using System.Linq;
using System.Collections.Generic;

namespace MyBrokenPage.Models
{
    public class FolderModel
    {
        public string Name { get; set; }

        public IEnumerable<string> Files { get; set; } = Enumerable.Empty<string>();
    }
}

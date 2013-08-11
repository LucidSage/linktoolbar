using System.Collections.Generic;

namespace LinkToolbar.Models
{
    public class ToolbarViewModel
    {
        public string FrameTarget { get; set; }
        public IEnumerable<Link> Links { get; set; }
    }
}
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Helpers;
using Newtonsoft.Json;

namespace LinkToolbar.Models
{
    [Table("Links")]
    public class Link
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int LinkId { get; set; }
        public int Version { get; set; }
        public string Name { get; set; }
        public string ImageSrc { get; set; }
        public string ImageAltText { get; set; }
        public LinkTarget Target { get; set; }
        public string TargetHref { get; set; }
        public IList<Link> Links { get; set; }
        [ForeignKey("Links")]
        public int? ParentId { get; set; }
        public ToolbarVisibility Visibility { get; set; }
    }

    public enum LinkTarget
    {
        Current,
        NewTab,
        NewTabNoFrame
    }

    public enum ToolbarVisibility
    {
        Public
    }
}
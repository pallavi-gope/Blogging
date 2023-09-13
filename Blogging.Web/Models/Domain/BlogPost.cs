﻿namespace Blogging.Web.Models.Domain
{
    public class BlogPost
    {
        public Guid Id { get; set; }
        public string? Heading { get; set; }
        public string? PageTitle { get; set; }
        public string? Content { get; set; }
        public string? ShortDescription { get; set; }
        public string? FeaturedImageUrl { get; set; }
        public string? UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public string? Author { get; set; } // string? mark denotes that this particular property can have null value
        public bool Status { get; set; }

        public ICollection<Tag>? Tags { get; set; }

        public ICollection<BlogPostLike>? Likes { get; set; }
        public ICollection<BlogPostComment>? Comments { get; set; }

    }
}

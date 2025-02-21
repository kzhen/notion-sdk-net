﻿using Newtonsoft.Json;

namespace Notion.Client
{
    public class PageParent : IPageParent, IDatabaseParent
    {
        /// <summary>
        /// Always "page_id".
        /// </summary>
        public ParentType Type { get; set; }

        /// <summary>
        /// The ID of the page that this page belongs to.
        /// </summary>
        [JsonProperty("page_id")]
        public string PageId { get; set; }
    }
}

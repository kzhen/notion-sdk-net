﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class TitleUpdatePropertySchema : UpdatePropertySchema, IUpdatePropertySchema
    {
        [JsonProperty("title")]
        public Dictionary<string, object> Title { get; set; }
    }
}

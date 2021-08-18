﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Notion.Client.ApiEndpoints;

namespace Notion.Client
{
    public class PagesClient : IPagesClient
    {
        private readonly IRestClient _client;

        public PagesClient(IRestClient client)
        {
            _client = client;
        }

        public async Task<Page> CreateAsync(NewPage page)
        {
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page));
            }

            if (page.Parent == null)
            {
                throw new ArgumentNullException(nameof(page.Parent), "Parent is required!");
            }

            if (page.Properties == null)
            {
                throw new ArgumentNullException(nameof(page.Properties), "Properties are required!");
            }

            return await _client.PostAsync<Page>(PagesApiUrls.Create(), page);
        }

        public async Task<Page> RetrieveAsync(string pageId)
        {
            var url = PagesApiUrls.Retrieve(pageId);
            return await _client.GetAsync<Page>(url);
        }

        public async Task<Page> UpdateAsync(string pageId, PagesUpdateParameters pagesUpdateParameters)
        {
            var url = PagesApiUrls.Update(pageId);
            var body = (IPagesUpdateBodyParameters)pagesUpdateParameters;

            return await _client.PatchAsync<Page>(url, body);
        }

        [Obsolete("This method is obsolute. Use UpdateAsync instead. This API will be removed in future release")]
        public async Task<Page> UpdatePropertiesAsync(
            string pageId,
            IDictionary<string, PropertyValue> updatedProperties)
        {
            var url = PagesApiUrls.UpdateProperties(pageId);
            var body = new UpdatePropertiesParameters { Properties = updatedProperties };

            return await _client.PatchAsync<Page>(url, body);
        }

        private class UpdatePropertiesParameters
        {
            public IDictionary<string, PropertyValue> Properties { get; set; }
        }
    }
}

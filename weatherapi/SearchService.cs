using System;
using System.Collections.Generic;
using System.Linq;

public class SearchService
{
    public List<SearchResult> SearchLocalFilesAndApps(string query)
    {
        // string Name, string IconUrl, string Description, string Type)
        var mockData = new List<SearchResult>
        {
            new SearchResult("File 1", "pathToIcon", "file 1 description", "file"),
            new SearchResult("File 2", "pathToIcon", "file 2 description", "file"),
            new SearchResult("App 1", "pathToIcon", "app 1 description", "app"),
            new SearchResult("App 2", "pathToIcon", "app 2 description", "app"),
            new SearchResult("FileApp", "pathToIcon", "app that contains the word file", "app"),
        };

        return mockData.Where(x => x.Name.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}

using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace DictionaryServer.Models;

public class DictionaryProvider
{
    private ReadOnlyDictionary<string, string> dictionary;
    public bool IsLoaded { get; private set; }

    public async Task LoadAsync()
    {
        //await Task.Delay(10000);
        const string url = "https://raw.githubusercontent.com/adambom/dictionary/master/dictionary.json";
        var httpClient = new HttpClient();
        var json = await httpClient.GetStringAsync(url);
        var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        if (data != null) IsLoaded = true;
        dictionary = new ReadOnlyDictionary<string, string>(data ?? new Dictionary<string, string>());
    }

    public string? GetValue(string key)
    {
        if (!IsLoaded) throw new NotImplementedException("Data not loaded yet.");
        if (dictionary.ContainsKey(key))
        {
            return dictionary[key];
        }
        return null;
    }
}
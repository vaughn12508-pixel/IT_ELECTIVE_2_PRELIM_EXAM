using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class GetCategories
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/categories.php";

        // Send GET request
        var response = await client.GetAsync(url);

        // Assert status code is 200 OK
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception($"Expected status code 200 OK but got {response.StatusCode}");
        }

        // Read response content
        string body = await response.Content.ReadAsStringAsync();

        // Parse JSON
        using JsonDocument document = JsonDocument.Parse(body);

        // Get categories array
        JsonElement categories = document.RootElement.GetProperty("categories");

        // Assert categories has more than 0 items
        if (categories.ValueKind == JsonValueKind.Null ||
            categories.GetArrayLength() <= 0)
        {
            throw new Exception("Categories array is empty.");
        }
    }
}
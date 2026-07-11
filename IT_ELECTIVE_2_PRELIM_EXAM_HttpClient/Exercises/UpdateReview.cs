using System.Text;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class UpdateReview
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://jsonplaceholder.typicode.com/posts/1";

        // Create JSON body
        string json = """
        {
            "id": 1,
            "title": "Updated Review",
            "body": "Even better than before!",
            "userId": 1
        }
        """;

        // Create StringContent with JSON
        using StringContent content = new StringContent(
            json,
            Encoding.UTF8,
            "application/json"
        );

        // Send PUT request
        var response = await client.PutAsync(url, content);

        // Assert status code is 200 OK
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception($"Expected status code 200 OK but got {response.StatusCode}");
        }

        // Read response content22
        string body = await response.Content.ReadAsStringAsync();

        // Parse JSON response
        using JsonDocument document = JsonDocument.Parse(body);

        // Get title
        string title = document.RootElement
            .GetProperty("title")
            .GetString() ?? "";

        // Assert title is Updated Review
        if (title != "Updated Review")
        {
            throw new Exception($"Expected title 'Updated Review' but got '{title}'");
        }
    }
}
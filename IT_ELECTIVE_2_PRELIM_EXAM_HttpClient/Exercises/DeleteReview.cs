namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class DeleteReview
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://jsonplaceholder.typicode.com/posts/1";

        // Send DELETE request
        var response = await client.DeleteAsync(url);

        // Assert status code is 200 OK2
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception($"Expected status code 200 OK but got {response.StatusCode}");
        }
    }
}
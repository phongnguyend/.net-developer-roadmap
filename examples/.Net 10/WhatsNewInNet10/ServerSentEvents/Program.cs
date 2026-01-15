using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/sse", (CancellationToken cancellationToken) =>
{
    async IAsyncEnumerable<DateTimeOffset> GetTime([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            yield return DateTimeOffset.UtcNow;
            await Task.Delay(2000, cancellationToken);
        }
    }

    return TypedResults.ServerSentEvents(GetTime(cancellationToken), eventType: "dateTime");
});

app.Run();

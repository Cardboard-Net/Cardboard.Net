using System.Collections.Immutable;
using Cardboard.Charts;
using Cardboard.Net.Rest.API;
using Cardboard.Rest.Drives;
using ActiveUserChart = Cardboard.Charts.ActiveUserChart;

namespace Cardboard.Rest;

internal static class ClientHelper
{
    public static async Task<RestUser> GetUserAsync(BaseMisskeyClient client, string id)
    {
        var model = await client.ApiClient.GetUserAsync(id).ConfigureAwait(false);
        if (model != null)
            return RestUser.Create(client, model);
        return null;
    }

    public static async Task<RestDriveFile> GetDriveFileAsync(BaseMisskeyClient client, string id)
    {
        var model = await client.ApiClient.GetFileAsync(id).ConfigureAwait(false);
        if (model != null)
            return RestDriveFile.Create(client, model);
        return null;
    }
    
    public static async Task<RestDriveFile> GetDriveFileAsync(BaseMisskeyClient client, Uri url)
    {
        var model = await client.ApiClient.GetFileAsync(url).ConfigureAwait(false);
        if (model != null)
            return RestDriveFile.Create(client, model);
        return null;
    }

    public static async Task<ActiveUserChart> GetActiveUserChartAsync(BaseMisskeyClient client, ChartType span, int? limit = null, int? offset = null)
    {
        GetChartParams chartParams = new GetChartParams()
        {
            Span = span,
            Limit = limit,
            Offset = offset
        };

        var model = await client.ApiClient.GetActiveUserChartAsync(chartParams).ConfigureAwait(false);
        
        ActiveUserChart chart = new ActiveUserChart()
        {
            Type = span,
            ReadWrite = model.ReadWrite.Length == 0 
                ? ImmutableArray<int>.Empty 
                : ImmutableArray.Create<int>(model.ReadWrite),
            Read = model.Read.Length == 0 
                ? ImmutableArray<int>.Empty 
                : ImmutableArray.Create<int>(model.Read),
            Write = model.Write.Length == 0 
                ? ImmutableArray<int>.Empty 
                : ImmutableArray.Create<int>(model.Write),
            RegisteredPastWeek = model.RegisteredPastWeek.Length == 0 
                ? ImmutableArray<int>.Empty 
                : ImmutableArray.Create<int>(model.RegisteredPastWeek),
            RegisteredPastMonth = model.RegisteredPastMonth.Length == 0 
                ? ImmutableArray<int>.Empty 
                : ImmutableArray.Create<int>(model.RegisteredPastMonth),
            RegisteredPastYear = model.RegisteredPastYear.Length == 0 
                ? ImmutableArray<int>.Empty 
                : ImmutableArray.Create<int>(model.RegisteredPastYear),
            RegisteredBeforeWeek = model.RegisteredBeforeWeek.Length == 0
                ? ImmutableArray<int>.Empty 
                : ImmutableArray.Create<int>(model.RegisteredBeforeWeek),
            RegisteredBeforeMonth = model.RegisteredBeforeMonth.Length == 0
                ? ImmutableArray<int>.Empty
                : ImmutableArray.Create<int>(model.RegisteredBeforeMonth),
            RegisteredBeforeYear = model.RegisteredBeforeYear.Length == 0
                ? ImmutableArray<int>.Empty 
                : ImmutableArray.Create<int>(model.RegisteredBeforeYear) 
        };
        
        return chart;
    }
}
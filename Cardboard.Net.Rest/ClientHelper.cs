using System.Collections.Immutable;
using Cardboard.Charts;
using Cardboard.Net.Rest.API;
using Cardboard.Rest.Drives;
using ActiveUserChart = Cardboard.Charts.ActiveUserChart;
using ApRequestChart = Cardboard.Charts.ApRequestChart;
using DriveChart = Cardboard.Charts.DriveChart;
using GenericChart = Cardboard.Charts.GenericChart;
using GenericDriveChart = Cardboard.Charts.GenericDriveChart;

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

    #region Charts
    
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
    
    public static async Task<ApRequestChart> GetApRequestChartAsync(BaseMisskeyClient client, ChartType span, int? limit = null, int? offset = null)
    {
        GetChartParams chartParams = new GetChartParams()
        {
            Span = span,
            Limit = limit,
            Offset = offset
        };

        var model = await client.ApiClient.GetApRequestChartAsync(chartParams).ConfigureAwait(false);

        ApRequestChart chart = new ApRequestChart()
        {
            Type = span,
            DeliverFailed = model.DeliverFailed.Length == 0
                ? ImmutableArray<int>.Empty 
                : ImmutableArray.Create<int>(model.DeliverFailed),
            DeliveredSucceeded = model.DeliverSucceeded.Length == 0
                ? ImmutableArray<int>.Empty 
                : ImmutableArray.Create<int>(model.DeliverSucceeded),
            InboxReceived = model.InboxReceived.Length == 0
                ? ImmutableArray<int>.Empty 
                : ImmutableArray.Create<int>(model.InboxReceived) 
        };
        
        return chart;
    }
    
    public static async Task<DriveChart> GetDriveChartAsync(BaseMisskeyClient client, ChartType span, int? limit = null, int? offset = null)
    {
        GetChartParams chartParams = new GetChartParams()
        {
            Span = span,
            Limit = limit,
            Offset = offset
        };

        var model = await client.ApiClient.GetDriveChartAsync(chartParams).ConfigureAwait(false);

        DriveChart chart = new DriveChart()
        {
            Type = span,
            Local = new GenericDriveChart()
            {
                IncreaseCount = model.Local.IncreaseCount.Length == 0 
                    ? ImmutableArray<int>.Empty 
                    : ImmutableArray.Create<int>(model.Local.IncreaseCount),
                DecreaseCount = model.Local.DecreaseCount.Length == 0
                    ? ImmutableArray<int>.Empty 
                    : ImmutableArray.Create<int>(model.Local.DecreaseCount),
                IncreaseSize = model.Local.IncreaseSize.Length == 0
                    ? ImmutableArray<ulong>.Empty
                    : ImmutableArray.Create<ulong>(model.Local.IncreaseSize),
                DecreaseSize = model.Local.DecreaseSize.Length == 0
                    ? ImmutableArray<ulong>.Empty 
                    : ImmutableArray.Create<ulong>(model.Local.DecreaseSize)
            },
            Remote = new GenericDriveChart()
            {
                IncreaseCount = model.Remote.IncreaseCount.Length == 0 
                    ? ImmutableArray<int>.Empty 
                    : ImmutableArray.Create<int>(model.Remote.IncreaseCount),
                DecreaseCount = model.Remote.DecreaseCount.Length == 0
                    ? ImmutableArray<int>.Empty 
                    : ImmutableArray.Create<int>(model.Remote.DecreaseCount),
                IncreaseSize = model.Remote.IncreaseSize.Length == 0
                    ? ImmutableArray<ulong>.Empty
                    : ImmutableArray.Create<ulong>(model.Remote.IncreaseSize),
                DecreaseSize = model.Remote.DecreaseSize.Length == 0
                    ? ImmutableArray<ulong>.Empty 
                    : ImmutableArray.Create<ulong>(model.Remote.DecreaseSize)
            }
        };
        
        return chart;
    }


    public static async Task<UsersChart> GetUsersChartAsync(BaseMisskeyClient client, ChartType span, int? limit = null,
        int? offset = null)
    {
        GetChartParams chartParams = new GetChartParams()
        {
            Span = span,
            Limit = limit,
            Offset = offset
        };
        
        var model = await client.ApiClient.GetUsersChartAsync(chartParams).ConfigureAwait(false);

        UsersChart chart = new UsersChart()
        {
            Type = span,
            Local = new GenericChart()
            {
                Total = model.Local.Total.Length == 0 
                    ? ImmutableArray<int>.Empty 
                    : ImmutableArray.Create<int>(model.Local.Total),
                Increase = model.Local.Increase.Length == 0 
                    ? ImmutableArray<int>.Empty 
                    : ImmutableArray.Create<int>(model.Local.Increase),
                Decrease = model.Local.Decrease.Length == 0 
                    ? ImmutableArray<int>.Empty 
                    : ImmutableArray.Create<int>(model.Local.Decrease)
            },
            Remote = new GenericChart()
            {
                Total = model.Remote.Total.Length == 0 
                    ? ImmutableArray<int>.Empty 
                    : ImmutableArray.Create<int>(model.Local.Total),
                Increase = model.Remote.Increase.Length == 0 
                    ? ImmutableArray<int>.Empty 
                    : ImmutableArray.Create<int>(model.Local.Increase),
                Decrease = model.Remote.Decrease.Length == 0 
                    ? ImmutableArray<int>.Empty 
                    : ImmutableArray.Create<int>(model.Local.Decrease)
            }
        };

        return chart;
    }

    #endregion
}
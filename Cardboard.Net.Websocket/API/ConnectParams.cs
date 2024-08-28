using Newtonsoft.Json;

namespace Cardboard.Net.Websocket.API;


/*
 * 	switch (type) {
 *  	case 'readNotification': this.onReadNotification(body); break;
 *  	case 'subNote': this.onSubscribeNote(body); break;
 *  	case 's': this.onSubscribeNote(body); break; // alias
 *  	case 'sr': this.onSubscribeNote(body); this.readNote(body); break;
 *  	case 'unsubNote': this.onUnsubscribeNote(body); break;
 *  	case 'un': this.onUnsubscribeNote(body); break; // alias
 *  	case 'connect': this.onChannelConnectRequested(body); break;
 *  	case 'disconnect': this.onChannelDisconnectRequested(body); break;
 *  	case 'channel': this.onChannelMessageRequested(body); break;
 *  	case 'ch': this.onChannelMessageRequested(body); break; // alias
 *  }
 */
internal class ConnectParams
{
    [JsonProperty("type")]
    public string Type { get; set; } = "connect";
    
    
}

internal class Body
{
    public string Channel { get; set; }
    public string Id { get; set; }
}
using System.Net;
using System.Text;
using WatsonWebsocket;
using Serilog;
using System.IO.Compression;
using System.Collections;
using System.Text.Json;
using BlackRevival.Common.Model;
using BlackRevival.Common.Networking;
using BlackRevival.Common.Util;
using BlackRevival.Common.GameDB.Item;

namespace BlackRevival.GameServer;

public class Server
{
    public IPEndPoint GameAddress = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 27900);
    
    static string _ServerIp = "localhost";
    static int _ServerPort = 0;
    static bool _Ssl = false;
    static bool _AcceptInvalidCertificates = true;
    static WatsonWsServer _Server = null;
    static string _LastIpPort = null;
    static int _lastClientID = 0;
    static void InitializeServer()
    {
        _Server = new WatsonWsServer(_ServerIp, _ServerPort, _Ssl);
        _Server.AcceptInvalidCertificates = _AcceptInvalidCertificates;
        _Server.ClientConnected += ClientConnected;
        _Server.ClientDisconnected += ClientDisconnected;
        _Server.MessageReceived += MessageReceived;
        _Server.Logger = Logger;
        _Server.HttpHandler = HttpHandler;
    }

        public async Task StartAsync(string ip, string port)
        {
            Thread.CurrentThread.Name = "GameService";
            _ServerIp = ip;
            _ServerPort = ushort.Parse(port);
            _Ssl = false;

            InitializeServer();
            Log.Information("GameServer Ready.");

            StartServer();
            //while (_State == ServiceState.RUNNING)
            //{
            //}
            await Task.Delay(-1);

        }
        static async Task StartServer()
        {
            // _Server.Start();
            await _Server.StartAsync();
            Log.Error("Server is listening: " + _Server.IsListening);
        }

        static void Logger(string msg)
        {
            Log.Debug(msg);
        }
        public static List<IngameClient> clientList = new List<IngameClient>();
        static void ClientConnected(object? sender, ConnectionEventArgs args)
        {
            clientList.Add(new IngameClient(args.Client.IpPort, _lastClientID++, args.Client.Guid));
            Log.Debug("Client " + args.Client.IpPort + " connected using URL " + args.HttpRequest.RawUrl);
            _LastIpPort = args.Client.IpPort;


            if (args.HttpRequest.Cookies != null && args.HttpRequest.Cookies.Count > 0)
            {
                Log.Debug(args.HttpRequest.Cookies.Count + " cookie(s) present:");
                foreach (Cookie cookie in args.HttpRequest.Cookies)
                {
                    Log.Debug("| " + cookie.Name + ": " + cookie.Value);
                }
            }
        }

        static void ClientDisconnected(object sender, DisconnectionEventArgs args)
        {
            var sClient = clientList.Find(s => s.clientAddress == args.Client.IpPort);
            Log.Debug($"Client {sClient.clientId} disconnected: " + args.Client.IpPort);         
        }

        private static bool firstMessage = true;
        static void MessageReceived(object sender, MessageReceivedEventArgs args)
        {
            string msg = "(null)";
            if (args.Data != null && args.Data.Count > 0) msg = Encoding.UTF8.GetString(args.Data.Array, 0, args.Data.Count);
            Log.Debug(args.MessageType.ToString() + " from " + args.Client.IpPort + ": " + msg);
            WebSocketMessage JsonObject = JsonSerializer.Deserialize<WebSocketMessage>(msg);
            DateTimeOffset now = DateTimeOffset.UtcNow;
            long unixTimeMilliseconds = now.ToUnixTimeMilliseconds();
            if (JsonObject.method == "Ping")
            {
                WebSocketResponse wsm = new WebSocketResponse();
                wsm.time = unixTimeMilliseconds;
                wsm.code = 200;
                wsm.id = JsonObject.id;
                string msgData = JsonSerializer.Serialize(wsm);
                //var bytes = Encoding.UTF8.GetBytes(msgData);

                _Server.SendAsync(args.Client.Guid, msgData).Wait();
                return;
            }
            if (JsonObject.method == "ping")
            {

                WebSocketResponse wsm = new WebSocketResponse();
                wsm.time = unixTimeMilliseconds;
                wsm.code = 200;
                wsm.id = JsonObject.id;
                string msgData = JsonSerializer.Serialize(wsm);
                //var bytes = Encoding.UTF8.GetBytes(msgData);

                _Server.SendAsync(args.Client.Guid, msgData).Wait();
                return;
            }
            if (JsonObject.method == "EnterMatching")
            {
                WebSocketResponse wsm = new WebSocketResponse();
                wsm.time = unixTimeMilliseconds;
                wsm.code = 200;
                wsm.id = JsonObject.id;
                string msgData = JsonSerializer.Serialize(wsm);
                var bytes = Encoding.UTF8.GetBytes(msgData);

                _Server.SendAsync(args.Client.Guid, msgData).Wait();
                return;
            }
            if (JsonObject.method == "createRoom")
            {
                //This is hard coded atm
                string resp = "{\r\n  \"rid\": "+ JsonObject.id +",\r\n  \"cod\": 200,\r\n  \"tme\": "+unixTimeMilliseconds+",\r\n  \"rst\": {\r\n    \"characters\": [\r\n      {\r\n        \"cnm\": 0,\r\n        \"unm\": -28677,\r\n        \"unn\": \"EnoughMessy ADELA\",\r\n        \"lwd\": \"What a shame.\",\r\n        \"wwd\": \"Hello!\",\r\n        \"cls\": 28,\r\n        \"crd\": 1,\r\n        \"ast\": 2805,\r\n        \"l2d\": false,\r\n        \"ehx\": 0,\r\n        \"rpc\": 0,\r\n        \"rwc\": 0,\r\n        \"npc\": 0,\r\n        \"nwc\": 0,\r\n        \"leg\": 2,\r\n        \"gbd\": 0,\r\n        \"bts\": {\r\n          \"uob\": false,\r\n          \"ht\": false,\r\n          \"gsl\": [],\r\n          \"pgl\": [],\r\n          \"pl\": [\r\n            50001,\r\n            50101,\r\n            50202\r\n          ],\r\n          \"sid\": [],\r\n          \"matchingCardCode\": 0,\r\n          \"titleCode\": 0\r\n        },\r\n        \"tnm\": 0,\r\n        \"psi\": 6005,\r\n        \"pmn\": 0,\r\n        \"pfr\": 0,\r\n        \"psd\": 0,\r\n        \"hst\": false,\r\n        \"nrs\": 0,\r\n        \"ctt\": 1\r\n      },\r\n      {\r\n        \"cnm\": 0,\r\n        \"unm\": -28678,\r\n        \"unn\": \"OftenMessy HART\",\r\n        \"lwd\": \"What a shame.\",\r\n        \"wwd\": \"Hello!\",\r\n        \"cls\": 22,\r\n        \"crd\": 1,\r\n        \"ast\": 2208,\r\n        \"l2d\": true,\r\n        \"ehx\": 0,\r\n        \"rpc\": 0,\r\n        \"rwc\": 0,\r\n        \"npc\": 0,\r\n        \"nwc\": 0,\r\n        \"leg\": 2,\r\n        \"gbd\": 0,\r\n        \"bts\": {\r\n          \"uob\": false,\r\n          \"ht\": false,\r\n          \"gsl\": [],\r\n          \"pgl\": [],\r\n          \"pl\": [\r\n            10001,\r\n            10102,\r\n            10201\r\n          ],\r\n          \"sid\": [],\r\n          \"matchingCardCode\": 0,\r\n          \"titleCode\": 0\r\n        },\r\n        \"tnm\": 0,\r\n        \"psi\": 6005,\r\n        \"pmn\": 0,\r\n        \"pfr\": 0,\r\n        \"psd\": 0,\r\n        \"hst\": false,\r\n        \"nrs\": 0,\r\n        \"ctt\": 1\r\n      },\r\n      {\r\n        \"cnm\": 0,\r\n        \"unm\": -28679,\r\n        \"unn\": \"WellMessy FIORA\",\r\n        \"lwd\": \"What a shame.\",\r\n        \"wwd\": \"Hello!\",\r\n        \"cls\": 2,\r\n        \"crd\": 1,\r\n        \"ast\": 204,\r\n        \"l2d\": true,\r\n        \"ehx\": 0,\r\n        \"rpc\": 0,\r\n        \"rwc\": 0,\r\n        \"npc\": 0,\r\n        \"nwc\": 0,\r\n        \"leg\": 2,\r\n        \"gbd\": 0,\r\n        \"bts\": {\r\n          \"uob\": false,\r\n          \"ht\": false,\r\n          \"gsl\": [],\r\n          \"pgl\": [],\r\n          \"pl\": [\r\n            20001,\r\n            20102,\r\n            20202\r\n          ],\r\n          \"sid\": [],\r\n          \"matchingCardCode\": 0,\r\n          \"titleCode\": 0\r\n        },\r\n        \"tnm\": 0,\r\n        \"psi\": 6005,\r\n        \"pmn\": 0,\r\n        \"pfr\": 0,\r\n        \"psd\": 0,\r\n        \"hst\": false,\r\n        \"nrs\": 0,\r\n        \"ctt\": 1\r\n      },\r\n      {\r\n        \"cnm\": 0,\r\n        \"unm\": -28680,\r\n        \"unn\": \"SlowlyMessy CAMILO\",\r\n        \"lwd\": \"What a shame.\",\r\n        \"wwd\": \"Hello!\",\r\n        \"cls\": 25,\r\n        \"crd\": 1,\r\n        \"ast\": 2502,\r\n        \"l2d\": true,\r\n        \"ehx\": 0,\r\n        \"rpc\": 0,\r\n        \"rwc\": 0,\r\n        \"npc\": 0,\r\n        \"nwc\": 0,\r\n        \"leg\": 2,\r\n        \"gbd\": 0,\r\n        \"bts\": {\r\n          \"uob\": false,\r\n          \"ht\": false,\r\n          \"gsl\": [],\r\n          \"pgl\": [],\r\n          \"pl\": [\r\n            10001,\r\n            10101,\r\n            10201\r\n          ],\r\n          \"sid\": [],\r\n          \"matchingCardCode\": 0,\r\n          \"titleCode\": 0\r\n        },\r\n        \"tnm\": 0,\r\n        \"psi\": 6001,\r\n        \"pmn\": 0,\r\n        \"pfr\": 0,\r\n        \"psd\": 0,\r\n        \"hst\": false,\r\n        \"nrs\": 0,\r\n        \"ctt\": 1\r\n      },\r\n      {\r\n        \"cnm\": 0,\r\n        \"unm\": -28681,\r\n        \"unn\": \"SafelyMessy XIUKAI\",\r\n        \"lwd\": \"What a shame.\",\r\n        \"wwd\": \"Hello!\",\r\n        \"cls\": 9,\r\n        \"crd\": 1,\r\n        \"ast\": 901,\r\n        \"l2d\": false,\r\n        \"ehx\": 0,\r\n        \"rpc\": 0,\r\n        \"rwc\": 0,\r\n        \"npc\": 0,\r\n        \"nwc\": 0,\r\n        \"leg\": 2,\r\n        \"gbd\": 0,\r\n        \"bts\": {\r\n          \"uob\": false,\r\n          \"ht\": false,\r\n          \"gsl\": [],\r\n          \"pgl\": [],\r\n          \"pl\": [\r\n            30001,\r\n            30102,\r\n            30202\r\n          ],\r\n          \"sid\": [],\r\n          \"matchingCardCode\": 0,\r\n          \"titleCode\": 0\r\n        },\r\n        \"tnm\": 0,\r\n        \"psi\": 6001,\r\n        \"pmn\": 0,\r\n        \"pfr\": 0,\r\n        \"psd\": 0,\r\n        \"hst\": false,\r\n        \"nrs\": 0,\r\n        \"ctt\": 1\r\n      },\r\n      {\r\n        \"cnm\": 0,\r\n        \"unm\": -28682,\r\n        \"unn\": \"SeldomMessy HYUNWOO\",\r\n        \"lwd\": \"What a shame.\",\r\n        \"wwd\": \"Hello!\",\r\n        \"cls\": 4,\r\n        \"crd\": 1,\r\n        \"ast\": 410,\r\n        \"l2d\": false,\r\n        \"ehx\": 0,\r\n        \"rpc\": 0,\r\n        \"rwc\": 0,\r\n        \"npc\": 0,\r\n        \"nwc\": 0,\r\n        \"leg\": 2,\r\n        \"gbd\": 0,\r\n        \"bts\": {\r\n          \"uob\": false,\r\n          \"ht\": false,\r\n          \"gsl\": [],\r\n          \"pgl\": [],\r\n          \"pl\": [\r\n            10001,\r\n            10101,\r\n            10202\r\n          ],\r\n          \"sid\": [],\r\n          \"matchingCardCode\": 0,\r\n          \"titleCode\": 0\r\n        },\r\n        \"tnm\": 0,\r\n        \"psi\": 6005,\r\n        \"pmn\": 0,\r\n        \"pfr\": 0,\r\n        \"psd\": 0,\r\n        \"hst\": false,\r\n        \"nrs\": 0,\r\n        \"ctt\": 1\r\n      },\r\n      {\r\n        \"cnm\": 0,\r\n        \"unm\": -28683,\r\n        \"unn\": \"NeverMessy SUA\",\r\n        \"lwd\": \"What a shame.\",\r\n        \"wwd\": \"Hello!\",\r\n        \"cls\": 33,\r\n        \"crd\": 1,\r\n        \"ast\": 3307,\r\n        \"l2d\": true,\r\n        \"ehx\": 0,\r\n        \"rpc\": 0,\r\n        \"rwc\": 0,\r\n        \"npc\": 0,\r\n        \"nwc\": 0,\r\n        \"leg\": 2,\r\n        \"gbd\": 0,\r\n        \"bts\": {\r\n          \"uob\": false,\r\n          \"ht\": false,\r\n          \"gsl\": [],\r\n          \"pgl\": [],\r\n          \"pl\": [\r\n            10001,\r\n            10102,\r\n            10201\r\n          ],\r\n          \"sid\": [],\r\n          \"matchingCardCode\": 0,\r\n          \"titleCode\": 0\r\n        },\r\n        \"tnm\": 0,\r\n        \"psi\": 6005,\r\n        \"pmn\": 0,\r\n        \"pfr\": 0,\r\n        \"psd\": 0,\r\n        \"hst\": false,\r\n        \"nrs\": 0,\r\n        \"ctt\": 1\r\n      },\r\n      {\r\n        \"cnm\": 0,\r\n        \"unm\": -28684,\r\n        \"unn\": \"KindlyMessy NICKY\",\r\n        \"lwd\": \"What a shame.\",\r\n        \"wwd\": \"Hello!\",\r\n        \"cls\": 43,\r\n        \"crd\": 1,\r\n        \"ast\": 4301,\r\n        \"l2d\": false,\r\n        \"ehx\": 0,\r\n        \"rpc\": 0,\r\n        \"rwc\": 0,\r\n        \"npc\": 0,\r\n        \"nwc\": 0,\r\n        \"leg\": 2,\r\n        \"gbd\": 0,\r\n        \"bts\": {\r\n          \"uob\": false,\r\n          \"ht\": false,\r\n          \"gsl\": [],\r\n          \"pgl\": [],\r\n          \"pl\": [\r\n            50001,\r\n            50101,\r\n            50201\r\n          ],\r\n          \"sid\": [],\r\n          \"matchingCardCode\": 0,\r\n          \"titleCode\": 0\r\n        },\r\n        \"tnm\": 0,\r\n        \"psi\": 6001,\r\n        \"pmn\": 0,\r\n        \"pfr\": 0,\r\n        \"psd\": 0,\r\n        \"hst\": false,\r\n        \"nrs\": 0,\r\n        \"ctt\": 1\r\n      },\r\n      {\r\n        \"cnm\": 0,\r\n        \"unm\": -28685,\r\n        \"unn\": \"GladlyMessy DANIEL\",\r\n        \"lwd\": \"What a shame.\",\r\n        \"wwd\": \"Hello!\",\r\n        \"cls\": 40,\r\n        \"crd\": 1,\r\n        \"ast\": 4001,\r\n        \"l2d\": false,\r\n        \"ehx\": 0,\r\n        \"rpc\": 0,\r\n        \"rwc\": 0,\r\n        \"npc\": 0,\r\n        \"nwc\": 0,\r\n        \"leg\": 2,\r\n        \"gbd\": 0,\r\n        \"bts\": {\r\n          \"uob\": false,\r\n          \"ht\": false,\r\n          \"gsl\": [],\r\n          \"pgl\": [],\r\n          \"pl\": [\r\n            50001,\r\n            50102,\r\n            50201\r\n          ],\r\n          \"sid\": [],\r\n          \"matchingCardCode\": 0,\r\n          \"titleCode\": 0\r\n        },\r\n        \"tnm\": 0,\r\n        \"psi\": 6001,\r\n        \"pmn\": 0,\r\n        \"pfr\": 0,\r\n        \"psd\": 0,\r\n        \"hst\": false,\r\n        \"nrs\": 0,\r\n        \"ctt\": 1\r\n      },\r\n      {\r\n        \"cnm\": 10155226,\r\n        \"unm\": 7562069,\r\n        \"unn\": \"ReplaceNameHere\",\r\n        \"lwd\": \"How can I die here...\",\r\n        \"wwd\": \"Come at me\",\r\n        \"cls\": 44,\r\n        \"crd\": 5,\r\n        \"ast\": 4401,\r\n        \"l2d\": false,\r\n        \"ehx\": 0,\r\n        \"cpt\": 3,\r\n        \"rpc\": 0,\r\n        \"rwc\": 0,\r\n        \"npc\": 0,\r\n        \"nwc\": 0,\r\n        \"leg\": 2,\r\n        \"gbd\": 0,\r\n        \"bts\": {\r\n          \"uob\": false,\r\n          \"ht\": true,\r\n          \"gsl\": [],\r\n          \"pgl\": [],\r\n          \"pl\": [\r\n            10001,\r\n            10101,\r\n            10201\r\n          ],\r\n          \"sid\": [\r\n            22007\r\n          ],\r\n          \"matchingCardCode\": 0,\r\n          \"titleCode\": 0\r\n        },\r\n        \"tnm\": 0,\r\n        \"psi\": 6001,\r\n        \"pmn\": 0,\r\n        \"pfr\": 0,\r\n        \"psd\": 0,\r\n        \"hst\": true,\r\n        \"nrs\": 0,\r\n        \"ctt\": 1\r\n      }\r\n    ],\r\n    \"observerUserNum\": 0,\r\n    \"userTitleListMap\": {\r\n      \"7562069\": 0,\r\n      \"-28677\": 0,\r\n      \"-28678\": 0,\r\n      \"-28679\": 0,\r\n      \"-28680\": 0,\r\n      \"-28681\": 0,\r\n      \"-28682\": 0,\r\n      \"-28683\": 0,\r\n      \"-28684\": 0,\r\n      \"-28685\": 0\r\n    },\r\n    \"userMatchingCardListMap\": {\r\n      \"7562069\": 0,\r\n      \"-28677\": 0,\r\n      \"-28678\": 0,\r\n      \"-28679\": 0,\r\n      \"-28680\": 0,\r\n      \"-28681\": 0,\r\n      \"-28682\": 0,\r\n      \"-28683\": 0,\r\n      \"-28684\": 0,\r\n      \"-28685\": 0\r\n    },\r\n    \"userPerkListMap\": {\r\n      \"7562069\": [\r\n        10001,\r\n        10101,\r\n        10201\r\n      ],\r\n      \"-28677\": [\r\n        50001,\r\n        50101,\r\n        50202\r\n      ],\r\n      \"-28678\": [\r\n        10001,\r\n        10102,\r\n        10201\r\n      ],\r\n      \"-28679\": [\r\n        20001,\r\n        20102,\r\n        20202\r\n      ],\r\n      \"-28680\": [\r\n        10001,\r\n        10101,\r\n        10201\r\n      ],\r\n      \"-28681\": [\r\n        30001,\r\n        30102,\r\n        30202\r\n      ],\r\n      \"-28682\": [\r\n        10001,\r\n        10101,\r\n        10202\r\n      ],\r\n      \"-28683\": [\r\n        10001,\r\n        10102,\r\n        10201\r\n      ],\r\n      \"-28684\": [\r\n        50001,\r\n        50101,\r\n        50201\r\n      ],\r\n      \"-28685\": [\r\n        50001,\r\n        50102,\r\n        50201\r\n      ]\r\n    },\r\n    \"roomKey\": \"936787\",\r\n    \"observerNickname\": \"\"\r\n  }\r\n}";
                _Server.SendAsync(args.Client.Guid, resp).Wait();
                return;
            }
            if (JsonObject.method == "startRoom")
            {
                //This is hard coded atm
                string resp = "{\"rid\":" + JsonObject.id + ",\"cod\":200,\"tme\":" + unixTimeMilliseconds + ",\"rst\":{\"characters\":[{\"cnm\":0,\"unm\":-28677,\"unn\":\"EnoughMessy ADELA\",\"lwd\":\"What a shame.\",\"wwd\":\"Hello!\",\"cls\":28,\"crd\":1,\"ast\":2805,\"l2d\":false,\"ehx\":0,\"rpc\":0,\"rwc\":0,\"npc\":0,\"nwc\":0,\"leg\":2,\"gbd\":0,\"bts\":{\"uob\":false,\"ht\":false,\"gsl\":[],\"pgl\":[],\"pl\":[50001,50101,50202],\"sid\":[],\"matchingCardCode\":0,\"titleCode\":0},\"tnm\":0,\"psi\":6005,\"pmn\":0,\"pfr\":0,\"psd\":0,\"hst\":false,\"nrs\":0,\"ctt\":1},{\"cnm\":0,\"unm\":-28678,\"unn\":\"OftenMessy HART\",\"lwd\":\"What a shame.\",\"wwd\":\"Hello!\",\"cls\":22,\"crd\":1,\"ast\":2208,\"l2d\":true,\"ehx\":0,\"rpc\":0,\"rwc\":0,\"npc\":0,\"nwc\":0,\"leg\":2,\"gbd\":0,\"bts\":{\"uob\":false,\"ht\":false,\"gsl\":[],\"pgl\":[],\"pl\":[10001,10102,10201],\"sid\":[],\"matchingCardCode\":0,\"titleCode\":0},\"tnm\":0,\"psi\":6005,\"pmn\":0,\"pfr\":0,\"psd\":0,\"hst\":false,\"nrs\":0,\"ctt\":1},{\"cnm\":0,\"unm\":-28679,\"unn\":\"WellMessy FIORA\",\"lwd\":\"What a shame.\",\"wwd\":\"Hello!\",\"cls\":2,\"crd\":1,\"ast\":204,\"l2d\":true,\"ehx\":0,\"rpc\":0,\"rwc\":0,\"npc\":0,\"nwc\":0,\"leg\":2,\"gbd\":0,\"bts\":{\"uob\":false,\"ht\":false,\"gsl\":[],\"pgl\":[],\"pl\":[20001,20102,20202],\"sid\":[],\"matchingCardCode\":0,\"titleCode\":0},\"tnm\":0,\"psi\":6005,\"pmn\":0,\"pfr\":0,\"psd\":0,\"hst\":false,\"nrs\":0,\"ctt\":1},{\"cnm\":0,\"unm\":-28680,\"unn\":\"SlowlyMessy CAMILO\",\"lwd\":\"What a shame.\",\"wwd\":\"Hello!\",\"cls\":25,\"crd\":1,\"ast\":2502,\"l2d\":true,\"ehx\":0,\"rpc\":0,\"rwc\":0,\"npc\":0,\"nwc\":0,\"leg\":2,\"gbd\":0,\"bts\":{\"uob\":false,\"ht\":false,\"gsl\":[],\"pgl\":[],\"pl\":[10001,10101,10201],\"sid\":[],\"matchingCardCode\":0,\"titleCode\":0},\"tnm\":0,\"psi\":6001,\"pmn\":0,\"pfr\":0,\"psd\":0,\"hst\":false,\"nrs\":0,\"ctt\":1},{\"cnm\":0,\"unm\":-28681,\"unn\":\"SafelyMessy XIUKAI\",\"lwd\":\"What a shame.\",\"wwd\":\"Hello!\",\"cls\":9,\"crd\":1,\"ast\":901,\"l2d\":false,\"ehx\":0,\"rpc\":0,\"rwc\":0,\"npc\":0,\"nwc\":0,\"leg\":2,\"gbd\":0,\"bts\":{\"uob\":false,\"ht\":false,\"gsl\":[],\"pgl\":[],\"pl\":[30001,30102,30202],\"sid\":[],\"matchingCardCode\":0,\"titleCode\":0},\"tnm\":0,\"psi\":6001,\"pmn\":0,\"pfr\":0,\"psd\":0,\"hst\":false,\"nrs\":0,\"ctt\":1},{\"cnm\":0,\"unm\":-28682,\"unn\":\"SeldomMessy HYUNWOO\",\"lwd\":\"What a shame.\",\"wwd\":\"Hello!\",\"cls\":4,\"crd\":1,\"ast\":410,\"l2d\":false,\"ehx\":0,\"rpc\":0,\"rwc\":0,\"npc\":0,\"nwc\":0,\"leg\":2,\"gbd\":0,\"bts\":{\"uob\":false,\"ht\":false,\"gsl\":[],\"pgl\":[],\"pl\":[10001,10101,10202],\"sid\":[],\"matchingCardCode\":0,\"titleCode\":0},\"tnm\":0,\"psi\":6005,\"pmn\":0,\"pfr\":0,\"psd\":0,\"hst\":false,\"nrs\":0,\"ctt\":1},{\"cnm\":0,\"unm\":-28683,\"unn\":\"NeverMessy SUA\",\"lwd\":\"What a shame.\",\"wwd\":\"Hello!\",\"cls\":33,\"crd\":1,\"ast\":3307,\"l2d\":true,\"ehx\":0,\"rpc\":0,\"rwc\":0,\"npc\":0,\"nwc\":0,\"leg\":2,\"gbd\":0,\"bts\":{\"uob\":false,\"ht\":false,\"gsl\":[],\"pgl\":[],\"pl\":[10001,10102,10201],\"sid\":[],\"matchingCardCode\":0,\"titleCode\":0},\"tnm\":0,\"psi\":6005,\"pmn\":0,\"pfr\":0,\"psd\":0,\"hst\":false,\"nrs\":0,\"ctt\":1},{\"cnm\":0,\"unm\":-28684,\"unn\":\"KindlyMessy NICKY\",\"lwd\":\"What a shame.\",\"wwd\":\"Hello!\",\"cls\":43,\"crd\":1,\"ast\":4301,\"l2d\":false,\"ehx\":0,\"rpc\":0,\"rwc\":0,\"npc\":0,\"nwc\":0,\"leg\":2,\"gbd\":0,\"bts\":{\"uob\":false,\"ht\":false,\"gsl\":[],\"pgl\":[],\"pl\":[50001,50101,50201],\"sid\":[],\"matchingCardCode\":0,\"titleCode\":0},\"tnm\":0,\"psi\":6001,\"pmn\":0,\"pfr\":0,\"psd\":0,\"hst\":false,\"nrs\":0,\"ctt\":1},{\"cnm\":0,\"unm\":-28685,\"unn\":\"GladlyMessy DANIEL\",\"lwd\":\"What a shame.\",\"wwd\":\"Hello!\",\"cls\":40,\"crd\":1,\"ast\":4001,\"l2d\":false,\"ehx\":0,\"rpc\":0,\"rwc\":0,\"npc\":0,\"nwc\":0,\"leg\":2,\"gbd\":0,\"bts\":{\"uob\":false,\"ht\":false,\"gsl\":[],\"pgl\":[],\"pl\":[50001,50102,50201],\"sid\":[],\"matchingCardCode\":0,\"titleCode\":0},\"tnm\":0,\"psi\":6001,\"pmn\":0,\"pfr\":0,\"psd\":0,\"hst\":false,\"nrs\":0,\"ctt\":1},{\"cnm\":10155226,\"unm\":7562069,\"unn\":\"ReplaceNameHere\",\"lwd\":\"How can I die here...\",\"wwd\":\"Come at me\",\"cls\":44,\"crd\":5,\"ast\":4401,\"l2d\":false,\"ehx\":0,\"cpt\":3,\"rpc\":0,\"rwc\":0,\"npc\":0,\"nwc\":0,\"leg\":2,\"gbd\":0,\"bts\":{\"uob\":false,\"ht\":true,\"gsl\":[],\"pgl\":[],\"pl\":[10001,10101,10201],\"sid\":[22007],\"matchingCardCode\":0,\"titleCode\":0},\"tnm\":0,\"psi\":6001,\"pmn\":0,\"pfr\":0,\"psd\":0,\"hst\":true,\"nrs\":0,\"ctt\":1}],\"roomKey\":\"936787\"}}";
                _Server.SendAsync(args.Client.Guid, resp).Wait();
                string resp2 = "{\"mtd\":\"startGame\",\"tme\":"+ unixTimeMilliseconds +",\"prm\":{\"mode\":12,\"userNum\":7562069,\"observer\":false,\"fieldCharacter\":{\"slayer\":false,\"cnm\":10155226,\"unm\":7562069,\"unn\":\"ReplaceNameHere\",\"lwd\":\"How can I die here...\",\"wwd\":\"Come at me\",\"cls\":44,\"crd\":5,\"ast\":4401,\"l2d\":false,\"ehx\":0,\"cpt\":3,\"rpc\":0,\"rwc\":0,\"npc\":0,\"nwc\":0,\"leg\":2,\"gbd\":0,\"tnm\":0,\"psi\":6001,\"pmn\":0,\"pfr\":0,\"psd\":0,\"hst\":false,\"mtp\":\"LUMIA\",\"cft\":23,\"cha\":{\"hea\":125.0,\"sta\":120.0,\"mht\":120.0,\"msm\":120.0,\"off\":8.0,\"def\":16.0,\"lvl\":1,\"tms\":120.0,\"cht\":1,\"tmh\":125.0,\"exp\":0.0},\"sga\":{\"currentDrainRatio\":0.0,\"currentHealth\":0.0,\"currentStamina\":0.0,\"currentOffence\":0.0,\"currentDefence\":0.0,\"currentAddedDmg\":0.0,\"currentReducedCooltime\":0.0,\"lpmh\":{},\"lpms\":{},\"lpo\":{},\"lpd\":{},\"lpad\":{},\"lprc\":{},\"lpdd\":{}},\"wvg\":[{\"wtp\":5,\"bfy\":56.0,\"afy\":0.0,\"mrk\":701},{\"wtp\":2,\"bfy\":56.0,\"afy\":0.0,\"mrk\":601},{\"wtp\":8,\"bfy\":56.0,\"afy\":0.0,\"mrk\":501},{\"wtp\":7,\"bfy\":55.0,\"afy\":0.0,\"mrk\":101},{\"wtp\":4,\"bfy\":56.0,\"afy\":0.0,\"mrk\":201},{\"wtp\":1,\"bfy\":76.0,\"afy\":0.0,\"mrk\":305},{\"wtp\":6,\"bfy\":56.0,\"afy\":0.0,\"mrk\":401}],\"wtp\":1,\"ivn\":{\"cpc\":6,\"fos\":[{\"fin\":\"32004-PvxUw1eFsvyh\",\"lqt\":0,\"bqt\":3,\"aiids\":[],\"spc\":0,\"dft\":0.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":0.0,\"dfc\":0.0,\"dfe\":0.0,\"ofr\":0.0,\"itm\":32004},{\"fin\":\"31007-RgXyxxJLanlv\",\"lqt\":0,\"bqt\":2,\"aiids\":[],\"spc\":0,\"dft\":0.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":0.0,\"dfc\":0.0,\"dfe\":0.0,\"ofr\":0.0,\"itm\":31007}]},\"eqp\":{\"eqp\":{\"8\":{\"fin\":\"13021-dN6GsxQrJ2zK\",\"lqt\":0,\"bqt\":1,\"aiids\":[],\"spc\":5077,\"dft\":0.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":8.0,\"dfc\":0.0,\"dfe\":0.0,\"ofr\":8.0,\"itm\":13021},\"2\":{\"fin\":\"22007-f1VQN7gnxHRQ\",\"lqt\":0,\"bqt\":1,\"aiids\":[],\"spc\":0,\"dft\":8.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":0.0,\"dfc\":8.0,\"dfe\":0.0,\"ofr\":0.0,\"itm\":22007}},\"esp\":[5077]},\"wdt\":[],\"spo\":[],\"sil\":[],\"ckc\":0,\"asc\":0,\"ddc\":0,\"mkc\":0,\"isl\":false,\"chs\":1,\"res\":false,\"pkl\":[10001,10101,10201],\"att\":\"\",\"ant\":\"TOMAS\",\"aot\":\"\",\"ltt\":\"DEFAULT_LANTERN\",\"cvt\":\"\",\"emj\":\"default\",\"rtc\":0,\"mcc\":0,\"dtc\":0,\"rcc\":2,\"tis\":[],\"cht\":1,\"ai\":false,\"mfi\":[],\"sbl\":[{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":2030,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":0.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":3030,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":70.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":6001,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":180.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":7011,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":0.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":7012,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":0.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":7014,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":0.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":5077,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":2,\"idr\":30.0,\"ict\":30.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0}],\"aep\":[{\"bst\":101,\"val\":10.0},{\"bst\":103,\"val\":8.0}],\"ded\":false,\"cto\":16.199999,\"ctd\":24.0,\"nrs\":0,\"ctt\":1},\"userNick\":\"ReplaceNameHere\",\"memoryItemSize\":4,\"allInformations\":[{\"slayer\":false,\"ai\":true,\"unm\":-28677,\"hea\":108.0,\"sht\":108.0,\"mha\":108.0,\"lea\":1665984990490,\"lef\":23,\"ast\":2805,\"exp\":0.0,\"unn\":\"EnoughMessy ADELA\",\"unb\":-28677,\"rtc\":0,\"lwd\":\"What a shame.\",\"wwd\":\"Hello!\",\"eqp\":{\"eqp\":{\"8\":{\"fin\":\"12033-KFVdnh9WMYKn\",\"lqt\":0,\"bqt\":1,\"aiids\":[],\"spc\":0,\"dft\":0.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":10.0,\"dfc\":0.0,\"dfe\":0.0,\"ofr\":10.0,\"itm\":12033},\"2\":{\"fin\":\"22007-5Y1n2fTVdwX2\",\"lqt\":0,\"bqt\":1,\"aiids\":[],\"spc\":0,\"dft\":8.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":0.0,\"dfc\":8.0,\"dfe\":0.0,\"ofr\":0.0,\"itm\":22007}},\"esp\":[]},\"ckc\":0,\"wtp\":[],\"sil\":false,\"ptc\":6005,\"wpt\":4,\"tnb\":0,\"l2d\":false,\"ddc\":0,\"ctf\":23,\"asc\":0,\"sly\":false,\"tbl\":[],\"lvl\":1,\"tfm\":false,\"pkl\":[50001,50101,50202],\"vgr\":4,\"ded\":false,\"ees\":0},{\"slayer\":false,\"ai\":true,\"unm\":-28678,\"hea\":116.0,\"sht\":116.0,\"mha\":116.0,\"lea\":1665984990490,\"lef\":23,\"ast\":2208,\"exp\":0.0,\"unn\":\"OftenMessy HART\",\"unb\":-28678,\"rtc\":0,\"lwd\":\"What a shame.\",\"wwd\":\"Hello!\",\"eqp\":{\"eqp\":{\"8\":{\"fin\":\"12033-s6HZsOsI4qkP\",\"lqt\":0,\"bqt\":1,\"aiids\":[],\"spc\":0,\"dft\":0.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":10.0,\"dfc\":0.0,\"dfe\":0.0,\"ofr\":10.0,\"itm\":12033},\"2\":{\"fin\":\"22007-njU57AcbMUZL\",\"lqt\":0,\"bqt\":1,\"aiids\":[],\"spc\":0,\"dft\":8.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":0.0,\"dfc\":8.0,\"dfe\":0.0,\"ofr\":0.0,\"itm\":22007}},\"esp\":[]},\"ckc\":0,\"wtp\":[],\"sil\":false,\"ptc\":6005,\"wpt\":4,\"tnb\":0,\"l2d\":true,\"ddc\":0,\"ctf\":23,\"asc\":0,\"sly\":false,\"tbl\":[],\"lvl\":1,\"tfm\":false,\"pkl\":[10001,10102,10201],\"vgr\":5,\"ded\":false,\"ees\":0},{\"slayer\":false,\"ai\":true,\"unm\":-28679,\"hea\":100.0,\"sht\":100.0,\"mha\":100.0,\"lea\":1665984990490,\"lef\":23,\"ast\":204,\"exp\":0.0,\"unn\":\"WellMessy FIORA\",\"unb\":-28679,\"rtc\":0,\"lwd\":\"What a shame.\",\"wwd\":\"Hello!\",\"eqp\":{\"eqp\":{\"8\":{\"fin\":\"14001-SFUok8OeJ7KL\",\"lqt\":0,\"bqt\":1,\"aiids\":[],\"spc\":0,\"dft\":0.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":10.0,\"dfc\":0.0,\"dfe\":0.0,\"ofr\":10.0,\"itm\":14001},\"2\":{\"fin\":\"22007-S1y7khBpovWZ\",\"lqt\":0,\"bqt\":1,\"aiids\":[],\"spc\":0,\"dft\":8.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":0.0,\"dfc\":8.0,\"dfe\":0.0,\"ofr\":0.0,\"itm\":22007}},\"esp\":[]},\"ckc\":0,\"wtp\":[],\"sil\":false,\"ptc\":6005,\"wpt\":6,\"tnb\":0,\"l2d\":true,\"ddc\":0,\"ctf\":23,\"asc\":0,\"sly\":false,\"tbl\":[],\"lvl\":1,\"tfm\":false,\"pkl\":[20001,20102,20202],\"vgr\":5,\"ded\":false,\"ees\":0},{\"slayer\":false,\"ai\":false,\"unm\":7562069,\"hea\":125.0,\"sht\":120.0,\"mha\":125.0,\"lea\":1665984990490,\"lef\":23,\"ast\":4401,\"exp\":0.0,\"unn\":\"ReplaceNameHere\",\"unb\":7562069,\"rtc\":0,\"lwd\":\"How can I die here...\",\"wwd\":\"Come at me\",\"eqp\":{\"eqp\":{\"8\":{\"fin\":\"13021-dN6GsxQrJ2zK\",\"lqt\":0,\"bqt\":1,\"aiids\":[],\"spc\":5077,\"dft\":0.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":8.0,\"dfc\":0.0,\"dfe\":0.0,\"ofr\":8.0,\"itm\":13021},\"2\":{\"fin\":\"22007-f1VQN7gnxHRQ\",\"lqt\":0,\"bqt\":1,\"aiids\":[],\"spc\":0,\"dft\":8.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":0.0,\"dfc\":8.0,\"dfe\":0.0,\"ofr\":0.0,\"itm\":22007}},\"esp\":[5077]},\"ckc\":0,\"wtp\":[],\"sil\":false,\"ptc\":6001,\"wpt\":1,\"tnb\":0,\"l2d\":false,\"ddc\":0,\"ctf\":23,\"asc\":0,\"sly\":false,\"tbl\":[],\"lvl\":1,\"tfm\":false,\"pkl\":[10001,10101,10201],\"vgr\":5,\"ded\":false,\"ees\":0},{\"slayer\":false,\"ai\":true,\"unm\":-28680,\"hea\":117.0,\"sht\":112.0,\"mha\":117.0,\"lea\":1665984990490,\"lef\":23,\"ast\":2502,\"exp\":0.0,\"unn\":\"SlowlyMessy CAMILO\",\"unb\":-28680,\"rtc\":0,\"lwd\":\"What a shame.\",\"wwd\":\"Hello!\",\"eqp\":{\"eqp\":{\"8\":{\"fin\":\"16003-BOh4W5ezkGu5\",\"lqt\":0,\"bqt\":15,\"aiids\":[],\"spc\":0,\"dft\":0.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":10.0,\"dfc\":0.0,\"dfe\":0.0,\"ofr\":10.0,\"itm\":16003},\"2\":{\"fin\":\"22007-OV5aILZOBKwN\",\"lqt\":0,\"bqt\":1,\"aiids\":[],\"spc\":0,\"dft\":8.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":0.0,\"dfc\":8.0,\"dfe\":0.0,\"ofr\":0.0,\"itm\":22007}},\"esp\":[]},\"ckc\":0,\"wtp\":[],\"sil\":false,\"ptc\":6001,\"wpt\":8,\"tnb\":0,\"l2d\":true,\"ddc\":0,\"ctf\":23,\"asc\":0,\"sly\":false,\"tbl\":[],\"lvl\":1,\"tfm\":false,\"pkl\":[10001,10101,10201],\"vgr\":4,\"ded\":false,\"ees\":0},{\"slayer\":false,\"ai\":true,\"unm\":-28681,\"hea\":120.0,\"sht\":120.0,\"mha\":120.0,\"lea\":1665984990490,\"lef\":23,\"ast\":901,\"exp\":0.0,\"unn\":\"SafelyMessy XIUKAI\",\"unb\":-28681,\"rtc\":0,\"lwd\":\"What a shame.\",\"wwd\":\"Hello!\",\"eqp\":{\"eqp\":{\"8\":{\"fin\":\"15009-TFiKUuJkrdCn\",\"lqt\":0,\"bqt\":1,\"aiids\":[],\"spc\":0,\"dft\":0.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":8.0,\"dfc\":0.0,\"dfe\":0.0,\"ofr\":8.0,\"itm\":15009},\"2\":{\"fin\":\"22007-xrIjXlrFGKg5\",\"lqt\":0,\"bqt\":1,\"aiids\":[],\"spc\":0,\"dft\":8.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":0.0,\"dfc\":8.0,\"dfe\":0.0,\"ofr\":0.0,\"itm\":22007}},\"esp\":[]},\"ckc\":0,\"wtp\":[],\"sil\":false,\"ptc\":6001,\"wpt\":1,\"tnb\":0,\"l2d\":false,\"ddc\":0,\"ctf\":23,\"asc\":0,\"sly\":false,\"tbl\":[],\"lvl\":1,\"tfm\":false,\"pkl\":[30001,30102,30202],\"vgr\":5,\"ded\":false,\"ees\":0},{\"slayer\":false,\"ai\":true,\"unm\":-28682,\"hea\":109.0,\"sht\":104.0,\"mha\":109.0,\"lea\":1665984990490,\"lef\":23,\"ast\":410,\"exp\":0.0,\"unn\":\"SeldomMessy HYUNWOO\",\"unb\":-28682,\"rtc\":0,\"lwd\":\"What a shame.\",\"wwd\":\"Hello!\",\"eqp\":{\"eqp\":{\"8\":{\"fin\":\"11001-25gyIZ7l52zb\",\"lqt\":0,\"bqt\":1,\"aiids\":[],\"spc\":0,\"dft\":0.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":8.0,\"dfc\":0.0,\"dfe\":0.0,\"ofr\":8.0,\"itm\":11001},\"2\":{\"fin\":\"22007-FlFBJrMmF2EU\",\"lqt\":0,\"bqt\":1,\"aiids\":[],\"spc\":0,\"dft\":8.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":0.0,\"dfc\":8.0,\"dfe\":0.0,\"ofr\":0.0,\"itm\":22007}},\"esp\":[]},\"ckc\":0,\"wtp\":[],\"sil\":false,\"ptc\":6005,\"wpt\":7,\"tnb\":0,\"l2d\":false,\"ddc\":0,\"ctf\":23,\"asc\":0,\"sly\":false,\"tbl\":[],\"lvl\":1,\"tfm\":false,\"pkl\":[10001,10101,10202],\"vgr\":4,\"ded\":false,\"ees\":0},{\"slayer\":false,\"ai\":true,\"unm\":-28683,\"hea\":108.0,\"sht\":108.0,\"mha\":108.0,\"lea\":1665984990490,\"lef\":23,\"ast\":3307,\"exp\":0.0,\"unn\":\"NeverMessy SUA\",\"unb\":-28683,\"rtc\":0,\"lwd\":\"What a shame.\",\"wwd\":\"Hello!\",\"eqp\":{\"eqp\":{\"8\":{\"fin\":\"12033-bkEDAb7S2yVd\",\"lqt\":0,\"bqt\":1,\"aiids\":[],\"spc\":0,\"dft\":0.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":10.0,\"dfc\":0.0,\"dfe\":0.0,\"ofr\":10.0,\"itm\":12033},\"2\":{\"fin\":\"22007-mDulX6VA1sMN\",\"lqt\":0,\"bqt\":1,\"aiids\":[],\"spc\":0,\"dft\":8.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":0.0,\"dfc\":8.0,\"dfe\":0.0,\"ofr\":0.0,\"itm\":22007}},\"esp\":[]},\"ckc\":0,\"wtp\":[],\"sil\":false,\"ptc\":6005,\"wpt\":4,\"tnb\":0,\"l2d\":true,\"ddc\":0,\"ctf\":23,\"asc\":0,\"sly\":false,\"tbl\":[],\"lvl\":1,\"tfm\":false,\"pkl\":[10001,10102,10201],\"vgr\":5,\"ded\":false,\"ees\":0},{\"slayer\":false,\"ai\":true,\"unm\":-28684,\"hea\":114.0,\"sht\":114.0,\"mha\":114.0,\"lea\":1665984990490,\"lef\":23,\"ast\":4301,\"exp\":0.0,\"unn\":\"KindlyMessy NICKY\",\"unb\":-28684,\"rtc\":0,\"lwd\":\"What a shame.\",\"wwd\":\"Hello!\",\"eqp\":{\"eqp\":{\"8\":{\"fin\":\"11001-P33GRB80SPVo\",\"lqt\":0,\"bqt\":1,\"aiids\":[],\"spc\":0,\"dft\":0.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":8.0,\"dfc\":0.0,\"dfe\":0.0,\"ofr\":8.0,\"itm\":11001},\"2\":{\"fin\":\"22007-jcdPdn9OkrB9\",\"lqt\":0,\"bqt\":1,\"aiids\":[],\"spc\":0,\"dft\":8.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":0.0,\"dfc\":8.0,\"dfe\":0.0,\"ofr\":0.0,\"itm\":22007}},\"esp\":[]},\"ckc\":0,\"wtp\":[],\"sil\":false,\"ptc\":6001,\"wpt\":7,\"tnb\":0,\"l2d\":false,\"ddc\":0,\"ctf\":23,\"asc\":0,\"sly\":false,\"tbl\":[],\"lvl\":1,\"tfm\":false,\"pkl\":[50001,50101,50201],\"vgr\":5,\"ded\":false,\"ees\":0},{\"slayer\":false,\"ai\":true,\"unm\":-28685,\"hea\":116.0,\"sht\":116.0,\"mha\":116.0,\"lea\":1665984990490,\"lef\":23,\"ast\":4001,\"exp\":0.0,\"unn\":\"GladlyMessy DANIEL\",\"unb\":-28685,\"rtc\":0,\"lwd\":\"What a shame.\",\"wwd\":\"Hello!\",\"eqp\":{\"eqp\":{\"8\":{\"fin\":\"14001-tCDiWfzdnOuW\",\"lqt\":0,\"bqt\":1,\"aiids\":[],\"spc\":0,\"dft\":0.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":10.0,\"dfc\":0.0,\"dfe\":0.0,\"ofr\":10.0,\"itm\":14001},\"2\":{\"fin\":\"22007-UtdDX7tcPCrW\",\"lqt\":0,\"bqt\":1,\"aiids\":[],\"spc\":0,\"dft\":8.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":0.0,\"dfc\":8.0,\"dfe\":0.0,\"ofr\":0.0,\"itm\":22007}},\"esp\":[]},\"ckc\":0,\"wtp\":[],\"sil\":false,\"ptc\":6001,\"wpt\":6,\"tnb\":0,\"l2d\":false,\"ddc\":0,\"ctf\":23,\"asc\":0,\"sly\":false,\"tbl\":[],\"lvl\":1,\"tfm\":false,\"pkl\":[50001,50102,50201],\"vgr\":5,\"ded\":false,\"ees\":0}],\"fieldType\":23,\"observerRoom\":false},\"gmd\":0,\"unn\":0}";
                _Server.SendAsync(args.Client.Guid, resp2).Wait();
                return;

            }
            if (JsonObject.method == "ready2Move")
            {
                
                string resp = "{\"rid\":"+ JsonObject.id + ",\"cod\":200,\"tme\":"+ unixTimeMilliseconds + ",\"rst\":{\"wasStarted\":true}}";
                Console.WriteLine(resp);
                _Server.SendAsync(args.Client.Guid, resp).Wait();

                KeyValueList kvl = new KeyValueList();
                kvl.Add("startInstant", false);
                kvl.Add("startAfterWaiting", unixTimeMilliseconds + 10000);

                // StartWaitngTime startReq = new StartWaitngTime();
                // startReq.startAfterWaiting = unixTimeMilliseconds;
                // startReq.startInstant = false;
                // KeyValueList kvp = new KeyValueList(startReq);
                //
                WebSocketRequest wsm = new WebSocketRequest("readyGame", unixTimeMilliseconds, kvl.ToHashtable());

                string msgData = JsonSerializer.Serialize(wsm);
                Console.WriteLine(msgData);
                _Server.SendAsync(args.Client.Guid, msgData);



                SupplyInfo supplies = new SupplyInfo();
                var time1 = new SupplyTime();
                var time2 = new SupplyTime();
                time1.beginSec = 369.995f;
                time2.beginSec = 699.995f;
                time1.durationSec = 120;
                time2.durationSec = 120;
                supplies.timeList = new List<SupplyTime>();
                supplies.timeList.Add(time1);
                supplies.timeList.Add(time2);
                supplies.itemList = new List<SupplyItemData>();
                var nullitem = new SupplyItemData();
                nullitem.step = 0;
                nullitem.category = 0;
                nullitem.code = 0;
                nullitem.count = 0;
                nullitem.itemId = 0;


                supplies.itemList.Add(nullitem);
                KeyValueList kvl2 = new KeyValueList(supplies);
                WebSocketRequest wsm2 = new WebSocketRequest("inGameSupplies", unixTimeMilliseconds, kvl2.ToHashtable());

                string msgData2 = JsonSerializer.Serialize(wsm2);
                Console.WriteLine(msgData2);
                _Server.SendAsync(args.Client.Guid, msgData2);
                
                
                
                return;
            }
            if (JsonObject.method == "chat")
            {
                //This is hard coded atm
                string resp = "{\"mtd\":\"userChat\",\"tme\":"+ unixTimeMilliseconds + ",\"prm\":{\"userNick\":\"Lailtban\",\"message\":\"PREPARE YOURSELF\",\"chatsubType\":0,\"chatType\":3},\"gmd\":0,\"unn\":7562069}";
                //Send to all clients that a chat has been sent
                //foreach(string client in _Server.ListClients())
                _Server.SendAsync(args.Client.Guid, resp).Wait();
                
                
                //This is terrible and only here temporarily
                if (firstMessage)
                {
                    firstMessage = false;
                    string msgData3 = "{\"mtd\":\"restrictField\",\"tme\":"+ unixTimeMilliseconds + ",\"prm\":{\"restrictedFieldTypes\":[11],\"fieldRestrictRemainSec\":180,\"isNight\":false,\"restrictionFieldStep\":1,\"wicklineField\":0,\"willRestrictFieldTypes\":[14,17,21,20,23],\"remainRestrictionCounts\":{\"1\":0,\"2\":0,\"3\":0,\"4\":0,\"5\":0,\"6\":0,\"7\":0,\"8\":0,\"9\":0,\"10\":0,\"11\":0,\"12\":0,\"13\":0,\"14\":2,\"15\":0,\"16\":0,\"17\":2,\"18\":0,\"19\":0,\"20\":3,\"21\":2,\"22\":0,\"23\":1}},\"gmd\":0,\"unn\":0}";
                    _Server.SendAsync(args.Client.Guid, msgData3);

                }
                return;
            }
            if (JsonObject.method == "restInfo")
            {

                //This is hard coded atm
                Hashtable table = new Hashtable();
                table.Add("staminaRequire", 0.0f);
                table.Add("healthTic", 2.0f);
                table.Add("staminaTic", 5.0f);
                table.Add("cureTime", 12.0f);
                WebSocketRequest wsm2 = new WebSocketRequest("", JsonObject.id, unixTimeMilliseconds, table);
                string msgData2 = JsonSerializer.Serialize(wsm2);
                //Log.Debug(Helpers.format_json(msgData2));


                //string resp = "{\"rid\":" + JsonObject.id + ",\"cod\":200,\"tme\":" + unixTimeMilliseconds + "}";
                _Server.SendAsync(args.Client.Guid, msgData2).Wait();
                return;
            }
            if(JsonObject.method == "everythingLocation")
            {
                //Hard Coded Response should be this class "EverythingLocation"
                string resp = "{\"rid\":"+ JsonObject.id + ",\"cod\":200,\"tme\":"+ unixTimeMilliseconds + ",\"rst\":{\"restrictRemainSec\":145,\"me\":{\"slayer\":false,\"cnm\":10155226,\"unm\":7562069,\"unn\":\"ReplaceNameHere\",\"lwd\":\"How can I die here...\",\"wwd\":\"Come at me\",\"cls\":44,\"crd\":5,\"ast\":4401,\"l2d\":false,\"ehx\":0,\"ddm\":1665995236000,\"cpt\":3,\"rpc\":0,\"rwc\":0,\"npc\":0,\"nwc\":0,\"leg\":2,\"gbd\":0,\"tnm\":0,\"psi\":6001,\"pmn\":0,\"pfr\":0,\"psd\":0,\"hst\":false,\"mtp\":\"LUMIA\",\"cft\":23,\"cha\":{\"hea\":125.0,\"sta\":120.0,\"mht\":120.0,\"msm\":120.0,\"off\":8.0,\"def\":16.0,\"lvl\":1,\"tms\":120.0,\"cht\":1,\"tmh\":125.0,\"exp\":0.0},\"sga\":{\"currentDrainRatio\":0.0,\"currentHealth\":0.0,\"currentStamina\":0.0,\"currentOffence\":0.0,\"currentDefence\":0.0,\"currentAddedDmg\":0.0,\"currentReducedCooltime\":0.0,\"lpmh\":{},\"lpms\":{},\"lpo\":{},\"lpd\":{},\"lpad\":{},\"lprc\":{},\"lpdd\":{}},\"wvg\":[{\"wtp\":5,\"bfy\":56.0,\"afy\":0.0,\"mrk\":701},{\"wtp\":2,\"bfy\":56.0,\"afy\":0.0,\"mrk\":601},{\"wtp\":8,\"bfy\":56.0,\"afy\":0.0,\"mrk\":501},{\"wtp\":7,\"bfy\":55.0,\"afy\":0.0,\"mrk\":101},{\"wtp\":4,\"bfy\":56.0,\"afy\":0.0,\"mrk\":201},{\"wtp\":1,\"bfy\":76.0,\"afy\":0.0,\"mrk\":305},{\"wtp\":6,\"bfy\":56.0,\"afy\":0.0,\"mrk\":401}],\"wtp\":1,\"wdt\":[],\"spo\":[],\"sil\":[],\"ckc\":0,\"asc\":0,\"ddc\":0,\"mkc\":0,\"isl\":false,\"chs\":1,\"res\":false,\"pkl\":[10001,10101,10201],\"att\":\"\",\"ant\":\"TOMAS\",\"aot\":\"\",\"ltt\":\"DEFAULT_LANTERN\",\"cvt\":\"\",\"emj\":\"default\",\"rtc\":0,\"mcc\":0,\"dtc\":0,\"rcc\":2,\"tis\":[],\"cht\":1,\"ai\":false,\"mfi\":[],\"sbl\":[{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":2030,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":0.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":3030,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":70.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":6001,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":180.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":7011,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":0.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":7012,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":0.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":7014,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":0.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":5077,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":2,\"idr\":30.0,\"ict\":30.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0}],\"aep\":[{\"bst\":101,\"val\":10.0},{\"bst\":103,\"val\":8.0}],\"ded\":false,\"cto\":16.199999,\"ctd\":24.0,\"nrs\":0,\"ctt\":1},\"publicLocation\":[],\"monsterClassAndFieldType\":{}}}";
                _Server.SendAsync(args.Client.Guid, resp).Wait();

            }
            if (JsonObject.method == "shiftField")
            {
                //Hard Coded Response should be this class "EverythingLocation"
                string resp = "{\"rid\":"+ JsonObject.id + ",\"cod\":200,\"tme\":"+ unixTimeMilliseconds + ",\"rst\":{\"restrictRemainSec\":59,\"me\":{\"slayer\":false,\"cnm\":10155226,\"unm\":7562069,\"unn\":\"ReplaceNameHere\",\"lwd\":\"How can I die here...\",\"wwd\":\"Come at me\",\"cls\":44,\"crd\":5,\"ast\":4401,\"l2d\":false,\"ehx\":0,\"ddm\":1665995236000,\"cpt\":3,\"rpc\":0,\"rwc\":0,\"npc\":0,\"nwc\":0,\"leg\":2,\"gbd\":0,\"tnm\":0,\"psi\":6001,\"pmn\":0,\"pfr\":0,\"psd\":0,\"hst\":false,\"mtp\":\"LUMIA\",\"cft\":3,\"cha\":{\"hea\":112.0,\"sta\":68.0,\"mht\":120.0,\"msm\":120.0,\"off\":8.0,\"def\":16.0,\"lvl\":1,\"tms\":120.0,\"cht\":1,\"tmh\":125.0,\"exp\":0.33333334},\"sga\":{\"currentDrainRatio\":0.0,\"currentHealth\":0.0,\"currentStamina\":0.0,\"currentOffence\":0.0,\"currentDefence\":0.0,\"currentAddedDmg\":0.0,\"currentReducedCooltime\":0.0,\"lpmh\":{},\"lpms\":{},\"lpo\":{},\"lpd\":{},\"lpad\":{},\"lprc\":{},\"lpdd\":{}},\"wvg\":[{\"wtp\":5,\"bfy\":56.0,\"afy\":0.0,\"mrk\":701},{\"wtp\":2,\"bfy\":56.0,\"afy\":0.0,\"mrk\":601},{\"wtp\":8,\"bfy\":56.0,\"afy\":0.0,\"mrk\":501},{\"wtp\":7,\"bfy\":55.0,\"afy\":0.0,\"mrk\":101},{\"wtp\":4,\"bfy\":56.0,\"afy\":0.0,\"mrk\":201},{\"wtp\":1,\"bfy\":76.0,\"afy\":0.0,\"mrk\":305},{\"wtp\":6,\"bfy\":56.0,\"afy\":0.0,\"mrk\":401}],\"wtp\":1,\"wdt\":[],\"spo\":[],\"sil\":[],\"ckc\":0,\"asc\":0,\"ddc\":0,\"mkc\":0,\"isl\":false,\"chs\":1,\"res\":false,\"pkl\":[10001,10101,10201],\"att\":\"\",\"ant\":\"TOMAS\",\"aot\":\"\",\"ltt\":\"DEFAULT_LANTERN\",\"cvt\":\"\",\"emj\":\"default\",\"rtc\":0,\"mcc\":0,\"dtc\":0,\"rcc\":2,\"tis\":[],\"cht\":1,\"ai\":false,\"mfi\":[],\"sbl\":[{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":2030,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":0.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":3030,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":70.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":6001,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":180.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":7011,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":0.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":7012,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":0.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":7014,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":0.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":5077,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":2,\"idr\":30.0,\"ict\":30.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0}],\"aep\":[{\"bst\":101,\"val\":10.0},{\"bst\":103,\"val\":25.0},{\"bst\":2102,\"val\":-1.0}],\"ded\":false,\"cto\":16.199999,\"ctd\":41.0,\"nrs\":0,\"ctt\":1},\"exhaust\":false,\"shiftFieldCoolTime\":2.0,\"exhaustDamage\":0.0}}";
                _Server.SendAsync(args.Client.Guid, resp).Wait();

            }
            if(JsonObject.method == "search")
            {
                string resp = "{\"rid\":" + JsonObject.id + ",\"cod\":200,\"tme\":" + unixTimeMilliseconds + ",\"rst\":{\"me\":{\"slayer\":false,\"cnm\":10155226,\"unm\":7562069,\"unn\":\"ReplaceNameHere\",\"lwd\":\"How can I die here...\",\"wwd\":\"Come at me\",\"cls\":44,\"crd\":5,\"ast\":4401,\"l2d\":false,\"ehx\":0,\"ddm\":1665995236000,\"cpt\":3,\"rpc\":0,\"rwc\":0,\"npc\":0,\"nwc\":0,\"leg\":2,\"gbd\":0,\"tnm\":0,\"psi\":6001,\"pmn\":0,\"pfr\":0,\"psd\":0,\"hst\":false,\"mtp\":\"LUMIA\",\"cft\":5,\"cha\":{\"hea\":125.0,\"sta\":106.0,\"mht\":120.0,\"msm\":120.0,\"off\":8.0,\"def\":16.0,\"lvl\":1,\"tms\":120.0,\"cht\":1,\"tmh\":125.0,\"exp\":0.16666667},\"sga\":{\"currentDrainRatio\":0.0,\"currentHealth\":0.0,\"currentStamina\":0.0,\"currentOffence\":0.0,\"currentDefence\":0.0,\"currentAddedDmg\":0.0,\"currentReducedCooltime\":0.0,\"lpmh\":{},\"lpms\":{},\"lpo\":{},\"lpd\":{},\"lpad\":{},\"lprc\":{},\"lpdd\":{}},\"wvg\":[{\"wtp\":5,\"bfy\":56.0,\"afy\":0.0,\"mrk\":701},{\"wtp\":2,\"bfy\":56.0,\"afy\":0.0,\"mrk\":601},{\"wtp\":8,\"bfy\":56.0,\"afy\":0.0,\"mrk\":501},{\"wtp\":7,\"bfy\":55.0,\"afy\":0.0,\"mrk\":101},{\"wtp\":4,\"bfy\":56.0,\"afy\":0.0,\"mrk\":201},{\"wtp\":1,\"bfy\":76.0,\"afy\":0.0,\"mrk\":305},{\"wtp\":6,\"bfy\":56.0,\"afy\":0.0,\"mrk\":401}],\"wtp\":1,\"wdt\":[],\"spo\":[],\"sil\":[],\"ckc\":0,\"asc\":0,\"ddc\":0,\"mkc\":0,\"isl\":false,\"chs\":1,\"res\":false,\"pkl\":[10001,10101,10201],\"att\":\"\",\"ant\":\"TOMAS\",\"aot\":\"\",\"ltt\":\"DEFAULT_LANTERN\",\"cvt\":\"\",\"emj\":\"default\",\"rtc\":0,\"mcc\":0,\"dtc\":0,\"rcc\":2,\"tis\":[],\"cht\":1,\"ai\":false,\"mfi\":[],\"sbl\":[{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":2030,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":0.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":3030,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":70.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":6001,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":180.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":7011,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":0.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":7012,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":0.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":7014,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":0.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":5077,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":2,\"idr\":30.0,\"ict\":30.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0}],\"aep\":[{\"bst\":101,\"val\":10.0},{\"bst\":103,\"val\":8.0}],\"ded\":false,\"cto\":16.199999,\"ctd\":24.0,\"nrs\":0,\"ctt\":1},\"exhaust\":false,\"memoryFieldItemCount\":0,\"itemList\":[{\"fin\":\"12005-OazlzXwbEoIa\",\"lqt\":0,\"bqt\":1,\"aiids\":[],\"spc\":0,\"dft\":0.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":12.0,\"dfc\":0.0,\"dfe\":0.0,\"ofr\":12.0,\"itm\":12005}],\"memoryFieldItem\":[],\"searchResultType\":7,\"exhaustDamage\":0.0}}";
                _Server.SendAsync(args.Client.Guid, resp).Wait();
            }
            if (JsonObject.method == "takeFieldItem")
            {
                //WE SHOULD MOVE THIS TO WHEN WE GENERATE ITEMS INTO THE FIELDS
                //When items are created they should be done so with a hash attached
                //Eg 51024-EGOiFRisEpXe ItemID-HASH (12chars) can contain upper case, lower case and numbers
                //var hashableCharacters = "ABCEDFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                //var hashLength = new char[12];
                //var random = new Random();
                //for (int i = 0; i < hashLength.Length; i++)
                //{
                //     hashLength[i] = hashableCharacters[random.Next(hashableCharacters.Length)];
                //}
                //var itemHash = new String(hashLength);
                //fieldItemCode + "-" + itemHash;
                string resp = "{\"rid\":" + JsonObject.id + ",\"cod\":200,\"tme\":" + unixTimeMilliseconds + ",\"rst\":{\"me\":{\"slayer\":false,\"cnm\":10155226,\"unm\":7562069,\"unn\":\"ReplaceNameHere\",\"lwd\":\"How can I die here...\",\"wwd\":\"Come at me\",\"cls\":44,\"crd\":5,\"ast\":4401,\"l2d\":false,\"ehx\":0,\"ddm\":1665995236000,\"cpt\":3,\"rpc\":0,\"rwc\":0,\"npc\":0,\"nwc\":0,\"leg\":2,\"gbd\":0,\"tnm\":0,\"psi\":6001,\"pmn\":0,\"pfr\":0,\"psd\":0,\"hst\":false,\"mtp\":\"LUMIA\",\"cft\":5,\"cha\":{\"hea\":125.0,\"sta\":112.0,\"mht\":120.0,\"msm\":120.0,\"off\":8.0,\"def\":16.0,\"lvl\":1,\"tms\":120.0,\"cht\":1,\"tmh\":125.0,\"exp\":0.0},\"sga\":{\"currentDrainRatio\":0.0,\"currentHealth\":0.0,\"currentStamina\":0.0,\"currentOffence\":0.0,\"currentDefence\":0.0,\"currentAddedDmg\":0.0,\"currentReducedCooltime\":0.0,\"lpmh\":{},\"lpms\":{},\"lpo\":{},\"lpd\":{},\"lpad\":{},\"lprc\":{},\"lpdd\":{}},\"wvg\":[{\"wtp\":5,\"bfy\":56.0,\"afy\":0.0,\"mrk\":701},{\"wtp\":2,\"bfy\":56.0,\"afy\":0.0,\"mrk\":601},{\"wtp\":8,\"bfy\":56.0,\"afy\":0.0,\"mrk\":501},{\"wtp\":7,\"bfy\":55.0,\"afy\":0.0,\"mrk\":101},{\"wtp\":4,\"bfy\":56.0,\"afy\":0.0,\"mrk\":201},{\"wtp\":1,\"bfy\":76.0,\"afy\":0.0,\"mrk\":305},{\"wtp\":6,\"bfy\":56.0,\"afy\":0.0,\"mrk\":401}],\"wtp\":1,\"ivn\":{\"cpc\":6,\"fos\":[{\"fin\":\"31007-KeA4tkM6Zlqw\",\"lqt\":0,\"bqt\":2,\"aiids\":[],\"spc\":0,\"dft\":0.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":0.0,\"dfc\":0.0,\"dfe\":0.0,\"ofr\":0.0,\"itm\":31007},{\"fin\":\"32004-yWFI2wREIsmE\",\"lqt\":0,\"bqt\":3,\"aiids\":[],\"spc\":0,\"dft\":0.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":0.0,\"dfc\":0.0,\"dfe\":0.0,\"ofr\":0.0,\"itm\":32004},{\"fin\":\"31006-vKPT001w5LLn\",\"lqt\":0,\"bqt\":2,\"aiids\":[],\"spc\":0,\"dft\":0.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":0.0,\"dfc\":0.0,\"dfe\":0.0,\"ofr\":0.0,\"itm\":31006}]},\"eqp\":{\"eqp\":{\"8\":{\"fin\":\"13021-VhwErQUTIgA4\",\"lqt\":0,\"bqt\":1,\"aiids\":[],\"spc\":5077,\"dft\":0.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":8.0,\"dfc\":0.0,\"dfe\":0.0,\"ofr\":8.0,\"itm\":13021},\"2\":{\"fin\":\"22007-L17N3yBi56w7\",\"lqt\":0,\"bqt\":1,\"aiids\":[],\"spc\":0,\"dft\":8.0,\"alb\":false,\"sil\":false,\"ofe\":0.0,\"ofc\":0.0,\"dfc\":8.0,\"dfe\":0.0,\"ofr\":0.0,\"itm\":22007}},\"esp\":[5077]},\"wdt\":[],\"spo\":[],\"sil\":[],\"ckc\":0,\"asc\":0,\"ddc\":0,\"mkc\":0,\"isl\":false,\"chs\":1,\"res\":false,\"pkl\":[10001,10101,10201],\"att\":\"\",\"ant\":\"TOMAS\",\"aot\":\"\",\"ltt\":\"DEFAULT_LANTERN\",\"cvt\":\"\",\"emj\":\"default\",\"rtc\":0,\"mcc\":0,\"dtc\":0,\"rcc\":2,\"tis\":[],\"cht\":1,\"ai\":false,\"mfi\":[],\"sbl\":[{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":2030,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":0.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":3030,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":70.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":6001,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":180.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":7011,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":0.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":7012,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":0.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":7014,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":0,\"idr\":0.0,\"ict\":0.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0},{\"usl\":[],\"usm\":{},\"msm\":{},\"ski\":5077,\"stt\":0,\"stc\":-1,\"stm\":-1,\"drt\":2,\"idr\":30.0,\"ict\":30.0,\"lta\":\"\",\"rdu\":0.0,\"rco\":0.0}],\"aep\":[{\"bst\":101,\"val\":10.0},{\"bst\":103,\"val\":8.0}],\"ded\":false,\"cto\":16.199999,\"ctd\":24.0,\"nrs\":0,\"ctt\":1},\"inventoryAddResult\":2}}";
                _Server.SendAsync(args.Client.Guid, resp).Wait();
            }
        }

        static void HttpHandler(HttpListenerContext ctx)
        {
            HttpListenerRequest req = ctx.Request;
            string contents = null;
            using (Stream stream = req.InputStream)
            {
                using (StreamReader readStream = new StreamReader(stream, Encoding.UTF8))
                {
                    contents = readStream.ReadToEnd();
                }
            }

            Console.WriteLine("Non-websocket request received for: " + req.HttpMethod.ToString() + " " + req.RawUrl);
            if (req.Headers != null && req.Headers.Count > 0)
            {
                Console.WriteLine("Headers:");
                var items = req.Headers.AllKeys.SelectMany(req.Headers.GetValues, (k, v) => new { key = k, value = v });
                foreach (var item in items)
                {
                    Console.WriteLine("  {0}: {1}", item.key, item.value);
                }
            }

            if (!String.IsNullOrEmpty(contents))
            {
                Console.WriteLine("Request body:");
                Console.WriteLine(contents);
            }
        }

}
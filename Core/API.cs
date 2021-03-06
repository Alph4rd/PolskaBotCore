﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using System.Net.Security;
using System.Text.RegularExpressions;
using PolskaBot.Core.Darkorbit;
using PolskaBot.Core.Darkorbit.Commands;
using PolskaBot.Core.Darkorbit.Commands.PostHandshake;
using PolskaBot.Fade;

namespace PolskaBot.Core
{
    public class API
    {
        public enum Mode
        {
            BOT
        };

        public Mode mode;

        private VanillaClient _vanillaClient;
        private FadeProxyClient _proxy;

        public DateTime LoginTime { get; protected set; } = DateTime.MinValue;

        // Logic
        public Account Account { get; set; }
        public List<Box> Boxes { get; set; } = new List<Box>();
        public List<Box> MemorizedBoxes { get; set; } = new List<Box>();
        public List<Ore> Ores { get; set; } = new List<Ore>();
        public List<Ship> Ships { get; set; } = new List<Ship>();
        public List<Gate> Gates { get; set; } = new List<Gate>();
        public List<Building> Buildings { get; set; } = new List<Building>();

        public object boxesLocker = new object();
        public object memorizedBoxesLocker = new object();
        public object oresLocker = new object();
        public object shipsLocker = new object();
        public object buildingsLocker = new object();

        public event EventHandler<EventArgs> Connecting;
        public event EventHandler<EventArgs> Disconnected;
        public event EventHandler<EventArgs> HeroInited;
        public event EventHandler<ShipAttacked> Attacked;
        public event EventHandler<ShipMove> ShipMoving;
        public event EventHandler<EventArgs> Destroyed;

        public API(FadeProxyClient proxy, Mode mode = Mode.BOT)
        {
            this.mode = mode;

            // Depedency injection
            Account = new Account(this);
            _proxy = proxy;
            _vanillaClient = new VanillaClient(this, proxy);

            Account.LoginSucceed += (s, e) => Connect();

            _vanillaClient.Disconnected += (s, e) => Disconnected?.Invoke(s, e);
            _vanillaClient.HeroInited += (s, e) =>
            {
                HeroInited?.Invoke(s, e);
                if (LoginTime == DateTime.MinValue)
                    LoginTime = DateTime.Now;
            };
            _vanillaClient.Attacked += (s, e) => Attacked?.Invoke(s, e);
            _vanillaClient.ShipMoving += (s, e) => ShipMoving?.Invoke(s, e);
            _vanillaClient.Destroyed += (s, e) => Destroyed?.Invoke(s, e);
        }

        public void Stop()
        {
            _vanillaClient.Stop();
            _vanillaClient.pingThread?.Abort();
        }

        public void Login(string username = null, string password = null)
        {
            if (username == null || password == null)
            {
                username = Environment.GetEnvironmentVariable(Config.USERNAME_ENV);
                password = Environment.GetEnvironmentVariable(Config.PASSWORD_ENV);
            }
            Account.SetCredentials(username, password);
            Account.Login();
        }

        public void Connect()
        {
            _vanillaClient.OnConnected += (o, e) => _vanillaClient.Send(new ClientVersionCheck(Config.MAJOR, Config.MINOR, Config.BUILD));
            _vanillaClient.Disconnected += (o, e) => Reconnect();

            Connecting?.Invoke(this, EventArgs.Empty);

            var serverIP = GetIP();
            if (serverIP != null)
                _vanillaClient.Connect(serverIP, 8080);
            else
                Reconnect();
        }

        public void SendEncoded(Command command)
        {
            _vanillaClient.SendEncoded(command);
        }

        public void Reconnect()
        {
            Console.WriteLine("Connection lost. Reconnecting.");
            _vanillaClient.pingThread?.Abort();
            Boxes.Clear();
            MemorizedBoxes.Clear();
            Ores.Clear();
            Ships.Clear();
            Gates.Clear();
            Buildings.Clear();
            _proxy.Reset();

            if(_vanillaClient.tcpClient.Connected)
                _vanillaClient.Disconnect();

            _vanillaClient.thread?.Abort();
        }

        public string GetIP()
        {
            using (var webClient = new WebClient())
            {
                try {
                    //Change SSL checks so that all checks pass
                    ServicePointManager.ServerCertificateValidationCallback =
                       new RemoteCertificateValidationCallback(
                            delegate
                            { return true; }
                        );
                }
                catch (Exception ex) {
                    Console.WriteLine(ex);
                }
                try
                {
                    var response = webClient.DownloadString($"http://{Account.Server}.darkorbit.bigpoint.com/spacemap/xml/maps.php");
                    var match = Regex.Match(response, $"<map id=\"{Account.Map}\"><gameserverIP>([0-9\\.]+)</gameserverIP></map>");
                    return match.Groups[1].ToString();
                }
                catch (Exception ex) {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }
    }
}

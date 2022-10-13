using Discord.WebSocket;
using Discord;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography.X509Certificates;

// https://discord.com/api/oauth2/authorize?client_id=1030218384094281818&permissions=8&scope=bot

namespace CSharp_Bot
{
    public class Program
    {
        public static Task Main(string[] args) => new Program().MainAsync();
        private DiscordSocketClient _client;

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        public async Task MainAsync()
        {
            {
                _client = new DiscordSocketClient();

                _client.Log += Log;

                var token = File.ReadAllText(@"E:\Desktop Stuff\Bot Files\CSharp_Bot\data\token.txt");

                await _client.LoginAsync(TokenType.Bot, token);
                await _client.StartAsync();

                // Block this task until the program is closed.
                await Task.Delay(-1);
            }
        }

    }

}


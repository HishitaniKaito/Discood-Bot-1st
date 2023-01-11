using Discord;
using Discord.WebSocket;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Discood_Bot_1st
{
    class Program
    {
        private readonly DiscordSocketClient _client;
        static void Main(string[] arga)
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public Program()
        {
            _client = new DiscordSocketClient();
            _client.Log += Log;
            _client.Ready += onReady;
            _client.MessageReceived += onMessage;
        }
        public async Task MainAsync()
        {
            //tokenはさらすわけには行けないので
            var token = "";

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(Timeout.Infinite);
        }
        private Task onReady()
        {
            Console.WriteLine($"{_client.CurrentUser} is Running!!");
            return Task.CompletedTask;
        }
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
        private async Task onMessage(SocketMessage message)
        {
            if (message.Author.Id == _client.CurrentUser.Id)
            {
                return;
            }
            if (message.Content == "aaaaa")
            {
                await message.Channel.SendMessageAsync("こんにちは！");
            }
            if (message.Content == "何時")
            {
                DateTime dt = DateTime.Now;
                await message.Channel.SendMessageAsync("今の時刻は" + dt.ToString("hh:mm"));
            }
        }
    }
}

using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Herobot.Plugins.Example.Modules
{
    class ExampleModule : ModuleBase<SocketCommandContext>
    {
        [Command("testCommand")]
        public Task Testcommand() => ReplyAsync("Je suis un test !");

        [Command("mp")]
        public async Task SendMp(SocketGuildUser socketGuildUser,[Remainder]string message) {
            await socketGuildUser.GetOrCreateDMChannelAsync().ContinueWith((channelOpen) =>
            {
                channelOpen.Result.SendMessageAsync(message);
            });
        }
    }
}

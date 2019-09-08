using Discord.Commands;
using Discord.WebSocket;
using HeroBot.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Herobot.Plugins.Example.Modules
{
    [Cooldown(1)]
    [NeedPlugin()]
    [Name("Example plugin")]
    public class ExampleModule : ModuleBase<SocketCommandContext>
    {
        [Command("testCommand")]
        public Task Testcommand() => ReplyAsync("I'm a test");

        [Command("mp")]
        [Cooldown(2)]
        public async Task SendMp(SocketGuildUser socketGuildUser,[Remainder]string message) {
            await socketGuildUser.GetOrCreateDMChannelAsync().ContinueWith((channelOpen) =>
            {
                channelOpen.Result.SendMessageAsync(message);
            });
        }
    }
}

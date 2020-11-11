
using Smile.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace Smile.BLL.Telegram
{
    public static class Bot
    {
        private static TelegramBotClient client;
        private static string ApiKey = "1265124021:AAFO-fgd48YpqgqkKX_kbUgImX0rtUa-0s8";
        public static async Task BotInit()
        {
            if (client != null)
                return;
           
            client = new TelegramBotClient(ApiKey);
            await client.SetWebhookAsync("");
        }
       
        public static async Task SendInfo(int id, string message)
        {
            if (client == null)
                await BotInit();
            await client.SendTextMessageAsync(id, message);
        }

        public static void Get()
        {
            client.StartReceiving();
            client.OnMessage += Client_OnMessage;
        }

        private static void Client_OnMessage(object sender, global::Telegram.Bot.Args.MessageEventArgs e)
        {
            client.SendTextMessageAsync(e.Message.Chat.Id, "Test!").ConfigureAwait(false);
        }
    }
}

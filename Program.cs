using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBot
{
    
    class Program
    {
        // Start the BotClient
        static TelegramBotClient Bot = new TelegramBotClient("1616770898:AAGdC_QpIZo08nww11q_PQAZgaPoR3k-2ec");
        static void Main(string[] args)
        {
            Bot.StartReceiving();
            Bot.OnMessage += Bot_OnMessage;

            //Time when method needs to be called
            var DailyTime = "11:25:00";
            var timeParts = DailyTime.Split(new char[1] { ':' });

            var dateNow = DateTime.Now;
            var date = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day,
                       int.Parse(timeParts[0]), int.Parse(timeParts[1]), int.Parse(timeParts[2]));
            TimeSpan ts;
            if (date > dateNow)
                ts = date - dateNow;
            else
            {
                date = date.AddDays(1);
                ts = date - dateNow;
            }

            //waits certan time and run the code "SendTextMessageAsync"
            Task.Delay(ts).ContinueWith((x) => Bot.SendTextMessageAsync("-1001446884829", "Pole"));

            Console.Read();

            Console.ReadLine();
        }

        private static void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            /*To read the chat ID and show it in the console*/
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                if(e.Message.Text.StartsWith("/id"))
                Bot.SendTextMessageAsync(e.Message.Chat.Id, "Revisa la consola!");
                Console.WriteLine(e.Message.Chat.Id);
            }

        }
    }
}

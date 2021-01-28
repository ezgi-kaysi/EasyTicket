using System;
using System.Collections.Generic;
using System.Text;

namespace EasyTicket.MessagingBus.Helpers
{
    public static class ConsoleHelper
    {
        public enum MessageType
        {
            Received,
            Published
        }

        public static void Writeline(string text, MessageType messageType)
        {
            if (messageType == MessageType.Received)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("***********   Received   *************");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("***********   Published  *************");
            }

            Console.WriteLine(text);
            Console.WriteLine("**************************************");
            Console.ResetColor();
        }
    }
}

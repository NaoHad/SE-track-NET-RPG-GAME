using System;
using System.Collections.Generic;
using System.Text;

namespace Maandag.Rooms
{
    class Room2 : Room
    {
        public void printMap()
        {
            throw new NotImplementedException();
        }

        public bool start()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Dit is room 2");
            Console.ReadLine();

            return false;
        }
    }
}

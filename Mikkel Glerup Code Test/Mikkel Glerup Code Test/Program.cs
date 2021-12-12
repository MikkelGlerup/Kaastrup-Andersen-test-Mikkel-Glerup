using System;

namespace Mikkel_Glerup_Code_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            MainMenu menu = new MainMenu();
            while (showMenu)
            {
                showMenu = menu.MenuHub();
            }
                

        }
    }
}


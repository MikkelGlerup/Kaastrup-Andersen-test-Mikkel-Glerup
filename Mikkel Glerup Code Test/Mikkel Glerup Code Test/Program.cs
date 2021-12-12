using System;

namespace Mikkel_Glerup_Code_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            Menu menu = new Menu();
            while (showMenu)
            {
                //change variable name
                showMenu = menu.MainMenu();
            }
                

        }
    }
}


using BookStorage.Admin.UI;

namespace BookStorage.Admin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();
            menu.ShowMenu();
        }
    }
}
using BookStorage.User.UI;

namespace BookStorage.User
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
public abstract class Menu<T>
{
    protected List<T> menuOptions;
    protected string title;
    protected bool continueExecution = true;

    public Menu() { }

    public Menu(string title, T[] options)
    {
        this.title = title;
        this.menuOptions = new List<T>(options);
    }

    public void Display()
    {
        Console.WriteLine("-------------------------");
        Console.WriteLine(title);
        for (int i = 0; i < menuOptions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {menuOptions[i]}");
        }
        Console.WriteLine("-------------------------");
    }

    public int GetSelected()
    {
        int selected = 0;
        while (true)
        {
            Display();
            Console.Write("Enter selection: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out selected))
            {
                break;
            }
            Console.WriteLine("Invalid option. Please try again.");
        }
        return selected;
    }

    public abstract void Execute(int selection);

    public void ExitMenu()
    {
        continueExecution = false;
    }

    public void Run()
    {
        int sizeOfMenu = menuOptions.Count;
        int selection;
        continueExecution = true;
        do
        {
            selection = GetSelected();
            if (selection > 0 && selection <= sizeOfMenu)
            {
                Execute(selection);
            }
            else
            {
                Console.WriteLine("Invalid option.\nPlease try again.");
            }

        } while (continueExecution);
    }
}

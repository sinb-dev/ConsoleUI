using ConsoleUI;
using ConsoleUI.Pages;

//Open ListHostsPage as the first page
Navigation.Open(new ListHostsPage());

ConsoleKeyInfo keyInfo;
while (true)
{
    //Show active page
    Navigation.Show();

    keyInfo = Console.ReadKey();

    switch(keyInfo.Key)
    {
        case ConsoleKey.Escape:
            break;
        case ConsoleKey.Tab:
            if (keyInfo.Modifiers == ConsoleModifiers.Shift)
                ControlBase.PreviousControl();
            else
                ControlBase.NextControl();
            break;
        default:
            ControlBase? activeControl = ControlBase.GetActiveControl();
            activeControl?.HandleKeyInfo(keyInfo);
            break;
    }
} //Program.cs
using ConsoleUI;
using ConsoleUI.Pages;

//Open ListHostsPage as the first page
Navigation.Open(new ListHostsPage());

ConsoleKeyInfo keyInfo;
while (true)
{
    //Show active page
    Navigation.Show();
    PageBase activePage = Navigation.ActivePage();
    keyInfo = Console.ReadKey();

    switch(keyInfo.Key)
    {
        case ConsoleKey.Escape:
            break;
        case ConsoleKey.Tab:
            
            if (keyInfo.Modifiers == ConsoleModifiers.Shift)
                activePage.PreviousControl();
            else
                activePage.NextControl();
            break;
        default:
            ControlBase? activeControl = activePage.GetActiveControl();
            activeControl?.HandleKeyInfo(keyInfo);
            break;
    }
} //Program.cs
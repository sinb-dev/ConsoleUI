using ConsoleUI;
using ConsoleUI.Pages;

//Open ListHostsPage as the first page
Navigation.Open(new ListHostsPage());

ConsoleKeyInfo keyInfo;
while (true)
{
    //Show active page
    Navigation.Show();

    Overlay.Show();

    ControlsManager? controlsManager;
    PageBase activePage = Navigation.ActivePage();
    controlsManager = activePage.ControlsManager;
    keyInfo = Console.ReadKey();

    switch(keyInfo.Key)
    {
        case ConsoleKey.Escape:
            break;
        case ConsoleKey.Tab:
            if (keyInfo.Modifiers == ConsoleModifiers.Shift)
                controlsManager?.PreviousControl();
            else
                controlsManager?.NextControl();
            break;
        default:
            ControlBase? activeControl = controlsManager?.GetActiveControl();
            activeControl?.HandleKeyInfo(keyInfo);
            break;
    }
} //Program.cs
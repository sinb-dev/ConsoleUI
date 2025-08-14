namespace ConsoleUI;
public static class Navigation 
{
    static Stack<PageBase> _navigation = new();
    public static void Open(PageBase page) 
    {
        _navigation.Push(page);
    }
    public static void Back()
    {
        _navigation.Pop();
    }
    public static void Show()
    {
        //Clear some stuff before this page is rendered
        Console.Clear();
        Console.CursorLeft = 0;
        Console.CursorTop = 0;

        //Write the breadcrumbs on page top
        Console.WriteLine(BreadCrumbs());
        //Render the active page
        PageBase activePage = ActivePage();
        activePage.Render();
    }
    public static PageBase ActivePage()
    {
        return _navigation.Peek();
    }
    public static string BreadCrumbs() 
    {
        Stack<PageBase> tempStack = new();
        //Transfer from navigation stack to a temporary
        while (_navigation.Count > 0) 
        {
            tempStack.Push(_navigation.Pop());
        }
        
        string[] titles = new string[tempStack.Count];
        int i = 0;
        //Move all pages back to the navigation stack
        while (tempStack.Count > 0)
        {
            PageBase currentPage = tempStack.Pop();
            titles[i++] = currentPage.ToString(); //Save the page title
            _navigation.Push(currentPage);
        }
        //Glue all titles together with > and return
        return string.Join(" > ", titles);
    }
} //Navigation.cs
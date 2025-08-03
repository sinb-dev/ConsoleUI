namespace ConsoleUI.Pages;

public class ListHostsPage : PageBase
{
    public ListHostsPage() : base("Hosts")
    {

    }
    protected override UIElement GetRoot()
    {
        ColumnContainer root = new();
        root.AddChild(new Label("Here comes a list of host IPs"));
        root.AddChild(new Button("New host", openEditHostPage));
        return root;
    }
    void openEditHostPage()
    {
        Navigation.Open(new EditHostPage());
    }
} //Pages/ListHostsPage.cs
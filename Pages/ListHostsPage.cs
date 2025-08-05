namespace ConsoleUI.Pages;

public class ListHostsPage : PageBase
{
    SelectBox test = new();
    public ListHostsPage() : base("Hosts")
    {

    }
    protected override UIElement GetMain()
    {
        ColumnContainer root = new();
        root.AddChild(new Label("Here comes a list of host IPs"));
        root.AddChild(new Button("New host", openEditHostPage));
        root.AddChild(test);
        return root;
    }
    void openEditHostPage()
    {
        Navigation.Open(new EditHostPage());
    }
} //Pages/ListHostsPage.cs
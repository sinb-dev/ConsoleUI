namespace ConsoleUI.Pages;

public class EditHostPage : PageBase
{
    public EditHostPage() : base("Edit host")
    {

    }
    protected override UIElement GetMain()
    {
        ColumnContainer root = new();
        root.AddChild(new Label("Here comes a form to edit a host with"));
        root.AddChild(new Label("Enter host name"));
        root.AddChild(new TextBox());
        root.AddChild(new Label("Enter IP address"));
        root.AddChild(new TextBox());
        root.AddChild(new Button("Go back", Navigation.Back));
        return root;
    }
} //Pages/EditHostPage.cs
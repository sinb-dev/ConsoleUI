namespace ConsoleUI.Pages;

public class EditHostPage : PageBase
{
    public EditHostPage() : base("Edit host")
    {

    }
    protected override UIElement GetRoot()
    {
        ColumnContainer root = new();
        root.AddChild(new Label("Here comes a form to edit a host with"));
        root.AddChild(new Button("Go back", Navigation.Back));
        return root;
    }
} //Pages/EditHostPage.cs
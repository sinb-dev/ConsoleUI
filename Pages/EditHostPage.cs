namespace ConsoleUI.Pages;

public class EditHostPage : PageBase
{
    //Declare controls on the class to prevent being reset every render
    TextBox txtHostName = new();
    TextBox txtIpAddress = new();
    public EditHostPage() : base("Edit host")
    {

    }
    protected override UIElement GetMain()
    {
        ColumnContainer root = new();
        root.AddChild(new Label("Here comes a form to edit a host with"));
        root.AddChild(new Label("Enter host name"));
        root.AddChild(txtHostName);
        root.AddChild(new Label("Enter IP address"));
        root.AddChild(txtIpAddress);
        RowContainer row = new();
        row.AddChild(new Button("Go back", Navigation.Back));
        row.AddChild(new Button("Reset", () => {
            txtHostName.Content = "";
            txtIpAddress.Content = "";
        }));
        root.AddChild(row);

        return root;
    }
} //Pages/EditHostPage.cs
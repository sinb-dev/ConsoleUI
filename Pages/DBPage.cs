using Microsoft.Data.SqlClient;

namespace ConsoleUI.Pages;

public class DBPage : PageBase
{
    public int MainElementId { get; set;}
    protected UIElement? Main = null;
    public DBPage() : base("Hosts")
    {

    }
    protected override UIElement GetMain()
    {
        if (Main == null)
        {
            Main = getMainFromDB();
        }
        return Main;
    }
    protected UIElement getMainFromDB()
    {
        object[] mainValues = _databaseHelper.getDBRow(MainElementId, "SELECT element_type FROM elements WHERE id=@id");
        string element_type = (string) mainValues[0];
        return _databaseHelper.InstanceFromDB(element_type, MainElementId) ?? new Label("Unknown main element");
    }

    public override void LoadFromDB(int id)
    {
        base.LoadFromDB(id);
        object[] values = _databaseHelper.getDBRow(id, "SELECT page_id, title, main_element_id FROM pages WHERE page_id=@id");
        Id = (int) values[0];
        _title = (string) values[1];
        MainElementId = (int) values[2];
    }
    
} //Pages/ListHostsPage.cs

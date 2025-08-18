namespace ConsoleUI;
public abstract class UIElement
{
    public int Id { get; set; } = 0;
    protected static DatabaseHelper _databaseHelper = new();
    protected int Width = 0;
    protected int Height = 0;
    public UIElement()
    {
        
    }
    public UIElement(int width, int height)
    {
        Width = width;
        Height = height;
    }
    
    public abstract void Render();
    public abstract void Render(int maxWidth, int maxHeight);

    public abstract (int Width, int Height) GetSize();
    protected UIElement? _parent;

    public UIElement? GetParent()
    {
        return _parent;
    }
    public void SetParent(UIElement element)
    {
        _parent = element;
    }
    public UIElement GetRoot()
    {
        UIElement? parent = GetParent();
        if (parent == null)
        {
            return this;
        }
        return parent.GetRoot();
    }
    public virtual void LoadFromDB(int id)
    {
        object[] values = _databaseHelper.getDBRow(id, "SELECT id, width, height FROM elements WHERE id=@id");
        Id = (int) values[0];
        Width = (int) values[1];
        Height = (int) values[2];
    }
} //UIElement.cs
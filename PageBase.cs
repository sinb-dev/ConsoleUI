namespace ConsoleUI;
public abstract class PageBase : UIElement, IControlManager
{
    protected string _title = "";
    protected ControlHelper _controlHelper = new();
    protected UIElement? _main = null;
    public PageBase(string title)
    {
        _title = title;
    }

    public override (int Width, int Height) GetSize()
    {
        return (Console.BufferWidth, Console.BufferHeight);
    }

    public override void Render()
    {
        Render(Console.BufferWidth, Console.BufferHeight);
    }

    public override void Render(int maxWidth, int maxHeight)
    {
        //Clear controls from helper
        _controlHelper.ClearControls();

         //Build UI Tree
        if (_main == null)
        {
            _main = GetMain();
        }

        //Set main node parent to page
        _main.SetParent(this);
        
        findAndAddControls(_main);
        
        _main.Render(maxWidth, maxHeight);
    } //PageBase.cs
    public void NextControl()
    {
        _controlHelper.NextControl();
    }
    public void PreviousControl()
    {
        _controlHelper.PreviousControl();
    }
    public ControlBase? GetActiveControl()
    {
        return _controlHelper.GetActiveControl();
    }
    void findAndAddControls(UIElement main)
    {
        List<ControlBase> controls = new();
        if (main is ContainerBase)
        {
            controls = ((ContainerBase) main).Find<ControlBase>();
        }
        else if (main is ControlBase control)
        {
            controls.Add(control);
        }
        
        foreach (ControlBase control in controls)
        {
            _controlHelper.AddControl(control);
        }
    }
    protected abstract UIElement GetMain();
    public override string ToString()
    {
        return _title;
    }
    
} //PageBase.cs
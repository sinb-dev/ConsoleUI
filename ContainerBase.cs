using System.Linq.Expressions;

namespace ConsoleUI;

public abstract class ContainerBase : UIElement
{
    protected List<UIElement> _children = new();
    public ContainerBase()
    {

    }
    public virtual void AddChild(UIElement element)
    {
        _children.Add(element);
    }
    public List<ControlBase> GetControls(List<ControlBase>? list = null)
    {
        if (list == null)
        {
            list = new();
        }
        foreach (UIElement child in _children)
        {
            if (child is ControlBase control)
            {
                list.Add(control);
            } 
            else if (child is ContainerBase container)
            {
                container.GetControls(list);
            }
        }
        return list;
    }
} //ContainerBase.cs
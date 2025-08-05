using System.Runtime.CompilerServices;

namespace ConsoleUI;

public abstract class ContainerBase : UIElement
{
    protected List<UIElement> _children = new();
    public ContainerBase()
    {

    }
    public void AddChild(UIElement element)
    {
        if (element is ControlBase)
        {
            ControlBase.AllControls.Add((ControlBase) element);
            
        }
        _children.Add(element);

        element.SetParent(element);
    }

    /// <summary>
    /// Find elements among children that match against a callback
    /// </summary>
    /// <typeparam name="T">A type of UIElement</typeparam>
    /// <param name="matcher"></param>
    /// <returns>A list of matching elements</returns>
public List<T> Find<T>(Func<UIElement, bool>? matcher = null) where T : UIElement
{
    if (matcher == null)
    {
        matcher = element => {
            if (element is T elementAsT)
            {
                return true;
            }
            return false;
        };
    }

    //Create a list of results
    List<T> found = new();
    
    //See if current instance matches
    if (this is T thisAsT) //cast 'this' to a T and create variable 'asT' for it
    {
        found.Add(thisAsT); //Add it to list
    }

    //Loop through each child
    foreach (UIElement element in _children)
    {
        //See if child element is a container too and look recursively
        if (element is ContainerBase container)
        {   
            found.AddRange(container.Find<T>(matcher));
        }
        else
        {
            //See if child element is a match and add it
            if (matcher.Invoke(element))
            {
                found.Add((T) element);
            }
        }
    }
    return found;
} //ContainerBase.cs
} //ContainerBase.cs
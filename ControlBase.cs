namespace ConsoleUI;

public abstract class ControlBase : UIElement
{
    // Checks if the current instance is active
    public bool IsActive()
    {
        IControlManager? manager = GetRoot() as IControlManager;
        if (manager != null)
        {
            return manager.GetActiveControl() == this;
        }
        return false;
    }

    // Require child classes to handle KeyInfo from console
    public abstract void HandleKeyInfo(ConsoleKeyInfo keyInfo);

} //ControlBase.cs
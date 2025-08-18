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

    public override void LoadFromDB(int id)
    {
        base.LoadFromDB(id);
        object[] values = _databaseHelper.getDBRow(id, "SELECT control_id FROM controlbase WHERE control_id=@id");
        Id = (int) values[0];
    }
} //ControlBase.cs
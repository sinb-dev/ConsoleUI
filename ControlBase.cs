namespace ConsoleUI;

public abstract class ControlBase : UIElement
{
    // Must contain all control. 
    // public static List<ControlBase> AllControls = new();
    // static int _activeControlIndex = 0;
    
    // // Gets the current active control, or null if there is no controls
    // public static ControlBase? GetActiveControl()
    // {
    //     if (AllControls.Count == 0)
    //     {
    //         return null;
    //     }
    //     return AllControls[_activeControlIndex];
    // }
    // public static void NextControl() => _activeControlIndex = ++_activeControlIndex >= AllControls.Count ? 0 : _activeControlIndex;
    // public static void PreviousControl() => _activeControlIndex = --_activeControlIndex < 0 ? AllControls.Count-1 : _activeControlIndex;

    // // Checks if the current instance is active
    // public bool IsActive()
    // {
    //     if (AllControls.Count == 0 || _activeControlIndex >= AllControls.Count)
    //     {
    //         return false;
    //     }
    //     return AllControls[_activeControlIndex] == this;
    // }

    // Require child classes to handle KeyInfo from console
    public abstract void HandleKeyInfo(ConsoleKeyInfo keyInfo);

} //ControlBase.cs
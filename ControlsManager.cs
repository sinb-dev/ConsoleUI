using System.Linq.Expressions;

namespace ConsoleUI;

public class ControlsManager
{
    public List<ControlBase> Controls = new();
    int _activeControlIndex = 0;
    // Gets the current active control, or null if there is no controls
    public ControlBase? GetActiveControl()
    {
        if (Controls.Count == 0)
        {
            return null;
        }
        return Controls[_activeControlIndex];
    }
    public void NextControl() => _activeControlIndex = ++_activeControlIndex >= Controls.Count ? 0 : _activeControlIndex;
    public void PreviousControl() => _activeControlIndex = --_activeControlIndex < 0 ? Controls.Count-1 : _activeControlIndex;
    public void AddControls(List<ControlBase> controls)
    {
        Controls.AddRange(controls);
    }

    // Checks if the control is active
    public bool IsActive(ControlBase control)
    {
        return GetActiveControl() == control;
    }
}
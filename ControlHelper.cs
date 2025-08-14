namespace ConsoleUI;

public class ControlHelper
{
    //This is where all the controls will be kept
    List<ControlBase> _controls = new();
    int _activeControlIndex = 0;
    
    // Gets the current active control, or null if there is no controls
    public ControlBase? GetActiveControl()
    {
        if (_controls.Count == 0)
        {
            return null;
        }
        return _controls[_activeControlIndex];
    }
    public void NextControl() => _activeControlIndex = ++_activeControlIndex >= _controls.Count ? 0 : _activeControlIndex;
    public void PreviousControl() => _activeControlIndex = --_activeControlIndex < 0 ? _controls.Count-1 : _activeControlIndex;
    public void AddControl(ControlBase control)
    {
        _controls.Add(control);
    }

    // Checks if the current instance is active
    public bool IsActive(ControlBase control)
    {
        if (_controls.Count == 0)
        {
            return false;
        }
        return _controls[_activeControlIndex] == control;
    }

    //Add possibility to clear controls, now that the list of control is private
    public void ClearControls()
    {
        _controls.Clear();
    }
} //ControlHelper.cs
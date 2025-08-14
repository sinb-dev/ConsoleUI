using ConsoleUI;

public interface IControlManager
{
    void NextControl();
    void PreviousControl();
    ControlBase? GetActiveControl();
} //IControlManager.cs
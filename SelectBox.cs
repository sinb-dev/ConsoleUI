namespace ConsoleUI;

public class SelectBox : ControlBase, IOverlayControl
{
    public class Option
    {
        public string Name { get; set; } = "";
        public object Value { get; set; } = "";
    }
    List<Option> _options = [new() { Name = "Option 1", Value = "value1"}, new() { Name = "Option 2", Value = "value2"}, new() { Name = "Option 3", Value = "value3"}];
    //Dictionary<string, object> _options = new() { { "Option 1", "value1" }, { "Option 2", "value2" }, { "Option 3", "value3" } } ;
    int defaultWidth = 20;
    string _selected = "";
    int _selectedIndex = 0;
    bool _showOptions = false;
    public SelectBox()
    {
    }
    void toggleShowOptions()
    {
        _showOptions = !_showOptions;
        if (_showOptions)
        {
            // foreach (KeyValuePair<string, object> option in _options)
            // {
            //     string active = " ";
            //     if (i++ == _selectedIndex)
            //     {
            //         active = ">";
            //     }
            //     options.AddChild(new Label(active + option.Key));
            // }
            
            Overlay.Set(this, Console.CursorLeft, Console.CursorTop + 1);
        }
    }
    public OverlayContainer BuildOverlay()
    {
        OverlayContainer optionsOverlay = new();
        int i = 0;
        foreach (Option option in _options)
        {
            string active = " ";
            if (i++ == _selectedIndex)
            {
                active = ">";
            }
            optionsOverlay.AddChild(new Button(active+option.Name));
        }
        return optionsOverlay;
    }
    
    public override (int Width, int Height) GetSize()
    {
        return (30,1);
    }

    public override void HandleKeyInfo(ConsoleKeyInfo keyInfo)
    {
        switch (keyInfo.Key)
        {
            case ConsoleKey.Enter:
                toggleShowOptions();
                break;
            case ConsoleKey.UpArrow:
                if (IsActive()) {
                    _selectedIndex = _selectedIndex > 0 ? _selectedIndex - 1 : _options.Count - 1;
                }
                break;
            case ConsoleKey.DownArrow:
                if (IsActive()) {
                    _selectedIndex = _selectedIndex < _options.Count-1 ? _selectedIndex + 1 : 0;
                }
                break;
        }
    }
    // KeyValuePair<string, object> getKeyValue() 
    // {
    //     int i = 0;
    //     foreach (KeyValuePair<string, object> kv in _options) 
    //     {
    //         if (i++ == _selectedIndex)
    //         {
    //             return kv;
    //         }
    //     }
    // }

    public override void Render()
    {
        Render(Console.BufferWidth, Console.BufferHeight);
    }

    public override void Render(int maxWidth, int maxHeight)
    {
        Console.BackgroundColor = IsActive() ? ConsoleColor.DarkYellow : ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.White;
        string content = _selected;
        if (content.Length > defaultWidth)
        {
            content.Substring(0, defaultWidth);
        } 
        else if (content.Length < defaultWidth)
        {
            content = content.PadRight(defaultWidth);
        }
        Console.Write(content);
    }
}
using ConsoleUI;

Console.CursorLeft = 1;
Console.CursorTop = 1;

ColumnContainer idColumn = new();
idColumn.AddChild(new Label("id", 50));
idColumn.AddChild(new Label("1", 50));
idColumn.AddChild(new Label("2", 50));
idColumn.AddChild(new Label("3", 50));
idColumn.AddChild(new Label("4", 50));
idColumn.AddChild(new TextBox("First name"));
ColumnContainer namesColumn = new();
namesColumn.AddChild(new Label("Name"));
namesColumn.AddChild(new Label("Konrad Sommer"));
namesColumn.AddChild(new Label("Anne Dam"));
namesColumn.AddChild(new Label("Remo Lademann"));
namesColumn.AddChild(new Label("Ella Stick"));
namesColumn.AddChild(new TextBox("Last name"));
namesColumn.AddChild(new Button("Save"));




RowContainer list = new();

list.AddChild(idColumn);
list.AddChild(namesColumn);

ConsoleKeyInfo keyInfo;
while (true)
{
    Console.CursorLeft = 0;
    Console.CursorTop = 0;
    list.Render();

    keyInfo = Console.ReadKey();

    switch(keyInfo.Key)
    {
        case ConsoleKey.Escape:
            break;
        case ConsoleKey.Tab:
            if (keyInfo.Modifiers == ConsoleModifiers.Shift)
                ControlBase.PreviousControl();
            else
                ControlBase.NextControl();
            break;
        default:
            ControlBase? activeControl = ControlBase.GetActiveControl();
            activeControl?.HandleKeyInfo(keyInfo);
            break;
    }
}
//Program.cs
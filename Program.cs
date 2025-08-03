using ConsoleUI;

Console.CursorLeft = 1;
Console.CursorTop = 1;
//Create some columns
ColumnContainer idColumn = new();
ColumnContainer namesColumn = new();
ColumnContainer actionColumn = new();
//Create some controls
TextBox txtId = new TextBox();
TextBox txtName = new TextBox();
Button btnSave = new Button("Save", AddPerson);
//Event handler as named function
void AddPerson()
{
    idColumn.AddChild(new Label(txtId.Content)); //Add label with textbox content
    namesColumn.AddChild(new Label(txtName.Content)); //Add name with textbox content
    txtId.Content = ""; // Clear textbox
    txtName.Content = ""; // Clear textbox
}
//Add some headers
idColumn.AddChild(new Label("id", 50));
namesColumn.AddChild(new Label("Name"));
actionColumn.AddChild(new Label("Actions"));

//Add the controls
idColumn.AddChild(txtId);
namesColumn.AddChild(txtName);
actionColumn.AddChild(btnSave);

RowContainer list = new();
list.AddChild(idColumn);
list.AddChild(namesColumn);
list.AddChild(actionColumn);

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
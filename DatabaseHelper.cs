using ConsoleUI.Pages;
using Microsoft.Data.SqlClient;

namespace ConsoleUI;

public class DatabaseHelper
{
    
    private SqlConnection getConnection()
    {
        SqlConnectionStringBuilder builder = new();
        builder.TrustServerCertificate = true;
        builder.InitialCatalog = "consoleui";
        builder.UserID = "sa";
        builder.Password = ""; //Put your password!
        builder.DataSource = "localhost";
        
        return new(builder.ToString());
    }
    private T? InstanceFromDB<T>(int element_id) where T : UIElement
    {
        T? element = null;
        using (SqlConnection conn = getConnection())
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT element_type FROM elements WHERE id=@id";
            cmd.Parameters.AddWithValue("@id", element_id);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string element_type = reader.GetString(0);
            try 
            {
                element = (T?) Activator.CreateInstance(typeof(T));
            }
            catch(Exception e)
            {
                Console.Write($"Failed creating element '{element_type}'");
                return default;
            }
            
        }
        if (element != null)
        {
            element?.LoadFromDB(element_id);
        }
        return element;
    }
    public UIElement? InstanceFromDB(string element_type, int element_id)
    {
        // WARNING: High coupling to element classes = BAD
        switch (element_type)
        {
            case "RowContainer":
                return InstanceFromDB<RowContainer>(element_id) ?? new();
            case "ColumnContainer":
                return InstanceFromDB<ColumnContainer>(element_id) ?? new();
            case "Button":
                return InstanceFromDB<Button>(element_id) ?? new();
            case "TextBox":
                return InstanceFromDB<TextBox>(element_id) ?? new();
            case "ListHostsPage":
                return InstanceFromDB<ListHostsPage>(element_id) ?? new();
            case "EditHostPage":
                return InstanceFromDB<EditHostPage>(element_id) ?? new();                
            case "Label":
                return InstanceFromDB<Label>(element_id) ?? new();
            default:
                return null;
        }
    }
    public object[] getDBRow(int id, string sql)
    {
        List<object[]> records = getDBRecords(id, sql);
        if (records.Count > 0)
        {
            return records[0];
        }
        return [0];
    }
    public List<object[]> getDBRecords(int id, string sql)
    {
        List<object[]> records = new();
        using (SqlConnection conn = getConnection())
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                object[] values = new object[reader.FieldCount];
                reader.GetValues(values);
                records.Add(values);
            }
        }
        return records;
    }
}
using System.Data.SQLite;


//ReadData(CreateConnection());
//InsertCustomer(CreateConnection());
DeleteCustomer(CreateConnection()); 
//FindCustomer(CreateConnection());
//DisplayProductWithCategory(CreateConnection());
//InsertCustomer(CreateConnection());


static SQLiteConnection CreateConnection()
{

    SQLiteConnection connection = new SQLiteConnection("Data Source=bar.db; Version = 3; New = True; Compress = True;");


    try
    {
        connection.Open();
        //Console.WriteLine("DB found.");
    }
    catch
    {
        Console.WriteLine("DB not found.");
    }
    return connection;


}
static void DisplayProductWithCategory(SQLiteConnection myConnection)
{
    
    SQLiteDataReader reader;
    SQLiteCommand command;

    command = myConnection.CreateCommand();
    command.CommandText = "SELECT product.rowid, product.ProductName, product.CategoryName FROM product" +
    "JOIN ProductCategory ON ProductCategory.CategoryName = Product.CategoryId";
    reader = command.ExecuteReader();

    while (reader.Read())
    {
        string readerRowid = reader["rowid"].ToString();
        string readerProductName = reader.GetString(1);
        string readerProductCategory = reader.GetString(2);
        

        Console.WriteLine($"{readerRowid}. {readerProductName}. Category: {readerProductCategory}");
    }

    myConnection.Close();
}


static void InsertCustomer(SQLiteConnection myConnection)
{
    SQLiteCommand command;
    string fName, lName;


    Console.WriteLine("First name:");
    fName = Console.ReadLine();

    Console.WriteLine("Last name:");
    lName = Console.ReadLine();


    command = myConnection.CreateCommand();
    command.CommandText = $" INSERT INTO Customer (firstName, lastName) " +
    $"VALUES ('{fName}', '{lName}')";

    int rowsInserted = command.ExecuteNonQuery();
    Console.WriteLine($"{rowsInserted} new row has been inserted.");




    (myConnection).Close();


}

static void DeleteCustomer(SQLiteConnection myConnection)
{
    SQLiteCommand command;

    string idToDelete;
    Console.WriteLine("Enter an id to delete:");
    idToDelete = Console.ReadLine();

    command = myConnection.CreateCommand();
    command.CommandText = $"DELETE FROM customer WHERE rowid = {idToDelete}";
    int rowRemoved = command.ExecuteNonQuery();
    Console.WriteLine($"{rowRemoved} was removed from the table customer.");

    (myConnection).Close;


}
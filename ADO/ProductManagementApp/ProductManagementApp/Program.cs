using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Spectre.Console;
namespace ProductManagementApp
{
    class Products
    {
        public void AddNewProduct(SqlConnection con)
        {

            SqlDataAdapter adp = new SqlDataAdapter("Select * from Product", con);
            DataSet ds = new DataSet();
            adp.Fill(ds, "ProductsTable");
            var row = ds.Tables["ProductsTable"].NewRow();
           
            Console.WriteLine("Enter Product Name:");
            row["ProdName"] = Convert.ToString(Console.ReadLine());
           
            Console.WriteLine("Enter Product Description:");
            row["ProdDescription"]= Convert.ToString(Console.ReadLine());
            
            Console.WriteLine("Enter Quantity: ");
            row["Quantity"]=Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Enter Price: ");
            row["Price"] = Convert.ToInt32(Console.ReadLine());
           
            ds.Tables["ProductsTable"].Rows.Add(row);
            SqlCommandBuilder cmd = new SqlCommandBuilder(adp);
            adp.Update(ds, "ProductsTable");
            Console.WriteLine("Product Added successfully");
        }
        public void GetProductID(SqlConnection con)
        {
            Console.WriteLine("Enter Product ID");
            int Id = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter adp = new SqlDataAdapter($"Select * from  Product where ProdId={Id}", con);
            DataSet ds = new DataSet();
            adp.Fill(ds, "ProdTable");
            for (int i = 0; i < ds.Tables["ProdTable"].Rows.Count; i++)
            {
                Console.WriteLine("ProdId | ProdName | ProdDescription | Quantity | Price ");
                for (int j = 0; j < ds.Tables["ProdTable"].Columns.Count; j++)
                {
                    Console.Write($"{ds.Tables["ProdTable"].Rows[i][j]} |");
                }
                Console.WriteLine();

            }
        }
        public void GetAllProduct(SqlConnection con)
        {

            SqlDataAdapter adp = new SqlDataAdapter("Select * from Product", con);
            DataSet ds = new DataSet();
            adp.Fill(ds, "ProdTable");
            for (int i = 0; i < ds.Tables["ProdTable"].Rows.Count; i++)
            {
                for (int j = 0; j < ds.Tables["ProdTable"].Columns.Count; j++)
                {
                    Console.Write($"{ds.Tables["ProdTable"].Rows[i][j]} |");
                }
                Console.WriteLine();
            }
        }
        public void UpdateProduct(SqlConnection con)
        {
            Console.WriteLine("Enter Product Id");
            int Id = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter adp = new SqlDataAdapter($"select * from Product where ProdId={Id}", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            var row = ds.Tables[0].Rows[0];
            
            Console.WriteLine("Enter Product Name for update: ");
            row["ProdName"] = Convert.ToString(Console.ReadLine());
           
            Console.WriteLine("Enter Product description for update: ");
            row["ProdDescription"] = Convert.ToString(Console.ReadLine());
           
            Console.WriteLine("Enter Quantity: ");
            row["Quantity"] = Convert.ToInt32(Console.ReadLine());
  
            Console.WriteLine("Enter Price: ");
            row["Price"] = Convert.ToInt32(Console.ReadLine());
            SqlCommandBuilder cmd = new SqlCommandBuilder(adp);
            adp.Update(ds);
            Console.WriteLine("Product Updated Successfully ");
        }
        public void DeleteProduct(SqlConnection con)
        {
            Console.WriteLine("Enter the Product id");
            int Id = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter adp = new SqlDataAdapter($"select * from Product where ProdId = {Id}", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            ds.Tables[0].Rows[0].Delete();
            SqlCommandBuilder cmd = new SqlCommandBuilder(adp);
            adp.Update(ds);
            Console.WriteLine("Product Deleted Successfully!");
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                
                Products obj = new Products();
                while (true)
                {
         
                    SqlConnection con = new SqlConnection("Server=IN-2HRQ8S3; database=ProductManagementApp; Integrated Security=true");
                    AnsiConsole.MarkupLine("[bold green]****Welcome To Product Management App****[/]");
                    AnsiConsole.MarkupLine("[bold yellow]1  Add New Product[/]");
                    AnsiConsole.MarkupLine("[bold yellow]2  Get Product by Id[/]");
                    AnsiConsole.MarkupLine("[bold yellow]3  Get All Product[/]");
                    AnsiConsole.MarkupLine("[bold yellow]4  Update Product[/]");
                    AnsiConsole.MarkupLine("[bold yellow]5  Delete Product[/]");
                    try
                    {
                        AnsiConsole.MarkupLine("[bold red]Enter your choice[/]");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                {
                                    obj.AddNewProduct(con);
                                    break;
                                }
                            case 2:
                                {
                                    obj.GetProductID(con);
                                    break;
                                }
                            case 3:
                                {
                                    obj.GetAllProduct(con);
                                    break;
                                }
                            case 4:
                                {
                                    obj.UpdateProduct(con);
                                    break;
                                }
                            case 5:
                                {
                                    obj.DeleteProduct(con);
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Enter a valid option");
                                    break;
                                }
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Enter Numbers Only From 1 to 5");
                    }
                }
            }


        }
    }
}

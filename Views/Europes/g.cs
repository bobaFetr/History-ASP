// using System;
// using System.Data.SqlClient;

// class Program
// {
//     static void Main()
//     {
//         string connectionString = "Server=yourserver;Database=yourdatabase;Trusted_Connection=True;";
        
//         using (SqlConnection connection = new SqlConnection(connectionString))
//         {
//             try
//             {
//                 connection.Open();
//                 Console.WriteLine("Connection successful!");
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"Connection failed: {ex.Message}");
//             }
//         }
//     }
// }
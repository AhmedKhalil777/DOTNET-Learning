using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccessTester
{

    public class ConnectionConfigs
    {
        public List<string> Connections { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("===================================================");
                    Console.WriteLine("===================================================");
                    Parallel.For(0, 1000, s => {
                        var conStr = "Password=Iskra1234;Persist Security Info=True;User ID=DBO;Data Source=BVT_Local;";
                var con = new OracleConnection(conStr);
                        con.Open();
                       // Console.WriteLine("Openned");
                        var trans = con.BeginTransaction();
                        con.Close();
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
               // Console.ReadLine();
            }

            var json= File.ReadAllText("./appSettings.json");
            var configs = JsonSerializer.Deserialize<ConnectionConfigs>(json);

            var enumrator = new OracleDataSourceEnumerator().GetDataSources();

            for (int i = 0; i < enumrator.DefaultView.Table.Rows.Count; i++)
            {
                Console.WriteLine("===================== Data Source ===========================================");

                for (int j = 0; j < enumrator.DefaultView[i].Row.ItemArray.Length; j++)
                {
                    Console.WriteLine(enumrator.DefaultView[i].Row[j]);

                }
                if (configs.Connections.Any(x => x.IndexOf(enumrator.DefaultView[i].Row[0].ToString(), StringComparison.OrdinalIgnoreCase) > 0))
                {
                    var connStr = configs.Connections.First(x => x.IndexOf(enumrator.DefaultView[i].Row[0].ToString(), StringComparison.OrdinalIgnoreCase) > 0);
                    Console.WriteLine("==================Trying To Connect=====================");
                    try
                    {
                        var props = connStr.Split(';');
                        var neededProps = props.Where(x => !x.StartsWith("Provider") && !x.StartsWith("Persist Security Info"));
                        connStr = string.Join(";", neededProps.ToArray());
                        var conn = new OracleConnection(connStr);
                       
                        conn.Open();
                        Console.WriteLine("Connection Opened Successfully ");
                        conn.Close();
                        conn.Dispose();
                        Console.WriteLine("Disconnected");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);

                    }

                }
            }
            Console.ReadKey();
        }
       
    }
}

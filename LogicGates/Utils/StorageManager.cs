using LogicGates.Gates;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LogicGates.Utils
{
    public class StorageManager
    {
        string connectionString;

        public StorageManager()
        {
            connectionString = @"Data Source=DESKTOP-SVHD06S\MSSQLSERVER01;Initial Catalog=Gates;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public void Save(string name, XmlDocument xml)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();

            string query = $"INSERT INTO GatesTable (Name, Author, Gate) VALUES ('{name}', 'Matthew', '{xml.OuterXml}')";
            var command = new SqlCommand(query, cnn);
            var adapter = new SqlDataAdapter();

            adapter.InsertCommand = new SqlCommand(query, cnn);
            adapter.InsertCommand.ExecuteNonQuery();

            command.Dispose();
            cnn.Close();

            LoadGatesFromDB();
        }

        public List<CircuitBase> LoadGatesFromDB()
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();

            var gates = new List<CircuitBase>();

            var query = "SELECT * FROM GatesTable";
            var command = new SqlCommand(query, cnn);

            var dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                int inputCount = 0;
                string name = dataReader.GetValue(0) as string;
                SqlXml doc = dataReader.GetSqlXml(2);
                var docReader = doc.CreateReader();
                docReader.MoveToContent();
                var res = new ResultTable();

                while (docReader.Read())
                {
                    if(docReader.NodeType == XmlNodeType.Element)
                    {
                        string elementName = docReader.LocalName;
                        if(elementName == "Circuit")
                        {
                            docReader.Read();
                            elementName = docReader.LocalName;
                        } else if (elementName == "InputCount")
                        {
                            docReader.Read();
                            inputCount = Convert.ToInt32(docReader.Value);
                        } else if(elementName == "Case")
                        {
                            docReader.Read();
                            docReader.Read();
                            int input = Convert.ToInt32(docReader.Value);
                            docReader.Read();
                            docReader.Read();
                            docReader.Read();
                            int output = Convert.ToInt32(docReader.Value);
                            res.Results.Add(input, output);
                        }
                    }
                }
                var gate = new CustomCircuit(Convert.ToInt32(inputCount));
                gate.Name = name;
                
                gate.SetPrecalculatedTable(name, res);
                gates.Add(gate);
            }

            command.Dispose();
            cnn.Close();

            return gates;
        }
    }
}

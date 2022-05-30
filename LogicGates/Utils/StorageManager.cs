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
        SqlConnection cnn;

        public StorageManager()
        {
            connectionString = @"Data Source=DESKTOP-SVHD06S\MSSQLSERVER01;Initial Catalog=Gates;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
        }

        public void CloseConnection()
        {
            cnn.Close();
        }

        public void Save(string name, XmlDocument xml)
        {
            

            string query = $"INSERT INTO GatesTable (Name, Author, Gate) VALUES ('{name}', 'Matthew', '{xml.OuterXml}')";
            var command = new SqlCommand(query, cnn);
            var adapter = new SqlDataAdapter();

            adapter.InsertCommand = new SqlCommand(query, cnn);
            try
            {
                adapter.InsertCommand.ExecuteNonQuery();
            } catch (Exception)
            {

            }
            
            command.Dispose();
        }

        public void Delete(string name)
        {
            string query = $"DELETE FROM GatesTable WHERE Name = '{name}'";
            var command = new SqlCommand(query, cnn);
            var adapter = new SqlDataAdapter();

            adapter.InsertCommand = new SqlCommand(query, cnn);
            try
            {
                adapter.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }


            command.Dispose();
        }

        public List<CircuitBase> LoadGatesFromDB()
        {

            var gates = new List<CircuitBase>();

            var query = "SELECT * FROM GatesTable";
            var command = new SqlCommand(query, cnn);

            var dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                int inputCount = 0;
                int OutputCount = 0;
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
                        if (elementName == "InputCount")
                        {
                            docReader.Read();
                            inputCount = Convert.ToInt32(docReader.Value);
                        }
                        if (elementName == "OutputCount")
                        {
                            docReader.Read();
                            OutputCount = Convert.ToInt32(docReader.Value);
                        }
                    }
                }
                var gate = new CustomCircuit(Convert.ToInt32(inputCount), Convert.ToInt32(OutputCount));
                gate.Name = name;

                gates.Add(gate);
            }

            command.Dispose();
            dataReader.Close();

            return gates;
        }

        public ResultTable GetPrecalcTable(string name)
        {
            var res = new ResultTable();

            var gates = new List<CircuitBase>();

            var query = "SELECT * FROM GatesTable";
            var command = new SqlCommand(query, cnn);

            var dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                int inputCount = 0;
                int outputCount = 0;
                if (dataReader.GetValue(0).ToString() != name)
                {
                    continue;
                }
                SqlXml doc = dataReader.GetSqlXml(2);
                var docReader = doc.CreateReader();
                docReader.MoveToContent();

                while (docReader.Read())
                {
                    if (docReader.NodeType == XmlNodeType.Element)
                    {
                        string elementName = docReader.LocalName;
                        if (elementName == "Circuit")
                        {
                            docReader.Read();
                            elementName = docReader.LocalName;
                        }
                        else if (elementName == "InputCount")
                        {
                            docReader.Read();
                            inputCount = Convert.ToInt32(docReader.Value);
                        }
                        else if (elementName == "OutputCount")
                        {
                            docReader.Read();
                            outputCount = Convert.ToInt32(docReader.Value);
                        }
                        else if (elementName == "Case")
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
            }

            
            command.Dispose();
            dataReader.Close();
            return res;
        }
    }
}

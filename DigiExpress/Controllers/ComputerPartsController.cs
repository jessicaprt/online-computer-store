﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using DigiExpress.Models;

namespace DigiExpress.Controllers
{
    public class ComputerPartsController
    {
        public static List<ComputerParts> GetLaptopPart(SqlConnection connection, string typeName)
        {

            List<ComputerParts> parts = new List<ComputerParts>();

            string query = $"SELECT * FROM dbo.de_parts where typename = '{typeName}'";

            SqlCommand command = new SqlCommand(query, connection);


            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ComputerParts curr = new ComputerParts();

                        curr.TypeName = reader.GetString(0);
                        curr.Id = reader.GetInt32(1);
                        curr.PartName = reader.GetString(2);
                        curr.ShortName = reader.GetString(3);
                        curr.Price = reader.GetInt32(4);

                        parts.Add(curr);
                    }
                }
            }
                

            return parts;

        }
    }
}
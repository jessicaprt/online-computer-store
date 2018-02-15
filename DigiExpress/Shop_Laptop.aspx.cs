using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DigiExpress.Controllers;
using DigiExpress.Models;

namespace DigiExpress
{
    public partial class Shop_Laptop : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection connection = DatabaseUtils.CreateConnection();
            connection.Open();

            ScreenSize.Items.Clear();
            Processor.Items.Clear();
            RamSize.Items.Clear();
            SsdCapacity.Items.Clear();

            LoadScreenSizes(connection);
            LoadProcessors(connection);
            LoadRam(connection);
            LoadSsd(connection);
            
            connection.Close();
        }

        public void LoadScreenSizes(SqlConnection connection)
        {

            string screenSizeQuery = "SELECT * FROM dbo.de_parts where typename = 'screen'";
            List<LaptopParts> screenSizes = LaptopPartsController.GetLaptopPart(connection, screenSizeQuery);

            foreach (var screenSize in screenSizes)
            {
                ScreenSize.Items.Add(
                    new ListItem(
                        screenSize.PartName,
                        screenSize.ShortName));
            }
        }

        public void LoadProcessors(SqlConnection connection)
        {

            string processorQuery = "SELECT * FROM dbo.de_parts where typename = 'processor'";
            List<LaptopParts> processors = LaptopPartsController.GetLaptopPart(connection, processorQuery);

            foreach (var processor in processors)
            {
                Processor.Items.Add(
                    new ListItem(
                        processor.PartName,
                        processor.ShortName));
            }
        }

        public void LoadRam(SqlConnection connection)
        {

            string ramQuery = "SELECT * FROM dbo.de_parts where typename = 'ram'";
            List<LaptopParts> rams = LaptopPartsController.GetLaptopPart(connection, ramQuery);

            foreach (var ram in rams)
            {
                RamSize.Items.Add(
                    new ListItem(
                        ram.PartName,
                        ram.ShortName));
            }
        }

        public void LoadSsd(SqlConnection connection)
        {

            string ssdQuery = "SELECT * FROM dbo.de_parts where typename = 'ssd'";
            List<LaptopParts> ssds = LaptopPartsController.GetLaptopPart(connection, ssdQuery);

            foreach (var ssd in ssds)
            {
                SsdCapacity.Items.Add(
                    new ListItem(
                        ssd.PartName,
                        ssd.ShortName));
            }
        }

    }
}
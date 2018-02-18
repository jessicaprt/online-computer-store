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
            OperatingSystem.Items.Clear();

            LoadScreenSizes(connection);
            LoadProcessors(connection);
            LoadRam(connection);
            LoadSsd(connection);
            LoadOs(connection);
                        
            connection.Close();
        }

        public void LoadScreenSizes(SqlConnection connection)
        {

            string screenSizeQuery = "SELECT * FROM dbo.de_parts where typename = 'screen'";
            List<ComputerParts> screenSizes = ComputerPartsController.GetLaptopPart(connection, screenSizeQuery);

            foreach (var screenSize in screenSizes)
            {
                ScreenSize.Items.Add(
                    new ListItem(
                        screenSize.PartName,
                        screenSize.Price.ToString()));
            }
        }

        public void LoadProcessors(SqlConnection connection)
        {

            string processorQuery = "SELECT * FROM dbo.de_parts where typename = 'processor'";
            List<ComputerParts> processors = ComputerPartsController.GetLaptopPart(connection, processorQuery);

            foreach (var processor in processors)
            {
                Processor.Items.Add(
                    new ListItem(
                        processor.PartName,
                        processor.Price.ToString()));
            }
        }

        public void LoadRam(SqlConnection connection)
        {

            string ramQuery = "SELECT * FROM dbo.de_parts where typename = 'ram'";
            List<ComputerParts> rams = ComputerPartsController.GetLaptopPart(connection, ramQuery);

            foreach (var ram in rams)
            {
                RamSize.Items.Add(
                    new ListItem(
                        ram.PartName,
                        ram.Price.ToString()));
            }
        }

        public void LoadSsd(SqlConnection connection)
        {

            string ssdQuery = "SELECT * FROM dbo.de_parts where typename = 'ssd'";
            List<ComputerParts> ssds = ComputerPartsController.GetLaptopPart(connection, ssdQuery);

            foreach (var ssd in ssds)
            {
                SsdCapacity.Items.Add(
                    new ListItem(
                        ssd.PartName,
                        ssd.Price.ToString()));
            }
        }

        public void LoadOs(SqlConnection connection)
        {
            string ssdQuery = "SELECT * FROM dbo.de_parts where typename = 'os'";
            List<ComputerParts> osi = ComputerPartsController.GetLaptopPart(connection, ssdQuery);

            foreach (var os in osi)
            {
                OperatingSystem.Items.Add(
                    new ListItem(
                        os.PartName,
                        os.Price.ToString()));
            }
        }

        public void CalculateTotal(object sender, EventArgs e)
        {
            int total = int.Parse(ScreenSize.SelectedValue) +
                        int.Parse(Processor.SelectedValue) +
                        int.Parse(RamSize.SelectedValue) +
                        int.Parse(SsdCapacity.SelectedValue) +
                        int.Parse(OperatingSystem.SelectedValue);

            TotalPrice.Text = $"${total}.00";
        }

        public void CalculateTotal()
        {
            int total = int.Parse(ScreenSize.SelectedValue) +
                        int.Parse(Processor.SelectedValue) +
                        int.Parse(RamSize.SelectedValue) +
                        int.Parse(SsdCapacity.SelectedValue) +
                        int.Parse(OperatingSystem.SelectedValue);

            TotalPrice.Text = $"${total}.00";
        }

    }
}
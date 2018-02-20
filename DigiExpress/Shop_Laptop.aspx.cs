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
        private List<ComputerParts> _screenSizes;
        private List<ComputerParts> _processors;
        private List<ComputerParts> _rams;
        private List<ComputerParts> _ssds;
        private List<ComputerParts> _osi;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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
                CalculateTotal();
                connection.Close();
            }
        }

        public void LoadScreenSizes(SqlConnection connection)
        {

            string screenSizeQuery = "SELECT * FROM dbo.de_parts where typename = 'screen'";
            _screenSizes = ComputerPartsController.GetLaptopPart(connection, screenSizeQuery);

            foreach (var screenSize in _screenSizes)
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
            _processors = ComputerPartsController.GetLaptopPart(connection, processorQuery);

            foreach (var processor in _processors)
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
            _rams = ComputerPartsController.GetLaptopPart(connection, ramQuery);

            foreach (var ram in _rams)
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
            _ssds = ComputerPartsController.GetLaptopPart(connection, ssdQuery);

            foreach (var ssd in _ssds)
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
            _osi = ComputerPartsController.GetLaptopPart(connection, ssdQuery);

            foreach (var os in _osi)
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

        protected void AddToCart(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
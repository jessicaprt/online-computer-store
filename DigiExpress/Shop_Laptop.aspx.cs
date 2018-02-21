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
    public partial class ShopLaptop : Page
    {
        private List<ComputerParts> _screenSizes;
        private List<ComputerParts> _processors;
        private List<ComputerParts> _rams;
        private List<ComputerParts> _ssds;
        private List<ComputerParts> _osi;

        private int _total;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Context.User.Identity.Name == "")
            {
                Response.Redirect("~/Account/Login.aspx", true);
            }

            var connection = DatabaseUtils.CreateConnection();
            connection.Open();

            LoadComputerParts(connection);

            if (!Page.IsPostBack)
            {
                LoadComputerParts(connection);
                ScreenSize.Items.Clear();
                Processor.Items.Clear();
                RamSize.Items.Clear();
                SsdCapacity.Items.Clear();
                OperatingSystem.Items.Clear();

                LoadScreenSizes();
                LoadProcessors();
                LoadRam();
                LoadSsd();
                LoadOs();
                CalculateTotal();
            }
            connection.Close();
        }

        public void LoadComputerParts(SqlConnection connection)
        {
            _screenSizes = ComputerPartsController.GetLaptopPart(connection, "screen");
            _processors = ComputerPartsController.GetLaptopPart(connection, "processor");
            _rams = ComputerPartsController.GetLaptopPart(connection, "ram");
            _ssds = ComputerPartsController.GetLaptopPart(connection, "ssd");
            _osi = ComputerPartsController.GetLaptopPart(connection, "os");
        }

        public void LoadScreenSizes()
        {
            foreach (var screenSize in _screenSizes)
            {
                ScreenSize.Items.Add(
                    new ListItem(
                        screenSize.PartName,
                        screenSize.Price.ToString()));
            }
        }

        public void LoadProcessors()
        {
            foreach (var processor in _processors)
            {
                Processor.Items.Add(
                    new ListItem(
                        processor.PartName,
                        processor.Price.ToString()));
            }
        }

        public void LoadRam()
        {
            foreach (var ram in _rams)
            {
                RamSize.Items.Add(
                    new ListItem(
                        ram.PartName,
                        ram.Price.ToString()));
            }
        }

        public void LoadSsd()
        {
            foreach (var ssd in _ssds)
            {
                SsdCapacity.Items.Add(
                    new ListItem(
                        ssd.PartName,
                        ssd.Price.ToString()));
            }
        }

        public void LoadOs()
        {
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
            _total = int.Parse(ScreenSize.SelectedValue) +
                        int.Parse(Processor.SelectedValue) +
                        int.Parse(RamSize.SelectedValue) +
                        int.Parse(SsdCapacity.SelectedValue) +
                        int.Parse(OperatingSystem.SelectedValue);

            TotalPrice.Text = $"${_total}.00";
        }

        protected void AddToCart(object sender, EventArgs e)
        {
            var laptop = new Laptop();

            laptop.ComputerType = "laptop";
            laptop.Id = LaptopController.GetLaptopCount() + 1;
            laptop.UserId = UserController.GetUserIdByName(Context.User.Identity.Name);
            laptop.UserName = Context.User.Identity.Name;

            laptop.Part1 = _screenSizes
                .Where(s => s.Price == int.Parse(ScreenSize.SelectedValue))
                .Select(s => s.ShortName)
                .First();

            laptop.Part2 = _processors
                .Where(s => s.Price == int.Parse(Processor.SelectedValue))
                .Select(s => s.ShortName)
                .First();

            laptop.Part3 = _rams
                .Where(s => s.Price == int.Parse(RamSize.SelectedValue))
                .Select(s => s.ShortName)
                .First();

            laptop.Part4 = _ssds
                .Where(s => s.Price == int.Parse(SsdCapacity.SelectedValue))
                .Select(s => s.ShortName)
                .First();

            laptop.Part5 = _osi
                .Where(s => s.Price == int.Parse(OperatingSystem.SelectedValue))
                .Select(s => s.ShortName)
                .First();

            LaptopController.AddLaptop(laptop);

            var newCartItem = new CartItem();

            newCartItem.UserName = Context.User.Identity.Name;
            newCartItem.TypeName = "laptop";
            newCartItem.ComputerId = laptop.Id;

            CartController.AddToCart(newCartItem);

            Response.Redirect("~/Cart.aspx", true);
        }
    }
}
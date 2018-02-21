using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DigiExpress.Controllers;
using DigiExpress.Models;

namespace DigiExpress
{
    public partial class ShopDesktop : Page
    {
        private List<ComputerParts> _videoCards;
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
                VideoCard.Items.Clear();
                Processor.Items.Clear();
                RamSize.Items.Clear();
                SsdCapacity.Items.Clear();
                OperatingSystem.Items.Clear();

                LoadVideoCards();
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
            _videoCards = ComputerPartsController.GetComputerPart(connection, "videocard");
            _processors = ComputerPartsController.GetComputerPart(connection, "processor");
            _rams = ComputerPartsController.GetComputerPart(connection, "ram");
            _ssds = ComputerPartsController.GetComputerPart(connection, "ssd");
            _osi = ComputerPartsController.GetComputerPart(connection, "os");
        }

        public void LoadVideoCards()
        {
            foreach (var videoCard in _videoCards)
            {
                VideoCard.Items.Add(
                    new ListItem(
                        videoCard.PartName,
                        videoCard.Price.ToString()));
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
            _total = int.Parse(VideoCard.SelectedValue) +
                        int.Parse(Processor.SelectedValue) +
                        int.Parse(RamSize.SelectedValue) +
                        int.Parse(SsdCapacity.SelectedValue) +
                        int.Parse(OperatingSystem.SelectedValue);

            TotalPrice.Text = $"${_total}.00";
        }

        public int CalculateTotal()
        {
            _total = int.Parse(VideoCard.SelectedValue) +
                        int.Parse(Processor.SelectedValue) +
                        int.Parse(RamSize.SelectedValue) +
                        int.Parse(SsdCapacity.SelectedValue) +
                        int.Parse(OperatingSystem.SelectedValue);

            TotalPrice.Text = $"${_total}.00";
            return _total;
        }

        protected void AddToCart(object sender, EventArgs e)
        {
            var desktop = new Computer();

            desktop.ComputerType = "desktop";
            desktop.Id = ComputerController.GetComputerCount() + 1;
            desktop.UserId = UserController.GetUserIdByName(Context.User.Identity.Name);
            desktop.UserName = Context.User.Identity.Name;

            desktop.Part1 = _videoCards
                .Where(s => s.Price == int.Parse(VideoCard.SelectedValue))
                .Select(s => s.ShortName)
                .First();

            desktop.Part2 = _processors
                .Where(s => s.Price == int.Parse(Processor.SelectedValue))
                .Select(s => s.ShortName)
                .First();

            desktop.Part3 = _rams
                .Where(s => s.Price == int.Parse(RamSize.SelectedValue))
                .Select(s => s.ShortName)
                .First();

            desktop.Part4 = _ssds
                .Where(s => s.Price == int.Parse(SsdCapacity.SelectedValue))
                .Select(s => s.ShortName)
                .First();

            desktop.Part5 = _osi
                .Where(s => s.Price == int.Parse(OperatingSystem.SelectedValue))
                .Select(s => s.ShortName)
                .First();

            ComputerController.AddComputer(desktop);

            var newCartItem = new CartItem();

            newCartItem.UserName = Context.User.Identity.Name;
            newCartItem.TypeName = "desktop";
            newCartItem.ComputerId = desktop.Id;
            newCartItem.Price = CalculateTotal();

            CartController.AddToCart(newCartItem);

            Response.Redirect("~/Cart.aspx", true);
        }
    }
}
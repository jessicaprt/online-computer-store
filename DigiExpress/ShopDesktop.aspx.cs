﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigiExpress
{
    public partial class ShopDesktop : Page
    {
        private int _total;
        private Dictionary<string, int> _videoCard;
        private Dictionary<string, int> _processors;
        private Dictionary<string, int> _rams;
        private Dictionary<string, int> _ssds;
        private Dictionary<string, int> _os;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetParts();
                LoadParts();
                CalculateTotal();
            }
        }

        private void GetParts()
        {
            _videoCard = new Dictionary<string, int>();
            _processors = new Dictionary<string, int>();
            _rams = new Dictionary<string, int>();
            _ssds = new Dictionary<string, int>();
            _os = new Dictionary<string, int>();

            _videoCard.Add("GTX 970", 100);
            _videoCard.Add("GTX 1070", 120);
            _videoCard.Add("GTX 1080", 140);
            _videoCard.Add("GTX 1080 TI", 180);
            _processors.Add("Intel Core i3", 200);
            _processors.Add("Intel Core i5", 300);
            _processors.Add("Intel Core i7", 500);
            _rams.Add("4GB RAM", 150);
            _rams.Add("8GB RAM", 200);
            _rams.Add("16GB RAM", 250);
            _rams.Add("32GB RAM", 300);
            _ssds.Add("256GB SSD", 200);
            _ssds.Add("512GB SSD", 300);
            _ssds.Add("1TB SSD", 500);
            _os.Add("Linux", 30);
            _os.Add("Widows 10", 50);
            _os.Add("Mac OSX", 90);
        }

        protected void LoadParts()
        {
            VideoCard.Items.Clear();
            Processor.Items.Clear();
            RamSize.Items.Clear();
            SsdCapacity.Items.Clear();
            OperatingSystem.Items.Clear();

            foreach (var i in _videoCard)
                VideoCard.Items.Add(
                    new ListItem(
                        i.Key,
                        i.Value.ToString()));

            foreach (var i in _processors)
                Processor.Items.Add(
                    new ListItem(
                        i.Key,
                        i.Value.ToString()));

            foreach (var i in _rams)
                RamSize.Items.Add(
                    new ListItem(
                        i.Key,
                        i.Value.ToString()));

            foreach (var i in _ssds)
                SsdCapacity.Items.Add(
                    new ListItem(
                        i.Key,
                        i.Value.ToString()));

            foreach (var i in _os)
                OperatingSystem.Items.Add(
                    new ListItem(
                        i.Key,
                        i.Value.ToString()));

        }

        protected void CalculateTotal(object sender, EventArgs e)
        {
            _total = int.Parse(VideoCard.SelectedValue) +
                     int.Parse(Processor.SelectedValue) +
                     int.Parse(RamSize.SelectedValue) +
                     int.Parse(SsdCapacity.SelectedValue) +
                     int.Parse(OperatingSystem.SelectedValue);

            TotalPrice.Text = $"${_total}.00";
        }

        private void CalculateTotal()
        {
            _total = int.Parse(VideoCard.SelectedValue) +
                     int.Parse(Processor.SelectedValue) +
                     int.Parse(RamSize.SelectedValue) +
                     int.Parse(SsdCapacity.SelectedValue) +
                     int.Parse(OperatingSystem.SelectedValue);

            TotalPrice.Text = $"${_total}.00";
        }

        protected void AddToCart(object sender, EventArgs e)
        {
            GetParts();
            CalculateTotal();

            Session["computer"] = "desktop";
            Session["part1"] = _videoCard.Keys.ElementAt(VideoCard.SelectedIndex);
            Session["part2"] = _processors.Keys.ElementAt(Processor.SelectedIndex);
            Session["part3"] = _rams.Keys.ElementAt(RamSize.SelectedIndex);
            Session["part4"] = _ssds.Keys.ElementAt(SsdCapacity.SelectedIndex);
            Session["part5"] = _os.Keys.ElementAt(OperatingSystem.SelectedIndex);
            Session["price"] = _total;
            Response.Redirect("Cart.aspx");
        }
    }
}
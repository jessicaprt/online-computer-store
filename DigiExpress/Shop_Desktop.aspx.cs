using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigiExpress
{
    public partial class Shop_Desktop : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VideoCard.Items.Clear();
            Processor.Items.Clear();
            RamSize.Items.Clear();
            SsdCapacity.Items.Clear();
            OperatingSystem.Items.Clear();

            VideoCard.Items.Add(
                new ListItem(
                    "GTX 970",
                    "970"));

            VideoCard.Items.Add(
                new ListItem(
                    "GTX 1070",
                    "1070"));

            VideoCard.Items.Add(
                new ListItem(
                    "GTX 1080",
                    "1080"));

            VideoCard.Items.Add(
                new ListItem(
                    "GTX 1080 TI",
                    "1080 TI"));

            Processor.Items.Add(
                new ListItem(
                    "Intel Core i3",
                    "i3"
                    ));

            Processor.Items.Add(
                new ListItem(
                    "Intel Core i5",
                    "i5"
                ));

            Processor.Items.Add(
                new ListItem(
                    "Intel Core i7",
                    "i7"
                ));

            RamSize.Items.Add(
                new ListItem(
                    "4GB RAM",
                    "4GB"));

            RamSize.Items.Add(
                new ListItem(
                    "8GB RAM",
                    "8GB"));

            RamSize.Items.Add(
                new ListItem(
                    "16GB RAM",
                    "16GB"));

            RamSize.Items.Add(
                new ListItem(
                    "32GB RAM",
                    "32GB"));

            SsdCapacity.Items.Add(
                new ListItem(
                    "256GB SSD",
                    "256GB"));

            SsdCapacity.Items.Add(
                new ListItem(
                    "512GB SSD",
                    "512GB"));

            SsdCapacity.Items.Add(
                new ListItem(
                    "1TB SSD",
                    "1TB"));

            OperatingSystem.Items.Add(
                new ListItem(
                    "Windows 10",
                    "Windows"));

            OperatingSystem.Items.Add(
                new ListItem(
                    "Mac OSX",
                    "Mac"));

            OperatingSystem.Items.Add(
                new ListItem(
                    "Linux",
                    "Linux"));

        }
    }
}
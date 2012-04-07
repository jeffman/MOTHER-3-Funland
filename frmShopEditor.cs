using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MOTHER3;
using Extensions;

namespace MOTHER3Funland
{
    public partial class frmShopEditor : M3Form
    {
        bool loading = true;

        // Tab stuff
        TabPage[] tabPage = new TabPage[3];

        // Item stuff
        LinkLabel[] lblItem = new LinkLabel[30];
        ComboBox[] cboItem = new ComboBox[30];
        
        // Text cache
        string[] itemNames = new string[TextItemNames.Entries];

        public frmShopEditor()
        {
            InitializeComponent();

            // Load item names
            for (int i = 0; i < itemNames.Length; i++)
                itemNames[i] = TextItemNames.GetName(i);

            // Draw the tab stuff
            for (int i = 0; i < 3; i++)
            {
                tabPage[i] = new TabPage("Page " + (i + 1).ToString());
                tabPage[i].Padding = new System.Windows.Forms.Padding(3);
                tabPage[i].UseVisualStyleBackColor = true;
                tabPage[i].TabIndex = i;

                tabMain.TabPages.Add(tabPage[i]);

                // Draw the item stuff
                for (int j = 0; j < 10; j++)
                {
                    LinkLabel ll = new LinkLabel();

                    ll.AutoSize = true;
                    ll.Text = "Item " + ((i * 10) + j + 1).ToString();
                    ll.Left = 6;
                    ll.Top = (j * 27) + 10;
                    ll.Tag = ((i * 10) + j);

                    ll.LinkClicked += (s, e) =>
                    {
                        LinkLabel l = s as LinkLabel;
                        int index = (int)l.Tag;

                        ModuleArbiter.ShowSelect(typeof(frmItemEditor), cboItem[index].SelectedIndex);
                    };

                    tabPage[i].Controls.Add(ll);
                    lblItem[(i * 10) + j] = ll;

                    ComboBox c = new ComboBox();

                    Helpers.CheckFont(c);

                    for (int k = 0; k < itemNames.Length; k++)
                        c.Items.Add("[" + k.ToString("X2") + "] " + itemNames[k]);

                    c.Width = 160;
                    c.DropDownStyle = ComboBoxStyle.DropDownList;
                    c.Left = ll.Left + 50;
                    c.Top = ll.Top - 3;

                    tabPage[i].Controls.Add(c);
                    cboItem[(i * 10) + j] = c;
                }
            }

            // Load the shop data
            ShopData.Init();
            string[] shopNames = Properties.Resources.shopnames.SplitN();
            loading = true;
            for (int i = 0; i < ShopData.Entries; i++)
                cboShop.Items.Add("[" + i.ToString("X2") + "] " + shopNames[i]);
            loading = false;
            cboShop.SelectedIndex = 0;
        }

        private void cboShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            int index = cboShop.SelectedIndex;
            ShopData sd = ShopData.Shops[index];

            for (int i = 0; i < 30; i++)
                cboItem[i].SelectedIndex = sd.Items[i];
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ShopData sd = ShopData.Shops[cboShop.SelectedIndex];

            for (int i = 0; i < 30; i++)
                sd.Items[i] = (ushort)cboItem[i].SelectedIndex;

            sd.Save();

            cboShop_SelectedIndexChanged(null, null);
        }

        public override void SelectIndex(int[] index)
        {
            cboShop.SelectedIndex = index[0];
        }

        public override int[] GetIndex()
        {
            return new int[] { cboShop.SelectedIndex }; ;
        }
    }
}

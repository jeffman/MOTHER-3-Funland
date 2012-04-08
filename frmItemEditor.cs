using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Extensions;
using MOTHER3;

namespace MOTHER3Funland
{
    public partial class frmItemEditor : M3Form
    {
        bool loading = false;

        // Ailment stuff
        Label[] lblAilment = new Label[11];
        TextBox[] txtAilment = new TextBox[11];

        // PSI stuff
        Label[] lblPsi = new Label[5];
        TextBox[] txtPsi = new TextBox[5];

        // Equipper stuff
        CheckBox[] chkEquip = new CheckBox[8];

        string[] itemNames = new string[TextItemNames.Entries];
        string[] itemTypes = null;
        string[] equippers = null;

        public frmItemEditor()
        {
            InitializeComponent();

            // Load item names
            for (int i = 0; i < itemNames.Length; i++)
                itemNames[i] = TextItemNames.GetName(i);

            // Draw the ailments stuff
            string[] weaknesses = Properties.Resources.weaknesses.SplitN();
            for (int i = 0; i < 11; i++)
            {
                Label l = new Label();

                l.AutoSize = true;
                l.Text = weaknesses[i];
                l.Left = 6;
                l.Top = (i * 27) + 9;

                tabAilments.Controls.Add(l);
                lblAilment[i] = l;

                TextBox t = new TextBox();

                t.Width = 64;
                t.Left = l.Left + 96;
                t.Top = (i * 27) + 7;
                t.MaxLength = 6;

                tabAilments.Controls.Add(t);
                txtAilment[i] = t;
            }
            
            // Draw the PSI stuff
            string[] psi = { "PK Love", "PK Fire", "PK Freeze", "PK Thunder", "Bomb" };
            for (int i = 0; i < 5; i++)
            {
                Label l = new Label();

                l.AutoSize = true;
                l.Text = psi[i];
                l.Left = 6;
                l.Top = (i * 27) + 9;

                tabPsi.Controls.Add(l);
                lblPsi[i] = l;

                TextBox t = new TextBox();

                t.Width = 64;
                t.Left = l.Left + 96;
                t.Top = (i * 27) + 7;
                t.MaxLength = 4;

                tabPsi.Controls.Add(t);
                txtPsi[i] = t;
            }

            // Draw the equipper stuff
            equippers = Properties.Resources.equippernames.SplitN();
            for (int i = 0; i < 8; i++)
            {
                CheckBox cb = new CheckBox();

                cb.AutoSize = true;
                cb.Text = equippers[i] + " can equip";
                cb.Left = lblItemType.Left + 5;
                cb.Top = lblHp.Top + (i * 26);

                tabBasic.Controls.Add(cb);
                chkEquip[i] = cb;
            }

            // Item types
            itemTypes = Properties.Resources.itemtypes.SplitN();
            cboItemType.Items.AddRange(itemTypes);

            Helpers.CheckFont(cboItem);
            Helpers.CheckFont(txtName);
            Helpers.CheckFont(txtDescription);
            cboItem.JapaneseSearch = M3Rom.Version == RomVersion.Japanese;

            // Load the item data
            ItemData.Init();

            loading = true;
            for (int i = 0; i < ItemData.Entries; i++)
                cboItem.Items.Add("[" + i.ToString("X2") + "] " + itemNames[i]);
            loading = false;
            cboItem.SelectedIndex = 0;
        }

        public override void SelectIndex(int[] index)
        {
            cboItem.SelectedIndex = index[0];
        }

        public override int[] GetIndex()
        {
            return new int[] { cboItem.SelectedIndex };
        }

        private void HighlightControl(Control c)
        {
            var tp = c.Parent as TabPage;
            tabMain.SelectedTab = tp;
            c.Focus();

            if (c is TextBox)
            {
                var t = c as TextBox;
                t.SelectAll();
            }

            else if ((c is ComboBox) || (c is CheckBox))
            {
                Color bc = c.BackColor;
                c.BackColor = Color.Blue;
                Thread.Sleep(200);
                c.BackColor = bc;
            }
        }

        private void cboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            int index = cboItem.SelectedIndex;
            ItemData id = ItemData.Items[index];

            txtName.Text = itemNames[index];
            txtSell.Text = id.Sell.ToString();
            txtHp.Text = id.Hp.ToString();
            txtPp.Text = id.Pp.ToString();
            txtOff.Text = id.Off.ToString();
            txtDef.Text = id.Def.ToString();
            txtIq.Text = id.Iq.ToString();
            txtSpeed.Text = id.Speed.ToString();
            txtHp1.Text = id.Hp1.ToString();
            txtHp2.Text = id.Hp2.ToString();
            txtDescription.Text = TextItemDescriptions.GetDescription(index);

            if ((id.ItemType >= 0) && (id.ItemType < cboItemType.Items.Count))
                cboItemType.SelectedIndex = id.ItemType;
            else
                cboItemType.SelectedIndex = -1;

            chkKeyItem.Checked = id.KeyItem;

            for (int i = 0; i < 8; i++)
                chkEquip[i].Checked = ((id.EquipOwner >> i) & 1) == 1;

            for (int i = 0; i < 11; i++)
                txtAilment[i].Text = id.ProtectionAilment[i].ToString();

            for (int i = 0; i < 5; i++)
                txtPsi[i].Text = id.ProtectionPsi[i].ToString();

            pIcon.Image = GfxItems.GetImage(index);
            pIcon.Refresh();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            int index = cboItem.SelectedIndex;
            ItemData id = ItemData.Items[index];

            loading = true;

            TextItemNames.SetName(index, txtName.Text);
            string newName = TextItemNames.GetName(index);
            itemNames[index] = newName;
            cboItem.Items[index] = "";
            cboItem.Items[index] = "[" + index.ToString("X2") + "] " + newName;

            loading = false;

            // Sell
            try
            {
                id.Sell = ushort.Parse(txtSell.Text);
            }
            catch
            {
                HighlightControl(txtSell);
                return;
            }
            
            // HP
            try
            {
                id.Hp = int.Parse(txtHp.Text);
            }
            catch
            {
                HighlightControl(txtHp);
                return;
            }

            // PP
            try
            {
                id.Pp = short.Parse(txtPp.Text);
            }
            catch
            {
                HighlightControl(txtPp);
                return;
            }

            // Offense
            try
            {
                id.Off = sbyte.Parse(txtOff.Text);
            }
            catch
            {
                HighlightControl(txtOff);
                return;
            }

            // Defese
            try
            {
                id.Def = sbyte.Parse(txtDef.Text);
            }
            catch
            {
                HighlightControl(txtDef);
                return;
            }

            // IQ
            try
            {
                id.Iq = sbyte.Parse(txtIq.Text);
            }
            catch
            {
                HighlightControl(txtIq);
                return;
            }

            // Speed
            try
            {
                id.Speed = sbyte.Parse(txtSpeed.Text);
            }
            catch
            {
                HighlightControl(txtSpeed);
                return;
            }

            // HP1
            try
            {
                id.Hp1 = ushort.Parse(txtHp1.Text);
            }
            catch
            {
                HighlightControl(txtHp1);
                return;
            }

            // HP2
            try
            {
                id.Hp2 = ushort.Parse(txtHp2.Text);
            }
            catch
            {
                HighlightControl(txtHp2);
                return;
            }
            
            // Item type
            id.ItemType = (byte)cboItemType.SelectedIndex;

            // Key item
            id.KeyItem = chkKeyItem.Checked;

            // Equip
            id.EquipOwner = 0;
            for (int i = 0; i < 8; i++)
            {
                if (chkEquip[i].Checked)
                    id.EquipOwner |= (byte)(1 << i);
            }

            // Ailment protection
            for (int i = 0; i < 11; i++)
            {
                try
                {
                    id.ProtectionAilment[i] = short.Parse(txtAilment[i].Text);
                }
                catch
                {
                    HighlightControl(txtAilment[i]);
                    return;
                }
            }

            // PSI protection
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    id.ProtectionPsi[i] = sbyte.Parse(txtPsi[i].Text);
                }
                catch
                {
                    HighlightControl(txtPsi[i]);
                    return;
                }
            }

            // Save changes
            id.Save();

            // Refresh
            cboItem_SelectedIndexChanged(null, null);
        }

        private void mnuGraphicsSave_Click(object sender, EventArgs e)
        {
            Helpers.GraphicsSave(sender, dlgSaveImage);
        }

        private void mnuGraphicsCopy_Click(object sender, EventArgs e)
        {
            Helpers.GraphicsCopy(sender);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MOTHER3;

namespace MOTHER3Funland
{
	public partial class PalSelector : UserControl
	{
		private bool loading = false;

		private Label[] lblCol = new Label[16];

		public int PalIndex
		{
			get
			{
				return m_palIndex;
			}
			set
			{
				m_palIndex = value;
				if (value == -1) return;

				if (cboPalIndex.Items.Count > value)
				{
					loading = true;
					cboPalIndex.SelectedIndex = m_palIndex;
					loading = false;

					for (int i = 0; i < 16; i++)
						lblCol[i].BackColor = m_pals.Entries[m_palIndex][i];

					PrimaryIndex = 0;
					SecondaryIndex = 15;
				}
			}
		}
		private int m_palIndex = 0;

		public MPalette Palettes
		{
			get
			{
				return m_pals;
			}
			set
			{
				if (value == null)
				{
					m_pals = null;
					return;
				}

                m_pals = (MPalette)value.Clone();

				loading = true;
				cboPalIndex.Items.Clear();

				if (m_pals == null)
				{
					cboPalIndex.SelectedIndex = -1;
				}
				else
				{
					for (int i = 0; i < m_pals.Count; i++)
						cboPalIndex.Items.Add(i.ToString());
					if (cboPalIndex.Items.Count > 0) cboPalIndex.SelectedIndex = 0;
				}
				loading = false;
				cboPalIndex_SelectedIndexChanged(null, null);
			}
		}
		private MPalette m_pals = null;

		public Color PrimaryColor
		{
			get
			{
				if (m_palIndex < 0) return Color.White;
				if (m_pals == null) return Color.White;
                return m_pals.Entries[m_palIndex][primaryIndex];
			}
		}

		public int PrimaryIndex
		{
			get
			{
				return primaryIndex;
			}
			set
			{
				primaryIndex = value;
				ColClick(lblCol[value], new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
			}
		}
		private int primaryIndex = 0;

		public Color SecondaryColor
		{
			get
			{
				if (m_palIndex < 0) return Color.White;
				if (m_pals == null) return Color.White;
				return m_pals.Entries[m_palIndex][secondaryIndex];
			}
		}

		public int SecondaryIndex
		{
			get
			{
				return secondaryIndex;
			}
			set
			{
				secondaryIndex = value;
				ColClick(lblCol[value], new MouseEventArgs(MouseButtons.Right, 1, 0, 0, 0));
			}
		}
		private int secondaryIndex = 0;

		public event EventHandler PalChanged
		{
			add
			{
				cboPalIndex.SelectedIndexChanged += value;
			}
			remove
			{
				cboPalIndex.SelectedIndexChanged -= value;
			}
		}

		public event EventHandler PalModified;

		protected virtual void OnPalModified(EventArgs e)
		{
			if (PalModified != null)
			{
				PalModified(this, e);
			}
		}

		public PalSelector()
		{
			InitializeComponent();

			for (int i = 0; i < 16; i++)
			{
				int baseLeft = lblPalSecondary.Left + lblPalSecondary.Width + 1;
				int baseTop = lblPalPrimary.Top;

				var l = new Label();
				l.AutoSize = false;
				l.Text = "";
				l.Size = new Size(24, 24);
				l.Top = baseTop + ((i >> 3) * 25);
				l.Left = baseLeft + ((i & 7) * 25);
				l.BackColor = Color.White;
				l.Visible = true;
				l.Tag = i;

				l.MouseClick += new MouseEventHandler(ColClick);

				l.MouseDoubleClick += (s, e) =>
				{
					Label ll = s as Label;
					int index = (int)ll.Tag;
					dlgColor.Color = m_pals.Entries[m_palIndex][index];

					if (dlgColor.ShowDialog() == DialogResult.OK)
					{
						Color c = dlgColor.Color;
						Color cc = Color.FromArgb(c.R & 0xF8, c.G & 0xF8, c.B & 0xF8);
                        m_pals.Entries[m_palIndex][index] = cc;
						ll.BackColor = c;

						if (primaryIndex == index) lblPalPrimary.BackColor = c;
						if (secondaryIndex == index) lblPalSecondary.BackColor = c;

						OnPalModified(new EventArgs());
					}
				};

				grpMain.Controls.Add(l);
				lblCol[i] = l;
			}
		}

		private void ColClick(object sender, MouseEventArgs e)
		{
			Label ll = sender as Label;
			int index = (int)ll.Tag;

			if (e.Button == MouseButtons.Left)
			{
				primaryIndex = index;
				lblPalPrimary.BackColor = PrimaryColor;
			}
			else if (e.Button == MouseButtons.Right)
			{
				secondaryIndex = index;
				lblPalSecondary.BackColor = SecondaryColor;
			}
		}

		private void cboPalIndex_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (loading) return;

			PalIndex = cboPalIndex.SelectedIndex;
		}
	}
}

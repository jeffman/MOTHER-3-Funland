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
	public partial class ComboSearch : UserControlBase
	{
		protected override Control SnapLineControl
		{
			get
			{
				return cboSearch;
			}
		}

		public ComboBox.ObjectCollection Items
		{
			get
			{
				return cboSearch.Items;
			}
		}

		public object DataSource
		{
			get
			{
				return cboSearch.DataSource;
			}
			set
			{
				cboSearch.DataSource = value;
			}
		}

		public event EventHandler SelectedIndexChanged
		{
			add
			{
				cboSearch.SelectedIndexChanged += value;
			}
			remove
			{
				cboSearch.SelectedIndexChanged -= value;
			}
		}

		public int SelectedIndex
		{
			get
			{
				return cboSearch.SelectedIndex;
			}
			set
			{
				cboSearch.SelectedIndex = value;
			}
		}

		public bool JapaneseSearch = false;

		public ComboBox InternalBox
		{
			get
			{
				return cboSearch;
			}
		}

		public ComboSearch()
		{
			InitializeComponent();
		}

		private void txtSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				string search = txtSearch.Text;
				if (search.Length == 0) return;

				if (JapaneseSearch)
				{
					// If it's Japanese, we need to convert our search to the unicode equivalent
					byte[] b = TextProvider.SJIS.GetBytes(search);
					List<byte> o = new List<byte>();
					for (int j = 0; j < b.Length; j++)
					{
						byte ch = b[j];
						if (ch < 0x80)
						{
							// ASCII
							ushort us = TextProvider.JapaneseAsciiMap[ch];

							o.Add((byte)((us >> 8) & 0xFF));
							o.Add((byte)(us & 0xFF));
						}
						else
						{
							// SJIS
							o.Add(ch);
							o.Add(b[j + 1]);
							j++;
						}
					}

					// Now it's in SJIS, so convert to unicode
					byte[] u = Encoding.Convert(TextProvider.SJIS, TextProvider.Unicode, o.ToArray());

					search = TextProvider.Unicode.GetString(u);
				}

				int startindex = cboSearch.SelectedIndex;
				bool wrapped = false;

				for (int i = startindex + 1; ; i++)
				{
					if (i == cboSearch.Items.Count)
					{
						i = 0;
						wrapped = true;
					}

					bool found = false;
					found = ((string)cboSearch.Items[i]).ToLower().Contains(search.ToLower());

					if (found)
					{
						cboSearch.SelectedIndex = i;
						break;
					}

					if (wrapped && (i == startindex)) break;
				}
			}
		}

		public void SetFont(Font font)
		{
			cboSearch.Font = font;
			txtSearch.Font = font;
		}

		public Font GetFont()
		{
			return cboSearch.Font;
		}

		private void cboSearch_Resize(object sender, EventArgs e)
		{
			this.Height = cboSearch.Height;
		}
	}
}
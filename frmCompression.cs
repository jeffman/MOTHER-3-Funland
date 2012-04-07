using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using GBA;
using MOTHER3;
using Extensions;

namespace MOTHER3Funland
{
	public partial class frmCompression : M3Form
	{
		public frmCompression()
		{
			InitializeComponent();
			ModuleArbiter.FormLoading(this);
		}

		private void btnDecomp_Click(object sender, EventArgs e)
		{
			int address = GetInt(txtAddress);
			if (address == -1)
			{
				txtAddress.SelectAll();
				return;
			}

			// Try to decomp
			byte[] output;
			int res = LZ77.Decompress(M3Rom.Rom, address, out output);

			if (res == -1)
			{
				MessageBox.Show("There was an error decompressing the data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				MessageBox.Show("Decompressed " + output.Length + " bytes from " + res + " bytes.", "Success");
				if (dlgSave.ShowDialog() == DialogResult.OK)
					File.WriteAllBytes(dlgSave.FileName, output);
			}
		}

		private void txtAddress_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnDecomp_Click(null, null);
			}
		}

		public override void SelectIndex(int[] index)
		{
			int a = index[0];
			if (a >= 0) txtAddress.Text = a.ToString("X");
		}

		public override int[] GetIndex()
		{
			return new int[] { GetInt(txtAddress) };
		}

		private int GetInt(TextBox t)
		{
			int address = 0;
			try
			{
				address = int.Parse(t.Text, System.Globalization.NumberStyles.HexNumber);
				if ((address < 0) || (address >= 0x1ffffff)) return -1;
			}
			catch
			{
				return -1;
			}
			return address;
		}
	}
}

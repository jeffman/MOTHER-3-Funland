using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using Extensions;

namespace MOTHER3Funland
{
    class ModuleArbiter
    {
        public static Dictionary<Type, Bitmap> FormIcons = new Dictionary<Type, Bitmap>();
        public static Dictionary<Type, M3Form> Forms = new Dictionary<Type, M3Form>();
        public static frmMain MainForm = null;

        static ModuleArbiter()
        {
            FormIcons.Add(typeof(frmBattleBgEntryEditor), Properties.Resources.bg);
            FormIcons.Add(typeof(frmBattleBgLayerEditor), Properties.Resources.bg2);
            FormIcons.Add(typeof(frmEnemyEditor), Properties.Resources.slug);
            FormIcons.Add(typeof(frmItemEditor), Properties.Resources.thunderbomb);
            FormIcons.Add(typeof(frmLevelExpEditor), Properties.Resources.lucashead);
            FormIcons.Add(typeof(frmLevelPsiEditor), Properties.Resources.ioniahead);
            FormIcons.Add(typeof(frmMainTextViewer), Properties.Resources.sparrow);
            FormIcons.Add(typeof(frmPsiEditor), Properties.Resources.butterfly);
            FormIcons.Add(typeof(frmShopEditor), Properties.Resources.vending);
            FormIcons.Add(typeof(frmSpriteEditor), Properties.Resources.claushead);
            FormIcons.Add(typeof(frmMapViewer), Properties.Resources.map);
            FormIcons.Add(typeof(frmBattleSwirlEditor), Properties.Resources.swirl);
            FormIcons.Add(typeof(frmTownMapEditor), Properties.Resources.map);
            FormIcons.Add(typeof(frmDontCareNamesEditor), Properties.Resources.salsa);
            FormIcons.Add(typeof(frmCharNamesEditor), Properties.Resources.guy);
        }

        public static Bitmap GetFormIcon(Type frmType)
        {
            if (FormIcons.ContainsKey(frmType)) return FormIcons[frmType];
            else return null;
        }

        public static void AddModule(string label, Type frmType)
        {
            Button b = AddButton(label);
            b.Image = GetFormIcon(frmType);
            b.ImageAlign = ContentAlignment.MiddleLeft;
            b.Click += (s, e) =>
            {
                ShowForm(frmType);
            };
        }

        private static Button AddButton(string text)
        {
            Button b = new Button();
            b.AutoSize = false;
            b.Text = text;
            b.TextAlign = ContentAlignment.MiddleCenter;
            b.Visible = false;

            b.Height = 25;
            b.Width = MainForm.ClientSize.Width;
            b.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            MainForm.AddControl(b);
            return b;
        }

        public static M3Form ShowForm(Type frmType)
        {
            M3Form f = null;
            if (Forms.ContainsKey(frmType))
                f = Forms[frmType];

            if ((f == null) || (f.IsDisposed))
                f = CreateForm(frmType);

            f.Show();
            f.Focus();

            if (Forms.ContainsKey(frmType))
                Forms[frmType] = f;
            else
                Forms.Add(frmType, f);

            return f;
        }

        public static void ShowSelect(Type frmType, int index)
        {
            ShowSelect(frmType, new int[] { index });
        }

        public static void ShowSelect(Type frmType, int[] index)
        {
            M3Form f = ShowForm(frmType);
            f.SelectIndex(index);
        }

        public static void CloseForms()
        {
            foreach (KeyValuePair<Type, M3Form> kv in Forms.ToList())
            {
                M3Form f = kv.Value;
                Forms.Remove(kv.Key);

                if ((f != null) && (!f.IsDisposed))
                {
                    f.Close();
                    f.Dispose();
                }
            }
        }

        public static void FormLoading(M3Form frm)
        {
            string frmType = frm.GetType().ToString();
            var d = M3Settings.MainSettings.FormParams;

            if (d.ContainsKey(frmType))
            {
                var p = d[frmType];
                frm.Location = p.WindowLoc;
                frm.Size = p.WindowSize;
                frm.WindowState = p.WindowState;
                frm.SelectIndex(p.ItemIndex);
            }
        }

        public static void FormClosing(object sender, FormClosingEventArgs e)
        {
            string frmType = sender.GetType().ToString();
            M3Form f = (M3Form)sender;

            FormParams p = new FormParams(f.Location, f.Size, f.WindowState, f.GetIndex());
            var d = M3Settings.MainSettings.FormParams;

            if (d.ContainsKey(frmType))
                d[frmType] = p;
            else
                d.Add(frmType, p);
        }

        private static M3Form CreateForm(Type frmType)
        {
            M3Form frm;

            // Better exception reporting
            try
            {
                frm = (M3Form)Activator.CreateInstance(frmType);
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }

            Bitmap bmp = GetFormIcon(frmType);
            if (bmp != null) frm.Icon = bmp.ToIcon();

            FormLoading(frm);
            return frm;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SIF3.Clases
{
    class SIFUtils
    {
        //public static void AutoNumberRowsForGridView(DataGridView dataGridView)
        //{
        //    if (dataGridView != null)
        //    {
        //        for (int count = 0; (count <= (dataGridView.Rows.Count - 1)); count++)
        //        {
        //            // dataGridView.Rows[count].HeaderCell.Value = string.Format((count + 1).ToString(), "0");
        //            dataGridView.Rows[count].HeaderCell.Value = (count + 1).ToString().PadLeft(2, '0');
        //        }
        //    }
        //}

        public static void FillListViewTelCel(List<SIFModelo.Articulo> lv, string Carrier)
        {
            lv = new List<SIFModelo.Articulo>();
            //lv.Items.Clear();
            //ListViewItem item = null;
            //ListViewItem.ListViewSubItem[] subItems = null;
            string CtasMail = ConfigSettings.ReadSetting(Carrier); //"ProdTelCel"
            string[] producto = null;

            if (!string.IsNullOrEmpty(CtasMail))
            {
                foreach (string Cad in CtasMail.Split('|'))
                {
                    if (!string.IsNullOrEmpty(Cad))
                    {
                        producto = Cad.Split(',');
                        //item = new ListViewItem(producto[0]);
                        //subItems = new ListViewItem.ListViewSubItem[] {
                        //new ListViewItem.ListViewSubItem(item, producto[1]),
                        //new ListViewItem.ListViewSubItem(item, producto[2]),
                        //new ListViewItem.ListViewSubItem(item, producto[3])
                        //};
                        //item.SubItems.AddRange(subItems);
                        //lv.Items.Add(item);

                        SIFModelo.Articulo articulo = new SIFModelo.Articulo();
                        articulo.NOMBRE1 = producto[0];
                    }
                }
            }
        }

        public static string ReadXMLFile(string FileName, int FileSize)
        {
            string filereadbuf;
            // lets define an array of type char field (i.e. variable) buf
            char[] buf = new char[FileSize];
            StreamReader sr = new StreamReader(
                new FileStream(FileName, FileMode.Open, FileAccess.Read), System.Text.Encoding.GetEncoding("iso-8859-1"));
            int retval = sr.ReadBlock(buf, 0, FileSize); // no. of bytes read 
            filereadbuf = new string(buf); // store it in our field 

            sr.Close();

            return filereadbuf;

        }
    }
}

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Runtime.InteropServices;

namespace Util
{
    public interface IForm_login
    {
        bool pasar_credenciales(string usuario, string bd_externa, string version, string dni, string ip, int USERID);
    }

    public interface IForm_Listado
    {
        bool pasar_valores(string par1, string par2, string par3, string par4, string par5, string par6, string par7);
        bool cerrar();
    }
    
    public class Utilidades
    {
       
        public System.Windows.Forms.Button btn_lista;
        public System.Windows.Forms.Button btnGrilla;

        public System.Windows.Forms.Button btn_buscar;

        public static void CopyCellToClipboard(string dataValue)
        {
            Clipboard.SetText(dataValue);
        }

        public static void CopyRowToClipboard(DataGridView dgv)
        {
            DataObject dataObj = dgv.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        public void copiar_contextual(DataGridView _dgv)
        {
            DataObject d = _dgv.GetClipboardContent();
            Clipboard.SetDataObject(d);
        }

        public void copiar_todo_encabezados(DataGridView _dgv)
        {
            //Copy to clipboard
            _dgv.SelectAll();
            _dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            DataObject dataObj = _dgv.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
            _dgv.ClearSelection();
            //  MessageBox.Show("Se copio al portapapeles");

        }

        public void copiar_todo_sin_encabezados(DataGridView _dgv)
        {
            //Copy to clipboard
            _dgv.SelectAll();
            _dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            DataObject dataObj = _dgv.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
            _dgv.ClearSelection();
            //  MessageBox.Show("Se copio al portapapeles");

        }
        
        public void FormatearGrillaEditable(DataGridView grilla, bool ordenar)
        {
            try
            {
                grilla.ReadOnly = false;
                grilla.RowHeadersVisible = false;
                grilla.RowHeadersWidth = 31;
                grilla.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                grilla.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(231, 231, 231);
                grilla.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grilla.RowHeadersDefaultCellStyle.Font = new Font("Tahoma", 8);
                grilla.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grilla.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(194, 200, 205);
                grilla.RowHeadersDefaultCellStyle.SelectionForeColor = Color.Black;

                grilla.BackgroundColor = Color.FromArgb(255, 255, 255);
                grilla.BackColor = Color.FromArgb(255, 255, 255);
                grilla.GridColor = Color.FromArgb(204, 204, 204);
                grilla.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
                grilla.DefaultCellStyle.ForeColor = Color.Black;
                grilla.DefaultCellStyle.Font = new Font("Tahoma", 7.4F);
                grilla.RowTemplate.Height = 18;
                grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(231, 231, 231);
                grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                grilla.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grilla.ColumnHeadersHeight = 18;
                grilla.DefaultCellStyle.SelectionBackColor = Color.FromArgb(252, 221, 130);
                grilla.DefaultCellStyle.SelectionForeColor = Color.Black;

                grilla.Columns[0].ReadOnly = true;
                grilla.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(231, 231, 231);
                grilla.Columns[0].DefaultCellStyle.SelectionBackColor = Color.FromArgb(194, 200, 205);

                if (ordenar == false)
                {
                    foreach (DataGridViewColumn col in grilla.Columns)
                    {
                        col.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }

                //for (int i = 0; i < grilla.Rows.Count; i++)
                //{
                //    grilla.Rows[i].HeaderCell.Value = (i + 1).ToString();
                //    //grilla.Rows[i].HeaderCell.Style.Font = new Font("Calibri", 8);
                //}

                //DataGridViewCellStyle style = new DataGridViewCellStyle();
                //style.Font = new Font(grilla.Font, FontStyle.Bold);
                //grilla.Rows[4].DefaultCellStyle = style;



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error debido a: " + ex.ToString());
            }
        }

        public void BotonGrillaEditable(DataGridView grilla, DataGridViewCellEventArgs e)
        {
            try
            {
                grilla[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.FromArgb(254, 240, 158);
                grilla[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Black;

                btnGrilla = new System.Windows.Forms.Button();
                btnGrilla.FlatStyle = FlatStyle.Flat;
                btnGrilla.FlatAppearance.BorderSize = 0;
                btnGrilla.FlatAppearance.MouseDownBackColor = Color.Transparent;
                btnGrilla.FlatAppearance.MouseOverBackColor = Color.Transparent;
                btnGrilla.BackgroundImage = ((System.Drawing.Image)(Util.Properties.Resources.PICKERchoosefromlist));
                btnGrilla.BackgroundImageLayout = ImageLayout.Center;
                btnGrilla.BackColor = Color.Transparent;
                btnGrilla.Font = new System.Drawing.Font("Tahoma", 7.4F);
                btnGrilla.Visible = true;

                btnGrilla.Width = grilla.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Height;
                btnGrilla.Height = grilla.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Height;


                grilla.Controls.Add(btnGrilla);

                btnGrilla.Location = new System.Drawing.Point(((grilla.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Right) -
                         (btnGrilla.Width)), grilla.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Y);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error debido a: " + ex.ToString());
            }
        }

        public void TextboxButton(TextBox Listado)
        {
            btn_lista = new System.Windows.Forms.Button();
            btn_lista.FlatStyle = FlatStyle.Flat;
            btn_lista.FlatAppearance.BorderSize = 0;
            btn_lista.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_lista.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_lista.BackgroundImage = ((System.Drawing.Image)(Util.Properties.Resources.PICKERchoosefromlist));
            btn_lista.BackgroundImageLayout = ImageLayout.Center;
            btn_lista.BackColor = Color.Transparent;
            btn_lista.Font = new System.Drawing.Font("Tahoma", 7.4F);
            btn_lista.Visible = true;
            btn_lista.Size = new Size(14, 12);
            btn_lista.Location = new Point(Listado.ClientSize.Width - btn_lista.Width - 2, 1);

            Listado.Controls.Add(btn_lista);

            Listado.BackColor = Color.FromArgb(254, 240, 158);

            if (!String.IsNullOrEmpty(Listado.Text))
            {
                Listado.SelectionStart = 0;
                Listado.SelectionLength = Listado.Text.Length;
            }
        }

        public void desactivarFrm(ToolStrip titulo, ToolStripButton ninimizar, ToolStripButton maximizar, ToolStripButton salir, bool tipo)
        {
            //tipo true=activo false=inactivo


            if (tipo == true)
            {
                titulo.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.shell_header_2));
                ninimizar.Image = ((System.Drawing.Image)(Properties.Resources.Frame_Minimize0));
                maximizar.Image = ((System.Drawing.Image)(Properties.Resources.Frame_Maximize0));
                salir.Image = ((System.Drawing.Image)(Properties.Resources.Frame_Close0));


            }

            if (tipo == false)
            {
                titulo.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.shell_header_d));
                ninimizar.Image = ((System.Drawing.Image)(Properties.Resources.Frame_Minimize2));
                maximizar.Image = ((System.Drawing.Image)(Properties.Resources.Frame_Maximize2));
                salir.Image = ((System.Drawing.Image)(Properties.Resources.Frame_Close2));


            }




        }

        public void FormatearCombo(object sender, DrawItemEventArgs e, string display)
        {
            if (e.Index < 0)
                return;

            ComboBox combo = sender as ComboBox;

            DataRowView drv = ((DataRowView)(combo.Items[e.Index]));
            string name = drv[display].ToString();


            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(252, 220, 130)), e.Bounds);
            else
                e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);

            e.Graphics.DrawString(name, e.Font, new SolidBrush(combo.ForeColor), new System.Drawing.Point(e.Bounds.X, e.Bounds.Y));

            e.DrawFocusRectangle();
        }

        public static DataTable GetEmpresas()
        {
            DataTable _tabla = new DataTable();

            _tabla.Columns.Add("id");
            _tabla.Columns.Add("empresa");

            DataRow row = _tabla.NewRow();
            row["id"] = 1;
            row["empresa"] = "Rumi Import S.A.";
            _tabla.Rows.Add(row);

            row = _tabla.NewRow();
            row["id"] = 2;
            row["empresa"] = "Mega Estructuras S.A";
            _tabla.Rows.Add(row);

            row = _tabla.NewRow();
            row["id"] = 3;
            row["empresa"] = "Industrias del Zinc S.A.";
            _tabla.Rows.Add(row);

            row = _tabla.NewRow();
            row["id"] = 4;
            row["empresa"] = "Manufacturas Industriales Mendoza S.A.";
            _tabla.Rows.Add(row);

            row = _tabla.NewRow();
            row["id"] = 5;
            row["empresa"] = "Postes y Estructuras S.A.C.";
            _tabla.Rows.Add(row);

            row = _tabla.NewRow();
            row["id"] = 6;
            row["empresa"] = "Steel Form S.A.C.";
            _tabla.Rows.Add(row);

            return _tabla;
        }

        public static DataTable GetMonedas()
        {
            DataTable _tabla = new DataTable();

            _tabla.Columns.Add("id");
            _tabla.Columns.Add("moneda");

            DataRow row = _tabla.NewRow();
            row["id"] = 1;
            row["moneda"] = "SOL";
            _tabla.Rows.Add(row);

            row = _tabla.NewRow();
            row["id"] = 2;
            row["moneda"] = "USD";
            _tabla.Rows.Add(row);


            return _tabla;
        }

    }

}

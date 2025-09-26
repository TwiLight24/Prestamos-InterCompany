using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace UIEsys
{
    public partial class UISAP : Form
    {

        private static int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private static Rectangle sizeGripRectangle;





        public static void Form(Form formulario, Button btnGrabar, Button btnCancelar, Button btnAux1, Button btnAux2, string titulo, string estilo, string TipoClose, string ControlBox)
        {
            // CargoPrivateFontCollection();

            Button btnClose = new Button();
            Button btnMax = new Button();
            Button btnRes = new Button();
            Button btnMin = new Button();
            Panel panelContenedorPrincipal = new Panel();
            Panel panel = new Panel();
            Label lblTit = new Label();


            #region Golden
            if (estilo == "Golden")
            {
                /* Formulario General */
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.FormBorderStyle = FormBorderStyle.FixedDialog;
                formulario.BackColor = Color.FromArgb(247, 247, 247);
                formulario.ControlBox = false;
                formulario.Text = "";
                formulario.AutoScaleMode = AutoScaleMode.None;
                formulario.Font = new Font("Tahoma", 7.6F);

                /* Marco Cabecera Formulario */
                panel.Dock = DockStyle.Top;
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.AutoSize = false;
                panel.Height = 30;
                panel.BackgroundImage = Properties.Resources.shell_header_2;
                panel.BackgroundImageLayout = ImageLayout.Stretch;

                /* Interior del Formulario */
                panelContenedorPrincipal.Dock = DockStyle.Fill;
                panelContenedorPrincipal.BorderStyle = BorderStyle.None;
                panelContenedorPrincipal.BackColor = Color.FromArgb(247, 247, 247);
                panelContenedorPrincipal.AutoSize = false;


                if (btnGrabar != null)
                {
                    btnGrabar.Text = "Crear";
                    btnGrabar.FlatStyle = FlatStyle.Flat;
                    btnGrabar.FlatAppearance.BorderSize = 0;
                    btnGrabar.BackgroundImage = Properties.Resources.btn_enfasis;
                    btnGrabar.BackgroundImageLayout = ImageLayout.Stretch;
                    btnGrabar.Height = 20;
                    btnGrabar.Width = 68;
                    btnGrabar.TextAlign = ContentAlignment.MiddleCenter;
                    btnGrabar.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom); ;
                    btnGrabar.Location = new Point(12, formulario.Height - 50);
                }

                if (btnCancelar != null)
                {

                    btnCancelar.Text = "Cancelar";
                    btnCancelar.FlatStyle = FlatStyle.Flat;
                    btnCancelar.FlatAppearance.BorderSize = 0;
                    btnCancelar.BackgroundImage = Properties.Resources.btn;
                    btnCancelar.BackgroundImageLayout = ImageLayout.Stretch;
                    btnCancelar.Height = 20;
                    btnCancelar.Width = 68;
                    btnCancelar.TextAlign = ContentAlignment.MiddleCenter;
                    btnCancelar.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom); ;
                    btnCancelar.Location = new Point(84, formulario.Height - 50);
                }

                if (btnAux1 != null)
                {
                    btnAux1.FlatStyle = FlatStyle.Flat;
                    btnAux1.FlatAppearance.BorderSize = 0;
                    btnAux1.BackgroundImage = Properties.Resources.btn;
                    btnAux1.BackgroundImageLayout = ImageLayout.Stretch;
                    btnAux1.Height = 20;
                    btnAux1.Width = 105;
                    btnAux1.TextAlign = ContentAlignment.MiddleCenter;
                    btnAux1.Location = new Point(formulario.Width - 240, formulario.Height - 35);
                    btnAux1.Anchor = (AnchorStyles.Right | AnchorStyles.Bottom);

                }

                if (btnAux2 != null)
                {
                    btnAux2.FlatStyle = FlatStyle.Flat;
                    btnAux2.FlatAppearance.BorderSize = 0;
                    btnAux2.BackgroundImage = Properties.Resources.btn;
                    btnAux2.BackgroundImageLayout = ImageLayout.Stretch;
                    btnAux2.Height = 20;
                    btnAux2.Width = 105;
                    btnAux2.TextAlign = ContentAlignment.MiddleCenter;
                    btnAux2.Location = new Point(formulario.Width - 130, formulario.Height - 35);
                    btnAux2.Anchor = (AnchorStyles.Right | AnchorStyles.Bottom);

                }


                /* Posicion del Titulo */
                lblTit.AutoSize = false;
                lblTit.Width = formulario.Width - 100;
                lblTit.Text = titulo;
                lblTit.Font = new Font("Tahoma", 8F);
                lblTit.Height = 18;
                lblTit.Location = new Point(2, 5);
                lblTit.BackColor = Color.Transparent;




                btnClose.Location = new Point(formulario.Width - 40, 1);
                btnClose.Image = Properties.Resources.Frame_Close;
                btnClose.FlatStyle = FlatStyle.Standard;
                btnClose.Width = 22;
                btnClose.Height = 22;
                btnClose.FlatAppearance.BorderSize = 0;


                btnMax.Location = new Point(formulario.Width - 60, 1);
                btnMax.Image = Properties.Resources.Frame_Maximize;
                btnMax.FlatStyle = FlatStyle.Standard;
                btnMax.Width = 22;
                btnMax.Height = 22;
                btnMax.FlatAppearance.BorderSize = 0;


                btnRes.Location = new Point(formulario.Width - 60, 1);
                btnRes.Image = Properties.Resources.Frame_Restore;
                btnRes.FlatStyle = FlatStyle.Standard;
                btnRes.Width = 22;
                btnRes.Height = 22;
                btnRes.FlatAppearance.BorderSize = 0;
                btnRes.Visible = false;


                btnMin.Location = new Point(formulario.Width - 80, 1);
                btnMin.Image = Properties.Resources.Frame_Minimize;
                btnMin.FlatStyle = FlatStyle.Standard;
                btnMin.Width = 22;
                btnMin.Height = 22;
                btnMin.FlatAppearance.BorderSize = 0;


                #region ControlBox Visible
                // 0 -->  Minimizar = NO, Maximizar = NO, Cerrar = NO
                // 1 -->  Minimizar = NO, Maximizar = NO, Cerrar = SI
                // 2 -->  Minimizar = SI, Maximizar = NO, Cerrar = SI
                // 3 -->  Minimizar = SI, Maximizar = SI, Cerrar = SI

                switch (ControlBox)
                {
                    case "0":
                        btnMax.Visible = false;
                        btnMin.Visible = false;
                        btnClose.Visible = false;

                        break;
                    case "1":
                        btnMax.Visible = false;
                        btnMin.Visible = false;
                        btnClose.Visible = true;

                        break;
                    case "2":
                        btnMax.Visible = true;
                        btnMin.Visible = false;
                        btnClose.Visible = true;
                        break;

                    case "3":
                        btnMax.Visible = true;
                        btnMin.Visible = true;
                        btnClose.Visible = true;
                        break;

                }

                #endregion


                formulario.Controls.Add(panel);
                formulario.Controls.Add(panelContenedorPrincipal);
                panel.Controls.Add(btnClose);
                panel.Controls.Add(btnMax);
                panel.Controls.Add(btnRes);
                panel.Controls.Add(btnMin);
                panel.Controls.Add(lblTit);


            }

            #endregion

            #region Fiori
            if (estilo == "Fiori")
            {
                formulario.StartPosition = FormStartPosition.WindowsDefaultLocation;
                formulario.BackColor = Color.FromArgb(255, 255, 255);
                formulario.ControlBox = false;
                formulario.Text = "";
                formulario.AutoScaleMode = AutoScaleMode.None;
                formulario.FormBorderStyle = FormBorderStyle.None;


                if (btnGrabar != null)
                {
                    btnGrabar.Text = "Crear";
                    btnGrabar.FlatStyle = FlatStyle.Flat;
                    btnGrabar.FlatAppearance.BorderSize = 0;
                    btnGrabar.ForeColor = Color.White;
                    btnGrabar.BackColor = Color.FromArgb(1, 155, 227);
                    btnGrabar.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 133, 195);
                    btnGrabar.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 133, 195);
                    btnGrabar.Height = 20;
                    btnGrabar.Width = 68;
                    btnGrabar.TextAlign = ContentAlignment.MiddleCenter;
                    btnGrabar.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom);
                    btnGrabar.Location = new Point(12, formulario.Height - 35);

                }

                if (btnCancelar != null)
                {

                    btnCancelar.Text = "Cancelar";
                    btnCancelar.FlatStyle = FlatStyle.Flat;
                    btnCancelar.FlatAppearance.BorderSize = 0;
                    btnCancelar.ForeColor = Color.White;
                    btnCancelar.BackColor = Color.FromArgb(119, 119, 119);
                    btnCancelar.FlatAppearance.MouseDownBackColor = Color.FromArgb(94, 92, 92);
                    btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(94, 92, 92);
                    btnCancelar.Height = 20;
                    btnCancelar.Width = 68;
                    btnCancelar.TextAlign = ContentAlignment.MiddleCenter;
                    btnCancelar.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom);
                    btnCancelar.Location = new Point(84, formulario.Height - 35);
                }

                if (btnAux1 != null)
                {
                    btnAux1.FlatStyle = FlatStyle.Flat;
                    btnAux1.FlatAppearance.BorderSize = 0;
                    btnAux1.BackColor = Color.FromArgb(119, 119, 119);
                    btnAux1.ForeColor = Color.White;
                    btnAux1.FlatAppearance.MouseDownBackColor = Color.FromArgb(94, 92, 92);
                    btnAux1.FlatAppearance.MouseOverBackColor = Color.FromArgb(94, 92, 92);
                    btnAux1.Height = 20;
                    btnAux1.Width = 105;
                    btnAux1.TextAlign = ContentAlignment.MiddleCenter;
                    btnAux1.Location = new Point(formulario.Width - 240, formulario.Height - 35);
                    btnAux1.Anchor = (AnchorStyles.Right | AnchorStyles.Bottom);

                }

                if (btnAux2 != null)
                {
                    btnAux2.FlatStyle = FlatStyle.Flat;
                    btnAux2.FlatAppearance.BorderSize = 0;
                    btnAux2.BackColor = Color.FromArgb(119, 119, 119);
                    btnAux2.ForeColor = Color.White;
                    btnAux2.FlatAppearance.MouseDownBackColor = Color.FromArgb(94, 92, 92);
                    btnAux2.FlatAppearance.MouseOverBackColor = Color.FromArgb(94, 92, 92);
                    btnAux2.Height = 20;
                    btnAux2.Width = 105;
                    btnAux2.TextAlign = ContentAlignment.MiddleCenter;
                    btnAux2.Location = new Point(formulario.Width - 130, formulario.Height - 35);
                    btnAux2.Anchor = (AnchorStyles.Right | AnchorStyles.Bottom);

                }



                panelContenedorPrincipal.Dock = DockStyle.Fill;
                panelContenedorPrincipal.BorderStyle = BorderStyle.Fixed3D;
                //  panelForm.BringToFront();
                panelContenedorPrincipal.BackColor = Color.FromArgb(247, 247, 247);



                panel.Dock = DockStyle.Top;
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.AutoSize = false;
                panel.Height = 30;
                panel.BackgroundImage = Properties.Resources.shell_headerf;
                panel.BackgroundImageLayout = ImageLayout.Stretch;



                lblTit.AutoSize = false;
                lblTit.Width = formulario.Width - 100;
                lblTit.Text = titulo;
                lblTit.Font = new Font("Segoe UI", 10);
                lblTit.Height = 18;
                lblTit.Location = new Point(2, 6);
                lblTit.BackColor = Color.Transparent;

                btnClose.Location = new Point(formulario.Width - 30, 5);
                btnClose.BackgroundImage = Properties.Resources.Frame_Close;
                btnClose.BackgroundImageLayout = ImageLayout.Stretch;
                btnClose.FlatStyle = FlatStyle.Flat;
                btnClose.Width = 18;
                btnClose.Height = 18;
                btnClose.FlatAppearance.BorderSize = 0;


                btnMax.Location = new Point(formulario.Width - 55, 5);
                btnMax.BackgroundImage = Properties.Resources.Frame_Maximize;
                btnMax.BackgroundImageLayout = ImageLayout.Stretch;
                btnMax.FlatStyle = FlatStyle.Flat;
                btnMax.Width = 18;
                btnMax.Height = 18;
                btnMax.FlatAppearance.BorderSize = 0;




                btnRes.Location = new Point(formulario.Width - 55, 5);
                btnRes.BackgroundImage = Properties.Resources.Frame_Restore;
                btnRes.BackgroundImageLayout = ImageLayout.Stretch;
                btnRes.FlatStyle = FlatStyle.Flat;
                btnRes.Width = 18;
                btnRes.Height = 18;
                btnRes.FlatAppearance.BorderSize = 0;
                btnRes.Visible = false;



                btnMin.Location = new Point(formulario.Width - 80, 5);
                btnMin.BackgroundImage = Properties.Resources.Frame_Minimize;
                btnMin.BackgroundImageLayout = ImageLayout.Stretch;
                btnMin.FlatStyle = FlatStyle.Flat;
                btnMin.Width = 18;
                btnMin.Height = 18;
                btnMin.FlatAppearance.BorderSize = 0;

                #region ControlBox Visible
                // 0 -->  Minimizar = NO, Maximizar = NO, Cerrar = NO
                // 1 -->  Minimizar = NO, Maximizar = NO, Cerrar = SI
                // 2 -->  Minimizar = SI, Maximizar = NO, Cerrar = SI
                // 3 -->  Minimizar = SI, Maximizar = SI, Cerrar = SI

                switch (ControlBox)
                {
                    case "0":
                        btnMax.Visible = false;
                        btnMin.Visible = false;
                        btnClose.Visible = false;

                        break;
                    case "1":
                        btnMax.Visible = false;
                        btnMin.Visible = false;
                        btnClose.Visible = true;

                        break;
                    case "2":
                        btnMax.Visible = true;
                        btnMin.Visible = false;
                        btnClose.Visible = true;
                        break;

                    case "3":
                        btnMax.Visible = true;
                        btnMin.Visible = true;
                        btnClose.Visible = true;
                        break;

                }

                #endregion


                formulario.Controls.Add(panelContenedorPrincipal);
                panel.Controls.Add(btnClose);
                panel.Controls.Add(btnMax);
                panel.Controls.Add(btnRes);
                panel.Controls.Add(btnMin);
                panel.Controls.Add(lblTit);
                formulario.Controls.Add(panel);

            }
            #endregion

            btnClose.Click += new EventHandler((sender1, e1) => btnClose_Click(sender1, e1, formulario, TipoClose));
            btnMax.Click += new EventHandler((sender1, e1) => btnMax_Click(sender1, e1, formulario, btnMax, btnRes, btnClose, btnMin));
            btnMin.Click += new EventHandler((sender1, e1) => btnMin_Click(sender1, e1, formulario, titulo, btnMax, btnRes, btnClose, btnMin));
            btnRes.Click += new EventHandler((sender1, e1) => btnRes_Click(sender1, e1, formulario, btnMax, btnRes, btnClose, btnMin));
            panel.MouseDown += new MouseEventHandler((sender1, e1) => PanelBarraTitulo_MouseDown(sender1, e1, formulario.Handle));
            lblTit.MouseDown += new MouseEventHandler((sender1, e1) => PanelBarraTitulo_MouseDown(sender1, e1, formulario.Handle));
            //formulario.SizeChanged += new EventHandler((sender1, e1) => OnSizeChanged(e1, panelContenedorPrincipal, formulario));
            //formulario.Paint += new PaintEventHandler((sender1, e1) => OnPaint(e1));




            TextboxHeight(formulario);
            FocusTxt(formulario, "Crear", estilo);
            ComboHeight(formulario);

        }

        public static void Grid(DataGridView grilla, bool ordenar, string estilo, bool multiseleccion)
        {
            CargoPrivateFontCollection();
            try
            {
                if (estilo == "Golden")
                {
                    //if (e.RowIndex == -1)
                    //    return;

                    grilla.EnableHeadersVisualStyles = false;
                    grilla.AllowUserToAddRows = false;
                    grilla.AllowUserToDeleteRows = false;
                    grilla.AllowUserToResizeRows = false;
                    grilla.AllowUserToOrderColumns = false;
                    grilla.ReadOnly = true;
                    grilla.MultiSelect = false;
                    grilla.RowHeadersVisible = false;
                    grilla.RowHeadersWidth = 31;
                    grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    grilla.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(231, 231, 231);
                    grilla.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                    grilla.RowHeadersDefaultCellStyle.Font = new Font("Tahoma", 7.6F); //new Font("SAP-icons", 10);
                    grilla.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    grilla.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(194, 200, 205);
                    grilla.RowHeadersDefaultCellStyle.SelectionForeColor = Color.Black;

                    grilla.BackgroundColor = Color.FromArgb(231, 231, 231);
                    grilla.BackColor = Color.FromArgb(231, 231, 231);
                    grilla.GridColor = Color.FromArgb(204, 204, 204);
                    grilla.DefaultCellStyle.BackColor = Color.FromArgb(231, 231, 231);
                    grilla.DefaultCellStyle.ForeColor = Color.Black;
                    grilla.DefaultCellStyle.Font = new Font("Tahoma", 7.6F);//new Font("SAP-icons", 8);
                    grilla.RowTemplate.Height = 16;
                    grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(231, 231, 231);
                    grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                    grilla.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                    grilla.ColumnHeadersHeight = 16;
                    grilla.DefaultCellStyle.SelectionBackColor = Color.FromArgb(252, 221, 130);
                    grilla.DefaultCellStyle.SelectionForeColor = Color.Black;


                    grilla.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top);
                    //grilla.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(231, 231, 231);
                    //grilla.Columns[0].DefaultCellStyle.SelectionBackColor = Color.FromArgb(194, 200, 205);

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

                if (estilo == "Fiori")
                {

                    grilla.AllowUserToAddRows = false;
                    grilla.AllowUserToDeleteRows = false;
                    grilla.AllowUserToResizeRows = false;
                    grilla.ReadOnly = true;
                    grilla.RowHeadersVisible = false;
                    grilla.RowHeadersWidth = 31;
                    grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    grilla.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(231, 231, 231);
                    grilla.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                    grilla.RowHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8);
                    grilla.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    grilla.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(194, 200, 205);
                    grilla.RowHeadersDefaultCellStyle.SelectionForeColor = Color.Black;

                    grilla.BackgroundColor = Color.FromArgb(231, 231, 231);
                    grilla.BackColor = Color.FromArgb(231, 231, 231);
                    grilla.GridColor = Color.FromArgb(204, 204, 204);
                    grilla.DefaultCellStyle.BackColor = Color.FromArgb(231, 231, 231);
                    grilla.DefaultCellStyle.ForeColor = Color.Black;
                    grilla.DefaultCellStyle.Font = new Font("Segoe UI", 7.4F);
                    grilla.RowTemplate.Height = 16;
                    grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(231, 231, 231);
                    grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                    grilla.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                    grilla.ColumnHeadersHeight = 16;
                    grilla.DefaultCellStyle.SelectionBackColor = Color.FromArgb(181, 213, 253);
                    grilla.DefaultCellStyle.SelectionForeColor = Color.Black;

                    //grilla.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(231, 231, 231);
                    //grilla.Columns[0].DefaultCellStyle.SelectionBackColor = Color.FromArgb(194, 200, 205);

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

                if (estilo == "Change")
                {
                    //if (e.RowIndex == -1)
                    //    return;

                    //grilla.EnableHeadersVisualStyles = false;
                    //grilla.AllowUserToAddRows = false;
                    //grilla.AllowUserToDeleteRows = false;
                    //grilla.AllowUserToResizeRows = false;
                    //grilla.AllowUserToOrderColumns = false;
                    //grilla.ReadOnly = true;
                    //grilla.MultiSelect = false;
                    //grilla.RowHeadersVisible = false;
                    grilla.RowHeadersWidth = 31;
                    grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    grilla.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(231, 231, 231);
                    grilla.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                    grilla.RowHeadersDefaultCellStyle.Font = new Font("Tahoma", 7.6F); //new Font("SAP-icons", 10);
                    grilla.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    grilla.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(194, 200, 205);
                    grilla.RowHeadersDefaultCellStyle.SelectionForeColor = Color.Black;

                    grilla.BackgroundColor = Color.FromArgb(231, 231, 231);
                    grilla.BackColor = Color.FromArgb(231, 231, 231);
                    grilla.GridColor = Color.FromArgb(204, 204, 204);
                    grilla.DefaultCellStyle.BackColor = Color.FromArgb(231, 231, 231);
                    grilla.DefaultCellStyle.ForeColor = Color.Black;
                    grilla.DefaultCellStyle.Font = new Font("Tahoma", 7.6F);//new Font("SAP-icons", 8);
                    grilla.RowTemplate.Height = 16;
                    grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(231, 231, 231);
                    grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                    grilla.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                    grilla.ColumnHeadersHeight = 16;
                    grilla.DefaultCellStyle.SelectionBackColor = Color.FromArgb(252, 221, 130);
                    grilla.DefaultCellStyle.SelectionForeColor = Color.Black;


                    grilla.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top);
                    //grilla.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(231, 231, 231);
                    //grilla.Columns[0].DefaultCellStyle.SelectionBackColor = Color.FromArgb(194, 200, 205);

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

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error debido a: " + ex.ToString());
            }
        }

        #region METODOS PARA CERRAR,MAXIMIZAR, MINIMIZAR FORMULARIO-----------------------------------------------

        static int lx, ly;
        static int sw, sh;

        private static void btnClose_Click(object sender, EventArgs e, Form form, string TipoClose)
        {

            if (MessageBox.Show("¿Está seguro de cerrar?", "Mensaje sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                //if (TipoClose == "Exit")
                //    Application.Exit();
                //if (TipoClose == "Close")
                //    form.Close();


                //Menu frmMenu = new Menu();
                //frmMenu.Show();
                form.Close();


            }

        }

        private static void btnMax_Click(object sender, EventArgs e, Form form, Button btnMax, Button btnRes, Button btnClose, Button btnMin)
        {

            lx = form.Location.X;
            ly = form.Location.Y;
            sw = form.Size.Width;
            sh = form.Size.Height;
            form.Size = Screen.PrimaryScreen.WorkingArea.Size;
            form.Location = Screen.PrimaryScreen.WorkingArea.Location;

            btnMax.Visible = false;
            btnRes.Visible = true;

            //btnRes.Location = new Point(form.Width - 55, 1);
            //btnClose.Location = new Point(form.Width - 40, 1);
            //btnMin.Location = new Point(form.Width - 80, 1);

            btnRes.Location = new Point(form.Width - 60, 1);
            btnClose.Location = new Point(form.Width - 40, 1);
            btnMax.Location = new Point(form.Width - 60, 1);
            btnMin.Location = new Point(form.Width - 80, 1);


        }

        private static void btnRes_Click(object sender, EventArgs e, Form form, Button btnMax, Button btnRes, Button btnClose, Button btnMin)
        {
            form.Size = new Size(sw, sh);
            form.Location = new Point(lx, ly);
            btnRes.Visible = false;
            btnMax.Visible = true;

            //btnRes.Location = new Point(form.Width - 55, 1);
            //btnClose.Location = new Point(form.Width - 40, 1);
            //btnMin.Location = new Point(form.Width - 80, 1);
            
            
            btnRes.Location = new Point(form.Width - 60, 1);
            btnClose.Location = new Point(form.Width - 40, 1);
            btnMax.Location = new Point(form.Width - 60, 1);
            btnMin.Location = new Point(form.Width - 80, 1);

        }

        private static void btnMin_Click(object sender, EventArgs e, Form form, string titulo, Button btn, Button btn1, Button btn2, Button btn3)
        {
            form.WindowState = FormWindowState.Minimized;
            form.StartPosition = FormStartPosition.CenterScreen;


        }

        #endregion

        #region METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private static void PanelBarraTitulo_MouseDown(object sender, MouseEventArgs e, IntPtr FormHandle)
        {
            ReleaseCapture();
            SendMessage(FormHandle, 0x112, 0xf012, 0);
        }

        #endregion

        #region METODO PARA CAMBIAR LA ALTURA DE COMBOBOX---------------------------------------------------------------------

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const int CB_SETITEMHEIGHT = 0x153;

        public static void ComboHeight(Control parent)
        {
            foreach (Control c in parent.Controls)
            {

                if (c is ComboBox)
                {
                    SetComboBoxHeight(c.Handle, 12);
                    c.Refresh();

                }
                if (c.Controls.Count > 0)
                {

                    ComboHeight(c);

                }
            }

        }

        private static void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
        }

        #endregion

        #region METODO PARA CAMBIAR LA ALTURA DE TEXTBOX---------------------------------------------------------------------

        public static void TextboxHeight(Control parent)
        {
            foreach (Control c in parent.Controls)
            {

                if (c is TextBoxBase)
                {
                    c.AutoSize = false;
                    //c.Height = 17;
                    if (!c.Name.Contains("Comentario")) c.Height = 17;
                    c.Font = new Font("Tahoma", 7.6F);//new Font("SAP-icons", 8.5F);
                    ((TextBoxBase)c).BorderStyle = BorderStyle.FixedSingle;
                    c.Refresh();


                }
                if (c.Controls.Count > 0)
                {

                    TextboxHeight(c);

                }
            }

        }

        #endregion

        #region METODO PARA CAMBIAR EL BACKCOLOR DE TEXTBOX AL TENER EL FOCO-----------------------------------------------------------

        public static void FocusTxt(Control contenedor, string modo, string estilo)
        {
            foreach (Control c in contenedor.Controls)
            {
                if (c.Controls.Count > 0) FocusTxt(c, modo, estilo);
                else
                {
                    try
                    {
                        var lastColorSaved = Color.Empty;


                        if (c is TextBoxBase)
                        {

                            c.Enter += (s, e) =>
                            {
                                //if (((TextBoxBase)c).ReadOnly == false)
                                // {
                                var control = (Control)s;

                                if (estilo == "Golden") control.BackColor = Color.FromArgb(254, 240, 158);
                                if (estilo == "Fiori") control.BackColor = Color.FromArgb(235, 247, 254);
                                //}


                            };
                            c.Leave += (s, e) =>
                            {
                                //if (c.ReadOnly == false)
                                //  {
                                var control = (Control)s;
                                control.BackColor = lastColorSaved;
                                control.Controls.Clear();
                                //}
                            };

                        }



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());

                    }
                }
            }
        }

        #endregion

        ////----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        // private static void OnSizeChanged(EventArgs e, Panel panel, Form formulario)
        //{
        //    var region = new Region(new Rectangle(0, 0, formulario.ClientRectangle.Width, formulario.ClientRectangle.Height));

        //    sizeGripRectangle = new Rectangle(formulario.ClientRectangle.Width - tolerance, formulario.ClientRectangle.Height - tolerance, tolerance, tolerance);

        //    region.Exclude(sizeGripRectangle);
        //    panel.Region = region;
        //    formulario.Invalidate();
        //}
        ////----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        //private static void OnPaint(PaintEventArgs e)
        //{

        //    SolidBrush blueBrush = new SolidBrush(Color.FromArgb(247, 247, 247));

        //    e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

        //    ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        //}


        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        public static FontFamily ff;
        public static Font Fuente;

        public static void CargoPrivateFontCollection()
        {
            // CREO EL BYTE[] Y TOMO SU LONGITUD
            byte[] fontArray = Properties.Resources._72_Regular;
            int dataLength = Properties.Resources._72_Regular.Length;


            // ASIGNO MEMORIA Y COPIO BYTE[] EN LA DIRECCION
            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontArray, 0, ptrData, dataLength);


            uint cFonts = 0;
            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            PrivateFontCollection pfc = new PrivateFontCollection();
            //PASO LA FUENTE A LA PRIVATEFONTCOLLECTION
            pfc.AddMemoryFont(ptrData, dataLength);

            //LIBERO LA MEMORIA "UNSAFE"
            Marshal.FreeCoTaskMem(ptrData);

            ff = pfc.Families[0];
            //font = new Font(ff, 8f, FontStyle.Regular);
        }

        public static void mensaje(string msg, bool tipo, ToolStripStatusLabel lmsg, StatusStrip sload, Timer tmsg, ToolStripStatusLabel tslBDSAP)
        {
            //tipo true=exito false=error


            if (tipo == true)
            {


                lmsg.Visible = true;
                tslBDSAP.Visible = false;
                lmsg.BackgroundImage = Properties.Resources.statussuccess;
                sload.BackColor = Color.FromArgb(127, 182, 123);
                lmsg.ForeColor = Color.Black;
                lmsg.Text = "     " + msg;
                tmsg.Start();

            }

            if (tipo == false)
            {
                lmsg.Visible = true;
                tslBDSAP.Visible = false;
                lmsg.BackgroundImage = Properties.Resources.statuserror;
                sload.BackColor = Color.FromArgb(204, 0, 0);
                lmsg.ForeColor = Color.White;
                lmsg.Text = "     " + msg;
                tmsg.Start();
            }




        }

        public static void mensaje_espera(string msg, ToolStripStatusLabel lmsg, StatusStrip sload, bool show)
        {

            //lcontador.Visible = !show;
            lmsg.Visible = show;
            lmsg.BackgroundImage = Properties.Resources.statuswarning;
            if (show == true)
            {
                sload.BackColor = Color.FromArgb(159, 177, 203);
            }
            else
            {
                sload.BackColor = Color.Transparent;
            }
            lmsg.ForeColor = Color.Black;
            lmsg.Text = "     " + msg;


        }

    }
}

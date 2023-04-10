
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Kursovaya
{

    public partial class Izmenenie : Form
    {
        public class LibWrap
        {
            [DllImport("Kernel32.dll")]
            public static extern void GetLocalTime([In, Out] SystemTime st);
        }

        [StructLayout(LayoutKind.Sequential)]
        public class SystemTime
        {
            public ushort year;
            public ushort month;
            public ushort weekday;
            public ushort day;
            public ushort hour;
            public ushort minute;
            public ushort second;
            public ushort millisecond;
        } 

        public static string izm_num;
        public static string connStr = "server=127.0.0.1;user=root;database=obshaga;password=mysql";
        public MySqlConnection conn = new MySqlConnection(connStr);

        public Izmenenie()
        {
            InitializeComponent();

            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView1.Rows.Clear();
            try
            {
                conn.Open();
            }
            catch
            {

            }
            String roomnum = textBox1.Text;
            String FIO = textBox2.Text;

            string query = "SELECT * FROM rooms where Room_num LIKE \'" + roomnum + "\' ";

            MySqlCommand command = new MySqlCommand(query, conn);

            MySqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[8]);

                data[data.Count - 1][0] = reader.GetString(0);
                data[data.Count - 1][1] = reader.GetString(1);
                data[data.Count - 1][2] = reader.GetString(2);
                data[data.Count - 1][3] = reader.GetString(5);
                data[data.Count - 1][4] = reader.GetString(6);
            }

            reader.Close();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
            if (textBox1.Text == "")
            {
                reader.Close();
                string queryZ = "SELECT * FROM rooms where FIO LIKE \'%" + FIO + "%\' ";

                MySqlCommand commandZ = new MySqlCommand(queryZ, conn);

                MySqlDataReader readerZ = commandZ.ExecuteReader();
                List<string[]> dataZ = new List<string[]>();
                while (readerZ.Read())
                {
                    dataZ.Add(new string[8]);

                    dataZ[dataZ.Count - 1][0] = readerZ.GetString(0);
                    dataZ[dataZ.Count - 1][1] = readerZ.GetString(1);
                    dataZ[dataZ.Count - 1][2] = readerZ.GetString(2);
                    dataZ[dataZ.Count - 1][3] = readerZ.GetString(5);
                    dataZ[dataZ.Count - 1][4] = readerZ.GetString(6);
                }

                readerZ.Close();
                foreach (string[] s in dataZ)
                    dataGridView1.Rows.Add(s);
            }

        }

        private void Izmenenie_Load(object sender, EventArgs e)
        {
            SystemTime st = new SystemTime();
            LibWrap.GetLocalTime(st);
            label4.Text = st.day.ToString() + "." + st.month.ToString() + "." + st.year.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f1 = new Glavnaya();
            f1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string delet = dataGridView1.SelectedCells[3].Value.ToString();
            string query = "DELETE FROM rooms where Treaty_num = '" + delet + "'";
            string query1 = "UPDATE archive SET Vyselenie_date = '" + label4.Text + "' WHERE Treaty_num = '" + delet + "'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlCommand cmd1 = new MySqlCommand(query1, conn);
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var izm = dataGridView1.SelectedCells[3].Value.ToString();
            izm_num = izm;
            Form fch = new Change();
            fch.Show();
            this.Hide();
        }


    }
    public class RoundButton : Control
    {
        public Color BackColor2 { get; set; }
        public Color ButtonBorderColor { get; set; }
        public int ButtonRoundRadius { get; set; }

        public Color ButtonHighlightColor { get; set; }
        public Color ButtonHighlightColor2 { get; set; }
        public Color ButtonHighlightForeColor { get; set; }

        public Color ButtonPressedColor { get; set; }
        public Color ButtonPressedColor2 { get; set; }
        public Color ButtonPressedForeColor { get; set; }

        private bool IsHighlighted;
        private bool IsPressed;

        public RoundButton()
        {
            Size = new Size(100, 40);
            ButtonRoundRadius = 30;
            BackColor = Color.Gainsboro;
            BackColor2 = Color.Silver;
            ButtonBorderColor = Color.Black;
            ButtonHighlightColor = Color.Orange;
            ButtonHighlightColor2 = Color.OrangeRed;
            ButtonHighlightForeColor = Color.Black;

            ButtonPressedColor = Color.Red;
            ButtonPressedColor2 = Color.Maroon;
            ButtonPressedForeColor = Color.White;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                return createParams;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            var foreColor = IsPressed ? ButtonPressedForeColor : IsHighlighted ? ButtonHighlightForeColor : ForeColor;
            var backColor = IsPressed ? ButtonPressedColor : IsHighlighted ? ButtonHighlightColor : BackColor;
            var backColor2 = IsPressed ? ButtonPressedColor2 : IsHighlighted ? ButtonHighlightColor2 : BackColor2;


            using (var pen = new Pen(ButtonBorderColor, 1))
                e.Graphics.DrawPath(pen, Path);

            using (var brush = new LinearGradientBrush(ClientRectangle, backColor, backColor2, LinearGradientMode.Vertical))
                e.Graphics.FillPath(brush, Path);

            using (var brush = new SolidBrush(foreColor))
            {
                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                var rect = ClientRectangle;
                rect.Inflate(-4, -4);
                e.Graphics.DrawString(Text, Font, brush, rect, sf);
            }

            base.OnPaint(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            IsHighlighted = true;
            Parent.Invalidate(Bounds, false);
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            IsHighlighted = false;
            IsPressed = false;
            Parent.Invalidate(Bounds, false);
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Parent.Invalidate(Bounds, false);
            Invalidate();
            IsPressed = true;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Parent.Invalidate(Bounds, false);
            Invalidate();
            IsPressed = false;
        }

        protected GraphicsPath Path
        {
            get
            {
                var rect = ClientRectangle;
                rect.Inflate(-1, -1);
                return GetRoundedRectangle(rect, ButtonRoundRadius);
            }
        }

        public static GraphicsPath GetRoundedRectangle(Rectangle rect, int d)
        {
            var gp = new GraphicsPath();

            gp.AddArc(rect.X, rect.Y, d, d, 180, 90);
            gp.AddArc(rect.X + rect.Width - d, rect.Y, d, d, 270, 90);
            gp.AddArc(rect.X + rect.Width - d, rect.Y + rect.Height - d, d, d, 0, 90);
            gp.AddArc(rect.X, rect.Y + rect.Height - d, d, d, 90, 90);
            gp.CloseFigure();

            return gp;
        }
    }
}



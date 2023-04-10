using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya
{
    public partial class Change : Form
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
        public static string connStr = "server=127.0.0.1;user=root;database=obshaga;password=mysql";
        public MySqlConnection conn = new MySqlConnection(connStr);
        public Change()
        {
            InitializeComponent();
            conn.Open();
        }

        private void Change_Load(object sender, EventArgs e)
        {
            SystemTime st = new SystemTime();
            LibWrap.GetLocalTime(st);
            label1.Text = st.day.ToString() + "." + st.month.ToString() + "." + st.year.ToString();

            string query = "SELECT * FROM rooms WHERE Treaty_num LIKE '" + Izmenenie.izm_num + "'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader.GetString(0);
                textBox2.Text = reader.GetString(1);
                textBox3.Text = reader.GetString(2);
            }

            reader.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f1 = new Glavnaya();
            f1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String roomnum = textBox1.Text;
            String FIO = textBox2.Text;
            String status = textBox3.Text;
           

            string query = "UPDATE rooms SET Room_num = '" + roomnum + "', FIO = '" + FIO + "', Status = '" + status + "', Vyselenie_date = 0  WHERE Treaty_num = '"+ Izmenenie.izm_num +"'";
            string query1 = "UPDATE archive SET Room_num = '" + roomnum + "', FIO = '" + FIO + "', Status = '" + status + "', Vyselenie_date = 0  WHERE Treaty_num = '" + Izmenenie.izm_num + "'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlCommand cmd1 = new MySqlCommand(query1, conn);
            cmd1.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
        }
    }
}

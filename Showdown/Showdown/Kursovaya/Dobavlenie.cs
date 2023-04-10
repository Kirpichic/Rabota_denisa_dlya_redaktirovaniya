using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya
{
    public partial class Dobavlenie : Form
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

        
        public Dobavlenie()
        {
            InitializeComponent();

            conn.Open();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SystemTime st = new SystemTime();
            LibWrap.GetLocalTime(st);
            label1.Text = st.day.ToString() + "." + st.month.ToString() + "." + st.year.ToString();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            String roomnum = comboBox1.Text;
            String FIO = textBox2.Text;
            String status = textBox3.Text;
            int Vil_count = Convert.ToInt32(textBox4.Text);
            String Vil_max = textBox5.Text;
            String Zaselenie_date = label1.Text;
            Vil_count += 1;
            string query = "INSERT INTO rooms ( Room_num, FIO, Status, Vil_count, Vil_max, Zaselenie_date, Vyselenie_date) VALUES ('"+ roomnum +"', '"+ FIO +"', '"+ status +"','"+ Vil_count +"','"+ Vil_max +"','"+ Zaselenie_date +"', 0 )";
            string query1 = "INSERT INTO archive ( Room_num, FIO, Status, Vil_count, Vil_max, Zaselenie_date, Vyselenie_date) VALUES ('" + roomnum + "', '" + FIO + "', '" + status + "','" + Vil_count + "','" + Vil_max + "','" + Zaselenie_date + "', 0 )";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlCommand cmd1 = new MySqlCommand(query1, conn);
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f1 = new Glavnaya();
            f1.Show();
            this.Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox5.Text == textBox4.Text)
            {
                label8.Text = "В этой комнате максимальное количество жильцов!";
                label8.ForeColor = Color.Red;
                button1.BackColor = Color.Gray;
                button1.Enabled = false;

            }
            else 
            {
                button1.BackColor = Color.PaleTurquoise;
                button1.Enabled = true;
                label8.Text = "";
            }
            if ((comboBox1.Text != "" && textBox5.Text != textBox4.Text)) 
            {
                label8.Text = "В этой комнате достаточно мест.";
                label8.ForeColor = Color.Green;
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String roomnum = comboBox1.Text;
            string query = "SELECT * from zhitelxrooms WHERE Room_num LIKE '" + roomnum + "'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox5.Text = reader.GetString(1);
            }

            reader.Close();

            string query1 = "SELECT COUNT(Room_num) from rooms WHERE Room_num LIKE '" + roomnum + "'";
            MySqlCommand cmd1 = new MySqlCommand(query1, conn);
            cmd1.ExecuteNonQuery();
            var Vil_count = cmd1.ExecuteScalar().ToString();


            textBox4.Text = System.Convert.ToString(Vil_count);

        }
    }
}

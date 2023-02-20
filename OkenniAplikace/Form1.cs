using System.Data.SqlClient;

namespace OkenniAplikace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string jmeno = textBox1.Text;
            string prijmeni = textBox2.Text;
            string datum = textBox3.Text;
            string plat = textBox4.Text;

            SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();
            consStringBuilder.UserID = "sa";
            consStringBuilder.Password = "student";
            consStringBuilder.InitialCatalog = "pv";
            consStringBuilder.DataSource = "PC972";
            consStringBuilder.ConnectTimeout = 30;
            try
            {
                using (SqlConnection connection = new SqlConnection(consStringBuilder.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Pripojeno");
                    
                    string query = "INSERT INTO Zamestnanec(jmeno,prijmeni,datum_narozeni,plat) values(@par1,@par2,@par3,@par4)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@par1", jmeno);
                        command.Parameters.AddWithValue("@par2", prijmeni);
                        command.Parameters.AddWithValue("@par3", datum);
                        command.Parameters.AddWithValue("@par4", plat);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();
            consStringBuilder.UserID = "sa";
            consStringBuilder.Password = "student";
            consStringBuilder.InitialCatalog = "pv";
            consStringBuilder.DataSource = "PC972";
            consStringBuilder.ConnectTimeout = 30;
            try
            {
                using (SqlConnection connection = new SqlConnection(consStringBuilder.ConnectionString))
                {
                    connection.Open();

                    string query2 = "select * from Zamestnanec";
                    using (SqlCommand command = new SqlCommand(query2, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                           label5.Text+= "\n " + reader[1] + " " + reader[2] + ", Datum narození: " + reader[3].ToString() + ", Plat: " + reader[4].ToString() + ",-";
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurs_Zavolozhin
{
    public partial class MainWindow : Form
    {
        SqlDataAdapter adapter;
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public MainWindow()
        {
            InitializeComponent();
            UpdateAll();
        }
        private void UpdateAll()
        {
            ShowClients();
            ShowMaterial();
            ShowPersonel();
            ShowCeh();
            FillMaterialBox();
            FillPersonelBox();
            ShowOrder();
            FillClientBox();
            ShowBuh();
            ShowGoods();
            FillCehBox();
            ShowSpis();
            FillGoodsBox();
            ShowPrice();
            ShowSklad();
            FillSkladBox();
            ShowUchet();
            FillZakazBox();
            ShowReal();

        }

        private void ShowClients()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("select * from Клиент", connection);
                adapter.Fill(dt);
                ClientsTable.DataSource = dt;
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (textBox5.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("insert into Клиент values(@Фамилия,@Имя,@Отчество,@ИНН)", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Фамилия", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Имя", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Отчество", textBox4.Text);
                    cmd.Parameters.AddWithValue("@ИНН", textBox5.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox1.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("delete from Клиент where Id_Клиента=@Id_Клиента", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_Клиента", textBox1.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите Id");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (textBox5.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("update Клиент set Фамилия=@Фамилия,Имя=@Имя,Отчество=@Отчество,Инн=@Инн where Id_Клиента=@Id_Клиента", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_Клиента", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Фамилия", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Имя", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Отчество", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Инн", textBox5.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }
        
        private void ShowMaterial()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("Select * from Сырье", connection);
                adapter.Fill(dt);
                MaterialTable.DataSource = dt;
                connection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox6.Text != "") && (textBox7.Text != "") && (textBox8.Text != "") && (textBox9.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("insert into Сырье values(@Наименование,@Количество,@Единица_измерения,@Стоимость,@Дата_поступления)", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Наименование", textBox9.Text);
                    cmd.Parameters.AddWithValue("@Количество", int.Parse(textBox8.Text));
                    cmd.Parameters.AddWithValue("@Единица_измерения", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Стоимость", double.Parse(textBox6.Text));
                    cmd.Parameters.AddWithValue("@Дата_поступления", dateTimePicker1.Value.ToShortDateString());
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox10.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("delete from Сырье where Id_Сырья=@Id_Сырья", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_Сырья", textBox10.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите Id сырья");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox6.Text != "") && (textBox7.Text != "") && (textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("update Сырье set Наименование=@Наименование,Количество=@Количество,Единица_изм=@Единица_изм,Стоимость_за_штуку=@Стоимость_за_штуку,Дата_поступления=@Дата_поступления where Id_Сырья=@Id_Сырья", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_Сырья", textBox10.Text);
                    cmd.Parameters.AddWithValue("@Наименование", textBox9.Text);
                    cmd.Parameters.AddWithValue("@Количество", textBox8.Text);
                    cmd.Parameters.AddWithValue("@Единица_изм", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Стоимость_за_штуку", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Дата_поступления", dateTimePicker1.Value.ToShortDateString());
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }
    
        private void ShowPersonel()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("select * from Персонал", connection);
                adapter.Fill(dt);
                PersonTable.DataSource = dt;
                connection.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox11.Text != "") && (textBox12.Text != "") && (textBox13.Text != "") && (textBox14.Text != "") && (textBox61.Text != "")
                    && (textBox62.Text != "") && (textBox63.Text != "") && (textBox64.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("insert into Персонал values(@Фамилия,@Имя,@Отчество,@Стаж,@Должность,@ЗП,@Адрес,@Телефон)", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Фамилия", textBox14.Text);
                    cmd.Parameters.AddWithValue("@Имя", textBox13.Text);
                    cmd.Parameters.AddWithValue("@Отчество", textBox12.Text);
                    cmd.Parameters.AddWithValue("@Стаж", textBox11.Text);
                    cmd.Parameters.AddWithValue("@Должность", textBox61.Text);
                    cmd.Parameters.AddWithValue("@ЗП", double.Parse(textBox62.Text));
                    cmd.Parameters.AddWithValue("@Адрес", textBox63.Text);
                    cmd.Parameters.AddWithValue("@Телефон", textBox64.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox15.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("delete from Персонал where Id_Работника=@Id_Работника", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_Работника", textBox15.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox11.Text != "") && (textBox12.Text != "") && (textBox13.Text != "") && (textBox14.Text != "") && (textBox61.Text != "")
                        && (textBox62.Text != "") && (textBox63.Text != "") && (textBox64.Text != "") && (textBox15.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("update Персонал set Фамилия=@Фамилия,Имя=@Имя,Отчество=@Отчество," +
                        "Стаж=@Стаж,Должность=@Должность,ЗП=@ЗП,Адрес=@Адрес,Телефон=@Телефон where Id_Работника=@Id_Работника", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Фамилия", textBox14.Text);
                    cmd.Parameters.AddWithValue("@Имя", textBox13.Text);
                    cmd.Parameters.AddWithValue("@Отчество", textBox12.Text);
                    cmd.Parameters.AddWithValue("@Стаж", textBox11.Text);
                    cmd.Parameters.AddWithValue("@Должность", textBox61.Text);
                    cmd.Parameters.AddWithValue("@ЗП", textBox62.Text);
                    cmd.Parameters.AddWithValue("@Адрес", textBox63.Text);
                    cmd.Parameters.AddWithValue("@Телефон", textBox64.Text);
                    cmd.Parameters.AddWithValue("@Id_Работника", textBox15.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }
    
        private void ShowCeh()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("select Id_Цеха,Цех.Id_Сырья,Сырье.Наименование,Сырье.Дата_поступления,Сырье.Количество,Сырье.Единица_изм,Персонал.Id_Работника," +
                    "Персонал.Фамилия,Персонал.Имя,Персонал.Отчество,Персонал.Должность from Цех" +
                    " join Сырье on Цех.Id_Сырья = Сырье.Id_Сырья join Персонал on Цех.Id_Работника = Персонал.Id_Работника", connection);
                adapter.Fill(dt);
                CehTable.DataSource = dt;
                connection.Close();
            }
        }
        
        private void FillMaterialBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select Id_Сырья, Наименование from Сырье", connection);
                connection.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Сырье");
                comboBox1.ValueMember = "Id_Сырья";
                comboBox1.DisplayMember = "Наименование";
                comboBox1.DataSource = ds.Tables["Сырье"];
            }
        }
        
        private void FillPersonelBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select Id_Работника, Фамилия from Персонал", connection);
                connection.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Персонал");
                comboBox2.ValueMember = "Id_Работника";
                comboBox2.DisplayMember = "Фамилия";
                comboBox2.DataSource = ds.Tables["Персонал"];
                comboBox4.ValueMember = "Id_Работника";
                comboBox4.DisplayMember = "Фамилия";
                comboBox4.DataSource = ds.Tables["Персонал"];
                comboBox12.ValueMember = "Id_Работника";
                comboBox12.DisplayMember = "Фамилия";
                comboBox12.DataSource = ds.Tables["Персонал"];
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("insert into Цех values(@Id_Сырья,@Id_Работника)", connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@Id_Сырья", comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@Id_Работника", comboBox2.SelectedValue);
                cmd.ExecuteNonQuery();
                connection.Close();
                UpdateAll();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox20.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("delete from Цех where Id_Цеха=@Id_Цеха", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_Цеха", textBox20.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox20.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("update Цех set Id_Сырья=@Id_Сырья,Id_Работника=@Id_Работника where Id_Цеха=@Id_Цеха", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_Сырья", comboBox1.SelectedValue);
                    cmd.Parameters.AddWithValue("@Id_Работника", comboBox2.SelectedValue);
                    cmd.Parameters.AddWithValue("@Id_Цеха", textBox20.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }
    
        private void ShowOrder()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("Select Id_Заказа,Заказ.Наименование,Заказ.Количество,Заказ.Стоимость,Заказ.Дата_заказа," +
                    "Клиент.Id_Клиента,Клиент.Имя,Клиент.Фамилия,Клиент.Отчество from Заказ join Клиент On Заказ.Id_Клиента = Клиент.Id_Клиента", connection);
                adapter.Fill(dt);
                OrderTable.DataSource = dt;
                connection.Close();
            }
        }
        private void FillClientBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select Id_Клиента, Фамилия from Клиент", connection);
                connection.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Клиент");
                comboBox3.ValueMember = "Id_Клиента";
                comboBox3.DisplayMember = "Фамилия";
                comboBox3.DataSource = ds.Tables["Клиент"];
                comboBox7.ValueMember = "Id_Клиента";
                comboBox7.DisplayMember = "Фамилия";
                comboBox7.DataSource = ds.Tables["Клиент"];
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox23.Text != "") && (textBox21.Text != "") && (textBox16.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("insert into Заказ values(@Id_клиента,@Наименование,@Дата_заказа,@Количество,@Стоимость)", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_клиента", comboBox3.SelectedValue);
                    cmd.Parameters.AddWithValue("@Наименование", textBox23.Text);
                    cmd.Parameters.AddWithValue("@Дата_заказа", dateTimePicker2.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Количество", textBox21.Text);
                    cmd.Parameters.AddWithValue("@Стоимость", textBox16.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox25.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("delete from Заказ where Id_Заказа=@Id_Заказа", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_Заказа", textBox25.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите Id");
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox25.Text != "") && (textBox23.Text != "") && (textBox21.Text != "") && (textBox16.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("update Заказ set Id_Клиента=@Id_Клиента,Наименование=@Наименование,Дата_Заказа=@Дата_Заказа,Количество=@Количество," +
                        " Стоимость=@Стоимость where Id_заказа=@Id_заказа", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_клиента", comboBox3.SelectedValue);
                    cmd.Parameters.AddWithValue("@Наименование", textBox23.Text);
                    cmd.Parameters.AddWithValue("@Дата_заказа", dateTimePicker2.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Количество", textBox21.Text);
                    cmd.Parameters.AddWithValue("@Стоимость", textBox16.Text);
                    cmd.Parameters.AddWithValue("@Id_заказа", textBox25.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }
    
        private void ShowBuh()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("select Id_Ведомости,Бухгалтерия.Id_Работника,Фамилия,Имя,Отчество,Должность," +
                    "Наименование_товара,Цена_товара,Дата_поступления,Дата_реализации from Бухгалтерия " +
                    "join Персонал on Бухгалтерия.Id_Работника = Персонал.Id_Работника", connection);
                adapter.Fill(dt);
                BuhTable.DataSource = dt;
                connection.Close();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox27.Text != "") && (textBox28.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("insert into Бухгалтерия values(@Id_Работника,@Наим_Товара,@Цена_Товара,@Дата_Поступ,@Дата_реализации)", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_Работника", comboBox4.SelectedValue);
                    cmd.Parameters.AddWithValue("@Наим_Товара", textBox28.Text);
                    cmd.Parameters.AddWithValue("@Цена_Товара", double.Parse(textBox27.Text));
                    cmd.Parameters.AddWithValue("@Дата_Поступ", dateTimePicker3.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Дата_реализации", dateTimePicker4.Value.ToShortDateString());
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox30.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("delete from Бухгалтерия where Id_ведомости=@Id_ведомости", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_ведомости", textBox30.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите Id");
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox27.Text != "") && (textBox28.Text != "") && (textBox30.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("update Бухгалтерия set Id_Работника=@Id_Работника,Наименование_товара=@Наименование_товара,Цена_товара=@Цена_товара," +
                        "Дата_поступления=@Дата_поступления,Дата_реализации=@Дата_реализации where Id_ведомости=@Id_ведомости", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_Работника", comboBox4.SelectedValue);
                    cmd.Parameters.AddWithValue("@Наименование_товара", textBox28.Text);
                    cmd.Parameters.AddWithValue("@Цена_товара", double.Parse(textBox27.Text));
                    cmd.Parameters.AddWithValue("@Дата_поступления", dateTimePicker3.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Дата_реализации", dateTimePicker4.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Id_ведомости", textBox30.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }
    
        private void ShowGoods()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("select * from Готовая_продукция", connection);
                adapter.Fill(dt);
                GoodsTable.DataSource = dt;
                connection.Close();
            }
        }

        private void FillCehBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select Id_Цеха from Цех", connection);
                connection.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Цех");
                comboBox5.ValueMember = "Id_Цеха";
                comboBox5.DisplayMember = "Id_Цеха";
                comboBox5.DataSource = ds.Tables["Цех"];
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox18.Text != "") && (textBox31.Text != "") && (textBox32.Text != "") && (textBox33.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("insert into Готовая_продукция values(@Id_Цеха,@Наименование,@Количество,@Единица_измерения,@Дата_изготовления,@Цена_за_шт)", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_Цеха", comboBox5.SelectedValue);
                    cmd.Parameters.AddWithValue("@Наименование", textBox33.Text);
                    cmd.Parameters.AddWithValue("@Количество", textBox32.Text);
                    cmd.Parameters.AddWithValue("@Единица_измерения", textBox31.Text);
                    cmd.Parameters.AddWithValue("@Дата_изготовления", dateTimePicker5.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Цена_за_шт", double.Parse(textBox18.Text));
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox35.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("delete from Готовая_продукция where Id_товара=@Id_товара", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_товара", textBox35.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox18.Text != "") && (textBox31.Text != "") && (textBox32.Text != "") && (textBox33.Text != "") && (textBox35.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("update Готовая_продукция set Id_цеха=@Id_цеха,Наименование=@Наименование,Количество=@Количество,Единица_изм=@Единица_изм," +
                        "Дата_изготовления=@Дата_изготовления,Цена_за_шт=@Цена_за_шт where Id_товара=@Id_товара", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_Цеха", comboBox5.SelectedValue);
                    cmd.Parameters.AddWithValue("@Наименование", textBox33.Text);
                    cmd.Parameters.AddWithValue("@Количество", textBox32.Text);
                    cmd.Parameters.AddWithValue("@Единица_изм", textBox31.Text);
                    cmd.Parameters.AddWithValue("@Дата_изготовления", dateTimePicker5.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Цена_за_шт", double.Parse(textBox18.Text));
                    cmd.Parameters.AddWithValue("@Id_товара", textBox35.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }
    
        private void ShowSpis()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("select Id_Списания,Списание.Id_Товара,Готовая_продукция.Наименование,Дата_списания,Списание.Количество " +
                    "from Списание join Готовая_продукция on Списание.Id_Товара = Готовая_продукция.Id_Товара", connection);
                adapter.Fill(dt);
                SpisTable.DataSource = dt;
                connection.Close();
            }
        }

        private void FillGoodsBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select Id_Товара, Наименование from Готовая_продукция", connection);
                connection.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Готовая_продукция");
                comboBox6.ValueMember = "Id_Товара";
                comboBox6.DisplayMember = "Наименование";
                comboBox6.DataSource = ds.Tables["Готовая_продукция"];
                comboBox9.ValueMember = "Id_Товара";
                comboBox9.DisplayMember = "Наименование";
                comboBox9.DataSource = ds.Tables["Готовая_продукция"];
                comboBox11.ValueMember = "Id_Товара";
                comboBox11.DisplayMember = "Наименование";
                comboBox11.DataSource = ds.Tables["Готовая_продукция"];
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox37.Text != "") )
                {
                    SqlCommand cmd = new SqlCommand("insert into Списание values(@Id_товара,@Дата_списания,@Количество)", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_товара", comboBox6.SelectedValue);
                    cmd.Parameters.AddWithValue("@Дата_списания", dateTimePicker6.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Количество", textBox37.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox40.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("delete from Списание where Id_списания=@Id_списания", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_списания", textBox40.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox40.Text != "") && (textBox37.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("update Списание set Id_Товара=@Id_Товара,Дата_списания=@Дата_списания,Количество=@Количество where Id_списания=@Id_списания", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_товара", comboBox6.SelectedValue);
                    cmd.Parameters.AddWithValue("@Дата_списания", dateTimePicker6.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Количество", textBox37.Text);
                    cmd.Parameters.AddWithValue("@Id_списания", textBox40.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }
    
        private void ShowPrice()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("select Id_Прайса,Наименование,Единица_измерения,Цена_за_штуку," +
                    "Прайс_лист.Id_Клиента,Клиент.Фамилия,Клиент.Имя,Клиент.Отчество from Прайс_лист join Клиент On Прайс_лист.Id_Клиента = Клиент.Id_Клиента", connection);
                adapter.Fill(dt);
                PriceTable.DataSource = dt;
                connection.Close();
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox44.Text != "") && (textBox43.Text != "") && (textBox42.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("insert into Прайс_лист values(@Наименование,@Единица_измерения,@Цена_за_штуку,@Id_Клиента)", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_Клиента", comboBox7.SelectedValue);
                    cmd.Parameters.AddWithValue("@Наименование", textBox44.Text);
                    cmd.Parameters.AddWithValue("@Единица_измерения", textBox43.Text);
                    cmd.Parameters.AddWithValue("@Цена_за_штуку", double.Parse(textBox42.Text));            
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox45.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("delete from Прайс_лист where Id_прайса=@Id_прайса", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_прайса", textBox45.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox45.Text != "") && (textBox44.Text != "") && (textBox43.Text != "") && (textBox42.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("update Прайс_лист set Наименование=@Наименование,Единица_измерения=@Единица_измерения," +
                        "Цена_за_штуку=@Цена_за_штуку,Id_Клиента=@Id_Клиента where Id_прайса=@Id_прайса", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_Клиента", comboBox7.SelectedValue);
                    cmd.Parameters.AddWithValue("@Наименование", textBox44.Text);
                    cmd.Parameters.AddWithValue("@Единица_измерения", textBox43.Text);
                    cmd.Parameters.AddWithValue("@Цена_за_штуку", double.Parse(textBox42.Text));
                    cmd.Parameters.AddWithValue("@Id_прайса", textBox45.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }
    
        private void ShowSklad()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("select Id_Склада,Склад.Id_Товара,Готовая_продукция.Наименование,Дата_поступления from Склад join Готовая_продукция on Склад.Id_Товара = Готовая_продукция.Id_Товара", connection);
                adapter.Fill(dt);
                SkladTable.DataSource = dt;
                connection.Close();
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("insert into Склад values(@Id_товара,@Дата_поступления)", connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@Id_товара", comboBox9.SelectedValue);
                cmd.Parameters.AddWithValue("@Дата_поступления", dateTimePicker8.Value.ToShortDateString());
                cmd.ExecuteNonQuery();
                connection.Close();
                UpdateAll();
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox55.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("delete from Склад where Id_Склада=@Id_Склада", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_Склада", textBox55.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox55.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("update Склад set Id_Товара=@Id_Товара,Дата_поступления=@Дата_поступления where Id_Склада=@Id_Склада", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_товара", comboBox9.SelectedValue);
                    cmd.Parameters.AddWithValue("@Дата_поступления", dateTimePicker8.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Id_Склада", textBox55.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }
    
        private void FillSkladBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select Id_Склада from Склад", connection);
                connection.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Склад");
                comboBox8.ValueMember = "Id_Склада";
                comboBox8.DisplayMember = "Id_Склада";
                comboBox8.DataSource = ds.Tables["Склад"];
                comboBox10.ValueMember = "Id_Склада";
                comboBox10.DisplayMember = "Id_Склада";
                comboBox10.DataSource = ds.Tables["Склад"];
            }
        }
    
        private void ShowUchet()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("select * from Карточка_учета", connection);
                adapter.Fill(dt);
                UchetTable.DataSource = dt;
                connection.Close();
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox46.Text != "") && (textBox47.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("insert into Карточка_учета values(@Id_склада,@Дата_реализации,@Реализовано,@Остаток)", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_склада", comboBox8.SelectedValue);
                    cmd.Parameters.AddWithValue("@Реализовано", textBox47.Text);
                    cmd.Parameters.AddWithValue("@Остаток", textBox46.Text);
                    cmd.Parameters.AddWithValue("@Дата_реализации", dateTimePicker7.Value.ToShortDateString());
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox50.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("delete from Карточка_учета where Id_номенклатуры=@Id_номенклатуры", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_номенклатуры", textBox50.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox46.Text != "") && (textBox47.Text != "") && (textBox50.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("update Карточка_учета set Id_Склада=@Id_Склада,Дата_реализации=@Дата_реализации,Реализовано=@Реализовано," +
                        "Остаток=@Остаток where Id_номенклатуры=@Id_номенклатуры", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_склада", comboBox8.SelectedValue);
                    cmd.Parameters.AddWithValue("@Реализовано", textBox47.Text);
                    cmd.Parameters.AddWithValue("@Остаток", textBox46.Text);
                    cmd.Parameters.AddWithValue("@Дата_реализации", dateTimePicker7.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Id_номенклатуры", textBox50.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }
    
        private void FillZakazBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select Id_Заказа, Наименование from Заказ", connection);
                connection.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Заказ");
                comboBox13.ValueMember = "Id_Заказа";
                comboBox13.DisplayMember = "Наименование";
                comboBox13.DataSource = ds.Tables["Заказ"];
            }
        }
    
        private void ShowReal()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("select Id_Реализации,Id_Склада,Реализация.Id_Товара,Готовая_продукция.Наименование,Реализация.Id_Работника," +
                    "Персонал.Фамилия,Персонал.Имя,Дата_Реализации,Id_Заказа,Цена from Реализация " +
                    "join Готовая_продукция on Реализация.Id_Товара = Готовая_продукция.Id_Товара " +
                    "join Персонал on Реализация.Id_Работника = Персонал.Id_Работника", connection);
                adapter.Fill(dt);
                RealTable.DataSource = dt;
                connection.Close();
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox19.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("insert into Реализация values(@Id_склада,@Id_Товара,@Id_Работника,@Дата_Реализации,@Id_заказа,@Цена)", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_склада", comboBox10.SelectedValue);
                    cmd.Parameters.AddWithValue("@Id_Товара", comboBox11.SelectedValue);
                    cmd.Parameters.AddWithValue("@Id_Работника", comboBox12.SelectedValue);
                    cmd.Parameters.AddWithValue("@Дата_Реализации", dateTimePicker9.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Id_заказа", comboBox13.SelectedValue);
                    cmd.Parameters.AddWithValue("@Цена", double.Parse(textBox19.Text));
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox60.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("delete from Реализация where Id_Реализации=@Id_Реализации", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_Реализации", textBox60.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if ((textBox19.Text != "") && (textBox60.Text != ""))
                {
                    SqlCommand cmd = new SqlCommand("update Реализация set Id_склада=@Id_склада,Id_Товара=@Id_Товара,Id_Работника=@Id_Работника,Дата_Реализации=@Дата_Реализации,Id_заказа=@Id_заказа,Цена=@Цена where Id_Реализации=@Id_Реализации", connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id_склада", comboBox10.SelectedValue);
                    cmd.Parameters.AddWithValue("@Id_Товара", comboBox11.SelectedValue);
                    cmd.Parameters.AddWithValue("@Id_Работника", comboBox12.SelectedValue);
                    cmd.Parameters.AddWithValue("@Дата_Реализации", dateTimePicker9.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Id_заказа", comboBox13.SelectedValue);
                    cmd.Parameters.AddWithValue("@Цена", double.Parse(textBox19.Text));
                    cmd.Parameters.AddWithValue("@Id_Реализации", textBox60.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    UpdateAll();
                }
                else
                {
                    MessageBox.Show("Введите значения");
                }
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            UpdateAll();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("select Id_Реализации,Id_Склада,Реализация.Id_Товара,Готовая_продукция.Наименование,Реализация.Id_Работника," +
                    "Персонал.Фамилия,Персонал.Имя,Дата_Реализации,Id_Заказа,Цена from Реализация " +
                    "join Готовая_продукция on Реализация.Id_Товара = Готовая_продукция.Id_Товара " +
                    "join Персонал on Реализация.Id_Работника = Персонал.Id_Работника " +
                    "where Дата_реализации='" + dateTimePicker9.Value.ToShortDateString() + "'", connection);
                adapter.Fill(dt);
                RealTable.DataSource = dt;
                connection.Close();
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("select Id_Реализации,Id_Склада,Реализация.Id_Товара,Готовая_продукция.Наименование,Реализация.Id_Работника," +
                    "Персонал.Фамилия,Персонал.Имя,Дата_Реализации,Id_Заказа,Цена from Реализация " +
                    "join Готовая_продукция on Реализация.Id_Товара = Готовая_продукция.Id_Товара " +
                    "join Персонал on Реализация.Id_Работника = Персонал.Id_Работника " +
                    "where Id_Склада=" + comboBox10.SelectedValue, connection);
                adapter.Fill(dt);
                RealTable.DataSource = dt;
                connection.Close();
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            UpdateAll();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("select Id_Склада,Склад.Id_Товара,Готовая_продукция.Наименование,Дата_поступления from Склад " +
                    "join Готовая_продукция on Склад.Id_Товара = Готовая_продукция.Id_Товара " +
                    "where Дата_поступления='" + dateTimePicker8.Value.ToShortDateString() + "'", connection);
                adapter.Fill(dt);
                SkladTable.DataSource = dt;
                connection.Close();
            }
        }
    }
}

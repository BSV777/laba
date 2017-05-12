using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Collections;
namespace курсовая
{
    public partial class Form1 : Form
    {

        public ArrayList spisok;
        public int pos;

        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "Время начала";
            dataGridView1.Columns[1].Name = "Время окончания";
            dataGridView1.Columns[2].Name = "День начала";
            dataGridView1.Columns[3].Name = "День окончания";
            dataGridView1.Columns[4].Name = "Месяц начала";
            dataGridView1.Columns[5].Name = "Месяц окончания";
            dataGridView1.Columns[6].Name = "Встреча";
            dataGridView1.Columns[7].Name = "Важность";



            dataGridView2.ColumnCount = 8;
            dataGridView2.Columns[0].Name = "Время начала";
            dataGridView2.Columns[1].Name = "Время окончания";
            dataGridView2.Columns[2].Name = "День начала";
            dataGridView2.Columns[3].Name = "День окончания";
            dataGridView2.Columns[4].Name = "Месяц начала";
            dataGridView2.Columns[5].Name = "Месяц окончания";
            dataGridView2.Columns[6].Name = "Встреча";
            dataGridView2.Columns[7].Name = "Важность";
            

            string MyFileName = "details.bin";

            spisok = new ArrayList();

            if (System.IO.File.Exists(MyFileName))
            {
                

                FileStream fs1 = new FileStream(MyFileName, FileMode.Open);
                BinaryFormatter bf1 = new BinaryFormatter();
                spisok = (ArrayList)bf1.Deserialize(fs1);
                
                dataGridView1.RowCount = spisok.Count;
                
                for (int i = 0; i < spisok.Count; i++)
                {
                    Details ob = (Details)spisok[i];

                    if (ob.Month1_end == null) { ob.Month1 = ""; }
                    if (ob.Day1_end == null) { ob.Day1_end = ""; }
                    if (ob.Time1_end == null) { ob.Time1_end = ""; }

                    dataGridView1.Rows[i].Cells[0].Value = ob.Time1;
                    dataGridView1.Rows[i].Cells[1].Value = ob.Time1_end;
                    dataGridView1.Rows[i].Cells[2].Value = ob.Day1;
                    dataGridView1.Rows[i].Cells[3].Value = ob.Day1_end;
                    dataGridView1.Rows[i].Cells[4].Value = ob.Month1;
                    dataGridView1.Rows[i].Cells[5].Value = ob.Month1_end;
                    dataGridView1.Rows[i].Cells[6].Value = ob.Idea1;
                    dataGridView1.Rows[i].Cells[7].Value = ob.Important1;
                
                    
                }
                fs1.Close();
            }
        }
        
      /////////
      
        private void button1_Click(object sender, EventArgs e)
        {

            string t, d, m, id, im;
            string t_end, d_end, m_end;

            string MyFileName = "details.bin";

            t = tbTime1.Text;
            d = dateTimePicker1.Value.ToString("dd");
            m = dateTimePicker1.Value.ToString("MMMM yyyy");

            t_end = tbTime2.Text;
            d_end = dateTimePicker2.Value.ToString("dd");
            m_end = dateTimePicker2.Value.ToString("MMMM yyyy");
            
            id = textBox3.Text;
            im = comboBox1.Text;

            if ((id == "") | (im == ""))
            {
                MessageBox.Show("Вы не заполнили необходимые поля", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {

                Details details = new Details(t, d, id, im, m, t_end, d_end, m_end);
                spisok.Add(details);
                tbTime1.Clear();
                tbTime2.Clear();
                textBox3.Clear();

                FileStream fs = new FileStream(MyFileName, FileMode.OpenOrCreate);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, spisok);
                fs.Close();

                FileStream fs1 = new FileStream(MyFileName, FileMode.Open);
                BinaryFormatter bf1 = new BinaryFormatter();
                spisok = (ArrayList)bf1.Deserialize(fs1);

                dataGridView1.RowCount = spisok.Count;

                for (int i = 0; i < spisok.Count; i++)
                {
                    Details ob = (Details)spisok[i];

                    dataGridView1.Rows[i].Cells[0].Value = ob.Time1;
                    dataGridView1.Rows[i].Cells[1].Value = ob.Time1_end;
                    dataGridView1.Rows[i].Cells[2].Value = ob.Day1;
                    dataGridView1.Rows[i].Cells[3].Value = ob.Day1_end;
                    dataGridView1.Rows[i].Cells[4].Value = ob.Month1;
                    dataGridView1.Rows[i].Cells[5].Value = ob.Month1_end;
                    dataGridView1.Rows[i].Cells[6].Value = ob.Idea1;
                    dataGridView1.Rows[i].Cells[7].Value = ob.Important1;

                }
                fs1.Close();
                btDel.Enabled = false;
            }
        }



        private void btFind_Click(object sender, EventArgs e)
        {

            int j = 0;
            dataGridView2.RowCount = 1;
            for (int k = 0; k < 8; k++) { dataGridView2.Rows[0].Cells[k].Value = ""; }

            if (tbIdea.Text != "")
            {

                dataGridView2.RowCount = spisok.Count + 1;

                for (int i = 0; i < spisok.Count; i++)
                {
                    Details ob = (Details)spisok[i];
                    
                    if (ob.Idea1.Contains(tbIdea.Text))
                    {

                        dataGridView2.Rows[j].Cells[0].Value = ob.Time1;
                        dataGridView2.Rows[j].Cells[1].Value = ob.Time1_end;
                        dataGridView2.Rows[j].Cells[2].Value = ob.Day1;
                        dataGridView2.Rows[j].Cells[3].Value = ob.Day1_end;
                        dataGridView2.Rows[j].Cells[4].Value = ob.Month1;
                        dataGridView2.Rows[j].Cells[5].Value = ob.Month1_end;
                        dataGridView2.Rows[j].Cells[6].Value = ob.Idea1;
                        dataGridView2.Rows[j].Cells[7].Value = ob.Important1;
                        j++;
                    }
                }
                dataGridView2.RowCount = j + 1;

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pos = e.RowIndex;
            btDel.Enabled = true;

            textBox3.Text = dataGridView1.Rows[pos].Cells[6].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[pos].Cells[7].Value.ToString();
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                spisok.RemoveAt(pos);

                dataGridView1.RowCount = spisok.Count;

                for (int i = 0; i < spisok.Count; i++)
                {
                    Details ob = (Details)spisok[i];

                    dataGridView1.Rows[i].Cells[0].Value = ob.Time1;
                    dataGridView1.Rows[i].Cells[1].Value = ob.Time1_end;
                    dataGridView1.Rows[i].Cells[2].Value = ob.Day1;
                    dataGridView1.Rows[i].Cells[3].Value = ob.Day1_end;
                    dataGridView1.Rows[i].Cells[4].Value = ob.Month1;
                    dataGridView1.Rows[i].Cells[5].Value = ob.Month1_end;
                    dataGridView1.Rows[i].Cells[6].Value = ob.Idea1;
                    dataGridView1.Rows[i].Cells[7].Value = ob.Important1;
                }


                string MyFileName = "details.bin";
                FileStream fs = new FileStream(MyFileName, FileMode.OpenOrCreate);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, spisok);
                fs.Close();
                btDel.Enabled = false;
            }
        }

 

  




    }
}

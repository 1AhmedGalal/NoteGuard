using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteGuardLauncher
{
    public partial class OldPasswordNote : Form
    {
        private Form1 _form1;
        private NoteStorage _noteStorage;

        public OldPasswordNote(Form1 form1)
        {
            this._form1 = form1;
            this._noteStorage = NoteStorage.Instance;
            InitializeComponent();
        }

        private void OldPasswordNote_Load(object sender, EventArgs e)
        {
            _noteStorage = NoteStorage.Instance;
            _noteStorage.NoteTypeHandled = NoteType.AccountPassword;

            foreach (AccountPassword item in _noteStorage)
            {
                comboBox1.Items.Add(item.WebsiteName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _noteStorage.NoteTypeHandled = NoteType.AccountPassword;

            if (comboBox1.SelectedIndex >= 0)
            {
                AccountPassword curr = _noteStorage.GetNote(comboBox1.SelectedIndex) as AccountPassword;
                if (curr is not null)
                {
                    textBox2.Text = curr.EmailOrUserName;
                    textBox3.Text = curr.Password;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            _form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _noteStorage.NoteTypeHandled = NoteType.AccountPassword;

            if (comboBox1.SelectedIndex >= 0)
            {
                AccountPassword? oldNote = _noteStorage.GetNote(comboBox1.SelectedIndex) as AccountPassword;
                AccountPassword updatedNote = new AccountPassword(comboBox1.Text, textBox2.Text, textBox3.Text, oldNote!.Id);
                _noteStorage.RemoveNote(comboBox1.SelectedIndex);
                _noteStorage.AddNote(updatedNote);
                _noteStorage.SaveAllNotes(_form1.FolderPath!);
                MessageBox.Show("Note Has Been Updated!", "Success");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _noteStorage.NoteTypeHandled = NoteType.AccountPassword;

            if (comboBox1.SelectedIndex >= 0)
            {
                _noteStorage.RemoveNote(comboBox1.SelectedIndex);
                _noteStorage.SaveAllNotes(_form1.FolderPath!);
                MessageBox.Show("Note Has Been Deleted!", "Success");

                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
            }
        }
    }
}

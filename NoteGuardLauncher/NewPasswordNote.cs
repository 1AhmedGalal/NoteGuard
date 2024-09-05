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
    public partial class NewPasswordNote : Form
    {
        private Form1 _form1;
        private NoteStorage _noteStorage;
        public NewPasswordNote(Form1 form1)
        {
            _form1 = form1;
            _noteStorage = NoteStorage.Instance;
            InitializeComponent();
        }

        private void NewPasswordNote_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string website = textBox1.Text == "" ? "No Website" : textBox1.Text;
            string username = textBox2.Text == "" ? "No Username" : textBox2.Text;
            string password = textBox3.Text == "" ? "No Password" : textBox3.Text;

            AccountPassword accountPassword = new AccountPassword(website, username, password);

            _noteStorage.NoteTypeHandled = NoteType.AccountPassword;
            _noteStorage.AddNote(accountPassword);

            if (_form1.FolderPath is null)
            {
                MessageBox.Show("You Didn't choose A File Directory! Please Make Sure to Choose One Before Closing The App", "Warning");
            }
            else
            {
                _noteStorage.SaveAllNotes(_form1.FolderPath);
                MessageBox.Show("Note Has Been Saved!", "Success");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            _form1.Show();
        }
    }
}

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
    public partial class NewLinkNote : Form
    {

        private Form1 _form1;
        private NoteStorage _noteStorage;
        public NewLinkNote(Form1 form1)
        {
            _form1 = form1;
            _noteStorage = NoteStorage.Instance;
            InitializeComponent();
        }

        private void NewLinkNote_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text == "" ? "No Website Name" : textBox1.Text;
            string link = textBox2.Text == "" ? "No Website Link" : textBox2.Text;

            WebsiteLink websiteLink = new WebsiteLink(name, link);

            _noteStorage.NoteTypeHandled = NoteType.WebsiteLink;
            _noteStorage.AddNote(websiteLink);

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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NoteGuardLauncher
{
    public partial class OldLinkNote : Form
    {
        private Form1 _form1;
        private NoteStorage _noteStorage;

        public OldLinkNote(Form1 form1)
        {
            this._form1 = form1;
            this._noteStorage = NoteStorage.Instance;
            InitializeComponent();
        }

        private void OldLinkNote_Load(object sender, EventArgs e)
        {
            _noteStorage = NoteStorage.Instance;
            _noteStorage.NoteTypeHandled = NoteType.WebsiteLink;
            updateComboBox();
        }

        private void updateComboBox()
        {
            comboBox1.Items.Clear();

            foreach (WebsiteLink item in _noteStorage)
            {
                comboBox1.Items.Add(item.WebsiteName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            _form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _noteStorage.NoteTypeHandled = NoteType.WebsiteLink;

            if (comboBox1.SelectedIndex >= 0)
            {
                WebsiteLink curr = _noteStorage.GetNote(comboBox1.SelectedIndex) as WebsiteLink;
                if (curr is not null)
                {
                    textBox1.Text = curr.WebsiteUrl;
                    linkLabel1.Links.Add(0, curr.WebsiteName.Length, curr.WebsiteName);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(e.Link.LinkData.ToString()) { UseShellExecute = true });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _noteStorage.NoteTypeHandled = NoteType.WebsiteLink;

            if (comboBox1.SelectedIndex >= 0)
            {
                _noteStorage.RemoveNote(comboBox1.SelectedIndex);
                _noteStorage.SaveAllNotes(_form1.FolderPath!);
                MessageBox.Show("Note Has Been Deleted!", "Success");

                textBox1.Text = "";
                linkLabel1.Links.Clear();
                updateComboBox();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _noteStorage.NoteTypeHandled = NoteType.WebsiteLink;

            if (comboBox1.SelectedIndex >= 0)
            {
                WebsiteLink? oldNote = _noteStorage.GetNote(comboBox1.SelectedIndex) as WebsiteLink;
                WebsiteLink updatedNote = new WebsiteLink(comboBox1.Text, textBox1.Text, oldNote!.Id);
                _noteStorage.RemoveNote(comboBox1.SelectedIndex);
                _noteStorage.AddNote(updatedNote);
                _noteStorage.SaveAllNotes(_form1.FolderPath!);
                updateComboBox();
                MessageBox.Show("Note Has Been Updated!", "Success");
            }
        }
    }
}

using System.Runtime.CompilerServices;

namespace NoteGuardLauncher
{
    public partial class Form1 : Form
    {

        private NoteStorage notesStorage;

        public Form1()
        {
            InitializeComponent();
            notesStorage = NoteStorage.Instance;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Normal Notes");
            comboBox1.Items.Add("Account Passwords");
            comboBox1.Items.Add("Website Links");

            comboBox2.Items.Add("Desktop");
            comboBox2.Items.Add("My Documents Folder");
        }

        //private void label1_Click(object sender, EventArgs e)
        //{

        //}

        private void button1_Click(object sender, EventArgs e)
        {
            string? folderPath = null;

            if (comboBox2.SelectedIndex == 0)
            {
                folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            else if(comboBox2.SelectedIndex == 1) 
            {
                folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            else
            {
                MessageBox.Show("Please Choose A Valid File Path", "Warning");
                return;
            }

            notesStorage.LoadAllNotes(folderPath);
        }
    }
}
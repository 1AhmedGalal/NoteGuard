using System.Runtime.CompilerServices;

namespace NoteGuardLauncher
{
    public partial class Form1 : Form
    {

        private NoteStorage _noteStorage;
        public string? FolderPath { get; private set; }

        public Form1()
        {
            FolderPath = null;
            _noteStorage = NoteStorage.Instance;
            InitializeComponent();
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

            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    break;
                case 1:
                    FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    break;
                default:
                    MessageBox.Show("Please Choose A Valid File Path", "Warning");
                    return;
            }

            _noteStorage.LoadAllNotes(FolderPath);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    NewStandardNote newStandardNote = new NewStandardNote(this);
                    this.Hide();
                    newStandardNote.Show();
                    break;

                case 1:
                    NewPasswordNote newPasswordNote = new NewPasswordNote(this);
                    this.Hide();
                    newPasswordNote.Show();
                    break;

                case 2:
                    NewLinkNote newLinkNote = new NewLinkNote(this);
                    this.Hide();
                    newLinkNote.Show();
                    break;

                default:
                    MessageBox.Show("Please Choose A Valid Type", "Warning");
                    return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
using System.Runtime.CompilerServices;

namespace NoteGuardLauncher
{
    public partial class Form1 : Form
    {

        private NoteStorage _noteStorage;      
        private NewStandardNote _newStandardNote;
        private NewPasswordNote _newPasswordNote;
        private NewLinkNote _newLinkNote ;
        private OldPasswordNote _oldPasswordNote;
        private OldLinkNote _oldLinkNote;
        private OldStandardNote _oldStandardNote;

        public string? FolderPath { get; private set; }

        public Form1()
        {
            FolderPath = null;
            _noteStorage = NoteStorage.Instance;
            _newStandardNote = new NewStandardNote(this);
            _newPasswordNote = new NewPasswordNote(this);
            _newLinkNote = new NewLinkNote(this);
            _oldPasswordNote = new OldPasswordNote(this);
            _oldLinkNote = new OldLinkNote(this);
            _oldStandardNote = new OldStandardNote(this);
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
                    this.Hide();
                    _newStandardNote.Show();
                    break;

                case 1:
                    this.Hide();
                    _newPasswordNote.Show();
                    break;

                case 2:
                    this.Hide();
                    _newLinkNote.Show();
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

        private void button3_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    this.Hide();
                    _oldStandardNote.Show();
                    break;

                case 1:
                    this.Hide();
                    _oldPasswordNote.Show();
                    break;

                case 2:
                    this.Hide();
                    _oldLinkNote.Show();
                    break;

                default:
                    MessageBox.Show("Please Choose A Valid Type", "Warning");
                    return;
            }
        }
    }
}
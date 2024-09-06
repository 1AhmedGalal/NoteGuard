namespace NoteGuardLauncher
{
    public partial class OldStandardNote : Form
    {
        private Form1 _form1;
        private NoteStorage _noteStorage;

        public OldStandardNote(Form1 form1)
        {
            this._form1 = form1;
            this._noteStorage = NoteStorage.Instance;
            InitializeComponent();
        }

        private void OldStandardNote_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            _form1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _noteStorage.NoteTypeHandled = NoteType.Standard;

            if (comboBox1.SelectedIndex >= 0)
            {
                StandardNote curr = _noteStorage.GetNote(comboBox1.SelectedIndex) as StandardNote;
                if (curr is not null)
                {
                    textBox1.Text = curr.Content;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _noteStorage.NoteTypeHandled = NoteType.Standard;
            comboBox1.Items.Clear();

            if (radioButton2.Checked)
            {
                foreach (StandardNote item in _noteStorage)
                {
                    comboBox1.Items.Add(item.Subject);
                }
            }
            else
            {
                foreach (StandardNote item in _noteStorage)
                {
                    if (item.Keywords.Contains(new Keyword(textBox2.Text)))
                        comboBox1.Items.Add(item.Subject);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _noteStorage.NoteTypeHandled = NoteType.Standard;

            if (comboBox1.SelectedIndex >= 0)
            {
                _noteStorage.RemoveNote(comboBox1.SelectedIndex);
                _noteStorage.SaveAllNotes(_form1.FolderPath!);
                MessageBox.Show("Note Has Been Deleted!", "Success");

                textBox1.Text = "";
                comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _noteStorage.NoteTypeHandled = NoteType.Standard;

            if (comboBox1.SelectedIndex >= 0)
            {
                StandardNote? oldNote = _noteStorage.GetNote(comboBox1.SelectedIndex) as StandardNote;
                StandardNote updatedNote = new StandardNote(comboBox1.Text, textBox1.Text, oldNote!.Id);
                _noteStorage.RemoveNote(comboBox1.SelectedIndex);
                _noteStorage.AddNote(updatedNote);
                _noteStorage.SaveAllNotes(_form1.FolderPath!);
                MessageBox.Show("Note Has Been Updated!", "Success");
            }
        }
    }
}

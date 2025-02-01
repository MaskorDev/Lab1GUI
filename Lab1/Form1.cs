using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Lab1
{
    public partial class Form1 : Form
    {
        private Button button;
        private TextBox textBox;
        private Label label;
        private CheckBox checkBox;
        private RadioButton radioButton;
        private ComboBox comboBox;
        private ListBox listBox;
        private TabControl tabControl;
        private Timer timer;
        private Panel panel;
        private TrackBar trackBar;
        private ProgressBar progressBar;
        private NumericUpDown numericUpDown;
        private PictureBox pictureBox;
        private GroupBox groupBox;
        private Label statusLabel;
        private Button innerGroupButton;
        public Form1()
        {
            Text = "������������ ������ 1";
            Size = new Size(800, 600);

      
            this.SizeChanged += MainForm_SizeChanged;

            this.MouseMove += MainForm_MouseMove;


            button = new Button
            {
                Text = "������",
                Location = new Point(20, 20)
            };
            button.Click += (s, e) => MessageBox.Show("������ ������!");
            button.MouseEnter += (s, e) => statusLabel.Text = "������ ���� �� ������";
            button.MouseLeave += (s, e) => statusLabel.Text = "�������� ������";

            
            textBox = new TextBox
            {
                Location = new Point(20, 60),
                Width = 150
            };
            textBox.TextChanged += (s, e) => label.Text = textBox.Text;
            textBox.KeyDown += (s, e) => statusLabel.Text = $"������ �������: {e.KeyCode}";

            
            label = new Label
            {
                Text = "�����",
                Location = new Point(20, 100),
                Width = 150
            };

            
            checkBox = new CheckBox
            {
                Text = "�������",
                Location = new Point(20, 140)
            };
            checkBox.CheckedChanged += (s, e) =>
            {
                button.Enabled = checkBox.Checked;
                statusLabel.Text = $"������� {(checkBox.Checked ? "�������" : "�� �������")}";
            };

           
            radioButton = new RadioButton
            {
                Text = "�����������",
                Location = new Point(20, 180)
            };
            radioButton.CheckedChanged += (s, e) =>
                statusLabel.Text = $"����������� {(radioButton.Checked ? "�������" : "�� �������")}";

            
            comboBox = new ComboBox
            {
                Location = new Point(20, 220),
                Width = 150
            };
            comboBox.Items.AddRange(new string[] { "������� 1", "������� 2", "������� 3" });
            comboBox.SelectedIndexChanged += (s, e) =>
                statusLabel.Text = $"������: {comboBox.SelectedItem}";

            
            listBox = new ListBox
            {
                Location = new Point(20, 260),
                Width = 150,
                Height = 80
            };
            listBox.Items.AddRange(new string[] { "������ 1", "������ 2", "������ 3" });
            listBox.SelectedIndexChanged += (s, e) =>
                statusLabel.Text = $"������ �� ������: {listBox.SelectedItem}";

           
            tabControl = new TabControl
            {
                Location = new Point(200, 20),
                Width = 200,
                Height = 100
            };
            tabControl.TabPages.Add("������� 1");
            tabControl.TabPages.Add("������� 2");
            tabControl.SelectedIndexChanged += (s, e) =>
                statusLabel.Text = $"�������� �������: {tabControl.SelectedTab.Text}";

            
            timer = new System.Windows.Forms.Timer { Interval = 1000 };
            timer.Tick += (s, e) =>
            {
                button.BackColor = button.BackColor == Color.Red ? Color.Blue : Color.Red;
                statusLabel.Text = "������ ������� ���� ������";
            };
            timer.Start();

            
            panel = new Panel
            {
                Location = new Point(200, 140),
                Width = 200,
                Height = 100,
                BackColor = Color.LightGray
            };
            panel.Click += (s, e) => statusLabel.Text = "���� �� ������";

           
            trackBar = new TrackBar
            {
                Location = new Point(200, 260),
                Width = 150
            };
            trackBar.Scroll += (s, e) =>
                statusLabel.Text = $"�������� TrackBar: {trackBar.Value}";

           
            progressBar = new ProgressBar
            {
                Location = new Point(200, 300),
                Width = 150,
                Value = 50
            };

            
            numericUpDown = new NumericUpDown
            {
                Location = new Point(200, 340),
                Width = 150
            };
            numericUpDown.ValueChanged += (s, e) =>
                statusLabel.Text = $"NumericUpDown: {numericUpDown.Value}";

            
            pictureBox = new PictureBox
            {
                Location = new Point(400, 20),
                Width = 100,
                Height = 100,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };
            pictureBox.MouseEnter += (s, e) => pictureBox.BackColor = Color.LightBlue;
            pictureBox.MouseLeave += (s, e) => pictureBox.BackColor = Color.White;
            pictureBox.Click += (s, e) => statusLabel.Text = "������ �� PictureBox";

           
            groupBox = new GroupBox
            {
                Location = new Point(400, 140),
                Width = 200,
                Height = 150,
                Text = "������",
                BackColor = Color.Transparent
            };
          
            groupBox.MouseEnter += (s, e) => groupBox.BackColor = Color.LightYellow;
            groupBox.MouseLeave += (s, e) => groupBox.BackColor = Color.Transparent;
            groupBox.Click += (s, e) => statusLabel.Text = "�������� �� GroupBox";

            innerGroupButton = new Button
            {
                Text = "���������� ������",
                Location = new Point(20, 30),
                Size = new Size(150, 30)
            };
            innerGroupButton.Click += (s, e) =>
            {
                innerGroupButton.Text = innerGroupButton.Text == "���������� ������"
                    ? "������!" : "���������� ������";
                statusLabel.Text = "������ ���������� ������ GroupBox";
            };
            groupBox.Controls.Add(innerGroupButton);

          
            statusLabel = new Label
            {
                Text = "������: �����",
                Location = new Point(20, 520),  
                Width = 350
            };

            // ��������� ��� �������� �� �����
            Controls.AddRange(new Control[]
            {
                button, textBox, label, checkBox, radioButton, comboBox, listBox, tabControl,
                panel, trackBar, progressBar, numericUpDown, pictureBox, groupBox, statusLabel
            });
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            statusLabel.Text = $"������ �����: {this.Width}x{this.Height}";
        }

       
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            statusLabel.Text = $"���������� ����: X={e.X}, Y={e.Y}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

    }

}
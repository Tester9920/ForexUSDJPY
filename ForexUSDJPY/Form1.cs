using System.Timers;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(this.ExecUpdateLabel);
            timer.Interval = 2000;
            timer.Start();
        }


        public void RefreshLabelEvent()
        {
            Decimal oldquote = Decimal.Parse(label1.Text);
            Decimal currentquote = Decimal.Parse(ForexClient.ForexDataClient());
            if (currentquote > oldquote)
            {
                label1.Text = currentquote.ToString();
                label1.ForeColor = Color.Red;
            } else if (currentquote < oldquote)
            {
                label1.Text = currentquote.ToString();
                label1.ForeColor = Color.Blue;
            } else if (currentquote == oldquote)
            {
                label1.Text = currentquote.ToString();
                label1.ForeColor = Color.Black;
            }
        }

        public void ExecUpdateLabel(object source, ElapsedEventArgs e)
        {
            this.Invoke(this.RefreshLabelEvent);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = ForexClient.ForexDataClient();
        }

        delegate void UpdateLabelDelegate(object source, ElapsedEventArgs e);

    }
}
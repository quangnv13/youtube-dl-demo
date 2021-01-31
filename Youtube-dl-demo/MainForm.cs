using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Youtube_dl_demo.Helper;

namespace Youtube_dl_demo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            FirstLoad();
        }

        private void FirstLoad()
        {
            txtSavePath.Text = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "downloaded");
            LogHelper.Form = this;
            LogHelper.ListBox = lbxLog;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            var downloadThread = new Thread(() => YoutubeDlHelper.Download(txtMediaLinkDownload.Text, txtSavePath.Text));
            downloadThread.Start();
        }

        private void btnChangeSavePath_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtSavePath.Text = fbd.SelectedPath;
                }
            }
        }
    }
}

using System.Security.Cryptography.X509Certificates;

namespace CertificateInstaller
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.Region = Region.FromHrgn(NativeMethods.Gdi32.CreateRoundRectRgn(0, 0, Width, Height, 10, 10));

            NativeMethods.DesktopWindowManager.SetImmersiveDarkMode(this.Handle, true);

            certBox.ExpandAll();
        }

        public List<string> GetCheckedNodes(TreeNodeCollection nodes)
        {
            List<string> checkedNodes = new List<string>();

            foreach (System.Windows.Forms.TreeNode aNode in nodes)
            {
                Application.DoEvents();

                if (aNode.Nodes.Count != 0)
                {
                    List<string> childNodes = GetCheckedNodes(aNode.Nodes);
                    foreach (string childNode in childNodes)
                    {
                        Application.DoEvents();

                        checkedNodes.Add(childNode);
                    }
                }

                if (!aNode.Checked)
                    continue;

                checkedNodes.Add(aNode.Text);
            }

            return checkedNodes;
        }

        public void CheckAllNodes(bool check, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = check;

                if (node.Nodes.Count != 0)
                {
                    CheckAllNodes(check, node.Nodes);
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // Exit
            Application.Exit();
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            CheckAllNodes(true, certBox.Nodes);
        }

        private void uncheckButton_Click(object sender, EventArgs e)
        {
            CheckAllNodes(false, certBox.Nodes);
        }

        private void installButton_Click(object sender, EventArgs e)
        {
            List<string> checkedItems = GetCheckedNodes(certBox.Nodes);

            if (checkedItems.Count == 0)
            {
                MessageBox.Show("No certificates are checked to be installed.\nCheck a certificate to install and try again.", "No Certificates Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (checkedItems.Contains("Soniczac7 CA"))
            {
                try
                {
                    X509Certificate2 cert = new X509Certificate2(Properties.Resources.CertCA);
                    X509Store store = new X509Store(StoreName.AuthRoot, StoreLocation.LocalMachine);
                    store.Open(OpenFlags.ReadWrite);
                    store.Add(cert); //where cert is an X509Certificate object
                    store.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"FAILURE: {ex.Message} ({ex.GetType().FullName})", "Certificate Install Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    MessageBox.Show("Soniczac7 CA Certificate successfully installed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (checkedItems.Contains("Soniczac7 Code Signing"))
            {
                if (checkedItems.Contains("Soniczac7 CA") == false)
                {
                    //MessageBox.Show("The certificate \"Soniczac7 Code Signing\" requires the certificate \"Soniczac7 CA\" to be installed.\nPlease check the certificate \"Soniczac7 CA\" to be installed and try again.", "Certificate Install Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult result = MessageBox.Show("The certificate \"Soniczac7 Code Signing\" was requested to be installed but the parent certificate \"Soniczac7 CA\" is not selected to be installed.\nThis will cause certificate validation errors.\nDo you want to continue with the installation anyway?", "Certificate Install Failure", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }
                try
                {
                    X509Certificate2 cert = new X509Certificate2(Properties.Resources.CodeSigning);
                    X509Store store = new X509Store(StoreName.TrustedPublisher, StoreLocation.LocalMachine);
                    store.Open(OpenFlags.ReadWrite);
                    store.Add(cert); //where cert is an X509Certificate object
                    store.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"FAILURE: {ex.Message} ({ex.GetType().FullName})", "Certificate Install Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    MessageBox.Show("Soniczac7 Code Signing Certificate successfully installed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}

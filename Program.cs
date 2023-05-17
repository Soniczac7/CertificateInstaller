using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace CertificateInstaller
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            if (args.Length == 0)
            {
                Application.Run(new MainForm());
            }
            else if (args[0].Contains("--install"))
            {
                //MessageBox.Show(args[1]);

                try
                {
                    if (args[1] == "Soniczac7 CA")
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
                            Environment.Exit(1);
                        }
                        finally
                        {
                            Debug.WriteLine("Soniczac7 CA Certificate successfully installed!");
                        }
                    }
                    else if (args[1] == "Soniczac7 Code Signing")
                    {
                        // Install Soniczac7 CA if it is not already installed
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
                            Environment.Exit(1);
                        }
                        finally
                        {
                            Debug.WriteLine("Soniczac7 CA Certificate successfully installed!");
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
                            Environment.Exit(1);
                        }
                        finally
                        {
                            Debug.WriteLine("Soniczac7 Code Signing Certificate successfully installed!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid certificate name specified. Please check the certificate name and try again.", "Certificate Install Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(2);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"FAILURE: {ex.Message} ({ex.GetType().FullName})", "Certificate Install Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(4);
                }

                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show("Soniczac7 Certificate Installer Command Line Help" +
                    "\n==============================================" +
                    "\n--install <name> - Silently install certificate and its dependencies", "Soniczac7 Certificate Installer", MessageBoxButtons.OK, MessageBoxIcon.None);
                Environment.Exit(3);
            }
        }
    }
}
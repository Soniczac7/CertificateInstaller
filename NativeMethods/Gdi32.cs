using System.Runtime.InteropServices;

namespace CertificateInstaller.NativeMethods
{
    public class Gdi32
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        /// <summary>
        /// Creates a rectangular region with rounded corners.
        /// </summary>
        /// <param name="nLeftRect">x-coordinate of upper-left corner</param>
        /// <param name="nTopRect">y-coordinate of upper-left corner</param>
        /// <param name="nRightRect">x-coordinate of lower-right corner</param>
        /// <param name="nBottomRect">y-coordinate of lower-right corner</param>
        /// <param name="nWidthEllipse">width of ellipse</param>
        /// <param name="nHeightEllipse">height of ellipse</param>
        public static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
    }
}

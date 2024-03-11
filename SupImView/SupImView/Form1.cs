using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace SupImView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                pictureBox1.ImageLocation = Globals.img_path.ToString();

                this.Activate();
                //int w = this.Width;
                //int h = this.Height;
                //pictureBox1.Refresh();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {



            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string directoryName = "";
                string path = Globals.img_path.ToString();

                string? v = Path.GetDirectoryName(path);
                directoryName = v;



                List<string> files = new List<string>();

                string[] filePaths = Directory.GetFiles(directoryName, "*.*", SearchOption.TopDirectoryOnly);

                /*
                string[] filePaths1 = Directory.GetFiles(directoryName, "*.jpg",
                                         SearchOption.TopDirectoryOnly);
                */

                if (filePaths.Length > 0)
                { 
                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        files.Add(files[i]);
                    }
                }


                files.Sort(StringComparer.Ordinal);


                if (Globals.start_img)
                {
                    Globals.pos = files.IndexOf(path);
                    Globals.start_img = false;
                }

                Globals.totals = files.Count;

                //MessageBox.Show(Globals.totals.ToString());

                switch (e.Button)
                {

                    case MouseButtons.Left:
                        // Left click
                        if (Globals.pos < Globals.totals - 1)
                            Globals.pos++;

                        //pictureBox1.Image = Image.FromFile(files[Globals.pos]);

                        pictureBox1.Load(files[Globals.pos]);

                        //pictureBox1.Refresh();

                        break;

                    case MouseButtons.Right:
                        // Right click
                        if (Globals.pos > 0)
                            Globals.pos--;

                        //pictureBox1.Image = Image.FromFile(files[Globals.pos]);

                        pictureBox1.Load(files[Globals.pos]);

                        //pictureBox1.Refresh();

                        break;
                }

                files.GetEnumerator().Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something stated as error. Please check.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Debug.Print(ex.Message);
            }




        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ComputerVision
{
    public partial class MainForm : Form
    {
        private string sSourceFileName = "";
        private FastImage workImage;
        private Bitmap image = null;
        private ImageProcessor processor = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            sSourceFileName = openFileDialog.FileName;
            panelSource.BackgroundImage = new Bitmap(sSourceFileName);
            image = new Bitmap(sSourceFileName);
            workImage = new FastImage(image);
        }

        private void buttonGrayscale_Click(object sender, EventArgs e)
        {
            processor = new ImageProcessor(new GrayscaleStrategy(), sSourceFileName);
            var processedImage = processor.ProcessImage();
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = processedImage;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            processor = new ImageProcessor(new NegativeStrategy(), sSourceFileName);
            var processedImage = processor.ProcessImage();
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = processedImage;
        }

       

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            processor = new ImageProcessor(new LightStrategy(trackBar1.Value), sSourceFileName);
            var processedImage = processor.ProcessImage();
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = processedImage;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void contrastTrackBar_Scroll(object sender, EventArgs e)
        {

        }

        private void contrastTrackBar_ValueChanged(object sender, EventArgs e)
        {
            processor = new ImageProcessor(new ContrastStrategy(contrastTrackBar.Value), sSourceFileName);
            var processedImage = processor.ProcessImage();
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = processedImage;
        }

        private void egalizareBtn_Click(object sender, EventArgs e)  
        {
            processor = new ImageProcessor(new EgalizareStrategy(), sSourceFileName);
            var processedImage = processor.ProcessImage();
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = processedImage;
        }

        private void reflexieBtn_Click(object sender, EventArgs e)
        {
            processor = new ImageProcessor(new ReflexieStrategy("Orizontala"), sSourceFileName);
            var processedImage = processor.ProcessImage();
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = processedImage;
        }

        private void reflexieComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            processor = new ImageProcessor(new FTJStrategy(int.Parse(textBoxZgomot.Text)), sSourceFileName);
            var processedImage = processor.ProcessImage();
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = processedImage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            processor = new ImageProcessor(new MedianStrategy(), sSourceFileName);
            var processedImage = processor.ProcessImage();
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = processedImage;
        }

        private void textBoxZgomot_TextChanged(object sender, EventArgs e)
        {

        }

        private void markovBtn_Click(object sender, EventArgs e)
        {
            processor = new ImageProcessor(new MarkovStrategy(), sSourceFileName);
            var processedImage = processor.ProcessImage();
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = processedImage;
        }

        private void FTSButton_Click(object sender, EventArgs e)
        {
            processor = new ImageProcessor(new FTSStrategy(), sSourceFileName);
            var processedImage = processor.ProcessImage();
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = processedImage;
        }

        private void unsharpMaskBtn_Click(object sender, EventArgs e)
        {
            processor = new ImageProcessor(new UnsharpMaskingStrategy(3), sSourceFileName);
            var processedImage = processor.ProcessImage();
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = processedImage;
        }

        private void kirschBtn_Click(object sender, EventArgs e)
        {
            processor = new ImageProcessor(new KirschStrategy(), sSourceFileName);
            var processedImage = processor.ProcessImage();
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = processedImage;
        }

        private void PrewittBtn_Click(object sender, EventArgs e)
        {
            processor = new ImageProcessor(new PrewittStrategy(), sSourceFileName);
            var processedImage = processor.ProcessImage();
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = processedImage;
        }

        private void FreiChenBtn_Click(object sender, EventArgs e)
        {
            processor = new ImageProcessor(new FreiChenStrategy(), sSourceFileName);
            var processedImage = processor.ProcessImage();
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = processedImage;
        }

        private void GaborBtn_Click(object sender, EventArgs e)
        {
            processor = new ImageProcessor(new GaborStrategy(), sSourceFileName);
            var processedImage = processor.ProcessImage();
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = processedImage;
        }
    }
}
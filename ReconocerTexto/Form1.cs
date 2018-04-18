using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;
using IronOcr;

namespace ReconocerTexto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Seleccione una imagen";
            dialog.Filter = "Imágenes JPG (*.jpg;*.jpeg)|*.jpeg;*.jpg|Imágenes PNG (*.png)|*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileName = dialog.FileName;
                    Bitmap image = new Bitmap(fileName);
                    pictureBox.Image = (System.Drawing.Image)image;
                    string imageName = dialog.SafeFileName;

                    //string path = Path.Combine(Environment.CurrentDirectory, "tessdata");
                    //var imagen = new Bitmap(fileName);
                    //var teseract = new TesseractEngine(path, "eng", EngineMode.Default);
                    //var page = teseract.Process(imagen);
                    //string text = page.GetText();
                    //txtTextoImagen.Text = text;


                    //=================================================================================
                    //=================================================================================
                    //using (var engine = new TesseractEngine(@"tessdata", "spa", EngineMode.Default))
                    //{
                    //    using (var img = Pix.LoadFromFile(fileName))
                    //    {

                    //        using (var page2 = engine.Process(img))
                    //        {
                    //            Console.WriteLine("GetMeanConfidence:\n" + page2.GetMeanConfidence());
                    //            string text2 = page2.GetText();
                    //            Console.WriteLine("Text2:\n" + text2);
                    //            txtTextoImagen.Text = text2;
                    //        }
                    //    }
                    //}
                    //var Ocr = new AutoOcr();
                    //var Result = Ocr.Read(fileName);
                    //Console.WriteLine(Result.Text);
                    //txtTextoImagen.Text = Result.Text;


                    //=================================================================================
                    //=================================================================================
                    var Ocr = new AdvancedOcr()
                    {
                        CleanBackgroundNoise = true,
                        EnhanceContrast = true,
                        EnhanceResolution = true,
                        Language = IronOcr.Languages.Spanish.OcrLanguagePack,
                        Strategy = IronOcr.AdvancedOcr.OcrStrategy.Advanced,
                        ColorSpace = AdvancedOcr.OcrColorSpace.Color,
                        DetectWhiteTextOnDarkBackgrounds = true,
                        InputImageType = AdvancedOcr.InputTypes.AutoDetect,
                        RotateAndStraighten = false,
                        ReadBarCodes = false,
                        ColorDepth = 6
                    };

                    var testImage = fileName;

                    var Results = Ocr.Read(testImage);

                    Console.WriteLine("==================================");
                    Console.WriteLine(Results.Text);
                    txtTextoImagen.Text = Results.Text;
                    Console.WriteLine("==================================");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lo sentimos, ocurrió un error al intentar procesar tu imagen: \n\n" + ex, "Error al procesar texto de imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}

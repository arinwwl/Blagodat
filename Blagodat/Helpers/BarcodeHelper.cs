using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Blagodat.Helpers
{
    public static class BarcodeHelper
    {
        public static void GenerateAndPrint(string barcodeText)
        {

            try
            {

                string barcodeImage = $"{barcodeText}.png";
                string path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), barcodeImage);
                using (Bitmap bitmap = new Bitmap(200, 100))
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.White);
                    graphics.DrawRectangle(Pens.Black, 0, 0, 199, 99);
                    graphics.DrawString(barcodeText, new Font("Arial", 12), Brushes.Black, 10, 40);
                    bitmap.Save(path);
                }

                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += (sender, e) =>
                {
                    using (Image img = Image.FromFile(path))
                    {
                        e.Graphics.DrawImage(img, 10, 10, 180, 80);
                    }
                };

                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
                System.IO.File.Delete(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при печати штрих-кода: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static Image GenerateBarcodeImage(string text)
        {

            Bitmap bmp = new Bitmap(200, 100);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                graphics.Clear(Color.White);
                graphics.DrawRectangle(Pens.Black, 0, 0, 199, 99);
                graphics.DrawString(text, new Font("Arial", 12), Brushes.Black, 10, 40);
            }
            return bmp;
        }
    }
}
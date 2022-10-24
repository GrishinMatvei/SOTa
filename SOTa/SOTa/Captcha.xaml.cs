using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Brush = System.Drawing.Brush;
using Brushes = System.Drawing.Brushes;
using Color = System.Drawing.Color;
using Image = System.Drawing.Image;
using Point = System.Drawing.Point;

namespace SOTa
{
    public partial class Captcha : Window
    {
        #region Осторожно говнокод!
        public string textcpt;
        
        public Captcha()
        {
            InitializeComponent();
            captcha.Source = CreateImage(Convert.ToInt32(captcha.Width), Convert.ToInt32(captcha.Height));
        }

        private BitmapImage CreateImage(int Width, int Height)
        {
            Random rnd = new Random();

            //Создадим изображение
            Bitmap bitmap = new Bitmap(Width, Height);

            //Вычислим позицию текста
            int Xpos = rnd.Next(0, Width / 2);
            int Ypos = rnd.Next(0, Height / 2);

            //Добавим различные цвета
            Brush[] colors = { Brushes.Black,
                     Brushes.Red,
                     Brushes.DarkBlue,
                     Brushes.Yellow };

            //Укажем где рисовать
            Graphics g = Graphics.FromImage((Image)bitmap);

            //Пусть фон картинки будет серым
            g.Clear(Color.Gray);

            //Сгенерируем текст
            string text = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjkklzxcvbnm";
            for (int i = 0; i < 5; ++i)
                text += ALF[rnd.Next(ALF.Length)];
            textcpt = text;

            //Нарисуем сгенирируемый текст
            g.DrawString(text,
                         new Font("Arial", 30),
                         colors[rnd.Next(colors.Length)],
                         new PointF(Xpos, Ypos));

            //Добавим немного помех
            /////Линии из углов
            g.DrawLine(Pens.Black,
                       new Point(0, 0),
                       new Point(Width - 1, Height - 1));
            g.DrawLine(Pens.Black,
                       new Point(0, Height - 1),
                       new Point(Width - 1, 0));

            ////Белые точки
            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (rnd.Next() % 20 == 0)
                        bitmap.SetPixel(i, j, Color.White);

            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            captcha.Source = CreateImage(Convert.ToInt32(captcha.Width), Convert.ToInt32(captcha.Height));
        }

        private void vvodCaptchi_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (vvodCaptchi.Text.Length >= 5 && e.Key != System.Windows.Input.Key.Back)
            {
                e.Handled = true;
            }
        }

        private void confirmer_Click(object sender, RoutedEventArgs e)
        {
            if (textcpt == vvodCaptchi.Text)
            {
                _textEntred = true;
                this.Close();
            }
            else captcha.Source = CreateImage(Convert.ToInt32(captcha.Width), Convert.ToInt32(captcha.Height));

        }

        private void myGif_MediaEnded(object sender, RoutedEventArgs e)
        {
            myGif.Position = new TimeSpan(0, 0, 1);
            myGif.Play();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) => e.Cancel = true; 
        #endregion
    }
}

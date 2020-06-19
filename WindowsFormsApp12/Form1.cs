using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApp12
{
    public partial class Form1 : Form
    {
       public static int    yükseklik=300, genişlik=600;
        Color x;
        public Form1()
        {
            InitializeComponent();
            
            toolStripComboBox1.SelectedIndex=0;
            toolStripComboBox2.SelectedIndex = 0;
            toolStripTextBox1.BackColor = Color.Black;
            toolStripTextBox1.Enabled = false;
            çizgirenk=Color.Black;
            x=pictureBox2.BackColor;
           
            //temel ayarlamaları yaptık comboboxlar ve arkaplan
            pictureBox2.Width = genişlik;
            pictureBox2.Height = yükseklik;
            boyut600x300ToolStripMenuItem.Text = "boyut( " + pictureBox2.Width.ToString() + "x " + pictureBox2.Height.ToString() + ")";


        }
        bool ciz;
        int eksenX, eksenY, //çizim eksenlerini belirledik ve kalınlıgı ayarladık
            kalınlık = 1;

        Color çizgirenk = new Color();// çizim rengini public olarak tanımlıyoruz
        private object printPreviewDialog1;
        private object printDocument1;
        private object myDocument;

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

      
       
        

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {

            ciz = true;
            eksenX = e.X;//eksenleri atadık ve ayarladık x ve y için
            eksenY = e.Y;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = pictureBox2.CreateGraphics();
            Pen p = new Pen(çizgirenk, kalınlık);
            Point point1 = new Point(eksenX, eksenY);
            Point point2 = new Point(e.X, e.Y);
            Pen silgi=new Pen(Color.White,kalınlık);
            if (toolStripComboBox1.SelectedIndex==0) { 
                if (ciz == true)
                {
                    g.DrawLine(p, point1, point2);
                    eksenX = e.X;
                    eksenY = e.Y;
                }// yukarıda farenin hareket ettigi süre eger çizgi seçilyise çizmesini sağlamak için bir fonksiyon yazdık
            }
            if (toolStripComboBox1.SelectedIndex == 5)
            {
                if (ciz == true)
                {
                    
                    g.DrawLine(silgi, point1, point2);
                    eksenX = e.X;
                    eksenY = e.Y;
                }// yukarıda farenin hareket ettigi süre eger çizgi seçilyise çizmesini sağlamak için bir fonksiyon yazdık
            }

        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = pictureBox2.CreateGraphics();  //picturebpx içinde bir çizim alanı olusturduk
            Pen p = new Pen(çizgirenk, kalınlık);   // programımıza bir kalem  olusturduk rengini ve kalınlıgnı degişkenlerle belirledik
            if (toolStripComboBox1.SelectedIndex == 1)//içi boş kare olusturan fonksiyon
            {
                g.DrawRectangle(p, Math.Min(eksenX, e.X), Math.Min(eksenY, e.Y), Math.Abs(eksenX - e.X), Math.Abs(eksenY - e.Y));//mouse bastıgımız an ile bıraktıgımız andaki mesafeyi bulup çizim yapan bir fonksiyon yazdık
            }
            if (toolStripComboBox1.SelectedIndex == 2)//içi dolu kare olusturan fonksiyon
            {
                Brush renk = new SolidBrush(çizgirenk);//by fonksiyonu bir dolgu malzemesi olarak kullandık boşlukları doldurup renklendiriyor
                g.FillRectangle(renk, Math.Min(eksenX, e.X), Math.Min(eksenY, e.Y), Math.Abs(eksenX - e.X), Math.Abs(eksenY - e.Y));
            }
            if (toolStripComboBox1.SelectedIndex == 3)//elips olusturan fonksiyon
            {
                g.DrawEllipse(p, Math.Min(eksenX, e.X), Math.Min(eksenY, e.Y), Math.Abs(eksenX - e.X), Math.Abs(eksenY - e.Y));//mouse bastıgımız an ile bıraktıgımız andaki mesafeyi bulup çizim yapan bir fonksiyon yazdık
            }
            if (toolStripComboBox1.SelectedIndex == 4)//içi dolu elips olusturan fonksiyon
            {
                Brush renk = new SolidBrush(çizgirenk);//by fonksiyonu bir dolgu malzemesi olarak kullandık boşlukları doldurup renklendiriyor
                g.FillEllipse(renk, Math.Min(eksenX, e.X), Math.Min(eksenY, e.Y), Math.Abs(eksenX - e.X), Math.Abs(eksenY - e.Y));
            }


            ciz = false;//mouse basmayı bırakınca çizmeyi durduruyoruz
        }

        private void arkaPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult tus;  // bu kısımda kendimize hazır bir renk paleti olusturup ayarlıyoruz
            tus =colorDialog1.ShowDialog();
            if (tus == DialogResult.OK)
            {
             
              
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        
        private void boyut600x300ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            genişlik = pictureBox2.Width;
            yükseklik = pictureBox2.Height;
             Boyut boyut =new Boyut();
            boyut.ShowDialog();
            pictureBox2.Width = genişlik;
            pictureBox2.Height = yükseklik;
            boyut600x300ToolStripMenuItem.Text = "boyut( " + pictureBox2.Width.ToString() + "x " + pictureBox2.Height.ToString() + ")";
        }
    
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();//yeni bir kaydetme diyaloğu oluşturuyoruz.

            sfd.Filter = "jpeg dosyası(*.jpg)|*.jpg|Bitmap(*.bmp)|*.bmp";//.bmp veya .jpg olarak kayıt imkanı sağlıyoruz.

            sfd.Title = "Kayıt";//diğaloğumuzun başlığını belirliyoruz.

            sfd.FileName = "resim";//kaydedilen resmimizin adını 'resim' olarak belirliyoruz.

            DialogResult sonuç = sfd.ShowDialog();

            if (sonuç == DialogResult.OK)
            {
                pictureBox2.Image.Save(sfd.FileName);//Böylelikle resmi istediğimiz yere kaydediyoruz.
            }
        }

        private void yazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {

            System.Drawing.Printing.PrintDocument myPrintDocument1 = new System.Drawing.Printing.PrintDocument();
            PrintDialog myPrinDialog1 = new PrintDialog();
            myPrintDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(myPrintDocument2_PrintPage);// bu kısımda programı hangi formatla kaydetmesini ve kaç tane renklimi degilmi gibi seçenekleri ayarlayoruz
            myPrinDialog1.Document = myPrintDocument1;
            if (myPrinDialog1.ShowDialog() == DialogResult.OK)
            {
                myPrintDocument1.Print();
            }
        }

        private void myPrintDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            Bitmap myBitmap1 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            pictureBox2.DrawToBitmap(myBitmap1, new Rectangle(0, 0,pictureBox2.Width, pictureBox2.Height));// bu kısımda nasıl yazdırıcıagını yazıyoruz
            e.Graphics.DrawImage(myBitmap1, 0, 0);
            myBitmap1.Dispose();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void baskıÖnizlemeToolStripMenuItem_Click(object sender, EventArgs e)
        {/*
            DialogResult sayfaOnizleme;
            sayfaOnizleme = printPreviewDialog1.;
            if (sayfaOnizleme == DialogResult.OK)
            {
               
            }*/
        }

        private void açToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            OpenFileDialog dosya = new OpenFileDialog(); //istedigimiz resmi açmak için dialogresult ları kullanıytoruz ve resimleri istedigimiz konumdan çekiyoruz

            dosya.InitialDirectory = "C:\\";

            dosya.Title = "Resim Seç";

            dosya.FilterIndex = 1;

            dosya.Filter = ("Jpeg Resim Dosyası (*.jpg)|*.jpg|Gif Resim Dosyası (*.gif)|*.gif|Bmp Resim Dosyası(*.bmp)|*.bmp|Tüm Dosyalar(*.*)|*.*"); //filitre işlevi uyguluyoruz

            if (dosya.ShowDialog() == DialogResult.OK)

            {
                string dosyaadi = "";

                dosyaadi = dosya.FileName; // isimle bulma 

                pictureBox2.Image = Image.FromFile(dosyaadi);

                pictureBox2.Top = 50;

                pictureBox2.Size = new System.Drawing.Size(pictureBox2.Width, pictureBox2.Height);

                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                this.Controls.Add(pictureBox2);

                this.Text = dosya.SafeFileName;

              /*  pictureBox2.Image.Save(Application.StartupPath + "\\resimler\\" + dosya.SafeFileName, System.Drawing.Imaging.ImageFormat.Jpeg);*/ 

            }
        }

    

     

        private void toolStripComboBox2_TextChanged(object sender, EventArgs e)
        {
             kalınlık = Convert.ToInt32(toolStripComboBox2.SelectedItem.ToString());//kalınlıgı degiştirdigimizde degişkenlerin degişmesini sağladık
        }

     

        private void renkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult tus;  // bu kısımda kendimize hazır bir renk paleti olusturup ayarlıyoruz
            tus = colorDialog1.ShowDialog();
            if (tus == DialogResult.OK)
            {
                çizgirenk = colorDialog1.Color; //yapılan çizimin rengini ayarladık
                toolStripTextBox1.BackColor = colorDialog1.Color;//hangi rengi kullandıgımızı gösteren barı ayarladık
            }
        }

        
    }
}

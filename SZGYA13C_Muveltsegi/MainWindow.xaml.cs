using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Linq;

namespace SZGYA13C_Muveltsegi
{
    public partial class MainWindow : Window
    {
        List<Muveltseg> muveltseg = new List<Muveltseg>();
        public MainWindow()
        {
            InitializeComponent();
            muveltseg = Muveltseg.FromFile(@"..\..\..\src\feladatok.txt");

            var kerdesek = muveltseg.Select(m => m.Kerdes).ToList();
            foreach (var k in kerdesek)
            {
                lib1.Items.Add(k);
            }

        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            var kerdojeles = muveltseg.FindAll(m => m.Kerdes.Contains("?"));
            lb1.Content = $"A kérdőjeles feladatok száma: {kerdojeles.Count()}";
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            var haromPontos = muveltseg.Where(m => m.Tananyag.Contains("kemia") && m.Pont == 3).Count();
            lb2.Content = $"Az adatfájlban {haromPontos} db 3 pontos kémia feladat van.";
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            var minValasz = muveltseg.Min(m => m.Valasz);
            var MaxValasz = muveltseg.Max(m => m.Valasz);
            lb3.Content = $"A válaszok számértéke {minValasz} és {MaxValasz} között terjed.";
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            var temakorok = muveltseg.OrderBy(m => m.Tananyag).Select(m => m.Tananyag).Distinct();
            foreach (var t in temakorok)
            {
                lib2.Items.Add(t);
            }
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            var kereses = muveltseg.Where(m => m.Kerdes.Contains(tbx1.Text)).ToList();
            if(kereses.Count != 0)
            {
                foreach (var k in kereses)
                {
                    lib3.Items.Add(k.Kerdes);
                }
            }
            else
            {
                MessageBox.Show("Ez a szó/szórészlet nem szerepel egyik kérdésben sem!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
                tbx1.Text = string.Empty;
            }
            
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            //itt randommal kellene, de mivel arra nem jöttem rá, ezért az első kérdéssel dolgoztam.
            Random rnd = new Random();
            var kereses = muveltseg.Where(m => m.Kerdes.Contains(tbx1.Text)).ToList();
            //var randomI = rnd.Next(1, kereses.Count() + 1);
            lb4.Content = muveltseg.Select(m => m.Kerdes).First();
            if (int.Parse(tbx2.Text) == muveltseg.Select(m => m.Valasz).First())
            {
                lb5.Content = $"A válasz {muveltseg.Select(m => m.Pont).First()} pontot ér.";
            }
            else
            {
                lb5.Content = $"A válasz 0 pontot ér.";
            }
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab6
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Towar> lista = new List<Towar>()
        {
            new Towar(){Nazwa = "Towar1", Cena = 10.50, Ilosc = 5, Kategoria = Kategoria.domyslna},
            new Towar(){Nazwa = "Towar2", Cena = 70.30, Ilosc = 20, Kategoria = Kategoria.srednia},
            new Towar(){Nazwa = "Towar3", Cena = 10.99, Ilosc = 5, Kategoria = Kategoria.wyzsza},
            new Towar(){Nazwa = "Towar4", Cena = 10.50, Ilosc = 2, Kategoria = Kategoria.domyslna},
            new Towar(){Nazwa = "Towar5", Cena = 70.30, Ilosc = 3, Kategoria = Kategoria.srednia},
            new Towar(){Nazwa = "Towar6", Cena = 99.99, Ilosc = 5, Kategoria = Kategoria.wyzsza},
            new Towar(){Nazwa = "Towar7", Cena = 21.37, Ilosc = 69, Kategoria = Kategoria.domyslna},
            new Towar(){Nazwa = "Towar8", Cena = 50.00, Ilosc = 9, Kategoria = Kategoria.srednia},
            new Towar(){Nazwa = "Towar9", Cena = 104.20, Ilosc = 1, Kategoria = Kategoria.wyzsza},
            new Towar(){Nazwa = "Towar10", Cena = 11.50, Ilosc = 25, Kategoria = Kategoria.domyslna},
        };
        public MainWindow()
        {
            InitializeComponent();
        }
        double FunkcjaRosenbrocka(double x, double y)
        {
            return Math.Pow((1-x), 2) +100 * Math.Pow((y - Math.Pow(x,20)), 2);
        }
        private void btnFunkcja1_Click(object sender, RoutedEventArgs e)
        {
            var wyn = ZadA.ZnajdZMinimumFunkcji2D(-10.0, 10.0, -10.0, 10.0, 10000, (x, y) => x * y);
            var wyn2 = ZadA.ZnajdZMinimumFunkcji2D(-10.0, 10.0, -10.0, 10.0, 10000, FunkcjaRosenbrocka);
            lblF2.Content = wyn;
            lblF2.Content = wyn2;
        }

        private void btnFunkcja2_Click(object sender, RoutedEventArgs e)
        {
            lblF2.Content = ZadA.ZnajdZMinimumFunkcji2D(-10, 10, -10, 10, 10000, (x, y) => Math.Pow((x - 4), 2) + Math.Pow((y + 2), 2));
        }

        private void btnLinq1_Click(object sender, RoutedEventArgs e)
        {
            var x = from s in lista where s.Ilosc > 5 orderby s.Ilosc select s;
            foreach(var v in x)
            {
                lstBox.Items.Add(v.ToString()); 
            }
        }

        private void btnLinq2_Click(object sender, RoutedEventArgs e)
        {

            var x = lista.Where(s => s.Kategoria == Kategoria.wyzsza).GroupBy(t => t.Kategoria).Select(s => new { Liczba = s.Sum(t => t.Ilosc)});
            foreach (var v in x)
            { 
                lstBox.Items.Add(v.ToString());
            }
        }

        private void btnLinq3_Click(object sender, RoutedEventArgs e)
        {
            var x = lista.Where(t => t.Cena > lista.Average(s => s.Cena)).Select(t => t.Nazwa +" "+ t.Cena);
            foreach (var v in x)
            {
                lstBox.Items.Add(v.ToString());
            }
        }

        private void btnLinq4_Click(object sender, RoutedEventArgs e)
        {
            var x = lista.GroupBy(t => t.Kategoria).Select(g => new { Kategoria = g.Key, Cena = g.Average(t => t.Cena), Ilosc = g.Sum(t => t.Ilosc) });
            foreach (var v in x)
            {
                lstBox.Items.Add(v.ToString());
            }
        }

        private void btnLinq5_Click(object sender, RoutedEventArgs e)
        {
            var x = lista.Where(t => t.Cena == lista.Max(s => s.Cena)).Select(t => t.Nazwa + " " + t.Cena);
            foreach (var v in x)
            {
                lstBox.Items.Add(v.ToString());
            }
        }
        // Zad Dom 1
        static void Wyswietl2(string t)
        {
            MessageBox.Show(t);
        }

        private void btnDom1_Click(object sender, RoutedEventArgs e)
        {
           Towar tow = new Towar() { Nazwa = "Towarek", Cena = 20.50, Ilosc = 5, Kategoria = Kategoria.domyslna };
          // tow.Wyswietl(tow, t => t.Wyswietl2);
        }

        private void btnDom2_Click(object sender, RoutedEventArgs e)
        {
            var wyn = Towar.ObliczPole(4);
            lblF2.Content = wyn;
        }
    }
}

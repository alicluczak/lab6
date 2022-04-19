using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public static class ZadA
    {

        public static (double, double, double) ZnajdZMinimumFunkcji2D(double minX, double maxX, double minY, double maxY, int liczbaIteracji, Func<double, double, double> funkcja)
        {
            double? x = null;
            double? y = null;
            double? minF = null;

            double tempX, tempY, tempF;
            Random random = new Random();

            for (int i = 1; i <= liczbaIteracji; i++)
            {
                tempX = random.NextDouble();
                tempY = random.NextDouble();
                tempF = funkcja(tempX, tempY);

                if (minF == null || tempF < minF)
                {
                    minF = tempF;
                    x = tempX;
                    y = tempY;
                }
            }
            return ((double)x, (double)y, (double)minF);
        }
    }
    //zad B
    public enum Kategoria
    {
        wyzsza,
        srednia,
        domyslna
    }
    public class Towar
    {
        public string Nazwa { get; set; }
        public double Cena { get; set; }
        public int Ilosc { get; set; }
        public Kategoria Kategoria { get; set; }

        public override string ToString()
        {
            return $"nazwa: {Nazwa}, ilość: {Ilosc}, kategoria: {Kategoria.ToString()}";
        }
        //static Action<string, double, int, Kategoria> act;
        //Action<string, double, int, Kategoria> act
        public static void Wyswietl(Towar dana, Action<Towar> act)
        {
            act(dana);
        }

        // zad dom 2
        public static (double,double) ObliczPole(double promien)
        {
            double? p = null;
            double? o = null;

            p = Math.PI * promien * promien;
            o = 2 * Math.PI * promien;
            return ((double)p, (double)o);
        }

    }    
}

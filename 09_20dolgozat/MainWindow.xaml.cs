using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

namespace _09_20dolgozat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<fuvar> lista = new List<fuvar>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void harmadik_btn_Click(object sender, RoutedEventArgs e)
        {
            var fajl = new OpenFileDialog();
            if (fajl.ShowDialog() == true)
            {
                StreamReader sr = new StreamReader(fajl.FileName);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    string[] adat = sor.Split(";");
                    fuvar fuvaros = new fuvar(Convert.ToInt32(adat[0]), Convert.ToDateTime(adat[1]), Convert.ToInt32(adat[2]), Convert.ToDouble(adat[3]), Convert.ToDouble(adat[4]), Convert.ToDouble(adat[5]), Convert.ToString(adat[6]));
                    lista.Add(fuvaros);
                }
                lbharmadik.Content = $"Harmadik feladat: {lista.Count()}";

                sr.Close();


            }
        }

        private void negyedik_btn_Click(object sender, RoutedEventArgs e)
        {
            lbnegyedik.Content = $"{lista.Sum(x => x.Dij).Where(x => x.Azonosito == 6185)} volt a bevétele, {lista.Count(x => x.Dij).Where(x => x.Azonosito == 6185)} darab fuvar volt";
            lbnegyedik.Content = $"{lista.Count(x => x.Azonosito == 6185)} fuvar alatt {lista.Where(x == x.Azonosito == 6185).Sum(x.Dij)}";
        }

        private void otodik_btn_Click(object sender, RoutedEventArgs e)
        {
            lbotodik.Items.Add("ötödik feladat");
            lbotodik.Items.Add($"Bankkártyás fizetés: {lista.Where(x => x.Fizetes_modja == "bankkártya").ToList().Count()}");
            lbotodik.Items.Add($"Készpénzes fizetés: {lista.Where(x => x.Fizetes_modja == "készpénz").ToList().Count()}");
            lbotodik.Items.Add($"Ismeretlen fizetés: {lista.Where(x => x.Fizetes_modja == "ismeretlen").ToList().Count()}");
            lbotodik.Items.Add($"Vitatott fizetés: {lista.Where(x => x.Fizetes_modja == "vitatott").ToList().Count()}");
            lbotodik.Items.Add($"Ingyenes fizetés: {lista.Where(x => x.Fizetes_modja == "ingyenes").ToList().Count()}");


        }

        private void hatodik_btn_Click(object sender, RoutedEventArgs e)
        {
            lbhatodik.Items.Add($"Hatodik feladat:{Math.Round(lista.Select(x => x.Megtett_tavolsag).Sum() * 1,6)}");
        }

        private void hetedik_btn_Click(object sender, RoutedEventArgs e)
        {
            lbhetedik.Items.Add($"hetedik feladat: A fuvar hossza:{lista.Select(x => x).OrderByDescending(x => x.Megtett_tavolsag).ToList().First().Utazas_idotartama}");
            lbhetedik.Items.Add($"hetedik felabat: Azonosito: {lista.Select(x => x).OrderByDescending(x => x.Megtett_tavolsag).ToList().First().Azonosito}");
            lbhetedik.Items.Add($"hetedik felabat: Tavolsag: {lista.Select(x => x).OrderByDescending(x => x.Megtett_tavolsag).ToList().First().Megtett_tavolsag}");
            lbhetedik.Items.Add($"hetedik felabat: Azonosito: {lista.Select(x => x).OrderByDescending(x => x.Megtett_tavolsag).ToList().First().Azonosito}");
            lbhetedik.Items.Add($"hetedik felabat: Dija: {lista.Select(x => x).OrderByDescending(x => x.Megtett_tavolsag).ToList().First().Dij}");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("hibak.txt");
            sw.WriteLine();
            lista.Where(x => x.Utazas_idotartama > 0 && x.Dij > 0).ToList().ForEach(x => x.);
             
        }
    }
}


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


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // init.
            string machaine = "ABCD";
            int i;
            string s;
            int alea;
            Random aleatoire = new Random();
            lb.Items.Clear();

            // traitement
            alea = aleatoire.Next(1, 100);
            for (i=1; i<=alea; i++) {
                    s = i.ToString() + " - " + machaine;
                    lb.Items.Add(s);
                }

            UpdatLabel();

            //int entier = aleatoire.next(); //Génère un entier aléatoire positif
            //int entierUnChiffre = aleatoire.next(10); //Génère un entier compris entre 0 et 9
            //int mois = aleatoire.Next(1, 13); // Génère un entier compris entre 1 et 12


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lb.Items.Clear();
            UpdatLabel();
        }

        private void UpdatLabel()
        {
            lab1.Content = lb.Items.Count.ToString() + " éléments.";
        }


    }
}

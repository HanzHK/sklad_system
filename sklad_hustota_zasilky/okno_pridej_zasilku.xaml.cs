﻿using System;
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
using System.Windows.Shapes;

namespace sklad_hustota_zasilky
{
    /// <summary>
    /// Interakční logika pro Window1.xaml
    /// </summary>
    public partial class okno_pridej_zasilku : Window
    {
        public okno_pridej_zasilku()
        {
            InitializeComponent();

            // Připojit události Changed na TextBoxy
            sirkaZasilkyTxt.TextChanged += AktualizujUdaje;
            delkaZasilkyTxt.TextChanged += AktualizujUdaje;
            vyskaZasilkyTxt.TextChanged += AktualizujUdaje;
        }
        private void AktualizujUdaje(object sender, TextChangedEventArgs e)
        {
            // Získat hodnoty z TextBoxů
            if (!string.IsNullOrWhiteSpace(vyskaZasilkyTxt.Text) && !string.IsNullOrWhiteSpace(delkaZasilkyTxt.Text) && !string.IsNullOrWhiteSpace(sirkaZasilkyTxt.Text))
            {
                if (double.TryParse(vyskaZasilkyTxt.Text, out double vyska) &&
                    double.TryParse(delkaZasilkyTxt.Text, out double delka) &&
                    double.TryParse(sirkaZasilkyTxt.Text, out double sirka))
                {
                    // Vypočítat objem (předpokládám základní vzorec objemu pro tuto ilustraci)
                    double objem = vyska * delka * sirka / 1_000_000;

                    // Aktualizovat obsah TextBlocku s výsledkem
                    objemZasilkyTxt.Text = $"Objem zásilky: {objem} m³";
                }
                else
                {
                    // Pokud některá z hodnot není číslo, zobrazit chybovou zprávu nebo prázdný text
                    objemZasilkyTxt.Text = "Nesprávný vstup";
                }

            }
            else
            {
                objemZasilkyTxt.Text = "";
            }
        }
    }
    }

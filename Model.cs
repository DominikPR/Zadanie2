using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropetyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        string
            buforIO = "",
            buforOperatora = "",
            buforPoprzedniegoOperatora = "",
            buforLiczby1 = "",
            buforLiczby2 = "",
            buforDziałania = "",
            buforWyniku = "";

        bool
            flagaOperatora = false,
            flagaWyniku = false,
            flagaCyfry = false,
            flagaPrzecinka = false,
            flagaZnaku = false;

        //Gettery i Settery
        public string Przypominajka
        {
            get
            {
               return $"{BuforLiczby1} {BuforOperatora} {BuforLiczby2}";
            }
        }

        public string BuforIO
        {
            get { return buforIO; }
            set
            {
                buforIO = value;
                OnPropetyChanged();
            }
        }

        public string BuforOperatora
        {
            get { return buforOperatora; }
            set
            {
                buforOperatora = value;
                OnPropetyChanged();
            }
        }
        public string BuforPoprzedniegoOperatora
        {
            get { return buforPoprzedniegoOperatora; }
            set
            {
                buforPoprzedniegoOperatora = value;
                OnPropetyChanged();
            }
        }

        public string BuforLiczby1
        {
            get { return buforLiczby1; }
            set
            {
                buforLiczby1 = value;
                OnPropetyChanged();
                OnPropetyChanged("Przypominajka");
            }
        }

        public string BuforLiczby2
        {
            get { return buforLiczby2; }
            set
            {
                buforLiczby2 = value;
                OnPropetyChanged();
                OnPropetyChanged("Przypominajka");
            }
        }

        public string BuforDziałania
        {
            get { return buforDziałania; }
            set
            {
                buforDziałania = value;
                OnPropetyChanged();
                OnPropetyChanged("Przypominajka");
            }
        }

        public string BuforWyniku
        {
            get { return buforWyniku; }
            set
            {
                buforWyniku = value;
                OnPropetyChanged();
                OnPropetyChanged("Przypominajka");
            }
        }

        public void DopiszCyfrę(string cyfra)
        {
            if(flagaWyniku == false){
                if (flagaCyfry == false){
                    if (BuforIO == "0")
                        BuforIO = "";
                    BuforIO += cyfra;
                }
                else{
                    BuforIO = "";
                    BuforIO += cyfra;
                    flagaCyfry = false;
                }
            }
            else{
                Skasuj();
                if (BuforIO == "0")
                    BuforIO = "";
                BuforIO += cyfra;
            }                    
        }

        public void PobierzOperator(string pobierzOerator)
        {
            BuforOperatora = pobierzOerator;
            flagaCyfry = true;
            flagaPrzecinka = false;
            if (flagaOperatora == false){
                BuforLiczby1 = BuforIO;
                flagaOperatora = true;
            }
            else{   
                if(flagaWyniku == false){
                    double wynik;
                    if (BuforPoprzedniegoOperatora == "+"){
                        BuforLiczby2 = BuforIO;
                        wynik = Convert.ToDouble(BuforLiczby1) + Convert.ToDouble(BuforLiczby2);
                        BuforIO = Convert.ToString(wynik);
                        BuforLiczby1 = BuforIO;
                        BuforLiczby2 = "";
                    }
                    if (BuforPoprzedniegoOperatora == "-"){
                        BuforLiczby2 = BuforIO;
                        wynik = Convert.ToDouble(BuforLiczby1) - Convert.ToDouble(BuforLiczby2);
                        BuforIO = Convert.ToString(wynik);
                        BuforLiczby1 = BuforIO;
                        BuforLiczby2 = "";
                    }
                    if (BuforPoprzedniegoOperatora == "×"){
                        BuforLiczby2 = BuforIO;
                        wynik = Convert.ToDouble(BuforLiczby1) * Convert.ToDouble(BuforLiczby2);
                        BuforIO = Convert.ToString(wynik);
                        BuforLiczby1 = BuforIO;
                        BuforLiczby2 = "";
                    }
                    if (BuforPoprzedniegoOperatora == "÷"){
                        BuforLiczby2 = BuforIO;
                        wynik = Convert.ToDouble(BuforLiczby1) / Convert.ToDouble(BuforLiczby2);
                        BuforIO = Convert.ToString(wynik);
                        BuforLiczby1 = BuforIO;
                        BuforLiczby2 = "";
                    }
                }
                else{
                    flagaWyniku = false;
                    BuforLiczby1 = BuforIO;
                    BuforLiczby2 = "";                  
                }
                
            }
            BuforPoprzedniegoOperatora = BuforOperatora;            
        }

        public void PobierzPrzecinek(string przecinek)
        {
            if (flagaWyniku == false){
                if (flagaPrzecinka == false){                    
                    BuforIO += przecinek;
                    flagaPrzecinka = true;
                }

            }
            else{
                Skasuj();
                BuforIO += przecinek;
                flagaPrzecinka = true;
            }
        }

        public void PrzełączZnak()
        {
            if (BuforIO != "0"){
                if (flagaZnaku == false){
                    BuforIO = "-" + BuforIO;
                    flagaZnaku = true;
                }
                else{
                    BuforIO = BuforIO.Substring(1);
                    flagaZnaku = false;
                }
            }               
        }
        public void PrzełączOperator(string operatorPrzełącz)
        {
            if (flagaCyfry == true){
                BuforOperatora = operatorPrzełącz;
                flagaOperatora = false;
            }

        }

        public void CofnijZnak()
        {
            BuforIO = BuforIO.Substring(0, BuforIO.Length - 1);
            if (BuforIO == ""){
                BuforIO = "0";
            }
        }

        public void Skasuj()
        {
            flagaOperatora = flagaWyniku = flagaCyfry = flagaPrzecinka = flagaZnaku = false;
            BuforIO = "0";
            BuforOperatora = "";
            buforPoprzedniegoOperatora = BuforLiczby1 = BuforLiczby2 = buforDziałania = BuforWyniku = "";  
        }

        public void Resetuj()
        {
            Skasuj();
            OnPropetyChanged("BuforWyniku");
            OnPropetyChanged("BuforDrugiejLiczby");
            OnPropetyChanged("BuforDziałania");
            OnPropetyChanged("Przypominajka");
        }

        public void DziałanieDwuargumentowe()
        {
            double wynik;
            if(BuforOperatora == "+"){
                BuforLiczby2 = BuforIO;
                wynik = Convert.ToDouble(BuforLiczby1) + Convert.ToDouble(BuforLiczby2);
                BuforIO = Convert.ToString(wynik);
                flagaWyniku = true;
            }
            if (BuforOperatora == "-"){
                BuforLiczby2 = BuforIO;
                wynik = Convert.ToDouble(BuforLiczby1) - Convert.ToDouble(BuforLiczby2);
                BuforIO = Convert.ToString(wynik);
                flagaWyniku = true;
            }
            if (BuforOperatora == "×"){
                BuforLiczby2 = BuforIO;
                wynik = Convert.ToDouble(BuforLiczby1) * Convert.ToDouble(BuforLiczby2);
                BuforIO = Convert.ToString(wynik);
                flagaWyniku = true;
            }
            if (BuforOperatora == "÷"){
                BuforLiczby2 = BuforIO;
                wynik = Convert.ToDouble(BuforLiczby1) / Convert.ToDouble(BuforLiczby2);
                BuforIO = Convert.ToString(wynik);
                flagaWyniku = true;
            }
        }      

        public void DziałanieProcentowe()
        {
            if(BuforLiczby1 == "" || BuforLiczby1 == "0"){
                BuforLiczby1 = "0";
            }
            else{
                BuforLiczby2 = BuforIO;
                double wynik;
                double wartosc;
                wartosc = (Convert.ToDouble(BuforLiczby2) * Convert.ToDouble(BuforLiczby1)) / 100;
                if(buforPoprzedniegoOperatora == "+"){
                    wynik = Convert.ToDouble(BuforLiczby1) + wartosc;
                    BuforLiczby2 = Convert.ToString(wartosc);
                    BuforIO = Convert.ToString(wynik);
                    flagaWyniku = true;
                }
                if (buforPoprzedniegoOperatora == "-"){
                    wynik = Convert.ToDouble(BuforLiczby1) + wartosc;
                    BuforLiczby2 = Convert.ToString(wartosc);
                    BuforIO = Convert.ToString(wynik);
                    flagaWyniku = true;
                }
                if (buforPoprzedniegoOperatora == "×"){
                    wynik = Convert.ToDouble(BuforLiczby1) + wartosc;
                    BuforLiczby2 = Convert.ToString(wartosc);
                    BuforIO = Convert.ToString(wynik);
                    flagaWyniku = true;
                }
                if (buforPoprzedniegoOperatora == "÷"){
                    wynik = Convert.ToDouble(BuforLiczby1) + wartosc;
                    BuforLiczby2 = Convert.ToString(wartosc);
                    BuforIO = Convert.ToString(wynik);
                    flagaWyniku = true;
                }

            }
        }

        public void DziałanieJednoargumentowe(string pobierzDziałanie)
        {
            BuforOperatora = "";
            BuforLiczby2 = "";
            BuforPoprzedniegoOperatora = "";  
            BuforDziałania = pobierzDziałanie;
            BuforLiczby1 = buforIO;
            double wynik;
            if (BuforDziałania == "1/x"){
                wynik = 1 / Convert.ToDouble(BuforLiczby1);
                BuforIO = Convert.ToString(wynik);
                BuforLiczby1 = "1/(" + BuforLiczby1 + ")";

            }
            if (BuforDziałania == "x²"){
                wynik = Convert.ToDouble(BuforLiczby1) * Convert.ToDouble(BuforLiczby1);
                BuforIO = Convert.ToString(wynik);
                BuforLiczby1 = "sqrt(" + BuforLiczby1 + ")";
            }
            if (BuforDziałania == "√x"){
                wynik = Math.Sqrt(Convert.ToDouble(BuforLiczby1));
                BuforIO = Convert.ToString(wynik);
                BuforLiczby1 = "√(" + BuforLiczby1 + ")";
            }
        }

        public void DziałanieJednoargumentowe()
        {
            double wynik;
            if(BuforDziałania == "1/x"){               
                wynik = 1 / Convert.ToDouble(BuforLiczby1);
                BuforIO = Convert.ToString(wynik);
                BuforLiczby1 = "1/(" + BuforLiczby1 + ")";
                
            }
            if (BuforDziałania == "x²"){
                wynik = Convert.ToDouble(BuforLiczby1) * Convert.ToDouble(BuforLiczby1);
                BuforIO = Convert.ToString(wynik);
                BuforLiczby1 = "sqrt(" + BuforLiczby1 + ")";
            }
            if (BuforDziałania == "√x"){
                wynik = Math.Sqrt(Convert.ToDouble(BuforLiczby1));
                BuforIO = Convert.ToString(wynik);
                BuforLiczby1 = "√(" + BuforLiczby1 + ")";
            }
        }      
    }
}

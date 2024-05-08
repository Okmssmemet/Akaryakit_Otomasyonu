namespace AkaryakıtProjesi
{
    internal class Program
    {
        static Fuel fuel = new Fuel();

        static void Main(string[] args)
        {
            bool confirmation = false;

            do
            {
                ApplicationScreen();

                int operationSelection = OperationSelection();

                Console.Clear();

                if (operationSelection == 1)
                {
                    fuel.Print();
                    confirmation = ProgramEndConfirmation();
                }
                else if (operationSelection == 2)
                {
                    char vote = FuelTypeSelection();
                    double newPrice = ChangePrice(vote);
                    fuel.ChangePrice(newPrice, vote);
                    fuel.PrintVote(vote);
                    confirmation = ProgramEndConfirmation();
                }
                else if (operationSelection == 3)
                {
                    Console.WriteLine("-----Akaryakıt Satışı-----");
                    char vote = FuelTypeSelection();
                    fuel.FuelSales(vote);
                    confirmation = ProgramEndConfirmation();

                }
                else if (operationSelection == 4)
                {
                    Console.WriteLine("-----Depo Durumu-----");
                    fuel.FuelTankStatus(); // Tekrar eden metodu buradan çağırıyoruz
                    confirmation = ProgramEndConfirmation();

                }
                else if (operationSelection == 5)
                {
                    Console.WriteLine("-----Toplam Satış Durumu-----");
                    fuel.TotalSalesStatus(); // Tekrar eden metodu buradan çağırıyoruz
                    confirmation = ProgramEndConfirmation();
                }
                else if (operationSelection == 6)
                {
                    Console.WriteLine("Uygulama Sonlanıyor");
                    Environment.Exit(0);

                }
                Console.Clear();
            } while (confirmation);

            Console.WriteLine("Uygulama Sonlanıyor");
            Environment.Exit(0);
        }

        public static void ApplicationScreen()
        {
            Console.WriteLine("AKARYAKIT SATIŞ TAKİP");
            Console.WriteLine("......................");
            Console.WriteLine("1.Birim Fiyat Göster\n2.Birim Fiyat Güncelle\n3.Akaryakıt Satışı Yap\n4.Depo Durumunu Göster\n5.Toplam Satışları Göster\n6.Çıkış");
        }
        public static int OperationSelection()
        {
            Console.WriteLine("Seçiminizi Yapınız [1,2,3,4,5,6]:");
            int secim = Convert.ToInt32(Console.ReadLine());

            do
            {

                if (!(secim == 1 || secim == 2 || secim == 3 || secim == 4 || secim == 5 || secim == 6))
                {
                    Console.WriteLine("Hatalı Bir Giriş Yaptınız...\nSeçiminizi Yapınız [1,2,3,4,5,6]:");
                    secim = Convert.ToInt32(Console.ReadLine());
                }

            } while (!(secim == 1 || secim == 2 || secim == 3 || secim == 4 || secim == 5 || secim == 6));

            return secim;
        }
        public static char FuelTypeSelection()
        {
            Console.WriteLine("Akaryakıt Tipini Seçiniz [D,B,L]:");
            char vote = Convert.ToChar(Console.ReadLine());
            vote = char.ToUpper(vote);

            do
            {

                if (!(vote == 'D' || vote == 'B' || vote == 'L'))
                {
                    Console.WriteLine("Hatalı Bir Tuşlama Yaptınız...\nAkaryakıt Tipini Seçiniz [D,B,L]:");
                    vote = Convert.ToChar(Console.ReadLine());
                    vote = char.ToUpper(vote);
                }

            } while (!(vote == 'D' || vote == 'B' || vote == 'L'));

            return vote;
        }
        public static double ChangePrice(char vote)
        {

            double newPrice;
            if (vote == 'D')
            {
                Console.WriteLine("Dizel (D):{0} TL/Litre : ", fuel.DieselUnitPrice);
                Console.WriteLine("Dizel İçin Yeni Fiyat Giriniz : ");
                newPrice = Convert.ToDouble(Console.ReadLine());
                return newPrice;
            }
            else if (vote == 'B')
            {
                Console.WriteLine("Benzin (B):{0} TL/Litre : ", fuel.GasolineUnitPrice);
                Console.WriteLine("Benzin İçin Yeni Fiyat Giriniz : ");
                newPrice = Convert.ToDouble(Console.ReadLine());
                return newPrice;
            }
            else
                Console.WriteLine("Benzin (B):{0} TL/Litre : ", fuel.GasolineUnitPrice);
            Console.WriteLine("Benzin İçin Yeni Fiyat Giriniz : ");
            newPrice = Convert.ToDouble(Console.ReadLine());
            return newPrice;
        }

        public static bool ProgramEndConfirmation()
        {
            bool confirmation = false;
            Console.WriteLine("Seçiminizi Yapınız: [1:ANA MENÜYE DÖN , 2:PROGRAMI KAPAT]");
            int vote = Convert.ToInt32(Console.ReadLine());
            if (vote == 1)
            {
                confirmation = true;
            }
            else
            {
                confirmation = false;
            }

            return confirmation;
        }
    }

    internal class Fuel
    {
        private double dieselUnitPrice;
        private double gasolineUnitPrice;
        private double lpgUnitPrice;
        private double totalDieselSales;
        private double totalgasolineSales;
        private double totalLpgSales;
        private double tankCapacity = 1000;

        private double dieselInTank;
        private double gasolineTank;
        private double lpgTank;
        public double DieselUnitPrice { get { return dieselUnitPrice; } 
            set 
            {
                if (value > 0)
                {
                    dieselUnitPrice = value;
                }
                else
                {
                    Console.WriteLine("Bir Ürünün Fiyatı 0'dan küçük veya 0'a eşit olamaz.Fiyat Güncellenmedi");
                }

            } 
        }
        public double GasolineUnitPrice { get { return gasolineUnitPrice; }
            set
            {
                if (value > 0)
                {
                    gasolineUnitPrice = value;
                }
                else
                {
                    Console.WriteLine("Bir Ürünün Fiyatı 0'dan küçük veya 0'a eşit olamaz.Fiyat Güncellenmedi");
                }

            }
        }
        public double LpgUnitPrice { get { return lpgUnitPrice; }
            set
            {
                if (value > 0)
                {
                    lpgUnitPrice = value;
                }
                else
                {
                    Console.WriteLine("Bir Ürünün Fiyatı 0'dan küçük veya 0'a eşit olamaz.Fiyat Güncellenmedi");
                }

            }
        }
        public double TotalDieselSales { get { return totalDieselSales; } set { totalDieselSales = value; } }
        public double TotalgasolineSales { get { return totalgasolineSales; } set { totalgasolineSales = value; } }
        public double TotalLpgSales { get { return totalLpgSales; } set { totalLpgSales = value; } }

        public double DieselInTank { get { return dieselInTank; } set { dieselInTank = value; } }
        public double GasolineTank { get { return gasolineTank; } set { gasolineTank = value; } }
        public double LpgTank { get { return lpgTank; } set { lpgTank = value; } }
        public double TankCapacity { get { return tankCapacity; } }

        public Fuel()
        {
            UnitPrice(ref dieselUnitPrice, ref gasolineUnitPrice, ref lpgUnitPrice, ref dieselInTank, ref gasolineTank, ref lpgTank);
        }

        private void UnitPrice(ref double dieselUnitPrice, ref double gasolineUnitPrice, ref double lpgUnitPrice,
            ref double dieselInTank, ref double gasolineTank, ref double lpgTank)
        {
            dieselUnitPrice = 41.39;
            gasolineUnitPrice = 43.98;
            lpgUnitPrice = 20.97;
            dieselInTank = 1000;
            gasolineTank = 1000;
            lpgTank = 1000;
        }
        public void Print()
        {

            Console.WriteLine("Dizel (D):{0} TL/Litre : ", DieselUnitPrice);

            Console.WriteLine("Benzin (B):{0} TL/Litre : ", GasolineUnitPrice);

            Console.WriteLine("LPG (L):{0} TL/Litre", LpgUnitPrice);



        }
        public void PrintVote(char vote)
        {
            if (vote == 'D')
            {
                Console.WriteLine("Dizel (D):{0} TL/Litre : ", DieselUnitPrice);
            }
            else if (vote == 'B')
            {
                Console.WriteLine("Benzin (B):{0} TL/Litre : ", GasolineUnitPrice);
            }
            else
            {
                Console.WriteLine("LPG (L):{0} TL/Litre", LpgUnitPrice);
            }


        }
        public void ChangePrice(double newPrice, char priceSelection)
        {
            if (priceSelection == 'D')
            {
                DieselUnitPrice = newPrice;
            }
            else if (priceSelection == 'B')
            {
                GasolineUnitPrice = newPrice;
            }
            else if (priceSelection == 'L')
            {
                LpgUnitPrice = newPrice;
            }

        }
        public void FuelSales(char PriceSelection)
        {
            double purchasedFuel = 0;
            if (PriceSelection == 'D')
            {
                Console.WriteLine("Ne Kadarlık Dizel Almak İstediğinizi Giriniz:");
                purchasedFuel = Convert.ToDouble(Console.ReadLine());
                DieselInTank = DieselInTank - purchasedFuel;
                purchasedFuel = purchasedFuel * DieselUnitPrice;
                TotalDieselSales = TotalDieselSales + purchasedFuel;
                Console.WriteLine("Yakıt Dolumu Tamamlanmıştır");
                Console.WriteLine("Deponuzda Toplam {0} litre dizel yakıt kalmıştır", DieselInTank);

            }
            else if (PriceSelection == 'B')
            {
                Console.WriteLine("Ne Kadarlık Benzin Almak İstediğinizi Giriniz:");
                purchasedFuel = Convert.ToDouble(Console.ReadLine());
                GasolineTank = GasolineTank - purchasedFuel;
                purchasedFuel = purchasedFuel * GasolineUnitPrice;
                TotalgasolineSales = TotalgasolineSales + purchasedFuel;
                Console.WriteLine("Yakıt Dolumu Tamamlanmıştır");
                Console.WriteLine("Deponuzda Toplam {0}/L dizel yakıt kalmıştır", DieselInTank);
            }
            else
            {
                Console.WriteLine("Ne Kadarlık LPG Almak İstediğinizi Giriniz:");
                purchasedFuel = Convert.ToDouble(Console.ReadLine());
                LpgTank = LpgTank - purchasedFuel;
                purchasedFuel = purchasedFuel * LpgUnitPrice;
                TotalLpgSales = TotalLpgSales + purchasedFuel;
                Console.WriteLine("Yakıt Dolumu Tamamlanmıştır");
                Console.WriteLine("Deponuzda Toplam {0}/L dizel yakıt kalmıştır", DieselInTank);
            }

        }
        public void FuelTankStatus()
        {
            double dieselTankFillPercentage = (DieselInTank / TankCapacity) * 100.0;
            Console.WriteLine("Dizel tankının doluluk oranı: %" + dieselTankFillPercentage.ToString("0.##"));

            double gasolineTankFillPercentage = (GasolineTank / TankCapacity) * 100.0;
            Console.WriteLine("Benzin tankının doluluk oranı: %" + gasolineTankFillPercentage.ToString("0.##"));

            double lpgTankFillPercentage = (LpgTank / TankCapacity) * 100.0;
            Console.WriteLine("LPG tankının doluluk oranı: %" + lpgTankFillPercentage.ToString("0.##"));
        }

        public void TotalSalesStatus()
        {
            Console.WriteLine("Toplam Satılan Dizel Yakıt = {0}", (TankCapacity - DieselInTank));
            Console.WriteLine("Dizel Yakıt Toplam Tutar : {0}", TotalDieselSales);

            Console.WriteLine("Toplam Satılan Benzin Yakıt = {0}", (TankCapacity - GasolineTank));
            Console.WriteLine("Benzin Yakıt Toplam Tutar : {0}", TotalgasolineSales);

            Console.WriteLine("Toplam Satılan Lpg Yakıt = {0}", (TankCapacity - LpgTank));
            Console.WriteLine("Lpg Yakıt Toplam Tutar : {0}", TotalLpgSales);
        }

    }
}
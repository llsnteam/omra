///////////////////////////////////////////////////////////
//  Keres�skezel�.cs
//  Implementation of the Class Keres�skezel�
//  Generated by Enterprise Architect
//  Created on:      02-�pr.-2016 10:16:29
//  Original author: D�niel
///////////////////////////////////////////////////////////




using Adatkezel�;
using Omra;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Adatkezel� {
	public class Keres�skezel� : IKeres�skezel� {

		public List<Bizony�t�k> Bizony�t�kkeres�s(string azonos�t�){

            List<Bizony�t�k> visszateresilista = new List<Bizony�t�k>();

            bool IDkereses = false;     //ID-re keres (sz�mmal kezd�dik) vagy a bizony�t�k t�pus�ra keres (bet�vel kezd�dik)

            for (int i = 0; i < 10; i++)
                if (azonos�t�.StartsWith(Convert.ToString(i))) IDkereses = true;

            if (IDkereses) //ha ID alap�
            {
                Decimal d = Convert.ToDecimal(azonos�t�);

                DatabaseElements DE = new DatabaseElements(); 

                var eredmeny = from x in DE.Bizonyitekok
                               where x.bizonyitekID == d
                               select x;

                foreach (var v in eredmeny)
                    visszateresilista.Add(new Bizony�t�k(v.bizonyitekID, v.megnevezes, v.felvetel));
            }
            else //ha megnevez�s alap�
            {
                DatabaseElements DE = new DatabaseElements();
                var eredmeny = from x in DE.Bizonyitekok
                               where x.megnevezes.Contains(azonos�t�)
                               select x;

                foreach (var v in eredmeny)
                    visszateresilista.Add(new Bizony�t�k(v.bizonyitekID, v.megnevezes, v.felvetel));
            }

            return visszateresilista;
		}


		public List<B�neset> B�nesetkeres�s(string azonos�t�){

            List<B�neset> visszateresilista = new List<B�neset>();

            if (azonos�t� != "")
            {
                Decimal d = Convert.ToDecimal(azonos�t�);

                DatabaseElements DE = new DatabaseElements();

                var eredmeny = from x in DE.Bunesetek
                               where x.bunesetID == d
                               select x;

                foreach (var v in eredmeny)
                {
                    var ered = from x in DE.Dolgozok
                                   where x.dolgozoID == v.felelos_ornagy
                                   select x;

                    Dolgoz� felelosornagy = null;

                    foreach (var m in ered)
                        felelosornagy = new Dolgoz�((Rang)Enum.Parse(typeof(Rang), m.rang.ToString()), m.jelszo, m.nev, m.lakcim, m.dolgozoID);

                    visszateresilista.Add(new B�neset(v.bunesetID, (B�llapot)Enum.Parse(typeof(B�llapot), v.allapot), v.felvetel, v.leiras, v.lezaras, felelosornagy));
                }
            }
            else
            {
                DatabaseElements DE = new DatabaseElements();

                var eredmeny = from x in DE.Bunesetek
                               select x;

                foreach (var v in eredmeny)
                {
                    var ered = from x in DE.Dolgozok
                               where x.dolgozoID == v.felelos_ornagy
                               select x;

                    Dolgoz� felelosornagy = null;

                    foreach (var m in ered)
                        felelosornagy = new Dolgoz�((Rang)Enum.Parse(typeof(Rang), m.rang.ToString()), m.jelszo, m.nev, m.lakcim, m.dolgozoID);

                    visszateresilista.Add(new B�neset(v.bunesetID, (B�llapot)Enum.Parse(typeof(B�llapot), v.allapot), v.felvetel, v.leiras, v.lezaras, felelosornagy));
                }
            }
            

            return visszateresilista;
		}


		public List<Dolgoz�> Dolgoz�keres�s(string azonosito){

            List<Dolgoz�> visszateresilista = new List<Dolgoz�>();

            bool IDkereses = false;     //ID-re keres (sz�mmal kezd�dik) vagy a bizony�t�k t�pus�ra keres (bet�vel kezd�dik)

            for (int i = 0; i < 10; i++)
                if (azonosito.StartsWith(Convert.ToString(i))) IDkereses = true;

            if (IDkereses) //ha ID alap�
            {
                Decimal d = Convert.ToDecimal(azonosito);

                DatabaseElements DE = new DatabaseElements();

                var eredmeny = from x in DE.Dolgozok
                               where x.dolgozoID == d
                               select x;

                foreach (var v in eredmeny)
                    visszateresilista.Add(new Dolgoz�((Rang)Enum.Parse(typeof(Rang),v.rang.ToString()), v.jelszo, v.nev, v.lakcim, v.dolgozoID));
            }
            else //ha megnevez�s alap�
            {
                DatabaseElements DE = new DatabaseElements();

                var eredmeny = from x in DE.Dolgozok
                               where x.nev.Contains(azonosito)
                               select x;

                foreach (var v in eredmeny)
                    visszateresilista.Add(new Dolgoz�((Rang)Enum.Parse(typeof(Rang), v.rang.ToString()), v.jelszo, v.nev, v.lakcim, v.dolgozoID));
            }

			return visszateresilista;
		}


		public List<object> Keres�s(string azonos�t�, Keres�sT�pus t�pus){

            //List<object> visszateresilista = new List<object>();

            //if (azonos�t� == "")
            //{
            //    if (t�pus == Keres�sT�pus.Bizony�t�k)
            //    {
            //        bool IDkereses = false;     //ID-re keres (sz�mmal kezd�dik) vagy a bizony�t�k t�pus�ra keres (bet�vel kezd�dik)
            //        for (int i = 0; i < 10; i++)
            //            if (azonos�t�.StartsWith(Convert.ToString(i))) IDkereses = true;

            //        if (IDkereses)
            //        {
            //            DatabaseElements DE = new DatabaseElements();


            //        }
            //        else
            //        {

            //        }
            //    }

            //    if (t�pus == Keres�sT�pus.B�neset)
            //    {

            //    }

            //    if (t�pus == Keres�sT�pus.Dolgoz�)
            //    {

            //    }

            //    if (t�pus == Keres�sT�pus.Gyan�s�tott)
            //    {

            //    }
            //}

            //else
            //{
            //    if (t�pus == Keres�sT�pus.Bizony�t�k)
            //    {

            //    }

            //    if (t�pus == Keres�sT�pus.B�neset)
            //    {

            //    }

            //    if (t�pus == Keres�sT�pus.Dolgoz�)
            //    {

            //    }

            //    if (t�pus == Keres�sT�pus.Gyan�s�tott)
            //    {

            //    }
            //}
            //return visszateresilista;
            return new List<object>();
		}


		public List<Gyan�s�tott> Gyan�s�tottkeres�s(string azonos�t�){

            List<Gyan�s�tott> visszateresilista = new List<Gyan�s�tott>();

            bool IDkereses = false;     //ID-re keres (sz�mmal kezd�dik) vagy a bizony�t�k t�pus�ra keres (bet�vel kezd�dik)

            for (int i = 0; i < 10; i++)
                if (azonos�t�.StartsWith(Convert.ToString(i))) IDkereses = true;

            if (IDkereses) //ha ID alap�
            {
                Decimal d = Convert.ToDecimal(azonos�t�);

                DatabaseElements DE = new DatabaseElements();

                var eredmeny = from x in DE.Gyanusitottak
                               where x.gyanusitottID == d
                               select x;

                foreach (var v in eredmeny)
                    visszateresilista.Add(new Gyan�s�tott((Gyan�s�tottSt�tusz)Enum.Parse(typeof(Gyan�s�tottSt�tusz), v.statusz.ToString()), v.nev, v.lakcim, v.gyanusitottID));

            }
            else //ha megnevez�s alap�
            {
                DatabaseElements DE = new DatabaseElements();

                var eredmeny = from x in DE.Gyanusitottak
                               where x.nev.Contains(azonos�t�)
                               select x;

                foreach (var v in eredmeny)
                    visszateresilista.Add(new Gyan�s�tott((Gyan�s�tottSt�tusz)Enum.Parse(typeof(Gyan�s�tottSt�tusz), v.statusz.ToString()), v.nev, v.lakcim, v.gyanusitottID));
            }

            return visszateresilista;

			
		}

	}//end Keres�skezel�

}//end namespace Adatkezel�
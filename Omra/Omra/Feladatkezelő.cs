///////////////////////////////////////////////////////////
//  Feladatkezelő.cs
//  Implementation of the Class Feladatkezelő
//  Generated by Enterprise Architect
//  Created on:      02-ápr.-2016 10:16:28
//  Original author: Dániel
///////////////////////////////////////////////////////////


using Adatkezelő;
using Omra;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Adatkezelő 
{
	public class Feladatkezelő : IFeladatkezelő
    {

        DatabaseElements DE = new DatabaseElements();

		/// 
		/// <param name="feladat"></param>
		public void FeladatÁllapotMódosítás(Feladat feladat)
        {
            decimal id = feladat.GetFeladatID;
            var aktFeladat = from x in DE.Bunesetek
                             where x.bunesetID == id
                             select x;
            Bunesetek kiválasztott = aktFeladat.First();
            if (kiválasztott.allapot == "Folyamatban")
            {
                kiválasztott.allapot = "Lezárt";
            }
            else
            {
                kiválasztott.allapot = "Folyamatban";
            }
		}

		/// 
		/// <param name="célszemély"></param>
		/// <param name="létrehozta"></param>
		/// <param name="leírás"></param>
		public void ÚjFeladat(Dolgozó célszemély, Dolgozó létrehozta, string leírás)
        {
            decimal utolsoFeladat = DE.Bunesetek.Last().bunesetID;
            decimal felelosId = létrehozta.GetAzonosító();
            var ujFeladat = new Bunesetek() { bunesetID=utolsoFeladat+1, allapot="Folyamatban", felvetel=DateTime.Now, leiras= leírás, felelos_ornagy=felelosId};   // DOLGOZOK ????
		}

        List<Feladat> IFeladatkezelő.FeladatokLekérdezése(Dolgozó dolgozo)
        {
            decimal id = dolgozo.GetAzonosító();    // linq nem szereti ha ott kérem el
            List<Feladat> vissza = new List<Feladat>();

            var bunesetek = from dolg in DE.FelvettDolgozok
                        where dolg.dolgozoID == id
                        select new { dolg.Bunesetek.bunesetID, dolg.Bunesetek.leiras };

            if (dolgozo.GetBeosztás() == Rang.Ornagy)
            {
                bunesetek = from bun in DE.Bunesetek
                                where bun.felelos_ornagy == id
                                select new { bun.bunesetID, bun.leiras };
            }

            foreach (var item in bunesetek)
            {
                vissza.Add(new Feladat(item.leiras, dolgozo, dolgozo));   // LÉTREHOZÓ KELL ????
            }
            return vissza;
        }
    }//end Feladatkezelő

}//end namespace Adatkezelő
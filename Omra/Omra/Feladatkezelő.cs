///////////////////////////////////////////////////////////
//  Feladatkezel�.cs
//  Implementation of the Class Feladatkezel�
//  Generated by Enterprise Architect
//  Created on:      02-�pr.-2016 10:16:28
//  Original author: D�niel
///////////////////////////////////////////////////////////


using Adatkezel�;
using Omra;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Adatkezel� 
{
	public class Feladatkezel� : IFeladatkezel�
    {

        DatabaseElements DE = new DatabaseElements();

		/// 
		/// <param name="feladat"></param>
		public void Feladat�llapotM�dos�t�s(Feladat feladat)
        {
            decimal id = feladat.GetFeladatID;
            var aktFeladat = from x in DE.Bunesetek
                             where x.bunesetID == id
                             select x;
            Bunesetek kiv�lasztott = aktFeladat.First();
            if (kiv�lasztott.allapot == "Folyamatban")
            {
                kiv�lasztott.allapot = "Lez�rt";
            }
            else
            {
                kiv�lasztott.allapot = "Folyamatban";
            }
		}

		/// 
		/// <param name="c�lszem�ly"></param>
		/// <param name="l�trehozta"></param>
		/// <param name="le�r�s"></param>
		public void �jFeladat(Dolgoz� c�lszem�ly, Dolgoz� l�trehozta, string le�r�s)
        {
            decimal utolsoFeladat = DE.Bunesetek.Last().bunesetID;
            decimal felelosId = l�trehozta.GetAzonos�t�();
            var ujFeladat = new Bunesetek() { bunesetID=utolsoFeladat+1, allapot="Folyamatban", felvetel=DateTime.Now, leiras= le�r�s, felelos_ornagy=felelosId};   // DOLGOZOK ????
		}

        List<Feladat> IFeladatkezel�.FeladatokLek�rdez�se(Dolgoz� dolgozo)
        {
            decimal id = dolgozo.GetAzonos�t�();    // linq nem szereti ha ott k�rem el
            List<Feladat> vissza = new List<Feladat>();

            var bunesetek = from dolg in DE.FelvettDolgozok
                        where dolg.dolgozoID == id
                        select new { dolg.Bunesetek.bunesetID, dolg.Bunesetek.leiras, dolg.Bunesetek.felvetel, dolg.Bunesetek.allapot };

            if (dolgozo.GetBeoszt�s() == Rang.Ornagy)
            {
                bunesetek = from bun in DE.Bunesetek
                                where bun.felelos_ornagy == id
                                select new { bun.bunesetID, bun.leiras, bun.felvetel,bun.allapot };
            }

            foreach (var item in bunesetek)
            {
                vissza.Add(new Feladat(item.leiras, dolgozo, item.felvetel,(F�llapot)Enum.Parse(typeof(F�llapot),item.allapot)));
            }
            return vissza;
        }
    }//end Feladatkezel�

}//end namespace Adatkezel�
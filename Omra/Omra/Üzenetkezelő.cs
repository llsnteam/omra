///////////////////////////////////////////////////////////
//  �zenetkezel�.cs
//  Implementation of the Class �zenetkezel�
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
	public class �zenetkezel� : I�zenetkezel� {

        DatabaseElements DE = new DatabaseElements();
		/// 
		/// <param name="t�rzs"></param>
		/// <param name="t�rgy"></param>
		/// <param name="k�ld�"></param>
		/// <param name="c�mzett"></param>
		public void �zenetK�ld�se(string t�rzs, string t�rgy, Dolgoz� k�ld�, Dolgoz� c�mzett)
        {
            var utolsoUzenet = from x in DE.Uzenetek
                               where x.uzenetID == DE.Uzenetek.Last().uzenetID
                               select x.uzenetID;
            decimal kuldoId=k�ld�.GetAzonos�t�();
            decimal cimzettId=c�mzett.GetAzonos�t�();
            var ujUzenet = new Uzenetek() {uzenetID=+1, szoveg = t�rzs, targy = t�rgy, felado = kuldoId, cimzett = cimzettId };
            DE.Uzenetek.Add(ujUzenet);     // TESZT !!!!!!!!!!!! 
            DE.SaveChanges();
		}

		/// 
		/// <param name="Dolgoz�"></param>
		public List<�zenet> �zenetMegtekint�se(Dolgoz� dolgozo)  // kilist�zza a be�rklezett �zeneteket
        {
            decimal id = dolgozo.GetAzonos�t�();    // linq nem szereti ha ott k�rem el
            List<�zenet> vissza = new List<�zenet>();
            var uzenetek = from x in DE.Uzenetek
                           where x.cimzett == id
                           select x;
            foreach (var item in uzenetek)
            {
                vissza.Add(new �zenet(item.szoveg,item.targy,KitolJott(item.felado),dolgozo));
            }
            return vissza;
		}

        Dolgoz� KitolJott(decimal id)   // l�trehoz az �zenetnek egy dolgoz� p�ld�nyt, azt akit�l j�tt az �zenet
        {
            var kitol = from x in DE.Dolgozok 
                             where x.dolgozoID == id 
                             select x;
            Dolgozok vissza = kitol.First();
            return new Dolgoz�((Rang)Enum.Parse(typeof(Rang),vissza.rang.ToString()), vissza.jelszo, vissza.nev, vissza.lakcim, vissza.dolgozoID);
        }

		/// 
		/// <param name="�zenet"></param>
		public void �zenetT�rl�se(�zenet �zenet)
        {
            decimal id = �zenet.GetUzenetID;
            var aktUzenet = DE.Uzenetek.Single(x => x.uzenetID == id);
            DE.Uzenetek.Remove(aktUzenet);
            DE.SaveChanges();
		}

	}//end �zenetkezel�

}//end namespace Adatkezel�
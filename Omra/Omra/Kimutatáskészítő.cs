///////////////////////////////////////////////////////////
//  Kimutat�sk�sz�t�.cs
//  Implementation of the Class Kimutat�sk�sz�t�
//  Generated by Enterprise Architect
//  Created on:      02-�pr.-2016 10:16:29
//  Original author: hallgato
///////////////////////////////////////////////////////////



using Omra;
using Adatkezel�;
using System;
using System.Linq;
using System.Collections.Generic;
namespace Adatkezel� {
	public class Kimutat�sk�sz�t�
    {
        private KimutatasTipus tipus;
		private Kimutat�s kimutat�s;
        private List<StatAdat> adatok;

        public List<StatAdat> GetAdatok()
        {
			return this.adatok;
		}

        public KimutatasTipus GetKimutat�sT�pus()
        {
            return this.tipus;
        }

        public Kimutat�sk�sz�t�(DateTime kezdet, DateTime vege, KimutatasTipus tipus)
        {
            this.kimutat�s = new Kimutat�s();
            kimutat�s.�jKimutat�s(vege,kezdet);
            this.tipus = tipus;
            adatok = new List<StatAdat>();
        }

        public void B�nesetKimutat�s()
        {
            List<B�neset> b�nesetek = this.kimutat�s.GetAdatok;

            //a b�nesetek �llapot szerinti csoportos�t�sa
            var query1 = from x in b�nesetek
                         group x by x.Get�llapot() into groups
                         select new {�llapot = groups.Key, Darab = groups.Count() };

            //StatAdat oszt�ly t�pusba ment�s, a k�nnyebb kezel�s �rdek�ben
            foreach (var akt in query1)
	        {
                adatok.Add(new StatAdat() { Darab = akt.Darab, Csoport = akt.�llapot.ToString() });
	        }
        }
    }//end Kimutat�sk�sz�t�


     //Ez itt az adatok t�rol�s�t szolg�lja
    public class StatAdat
    {
        public int Darab { get; set; }
        public string Csoport { get; set; }
    }
}//end namespace Adatkezel�
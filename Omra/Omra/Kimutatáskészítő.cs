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
	public class Kimutat�sk�sz�t� : IKimutat�skezel�
    {
        private DateTime kezdet;
        private DateTime vege;
        private List<StatAdat> adatok;
        private List<B�neset> relev�nsB�nesetek;

        public List<StatAdat> GetAdatok()
        {
			return this.adatok;
		}

        public Kimutat�sk�sz�t�(DateTime kezdet, DateTime vege)
        {
            adatok = new List<StatAdat>();
            �jKimutat�s(vege,kezdet);
        }

        public void B�nesetKimutat�s()
        {
            //a b�nesetek �llapot szerinti csoportos�t�sa
            var query = from x in relev�nsB�nesetek
                         group x by x.Get�llapot() into groups
                         select new {�llapot = groups.Key, Darab = groups.Count() };

            //StatAdat oszt�ly t�pusba ment�s, a k�nnyebb kezel�s �rdek�ben
            foreach (var akt in query)
                adatok.Add(new StatAdat() { Darab = akt.Darab, Csoport = akt.�llapot.ToString() });
        }

        public void Bizony�t�kKimutat�s()
        {
            List<string> bizonyitekok = new List<string>();

            DatabaseElements DE = new DatabaseElements();

            //Bizony�t�kok nev�nek egy list�ba ment�se
            foreach (var akt in relev�nsB�nesetek)
            {
                var q = from x in DE.FelvettBizonyitekok
                        where x.bunesetID == akt.GetAzonos�t�
                        select new { Nev = x.Bizonyitekok.megnevezes };

                //Egy b�nesetn�l t�bb bizony�t�k is lehet
                foreach (var q_akt in q)
                    bizonyitekok.Add(q_akt.Nev);
            }

            //A bizony�t�kok csoportos�t�sa
            var query = bizonyitekok
                                .GroupBy(x => x)
                                .Select(g => new { N�v = g.Key, Darab = g.Count() });

            //StatAdat oszt�ly t�pusba ment�s, a k�nnyebb kezel�s �rdek�ben
            foreach (var akt in query)
                adatok.Add(new StatAdat() { Darab = akt.Darab, Csoport = akt.N�v.ToString() });
        }

        public void Gyanus�tottKimutat�s()
        {
            List<string> gyanusitottakNevei = new List<string>();

            DatabaseElements DE = new DatabaseElements();

            //Gyanus�tottak nev�nek egy list�ba ment�se
            foreach (var akt in relev�nsB�nesetek)
            {
                var q = from x in DE.FelvettGyanusitottak
                        where x.bunesetID == akt.GetAzonos�t�
                        select new { Nev = x.Gyanusitottak.nev };

                //Egy b�nesetn�l t�bb gyanus�tott is lehet
                foreach (var q_akt in q)
                    gyanusitottakNevei.Add(q_akt.Nev);
            }

            //A gyanus�tottak csoportos�t�sa
            var query = gyanusitottakNevei
                                .GroupBy(x => x)
                                .Select(g => new { N�v = g.Key, Darab = g.Count() });

            //StatAdat oszt�ly t�pusba ment�s, a k�nnyebb kezel�s �rdek�ben
            foreach (var akt in query)
                adatok.Add(new StatAdat() { Darab = akt.Darab, Csoport = akt.N�v.ToString() });
        }

        public void �jKimutat�s(DateTime vege, DateTime kezdet)
        {
            this.vege = vege;
            this.kezdet = kezdet;
            relev�nsB�nesetek = new List<B�neset>();

            // Adatokat a list�ba gy�jt�se
            DatabaseElements DE = new DatabaseElements();

            var eredmeny = from x in DE.Bunesetek
                           where x.felvetel >= this.kezdet && x.felvetel <= this.vege
                           select x;

            foreach (var v in eredmeny)
                relev�nsB�nesetek.Add(new B�neset(v.bunesetID, (B�llapot)Enum.Parse(typeof(B�llapot), v.allapot), v.felvetel, v.leiras, v.lezaras, null));
        }
    }//end Kimutat�sk�sz�t�

     //Ez itt az adatok t�rol�s�t szolg�lja
    public class StatAdat
    {
        public int Darab { get; set; }
        public string Csoport { get; set; }
    }
}//end namespace Adatkezel�
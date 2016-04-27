///////////////////////////////////////////////////////////
//  B�neset.cs
//  Implementation of the Class B�neset
//  Generated by Enterprise Architect
//  Created on:      02-�pr.-2016 10:16:28
//  Original author: D�niel
///////////////////////////////////////////////////////////




using Adatkezel�;
using System;
using System.Collections.Generic;
using Omra;
namespace Adatkezel� {
	public class B�neset 
    {

		private decimal azonos�t�;

		private B�llapot �llapot;

        private DateTime felvetel;
        private DateTime? lezaras;

        private string leiras;

        private Dolgoz� felel�s�rnagy;

        private DatabaseElements DE = new DatabaseElements();
        
		/// 
		/// <param name="azonos�t�"></param>
		public B�neset(decimal azonos�t�, string leiras, Dolgoz� fel�rnagy){   //felv�telhez
            this.azonos�t� = azonos�t�;

            this.�llapot = B�llapot.Folyamatban;
            this.felvetel = DateTime.Now;
            this.leiras = leiras;
            this.felel�s�rnagy = fel�rnagy;
		}

        public B�neset(decimal azonos�t�, B�llapot allapot, DateTime felvetel, string leiras, DateTime? lezaras, Dolgoz� fel�rnagy)  //megjelen�t�shez a keres�sben
        {
            this.azonos�t� = azonos�t�;
            this.�llapot = allapot;
            this.felvetel = felvetel;
            this.leiras = leiras;
            this.lezaras = lezaras;
            this.felel�s�rnagy = fel�rnagy;
        }

		public void �llapotm�dos�t�s()
        {
            if (�llapot == B�llapot.Folyamatban)
            {
                �llapot = B�llapot.Lez�rt;
                this.lezaras = DateTime.Now;
            }
            if (�llapot == B�llapot.Lez�rt)
            {
                �llapot = B�llapot.Folyamatban;
                lezaras = null;
            }
		}

		/// 
		/// <param name="B�neset"></param>
		/// <param name="Bizony�t�k"></param>
		public void Bizony�t�kHozz�ad�sa(B�neset B�neset, Bizony�t�k Bizony�t�k)
        {
            
		}

		public B�llapot Get�llapot(){

            return this.�llapot;
		}

		public decimal GetAzonos�t�{
			get
            {
				return azonos�t�;
			}
		}

        public DateTime GetFelvetel
        {
            get
            {
                return felvetel;
            }
        }

        public DateTime? GetLezaras
        {
            get
            {
                return lezaras;
            }
        }

        public string GetLeiras
        {
            get
            {
                return leiras;
            }
        }

        public Dolgoz� GetFelel�s
        {
            get
            {
                return felel�s�rnagy;
            }
        }

		/// 
		/// <param name="Gyan�s�tott"></param>
		public void Gyan�s�tottHozz�ad�sa(Gyan�s�tott Gyan�s�tott)
        {
            var ujgyan = new Gyanusitottak()
            {
                gyanusitottID = Gyan�s�tott.GetAzonos�t�(),
                nev = Gyan�s�tott.GetN�v(),
                lakcim = Gyan�s�tott.GetBejelentettLakc�m(),
                statusz = Gyan�s�tott.GetSt�tusz().ToString()
            };
            var ujfelvgyan = new FelvettGyanusitottak()
            {
                bunesetID = azonos�t�,
                gyanusitottID = Gyan�s�tott.GetAzonos�t�(),
                felvetel_idopontja = DateTime.Now
            };
            DE.FelvettGyanusitottak.Add(ujfelvgyan);
            DE.Gyanusitottak.Add(ujgyan);
            //DE.SaveChanges();  ide valami�rt ezt nem engedi berakni
		}

        public override string ToString()
        {
            return "ID:" + azonos�t� + " �llapot: " + �llapot.ToString() + " Felv�tel: " + felvetel.ToShortDateString() + "\n Le�r�s: " + leiras;
        }

	}//end B�neset

}//end namespace Adatkezel�
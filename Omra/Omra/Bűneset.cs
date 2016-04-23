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
namespace Adatkezel� {
	public class B�neset 
    {

		private string azonos�t�;
		private List<Dolgoz�> dolgoz�k;
		private List<Gyan�s�tott> gyan�s�tottak;
		private List<Bizony�t�k> bizony�t�kok;
		private B�llapot �llapot;

        private DateTime felvetel;
        private DateTime lezaras;

        private string leiras;
        
		/// 
		/// <param name="azonos�t�"></param>
		public B�neset(string azonos�t�, string leiras){   //felv�telhez
            this.azonos�t� = azonos�t�;
            this.dolgoz�k = new List<Dolgoz�>();
            this.gyan�s�tottak = new List<Gyan�s�tott>();
            this.bizony�t�kok = new List<Bizony�t�k>();
            this.�llapot = B�llapot.Folyamatban;
            this.felvetel = DateTime.Now;
            this.leiras = leiras;
		}

        public B�neset(string azonos�t�, B�llapot allapot, DateTime felvetel, string leiras)  //megjelen�t�shez a keres�sben
        {
            this.azonos�t� = azonos�t�;
            this.�llapot = allapot;
            this.felvetel = felvetel;
            this.leiras = leiras;
        }

		public void �llapotm�dos�t�s(){
            if (�llapot == B�llapot.Folyamatban)
            {
                �llapot = B�llapot.Lez�rt;
                this.lezaras = DateTime.Now;
            }
            if (�llapot == B�llapot.Lez�rt)
            {
                �llapot = B�llapot.Folyamatban;
                //lezaras = null    //datetime nem null�zhat� -> mivel legyen jel�lve?
            }
		}

		/// 
		/// <param name="B�neset"></param>
		/// <param name="Bizony�t�k"></param>
		public void Bizony�t�kHozz�ad�sa(B�neset B�neset, Bizony�t�k Bizony�t�k){
            this.bizony�t�kok.Add(Bizony�t�k);
		}

		public B�llapot Get�llapot(){

            return this.�llapot;
		}

		public string GetAzonos�t�{
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

        public DateTime GetLezaras
        {
            get
            {
                return lezaras;
            }
        }

		public List<Bizony�t�k> GetBizony�t�kok(){

            return this.bizony�t�kok;
		}

		public List<Gyan�s�tott> GetGyan�s�tottak(){

            return this.gyan�s�tottak;
		}

		/// 
		/// <param name="Gyan�s�tott"></param>
		public void Gyan�s�tottHozz�ad�sa(Gyan�s�tott Gyan�s�tott){
            this.gyan�s�tottak.Add(Gyan�s�tott);
		}

        public override string ToString()
        {
            return "ID:" + azonos�t� + " �llapot: " + �llapot.ToString() + " Felv�tel: " + felvetel.ToShortDateString() + "\n Le�r�s: " + leiras;
        }

	}//end B�neset

}//end namespace Adatkezel�
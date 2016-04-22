///////////////////////////////////////////////////////////
//  Dolgoz�.cs
//  Implementation of the Class Dolgoz�
//  Generated by Enterprise Architect
//  Created on:      02-�pr.-2016 10:16:28
//  Original author: gabi1_000
///////////////////////////////////////////////////////////




using Adatkezel�;
namespace Adatkezel� {
	public class Dolgoz� : Szem�ly {

		private string jelsz�;
		private Rang beoszt�s;
        
		/// 
		/// <param name="Rang"></param>
		/// <param name="jelsz�"></param>
		/// <param name="n�v"></param>
		/// <param name="lakc�m"></param>
		/// <param name="szem�lyiazonos�t�"></param>
		public Dolgoz�(Rang Rang, string jelsz�, string n�v, string lakc�m, decimal szem�lyiazonos�t�)
            :base(szem�lyiazonos�t�,lakc�m,n�v)
        {
            this.beoszt�s = Rang;
            this.jelsz� = jelsz�;
		}

		public Rang GetBeoszt�s(){

            return beoszt�s;
		}

		public string GetJelsz�(){
            return jelsz�;
		}

	}//end Dolgoz�

}//end namespace Adatkezel�
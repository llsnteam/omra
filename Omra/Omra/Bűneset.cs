///////////////////////////////////////////////////////////
//  B�neset.cs
//  Implementation of the Class B�neset
//  Generated by Enterprise Architect
//  Created on:      02-�pr.-2016 10:16:28
//  Original author: D�niel
///////////////////////////////////////////////////////////




using Adatkezel�;
using System.Collections.Generic;
namespace Adatkezel� {
	public class B�neset 
    {

		private string azonos�t�;
		private List<Dolgoz�> dolgoz�k;
		private List<Gyan�s�tott> gyan�s�tottak;
		private List<Bizony�t�k> bizony�t�kok;
		private B�llapot �llapot;

		public B�neset(){
            this.azonos�t� = "Ha ezt l�tod, siker�lt";

            this.azonos�t� += "04.03. 22:12";

            this.azonos�t� += "04.05. 08:10";

            string blabla = "bla";
            int valami = 0;
            bool megintvalami = false;
            bool vs12thasznalok = true;
		}

		~B�neset(){

		}

		public virtual void Dispose(){

		}

		/// 
		/// <param name="azonos�t�"></param>
		public B�neset(string azonos�t�){

		}

		public void �llapotm�dos�t�s(){

		}

		/// 
		/// <param name="B�neset"></param>
		/// <param name="Bizony�t�k"></param>
		public void Bizony�t�kHozz�ad�sa(B�neset B�neset, Bizony�t�k Bizony�t�k){

		}

		public B�llapot Get�llapot(){

            return this.�llapot;
		}

		public string GetAzonos�t�{
			get{
				return azonos�t�;
			}
			set{
				azonos�t� = value;
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

	}//end B�neset

}//end namespace Adatkezel�
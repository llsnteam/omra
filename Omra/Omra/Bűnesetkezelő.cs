///////////////////////////////////////////////////////////
//  B�nesetkezel�.cs
//  Implementation of the Class B�nesetkezel�
//  Generated by Enterprise Architect
//  Created on:      02-�pr.-2016 10:16:28
//  Original author: D�niel
///////////////////////////////////////////////////////////




using Adatkezel�;
using System.Collections.Generic;
namespace Adatkezel� {
	public class B�nesetkezel� : IB�nesetkezel�, IGyan�s�tottkezel�, IBizony�t�kkezel� 
    {

		private List<B�neset> b�nesetek;
        

		public B�nesetkezel�(){

		}

		~B�nesetkezel�(){

		}

		public virtual void Dispose(){
            // valami!
		}

		public string Azonos�t�Gener�l�s(){

			return "";
		}

		/// 
		/// <param name="bizony�t�k">ez k�rd�ses</param>
		/// <param name="b�neset"></param>
		public void Bizony�t�kHozz�ad�sa(Bizony�t�k bizony�t�k, B�neset b�neset){
            b�neset.Bizony�t�kHozz�ad�sa(b�neset, bizony�t�k);
		}
        
		/// 
		/// <param name="megnevez�s"></param>
		public List<Bizony�t�k> Bizony�t�kKeres�s(string megnevez�s){
            //nem is kellene ide ? -> keres�skezel� val�s�tja meg
			return null;
		}

		/// 
		/// <param name="b�neset"></param>
		public void B�neset�llapotm�dos�t�s(B�neset b�neset){
            b�neset.�llapotm�dos�t�s();
            //---------------------Adatb�zisban m�dos�tani
		}

		/// 
		/// <param name="azonos�t�"></param>
		public B�neset B�nesetKeres�s(string azonos�t�){
            //nem is kellene ide ? -> keres�skezel� val�s�tja meg
			return null;
		}

		public List<B�neset> GetB�nesetek(){
			return b�nesetek;
		}

		/// 
		/// <param name="Gyan�s�tott"></param>
		/// <param name="B�neset"></param>
		public void Gyan�s�tottHozz�ad�sa(Gyan�s�tott Gyan�s�tott, B�neset B�neset){
            B�neset.Gyan�s�tottHozz�ad�sa(Gyan�s�tott);
		}

		/// 
		/// <param name="megnevez�s">Mint pl. k�s, pisztoly stb.</param>
		/// <param name="azonos�t�"></param>
		public void �jBizony�t�k(string megnevez�s){
            string azonos�t� = Azonos�t�Gener�l�s();
            Bizony�t�k b = new Bizony�t�k(megnevez�s, azonos�t�);
		}

		public void �jB�neset(){
            B�neset b = new B�neset(Azonos�t�Gener�l�s());
            b�nesetek.Add(b); //------------------------------------- b�neset az adatb�zisba
		}

		/// 
		/// <param name="gyan�s�tott"></param>
		public void Gyan�s�tottM�dos�t�sa(Gyan�s�tott gyan�s�tott){
            
		}

		/// 
		/// <param name="gyan�s�tottSt�tusz"></param>
		/// <param name="lakc�m"></param>
		/// <param name="szem�lyiAzonos�t�"></param>
		/// <param name="n�v"></param>
		public void �jGyan�s�tott(Gyan�s�tottSt�tusz gyan�s�tottSt�tusz, string lakc�m, string szem�lyiAzonos�t�, string n�v){
            Gyan�s�tott gy = new Gyan�s�tott(gyan�s�tottSt�tusz, n�v, lakc�m, szem�lyiAzonos�t�);
            //----------------------------------------gyan�s�tott az adatb�zisba
		}

	}//end B�nesetkezel�

}//end namespace Adatkezel�
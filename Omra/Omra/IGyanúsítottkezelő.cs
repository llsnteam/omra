///////////////////////////////////////////////////////////
//  IGyan�s�tottkezel�.cs
//  Implementation of the Interface IGyan�s�tottkezel�
//  Generated by Enterprise Architect
//  Created on:      02-�pr.-2016 10:16:28
//  Original author: D�niel
///////////////////////////////////////////////////////////




using Adatkezel�;
namespace Adatkezel� {
	public interface IGyan�s�tottkezel� {

		/// 
		/// <param name="gyan�s�tott"></param>
		/// <param name="b�neset"></param>
		void Gyan�s�tottHozz�ad�sa(Gyan�s�tott gyan�s�tott, B�neset b�neset);

		/// <param name="gyan�s�tottSt�tusz"></param>
		/// <param name="lakc�m"></param>
		/// <param name="szem�lyiAzonos�t�"></param>
		/// <param name="n�v"></param>
		void �jGyan�s�tott(Gyan�s�tottSt�tusz gyan�s�tottSt�tusz, string lakc�m, decimal szem�lyiAzonos�t�, string n�v);
	}//end IGyan�s�tottkezel�

}//end namespace Adatkezel�
///////////////////////////////////////////////////////////
//  IB�nesetkezel�.cs
//  Implementation of the Interface IB�nesetkezel�
//  Generated by Enterprise Architect
//  Created on:      02-�pr.-2016 10:16:28
//  Original author: D�niel
///////////////////////////////////////////////////////////




namespace Adatkezel� {
	public interface IB�nesetkezel� {

		/// 
		/// <param name="B�neset"></param>
		B�llapot B�neset�llapotm�dos�t�s(B�neset B�neset);

		/// 
		/// <param name="Gyan�s�tott"></param>
		/// <param name="B�neset"></param>
		void Gyan�s�tottHozz�ad�sa(Gyan�s�tott Gyan�s�tott, B�neset B�neset);

		void �jB�neset(string leiras);
	}//end IB�nesetkezel�

}//end namespace Adatkezel�
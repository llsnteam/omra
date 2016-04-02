///////////////////////////////////////////////////////////
//  IKeres�skezel�.cs
//  Implementation of the Interface IKeres�skezel�
//  Generated by Enterprise Architect
//  Created on:      02-�pr.-2016 10:16:29
//  Original author: D�niel
///////////////////////////////////////////////////////////




using Adatkezel�;
namespace Adatkezel� {
	public interface IKeres�skezel� {

		/// 
		/// <param name="azonos�t�"></param>
		Bizony�t�k Bizony�t�kkeres�s(string azonos�t�);

		/// 
		/// <param name="azonos�t�"></param>
		B�neset B�nesetkeres�s(string azonos�t�);

		/// 
		/// <param name="azonosito"></param>
		Dolgoz� Dolgoz�keres�s(string azonosito);

		/// 
		/// <param name="azonos�t�"></param>
		Gyan�s�tott Gyan�s�tottkeres�s(string azonos�t�);

		/// 
		/// <param name="azonos�t�"></param>
		/// <param name="t�pus"></param>
		List<object> Keres�s(string azonos�t�, Keres�sT�pus t�pus);
	}//end IKeres�skezel�

}//end namespace Adatkezel�
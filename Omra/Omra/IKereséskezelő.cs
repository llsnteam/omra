///////////////////////////////////////////////////////////
//  IKeres�skezel�.cs
//  Implementation of the Interface IKeres�skezel�
//  Generated by Enterprise Architect
//  Created on:      02-�pr.-2016 10:16:29
//  Original author: D�niel
///////////////////////////////////////////////////////////




using Adatkezel�;
using System.Collections.Generic;
namespace Adatkezel� {

    public enum Keres�sT�pus { B�neset, Gyan�s�tott, Bizony�t�k, Dolgoz� }
	public interface IKeres�skezel� {

		/// 
		/// <param name="azonos�t�"></param>
		List<Bizony�t�k> Bizony�t�kkeres�s(string azonos�t�);

		/// 
		/// <param name="azonos�t�"></param>
		List<B�neset> B�nesetkeres�s(string azonos�t�);

		/// 
		/// <param name="azonosito"></param>
		List<Dolgoz�> Dolgoz�keres�s(string azonosito);

		/// 
		/// <param name="azonos�t�"></param>
		List<Gyan�s�tott> Gyan�s�tottkeres�s(string azonos�t�);

		/// 
		/// <param name="azonos�t�"></param>
		/// <param name="t�pus"></param>
		//List<object> Keres�s(string azonos�t�, Keres�sT�pus t�pus);
	}//end IKeres�skezel�

}//end namespace Adatkezel�
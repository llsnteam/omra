///////////////////////////////////////////////////////////
//  I�zenetkezel�.cs
//  Implementation of the Interface I�zenetkezel�
//  Generated by Enterprise Architect
//  Created on:      02-�pr.-2016 10:16:29
//  Original author: D�niel
///////////////////////////////////////////////////////////




using Adatkezel�;
using System.Collections.Generic;
namespace Adatkezel� {
	public interface I�zenetkezel� {

		/// 
		/// <param name="t�rzs"></param>
		/// <param name="t�rgy"></param>
		/// <param name="k�ld�"></param>
		/// <param name="c�mzett"></param>
		void �zenetK�ld�se(string t�rzs, string t�rgy, Dolgoz� k�ld�, Dolgoz� c�mzett);

		/// 
		/// <param name="Dolgoz�"></param>
		List<�zenet> �zenetMegtekint�se(Dolgoz� Dolgoz�);

		/// 
		/// <param name="�zenet"></param>
		void �zenetT�rl�se(�zenet �zenet);
	}//end I�zenetkezel�

}//end namespace Adatkezel�
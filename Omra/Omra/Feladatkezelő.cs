///////////////////////////////////////////////////////////
//  Feladatkezelő.cs
//  Implementation of the Class Feladatkezelő
//  Generated by Enterprise Architect
//  Created on:      02-ápr.-2016 10:16:28
//  Original author: Dániel
///////////////////////////////////////////////////////////




using Adatkezelő;
using System.Collections.Generic;
namespace Adatkezelő {
	public class Feladatkezelő : IFeladatkezelő {

		private Feladat feladatok;

		public Feladatkezelő(){

		}

		~Feladatkezelő(){

		}

		public virtual void Dispose(){

		}

		/// 
		/// <param name="feladat"></param>
		public void FeladatÁllapotMódosítás(Feladat feladat){

		}

		/// 
		/// <param name="Dolgozó"></param>
		public List<Feladat> FeladatokLekérdezése(Dolgozó Dolgozó){

			return null;
		}

		/// 
		/// <param name="célszemély"></param>
		/// <param name="létrehozta"></param>
		/// <param name="leírás"></param>
		public void ÚjFeladat(Dolgozó célszemély, Dolgozó létrehozta, string leírás){

		}

	}//end Feladatkezelő

}//end namespace Adatkezelő
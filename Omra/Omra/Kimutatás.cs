///////////////////////////////////////////////////////////
//  Kimutatás.cs
//  Implementation of the Class Kimutatás
//  Generated by Enterprise Architect
//  Created on:      02-ápr.-2016 10:16:29
//  Original author: hallgato
///////////////////////////////////////////////////////////




using System;
using System.Collections.Generic;
namespace Adatkezelő {
	public class Kimutatás {

		protected DateTime kezdet;
		protected DateTime vege;

		public Kimutatás(){

		}

		~Kimutatás(){

		}

		public virtual void Dispose(){

		}

		/// 
		/// <param name="vege"></param>
		/// <param name="kezdet"></param>
		public Kimutatás(DateTime vege, DateTime kezdet){
            this.vege = vege;
            this.kezdet = kezdet;
		}

	}//end Kimutatás

}//end namespace Adatkezelő
///////////////////////////////////////////////////////////
//  Kimutat�s.cs
//  Implementation of the Class Kimutat�s
//  Generated by Enterprise Architect
//  Created on:      02-�pr.-2016 10:16:29
//  Original author: hallgato
///////////////////////////////////////////////////////////




using System;
using System.Collections.Generic;
namespace Adatkezel� {
	public class Kimutat�s:IKimutat�skezel� 
    {
		protected DateTime kezdet;
		protected DateTime vege;
        private List<int> statAdatok;

		/// 
		/// <param name="vege"></param>
		/// <param name="kezdet"></param>
		public Kimutat�s(DateTime vege, DateTime kezdet)
        {
            this.vege = vege;
            this.kezdet = kezdet;
            statAdatok = new List<int>();
		}

        public void �jKimutat�s(DateTime vege, DateTime kezdet)
        {
 	        throw new NotImplementedException();
            // linq val �sszegy�jti az adatokat a list�ba
            // 
        }

    }//end Kimutat�s

}//end namespace Adatkezel�
///////////////////////////////////////////////////////////
//  Feladat.cs
//  Implementation of the Class Feladat
//  Generated by Enterprise Architect
//  Created on:      02-�pr.-2016 10:16:28
//  Original author: D�niel
////////////////////////////////////////////////////////////




using Adatkezel�;
using System;
namespace Adatkezel� {
	public class Feladat {

		/// <summary>
		/// Akinek a feladat sz�l
		/// </summary>
		private Dolgoz� c�lszem�ly;
		private string le�r�s;
		private F�llapot �llapot;
        /// <summary>
        /// Amikor a b�neset l�tre lett hozva
        /// </summary>
        private DateTime l�trehoz�s;
        
		/// 
		/// <param name="le�r�s"></param>
		/// <param name="c�lszem�ly"></param>
		/// <param name="l�trehoz�"></param>
		public Feladat(string le�r�s, Dolgoz� c�lszem�ly, DateTime l�trehoz�s,F�llapot �llapot)
        {
            this.le�r�s = le�r�s;
            this.c�lszem�ly = c�lszem�ly;
            this.�llapot = �llapot;
            this.l�trehoz�s = l�trehoz�s;
		}

		/// <summary>
		/// Akinek a feladat sz�l
		/// </summary>
		public Dolgoz� GetC�lszem�ly
        {
            get { return c�lszem�ly; }
            set { c�lszem�ly = value; }
		}

		public string GetLe�r�s{
            get { return le�r�s; }
            set { le�r�s = value; }
		}

        public DateTime GetL�trehoz�s
        {
            get { return l�trehoz�s; }
            set { l�trehoz�s = value; }
        }

        public F�llapot Get�llapot
        {
            get { return �llapot; }
            set { �llapot = value; }
        }
        
        public override string ToString()
        {
            if (this.le�r�s.Length > 30)
                return this.le�r�s.Substring(0, 30) + "...";
            return this.le�r�s;
        }

	}//end Feladat

}//end namespace Adatkezel�
///////////////////////////////////////////////////////////
//  Feladat.cs
//  Implementation of the Class Feladat
//  Generated by Enterprise Architect
//  Created on:      02-�pr.-2016 10:16:28
//  Original author: D�niel
///////////////////////////////////////////////////////////




using Adatkezel�;
namespace Adatkezel� {
	public class Feladat {

		/// <summary>
		/// Akinek a feladat sz�l
		/// </summary>
		private Dolgoz� c�lszem�ly;
		private string le�r�s;
		/// <summary>
		/// Ki adta ki a feladatot
		/// </summary>
		private Dolgoz� l�trehozta;
		private F�llapot �llapot;

		public Feladat(){

		}

		~Feladat(){

		}

		public virtual void Dispose(){

		}

		/// 
		/// <param name="le�r�s"></param>
		/// <param name="c�lszem�ly"></param>
		/// <param name="l�trehoz�"></param>
		public Feladat(string le�r�s, Dolgoz� c�lszem�ly, Dolgoz� l�trehoz�){

		}

		/// <summary>
		/// Akinek a feladat sz�l
		/// </summary>
		public Dolgoz� GetC�lszem�ly{
			get{
				return c�lszem�ly;
			}
			set{
				c�lszem�ly = value;
			}
		}

		public string GetLe�r�s{
			get{
				return le�r�s;
			}
			set{
				le�r�s = value;
			}
		}

		/// <summary>
		/// Ki adta ki a feladatot
		/// </summary>
		public Dolgoz� GetL�trehozta{
			get{
				return l�trehozta;
			}
			set{
				l�trehozta = value;
			}
		}

	}//end Feladat

}//end namespace Adatkezel�
///////////////////////////////////////////////////////////
//  Bizony�t�k.cs
//  Implementation of the Class Bizony�t�k
//  Generated by Enterprise Architect
//  Created on:      02-�pr.-2016 10:16:28
//  Original author: D�niel
///////////////////////////////////////////////////////////




namespace Adatkezel� {
	public class Bizony�t�k {

		private string azonos�t�;
		/// <summary>
		/// pl. k�s, pisztoly stb.
		/// </summary>
		private string megnevez�s;

		public Bizony�t�k(){

		}

		~Bizony�t�k(){

		}

		public virtual void Dispose(){

		}

		/// 
		/// <param name="megnevez�s"></param>
		/// <param name="azonos�t�"></param>
		public Bizony�t�k(string megnevez�s, string azonos�t�){

		}

		public string GetAzonos�t�{
			get{
				return azonos�t�;
			}
			set{
				azonos�t� = value;
			}
		}

		public string GetMegnevez�s(){

			return "";
		}

	}//end Bizony�t�k

}//end namespace Adatkezel�
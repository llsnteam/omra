///////////////////////////////////////////////////////////
//  Szem�ly.cs
//  Implementation of the Class Szem�ly
//  Generated by Enterprise Architect
//  Created on:      02-�pr.-2016 10:16:29
//  Original author: gabi1_000
///////////////////////////////////////////////////////////




namespace Adatkezel� {
	public abstract class Szem�ly {

		protected string azonos�t�;
		protected string bejelentettLakc�m;
		protected string n�v;

        public Szem�ly(string azonos�t�, string lakc�m, string n�v)
        {
            this.azonos�t� = azonos�t�;
            this.bejelentettLakc�m = lakc�m;
            this.n�v = n�v;
        }

		public string GetAzonos�t�(){

			return this.azonos�t�;
		}

		public string GetBejelentettLakc�m(){

			return this.bejelentettLakc�m;
		}

		public string GetN�v(){

			return this.n�v;
		}

	}//end Szem�ly

}//end namespace Adatkezel�
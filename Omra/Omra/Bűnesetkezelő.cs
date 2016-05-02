///////////////////////////////////////////////////////////
//  B�nesetkezel�.cs
//  Implementation of the Class B�nesetkezel�
//  Generated by Enterprise Architect
//  Created on:      02-�pr.-2016 10:16:28
//  Original author: D�niel
///////////////////////////////////////////////////////////




using Adatkezel�;
using Omra;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
namespace Adatkezel� {
	public class B�nesetkezel� : IB�nesetkezel�, IGyan�s�tottkezel�, IBizony�t�kkezel� 
    {
        DatabaseElements DE = new DatabaseElements();
        private object lockObject = new Object();
		public decimal Azonos�t�Gener�l�s(B�neset buneset)
        {
            if(buneset!=null)
            {
                var meglevoID = from x in DE.Bunesetek
                               where x.bunesetID == buneset.GetAzonos�t�
                               select x.bunesetID;

                return meglevoID.First();
            }
            else
            {
                var utolsoID = from x in DE.Bunesetek
                               where x.bunesetID == DE.Bunesetek.Max(y => y.bunesetID)
                               select x.bunesetID;

                return utolsoID.First() + 1;
            }
		}

        public ObservableCollection<Gyan�s�tott> Gyan�s�tottakKigy�jt�se(B�neset b�neset)
        {
            //p�rhuzamos�t�s miatt
            DatabaseElements DE2 = new DatabaseElements();

            ObservableCollection<Gyan�s�tott> gyan�s�tottak = new ObservableCollection<Gyan�s�tott>();
            lock (lockObject)
            {
                var gyanlista = from x in DE2.FelvettGyanusitottak
                                where x.bunesetID == b�neset.GetAzonos�t�
                                select x.Gyanusitottak;

                foreach (var gyan in gyanlista)
                    gyan�s�tottak.Add(new Gyan�s�tott((Gyan�s�tottSt�tusz)Enum.Parse(typeof(Gyan�s�tottSt�tusz), gyan.statusz), gyan.nev, gyan.lakcim, gyan.gyanusitottID));
            }
            return gyan�s�tottak;
        }

        public ObservableCollection<Bizony�t�k> Bizony�t�kokKigy�jt�se(B�neset b�neset)
        {
            ObservableCollection<Bizony�t�k> bizony�t�k = new ObservableCollection<Bizony�t�k>();
            lock (lockObject) {
            var bizlista = from x in DE.FelvettBizonyitekok
                            where x.bunesetID == b�neset.GetAzonos�t�
                            select x.Bizonyitekok;

            foreach (var biz in bizlista)
                bizony�t�k.Add(new Bizony�t�k(biz.bizonyitekID, biz.megnevezes, biz.felvetel));
                }
            return bizony�t�k;
        }

		/// 
		/// <param name="bizony�t�k">ez k�rd�ses</param>
		/// <param name="b�neset"></param>
		public void Bizony�t�kHozz�ad�sa(Bizony�t�k bizony�t�k, B�neset b�neset)
        {
            var ujfelvbiz = new FelvettBizonyitekok()
            {
                bunesetID = b�neset.GetAzonos�t�,
                bizonyitekID = bizony�t�k.GetAzonos�t�,
                felvetel_idopontja = DateTime.Now
            };
            DE.FelvettBizonyitekok.Add(ujfelvbiz);
            DE.SaveChanges();
		}
        
		/// 
		/// <param name="b�neset"></param>
		public B�llapot B�neset�llapotm�dos�t�s(B�neset b�neset) // a b�neset m�dos�t�as ut�ni ment�sn�l 
        {
            return b�neset.�llapotm�dos�t�s();
		}

		/// 
		/// <param name="Gyan�s�tott"></param>
		/// <param name="B�neset"></param>
		public void Gyan�s�tottHozz�ad�sa(Gyan�s�tott Gyan�s�tott, B�neset B�neset)
        {
            var ujfelvgyan = new FelvettGyanusitottak()
            {
                bunesetID = B�neset.GetAzonos�t�,
                gyanusitottID = Gyan�s�tott.GetAzonos�t�(),
                felvetel_idopontja = DateTime.Now
            };
            DE.FelvettGyanusitottak.Add(ujfelvgyan);
            DE.SaveChanges();
		}

		/// 
		/// <param name="megnevez�s">Mint pl. k�s, pisztoly stb.</param>
		/// <param name="azonos�t�"></param>
		public void �jBizony�t�k(string megnevez�s, decimal id){

            var bizony = DE.Bizonyitekok.Single(x => x.bizonyitekID == id);
            if (bizony != null)  // m�r l�tezik �s csak m�dos�t egy megl�v�t
            {
                bizony.megnevezes = megnevez�s;
            }
            else
            {
                decimal azonos�t� = Convert.ToDecimal(Azonos�t�Gener�l�s(null));
                var ujbizonyitek = new Bizonyitekok()
                {
                    bizonyitekID = azonos�t�,
                    megnevezes = megnevez�s,
                    felvetel = DateTime.Now
                };
                DE.Bizonyitekok.Add(ujbizonyitek);
            }
            DE.SaveChanges();
		}
        
		/// 
		/// <param name="gyan�s�tottSt�tusz"></param>
		/// <param name="lakc�m"></param>
		/// <param name="id"></param>
		/// <param name="n�v"></param>
		public void �jGyan�s�tott(Gyan�s�tottSt�tusz gyan�s�tottSt�tusz, string lakc�m, decimal id, string n�v)
        {
            var gyanusitott = from x in DE.Gyanusitottak
                              where x.gyanusitottID == id
                              select x;
            if (gyanusitott.Count() != 0)     // azaz m�r l�tezik �s csak m�dos�t egy megl�v�t
            {
                Gyanusitottak gyanu = gyanusitott.First();
                gyanu.lakcim = lakc�m;
                gyanu.statusz = gyan�s�tottSt�tusz.ToString();
                gyanu.nev = n�v;
            }
            else
            {
                var ujgyan = new Gyanusitottak()
                {
                    gyanusitottID = id,
                    nev = n�v,
                    lakcim = lakc�m,
                    statusz = gyan�s�tottSt�tusz.ToString()
                };
                DE.Gyanusitottak.Add(ujgyan);
            }
            DE.SaveChanges();
		}

        public void �jB�neset(decimal azon,string allapot, DateTime felvetel, string leiras, decimal felOrnagyId)
        {
            var ujbun = new Bunesetek() 
            { 
                allapot=allapot, bunesetID=azon,
                felelos_ornagy=felOrnagyId, 
                felvetel=felvetel, 
                leiras=leiras 
            };
            DE.Bunesetek.Add(ujbun);
            DE.SaveChanges();
        }

        public void B�nesetM�dos�t�s(B�neset kivalasztott,decimal felOrnagyID, string leiras, string allapot)
        {
            var modositott = DE.Bunesetek.Single(x => x.bunesetID == kivalasztott.GetAzonos�t�);
            modositott.felelos_ornagy = felOrnagyID;
            modositott.leiras = leiras;
            modositott.allapot = allapot;

        }

    }//end B�nesetkezel�

}//end namespace Adatkezel�
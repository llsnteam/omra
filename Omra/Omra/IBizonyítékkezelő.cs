///////////////////////////////////////////////////////////
//  IBizony�t�kkezel�.cs
//  Implementation of the Interface IBizony�t�kkezel�
//  Generated by Enterprise Architect
//  Created on:      02-�pr.-2016 10:16:28
//  Original author: D�niel
///////////////////////////////////////////////////////////




namespace Adatkezel� {
	public interface IBizony�t�kkezel� {

		/// 
		/// <param name="bizony�t�k">ez k�rd�ses</param>
		/// <param name="b�neset"></param>
		void Bizony�t�kHozz�ad�sa(Bizony�t�k bizony�t�k, B�neset b�neset);
        
		/// 
		/// <param name="megnevez�s">Mint pl. k�s, pisztoly stb.</param>
		void �jBizony�t�k(Bizony�t�k biz);
	}//end IBizony�t�kkezel�

}//end namespace Adatkezel�
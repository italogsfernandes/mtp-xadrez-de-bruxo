using UnityEngine;
using System.Collections;
using System;

public class Torre : Peca {


	public override void SetMovimentos() {

	}

	public override void SetPosicaoInicial() {
		posicao = 129;
		/*
		 * Posicao dos peoes
		 * 
		 *   A B C D E F G H
		 * 8|0 0 0 0 0 0 0 0 |8
		 * 7|0 0 0 0 0 0 0 0 |7
		 * 6|0 0 0 0 0 0 0 0 |6
		 * 5|0 0 0 0 0 0 0 0 |5
		 * 4|0 0 0 0 0 0 0 0 |4
		 * 3|0 0 0 0 0 0 0 0 |3
		 * 2|0 0 0 0 0 0 0 0 |2
		 * 1|1 0 0 0 0 0 0 1 |1
		 * 	 A B C D E F G H
		 * 
		 * Binario = 10000001
		 * Decimal = 129
		 * 
		 */
		if (setdepecas.PecaCor.Equals(Setdepecas.Cordaspecas.Pretas) {
			posicao = posicao << 56;
		}
	}
	public Torre (Setdepecas Set) {
		this.setdepecas = Set;
	}
}

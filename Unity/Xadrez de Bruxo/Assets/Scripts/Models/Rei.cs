using UnityEngine;
using System.Collections;
using System;

public class Rei : Peca {


	public override void SetMovimentos() {
		//Movimentação Normal:
		//1 para frente
		movimentos = posicao << 8;
		//1 para tras
		movimentos = movimentos | (posicao >> 8);
		//1 para a direita
		movimentos = movimentos | (posicao << 1);
		//1 para esquerta
		movimentos = movimentos | (posicao >> 1);

		//Barrando Lugares Ocupados:
		movimentos = movimentos ^ (movimentos & setdepecas.tabuleiro.ocupadas);
		//Verifica quais lugares possuem movimento e pecas do tabuleiro
		//usa o XOR(^) pra selecionar aqueles lugares q so estejam no movimento
	}

	public override void SetPosicaoInicial() {
		posicao = 8;
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
		 * 1|0 0 0 0 1 0 0 0 |1
		 * 	 A B C D E F G H
		 * 
		 * Binario = 00001000
		 * Decimal = 8
		 * 
		 */
		if (setdepecas.PecaCor.Equals(Setdepecas.Cordaspecas.Pretas) {
			posicao = posicao << 56;
		}
	}
	public Rei (Setdepecas Set) {
		this.setdepecas = Set;
	}
}

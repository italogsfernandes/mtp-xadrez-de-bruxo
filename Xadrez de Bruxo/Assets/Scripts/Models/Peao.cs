using UnityEngine;
using System.Collections;
using System;

public class Peao : Peca {


	public override void SetMovimentos() {
		//Movimentação Normal (1 linha para frente):
		if (setdepecas.PecaCor.Equals(Setdepecas.Cordaspecas.Brancas) {
			movimentos = posicao << 8;
		} else {
			movimentos = posicao >> 8;
		}

		//move os bits em 8 posições, levando 1 linha a frente

		//Barrando Lugares Ocupados:
		movimentos = movimentos ^ (movimentos & setdepecas.tabuleiro.ocupadas);
		//Verifica quais lugares possuem movimento e pecas do tabuleiro
		//usa o XOR(^) pra selecionar aqueles lugares q so estejam no movimento

		//TODO: pensar num jeito pra jogada inicial
	}

	public override void SetPosicaoInicial() {
		posicao = 65280;
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
		 * 2|1 1 1 1 1 1 1 1 |2
		 * 1|0 0 0 0 0 0 0 0 |1
		 * 	 A B C D E F G H
		 * 
		 * Binario = 11111111 00000000
		 * Decimal = 65280
		 * 
		 */
		if (setdepecas.PecaCor.Equals(Setdepecas.Cordaspecas.Pretas) {
			posicao = posicao << 40;
		}
	}
	public Peao (Setdepecas Set) {
		this.setdepecas = Set;
	}
}

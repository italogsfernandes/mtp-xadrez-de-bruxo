using UnityEngine;
using System.Collections;


public class Torre : Peca {

	static public bool[,] GetMovimentos(int[,] posicoes, int linha, int coluna){
		bool[,] movimentos;
		movimentos = criarmatriz();
		int peca = posicoes [linha, coluna];

		/*Condicoes;
		 * 
		 * Sobre todas as linhas ate ter algum
		 * Se algum for inimigo sobe ate ele tbm
		 * 
		 * Sobe todas as colunas ate ter algum
		 * Se algum for inimigo sobre ate ele tbm
		 * 
		 */

		//supondo torre no D4
		//colocando movimentos ate o 8
		for (int i = linha+1; i < 8; i++) {
			if (posicoes [i, coluna] == 0) {
				movimentos [i, coluna] = true;
			} else if (posicoes [i, coluna] * peca < 0) {// se for  inimigo
				movimentos [i, coluna] = true;
				break;
			} else {
				break;
			}
		}

		//colocando movimentos ate o 0
		for (int i = linha-1; i >= 0; i--) {
			if (posicoes [i, coluna] == 0) {
				movimentos [i, coluna] = true;
			} else if (posicoes [i, coluna] * peca < 0) {// se for  inimigo
				movimentos [i, coluna] = true;
				break;
			} else {
				break;
			}
		}

		//colocando movimentos ate o H
		for (int j = coluna+1; j < 8; j++) {
			if (posicoes [linha, j] == 0) {
				movimentos [linha, j] = true;
			} else if (posicoes [linha, j] * peca < 0) {// se for  inimigo
				movimentos [linha, j] = true;
				break;
			} else {
				break;
			}
		}

		//colocando movimentos ate o A
		for (int j = coluna-1; j >= 0; j--) {
			if (posicoes [linha, j] == 0) {
				movimentos [linha, j] = true;
			} else if (posicoes [linha, j] * peca < 0) {// se for  inimigo
				movimentos [linha, j] = true;
				break;
			} else {
				break;
			}
		}
		return movimentos;
	}

}

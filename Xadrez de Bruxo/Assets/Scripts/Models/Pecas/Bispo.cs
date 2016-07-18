using UnityEngine;
using System.Collections;


public class Bispo : Peca {

	static public bool[,] GetMovimentos(int[,] posicoes, int linha, int coluna){
		bool[,] movimentos;
		movimentos = criarmatriz();
		int peca = posicoes [linha, coluna];

		/*Condicoes;
		 * 
		 * Equanto existe e não ha impedimento
		 * x++1
		 * y++1
		 * 
		 * x++1
		 * y--1
		 * 
		 * x--1
		 * y++1
		 * 
		 * x--1
		 * y--1
		 * 
		 */

		//supondo torre no D4
		//colocando movimentos ate o 8
		int i;
		int j;

		i = linha + 1;
		j = coluna + 1;
		while (testalimite(i,j)) {
			if (peca * posicoes [i, j] < 0) {
				movimentos [i, j] = true;
				break;
			} else if (peca * posicoes [i, j] > 0) {
				break;
			} else {
				movimentos [i, j] = true;
			}
			i++;
			j++;
		}

		i = linha + 1;
		j = coluna - 1;
		while (testalimite(i,j)) {
			if (peca * posicoes [i, j] < 0) {
				movimentos [i, j] = true;
				break;
			} else if (peca * posicoes [i, j] > 0) {
				break;
			} else {
				movimentos [i, j] = true;
			}
			i++;
			j--;
		}

		i = linha - 1;
		j = coluna + 1;
		while (testalimite(i,j)) {
			if (peca * posicoes [i, j] < 0) {
				movimentos [i, j] = true;
				break;
			} else if (peca * posicoes [i, j] > 0) {
				break;
			} else {
				movimentos [i, j] = true;
			}
			i--;
			j++;
		}

		i = linha - 1;
		j = coluna - 1;
		while (testalimite(i,j)) {
			if (peca * posicoes [i, j] < 0) {
				movimentos [i, j] = true;
				break;
			} else if (peca * posicoes [i, j] > 0) {
				break;
			} else {
				movimentos [i, j] = true;
			}
			i--;
			j--;
		}

		return movimentos;
	}

	private static bool testalimite(int x,int y) {
		if (x < 0 || y < 0)
			return false;
		if (x > 7 || y > 7)
			return false;
		return true;
	}

}

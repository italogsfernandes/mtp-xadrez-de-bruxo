using UnityEngine;
using System.Collections;


public class Rei : Peca {

	static public bool[,] GetMovimentos(int[,] posicoes, int linha, int coluna){
		bool[,] movimentos;
		movimentos = criarmatriz();
		int peca = posicoes [linha, coluna];

		/*Condicoes;
		 * 
		 * Se existir e tiver vazia:
		 * x++2
		 * 		y+1
		 * 		y-1
		 * 
		 * x--2
		 * 		y+1
		 * 		y-1
		 * 
		 * y++2
		 * 		x+1
		 * 		x-1
		 * y--2
		 * 		x+1
		 * 		x-2
		 * 
		 */
		for (int i = linha-1; i <= linha+1; i++) {
			for (int j = coluna-1; j <= coluna+1; j++) {
				movimentos [i, j] = testacandidato (i, j, peca, posicoes);
			}
		}
		//TODO: ROQUE
		//TODO: Veriricar Cheque
		return movimentos;
	}

	private static bool testacandidato(int x,int y, int peca, int[,] posicoes) {
		if (x < 0 || y < 0)
			return false;
		if (x > 7 || y > 7)
			return false;
		if (peca * posicoes[x,y] > 0)
			return false;

		return true;
	}


}

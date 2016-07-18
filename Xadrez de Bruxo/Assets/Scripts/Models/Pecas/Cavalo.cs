using UnityEngine;
using System.Collections;


public class Cavalo : Peca {

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
		int i;
		int j;

		i = linha + 2;
		j = coluna + 1;
		movimentos[i, j] = testacandidato(i, j, peca, posicoes);
		j = coluna - 1;
		movimentos[i, j] = testacandidato(i, j, peca, posicoes);

		i = linha - 2;
		j = coluna + 1;
		movimentos[i, j] = testacandidato(i, j, peca, posicoes);
		j = coluna - 1;
		movimentos[i, j] = testacandidato(i, j, peca, posicoes);

		j = coluna + 2;
		i = linha + 1;
		movimentos[i, j] = testacandidato(i, j, peca, posicoes);
		i = linha - 1;
		movimentos[i, j] = testacandidato(i, j, peca, posicoes);

		j = coluna - 2;
		i = linha + 1;
		movimentos[i, j] = testacandidato(i, j, peca, posicoes);
		i = linha - 1;
		movimentos[i, j] = testacandidato(i, j, peca, posicoes);

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

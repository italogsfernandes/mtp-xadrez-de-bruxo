using UnityEngine;
using System.Collections;
using System;

public class Peao : Peca {

	static public bool[,] GetMovimentos(int[,] posicoes, int linha, int coluna){
		bool[,] movimentos;
		movimentos = criarmatriz();
		int peca = posicoes [linha, coluna];

		/*Condicoes;
		 * 
		 * Se existir e tiver vazia:
		 * Casa da frente
		 * 
		 * Se tiver inimigo nas diagonais:
		 * Casa do inimigo tbm
		 * 
		 * Detalhe: Frente muda de acordo com a cor da peça
		 * 
		 */
		int i;
		int j;
		//Debug.Log ("Meu peao esta em: " + linha.ToString () + ", " + coluna.ToString ());
		//Movimentacao normal:
		i = linha + Math.Sign(peca)*1;
		//Se for branca avança 1, se for preta retorna 1
		j = coluna;

		//Debug.Log ("Meu peao vai para: " + i.ToString () + ", " + j.ToString ());
		if (testacandidato (i, j, peca, posicoes) ){
			movimentos [i, j] = true;
		}

		if ((linha == 1 && peca > 0) || (linha == 6 && peca < 0)) {
			i = i + Math.Sign (peca) * 1;
			movimentos [i, j] = testacandidato (i, j, peca, posicoes);
			i = linha + Math.Sign(peca)*1;
		}

		//Movimentacao de comer
		j = coluna + 1;
		if (testacandidato (i, j, peca, posicoes))
			movimentos [i, j] = peca * posicoes [i, j] < 0;

		j = coluna - 1;
		if (testacandidato (i, j, peca, posicoes))
			movimentos [i, j] = peca * posicoes [i, j] < 0;
		//TODO: Promoção de peoes
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

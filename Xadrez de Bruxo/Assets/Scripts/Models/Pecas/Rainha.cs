using UnityEngine;
using System.Collections;


public class Rainha : Peca {

	static public bool[,] GetMovimentos(int[,] posicoes, int linha, int coluna){
		bool[,] movimentos_torre;
		bool[,] movimentos_bispo;

		bool[,] movimentos;
		movimentos = criarmatriz ();

		movimentos_torre = Torre.GetMovimentos (posicoes, linha, coluna);
		movimentos_bispo = Bispo.GetMovimentos (posicoes, linha, coluna);

		/*Condicoes;
		 * 
		 * Uniao de torre e bispo
		 * 
		 */
		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				movimentos [i, j] = movimentos_torre [i, j] || movimentos_bispo [i, j];
			}
		}
		return movimentos;
	}

}

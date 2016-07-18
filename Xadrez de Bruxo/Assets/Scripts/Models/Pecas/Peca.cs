using UnityEngine;
using System.Collections;

public class Peca {

	static public bool[,] criarmatriz () {
		bool[,] matriz = new bool[8,8];
		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				matriz[i,j] = false;
			}
		}
		return matriz;
	}

		
}

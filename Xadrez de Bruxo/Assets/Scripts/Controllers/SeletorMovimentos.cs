using UnityEngine;
using System.Collections;
using System;

public class SeletorMovimentos : MonoBehaviour {

	public GameObject tabuleiroController;
	public GameObject destaque;
	public GameObject marcadores;

	private TabuleiroController scriptTabController;
	// Use this for initialization
	void Start () {
		scriptTabController = tabuleiroController.GetComponent<TabuleiroController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			MarcarLugares (
						Mathf.RoundToInt (position.x) + 4,
						Mathf.RoundToInt (position.y) + 4);
		}
	}

	public int GetPecaAt(int linha, int coluna) {
		return scriptTabController.tabuleiro.posicoes [linha, coluna];
	}

	private void MarcarLugares(int linha, int coluna) {
		bool[,] lugares = GerarMatrizdeMovimentos(linha,coluna);


		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				if (lugares [i, j]) {
					//TODO: Algo mais bonito que a esfera
					GameObject element = (GameObject) Instantiate (destaque,
						new Vector3 (
							(j - 4) * scriptTabController.y_unidade,
							(i - 4) * scriptTabController.x_unidade,
							0f),
						Quaternion.identity);
					element.transform.SetParent(marcadores.transform,true);
				}
			}
		}

	}

	public bool[,] GerarMatrizdeMovimentos(int linha, int coluna){
		bool[,] lugares;
		switch (Math.Abs( GetPecaAt (linha, coluna) )) {
		case 1:
			lugares = Peao.GetMovimentos (
				scriptTabController.tabuleiro.posicoes,
				linha,
				coluna);
			break;
		case 2:
			lugares = Torre.GetMovimentos (
				scriptTabController.tabuleiro.posicoes,
				linha,
				coluna);
			break;
		case 3:
			lugares = Cavalo.GetMovimentos (
				scriptTabController.tabuleiro.posicoes,
				linha,
				coluna);
			break;
		case 4:
			lugares = Bispo.GetMovimentos (
				scriptTabController.tabuleiro.posicoes,
				linha,
				coluna);
			break;
		case 5:
			lugares = Rainha.GetMovimentos (
				scriptTabController.tabuleiro.posicoes,
				linha,
				coluna);
			break;
		case 6:
			lugares = Rei.GetMovimentos (
				scriptTabController.tabuleiro.posicoes,
				linha,
				coluna);
			break;
		default:
			lugares = Peca.criarmatriz ();
			break;
		}
		return lugares;
	}

}

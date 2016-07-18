using UnityEngine;
using System.Collections;
using System;

public class SeletorMovimentos : MonoBehaviour {

	public GameObject tabuleiroController;
	public GameObject destaque;
	public GameObject marcadores;
	public bool isSelected = false;

	private int linha_anterior = -1;
	private int coluna_anterior = -1;

	private TabuleiroController scriptTabController;

	// Use this for initialization
	void Start () {
		scriptTabController = tabuleiroController.GetComponent<TabuleiroController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);

			int linha = Mathf.RoundToInt (position.y) + 4;
			int coluna = Mathf.RoundToInt (position.x) + 4;

			if(isSelected)
				MoverPeca(linha_anterior, coluna_anterior, linha, coluna);
				
			isSelected = MarcarLugares ( linha, coluna);

			linha_anterior = linha;
			coluna_anterior = coluna;

		}
	}

	public int GetPecaAt(int linha, int coluna) {
		if(Peca.testalimite(linha,coluna)) {
			return scriptTabController.tabuleiro.posicoes [linha, coluna];
		} else {
			return 0;
		}
	}

	private bool MarcarLugares(int linha, int coluna) {
		bool[,] lugares = GerarMatrizdeMovimentos(linha,coluna);
		bool possibilidade = false;

		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				if (lugares [i, j]) {
					possibilidade = true;
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

		return possibilidade;

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

	public void MoverPeca(int origem_i, int origem_j, int destino_i, int destino_j) {
		bool[,] movimentos = GerarMatrizdeMovimentos (origem_i, origem_j);

		if(movimentos[destino_i,destino_j]) {
			scriptTabController.tabuleiro.posicoes [destino_i, destino_j] =
				scriptTabController.tabuleiro.posicoes [origem_i, origem_j];
			
			scriptTabController.tabuleiro.posicoes [origem_i, origem_j] = 0;

			Debug.Log ("Movida");
			MovePecaVisao (origem_i, origem_j, destino_i, destino_j);
		}

	}
	public void MovePecaVisao(int origem_i,int origem_j, int destino_i, int destino_j){
		Transform elemento = GetImagemPecaAt (origem_i, origem_j);
		elemento.position.Set (
			(destino_j - 4) * scriptTabController.x_unidade,
			(destino_i - 4) * scriptTabController.y_unidade,
			0f
		);
	}

	public Transform GetImagemPecaAt(int linha, int coluna) {
		Transform[] possiveis_go = tabuleiroController.GetComponentsInChildren<Transform> ();
		foreach (Transform item in possiveis_go) {
			if (item.position.Equals(new Vector3 ( linha,
				coluna, 0))) {
				Debug.Log (item);
				Debug.Log ("selecionado");
				return item;
			}
		}
		Debug.Log ("nada");
		return null;
	}

	public void AtualizaTabuleiro() {
		tabuleiroController.SendMessage ("AtualizaVisao");

	}

}

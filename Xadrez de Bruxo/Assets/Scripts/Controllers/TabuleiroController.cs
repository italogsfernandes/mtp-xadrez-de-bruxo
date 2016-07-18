using UnityEngine;
using System.Collections;

public class TabuleiroController : MonoBehaviour {

	// Use this for initialization
	public Tabuleiro tabuleiro;

	public float x_unidade;
	public float y_unidade;

	public GameObject peaoP;
	public GameObject torreP;
	public GameObject cavaloP;
	public GameObject bispoP;
	public GameObject reiP;
	public GameObject rainhaP;

	public GameObject peaoB;
	public GameObject torreB;
	public GameObject cavaloB;
	public GameObject bispoB;
	public GameObject reiB;
	public GameObject rainhaB;


	void Start () {
		tabuleiro = new Tabuleiro ();
		ConvertePecas ();
	}
		
	public void ConvertePecas(){
		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				switch (tabuleiro.posicoes[i,j]) {
				case -1:
					Posiciona (peaoP, i, j);
					break;
				case -2:
					Posiciona (torreP, i, j);
					break;
				case -3:
					Posiciona (cavaloP, i, j);
					break;
				case -4:
					Posiciona (bispoP, i, j);
					break;
				case -5:
					Posiciona (rainhaP, i, j);
					break;
				case -6:
					Posiciona (reiP, i, j);
					break;
				case 1:
					Posiciona (peaoB, i, j);
					break;
				case 2:
					Posiciona (torreB, i, j);
					break;
				case 3:
					Posiciona (cavaloB, i, j);
					break;
				case 4:
					Posiciona (bispoB, i, j);
					break;
				case 5:
					Posiciona (rainhaB, i, j);
					break;
				case 6:
					Posiciona (reiB, i, j);
					break;
				default:
					break;
				}
			}
		}
	}

	private void Posiciona(GameObject peca, int x, int y) {
		GameObject element = (GameObject) Instantiate (peca,
			new Vector3 ((y-4) * y_unidade, (x - 4) * y_unidade, 0f),
			Quaternion.identity);
		element.name = peca.name + "("+x.ToString()+", " + y.ToString() + ")";
		element.transform.SetParent (this.transform, true);
	}

	public void AtualizaVisao() {
		
	}


}
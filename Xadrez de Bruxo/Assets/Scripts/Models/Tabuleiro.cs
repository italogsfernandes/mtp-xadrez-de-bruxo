using UnityEngine;
using System.Collections;
using System;

public class Tabuleiro {

	//public enum Pecas{ peao, torre, cavalo, bispo, rei, rainha};

	public int[,] posicoes { get; set; }
	
	public int[,] movimentos = new int[8,8];

	public Tabuleiro() {
		PosicoesIniciais ();

	}
	public void PosicoesIniciais(){
		this.posicoes = new int[,] { 
			{ 2, 3, 4, 5, 6, 4, 3, 2},
			{ 1, 1, 1, 1, 1, 1, 1, 1},
			{ 0, 0, 0, 0, 0, 0, 0, 0},
			{ 0, 0, 0, 0, 0, 0, 0, 0},
			{ 0, 0, 0, 0, 0, 0, 0, 0},
			{ 0, 0, 0, 0, 0, 0, 0, 0},
			{-1,-1,-1,-1,-1,-1,-1,-1},
			{-2,-3,-4,-5,-6,-4,-3,-2} };
	}
}

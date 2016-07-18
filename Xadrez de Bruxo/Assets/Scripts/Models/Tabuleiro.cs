using UnityEngine;
using System.Collections;
using System;

public class Tabuleiro {

	//public enum Pecas{ peao, torre, cavalo, bispo, rei, rainha};

	public int[,] posicoes { get; set; }

	public Tabuleiro() {
		PosicoesIniciais ();
	}

	public void PosicoesIniciais(){
		this.posicoes = new int[,] {   //i
			{ 2, 3, 4, 5, 6, 4, 3, 2}, //1
			{ 1, 1, 1, 1, 1, 1, 1, 1}, //2
			{ 0, 0, 0, 0, 0, 0, 0, 0}, //3
			{ 0, 0, 0, 0, 0, 0, 0, 0}, //4
			{ 0, 0, 0, 0, 0, 0, 0, 0}, //5
			{ 0, 0, 0, 0, 0, 0, 0, 0}, //6
			{-1,-1,-1,-1,-1,-1,-1,-1}, //7
			{-2,-3,-4,-5,-6,-4,-3,-2}  //8
		};//j A, B, C, D, E, F, G, H
	}
}

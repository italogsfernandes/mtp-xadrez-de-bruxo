using UnityEngine;
using System.Collections;
using System;

public class Tabuleiro {


	public Setdepecas brancas;
	public Setdepecas pretas;

	public UInt64 ocupadas {
		get{
			return (brancas.ocupadas | pretas.ocupadas);
		}
		private set{ ;}
	}

	public UInt64 livres {
		get{ 
			return (~ocupadas);
		}
		set{ ;}
	}

	public Tabuleiro() {
		this.brancas = new Setdepecas (this, 0);
		this.pretas = new Setdepecas (this, 1);
	}

	public void Mover(Vector2 Inicio, Vector2 Final){
		UInt64 inicio = 1;
		inicio = inicio << Convert.ToInt32(Inicio.x);
		inicio = inicio << Convert.ToInt32(Inicio.y * 8);

		UInt64 final = 1;
		final = final << Convert.ToInt32(Final.x);
		final = final << Convert.ToInt32(Final.y * 8);

//		var quem = GetPecaAt (inicio);
	}

//	public Peca GetPecaAt(UInt64 local){
//		if ((local & pretas.ocupadas) > 0) {
//			if ((local & pretas.peoes.posicao) > 0) {
//				return pretas.peoes;
//			} else if ((local & pretas.torres.posicao) > 0) {
//				return pretas.torres;
//			} else if ((local & pretas.cavalos.posicao) > 0) {
//				return pretas.cavalos;
//			} else if ((local & pretas.bispos.posicao) > 0) {
//				return pretas.bispos;
//			} else if ((local & pretas.rei.posicao) > 0) {
//				return pretas.rei;
//			} else if ((local & pretas.rainha.posicao) > 0) {
//				return pretas.rainha;
//			} 
//		} else if ((local & brancas.ocupadas) > 0) {
//			if ((local & brancas.peoes.posicao) > 0) {
//				return brancas.peoes;
//			} else if ((local & brancas.torres.posicao) > 0) {
//				return brancas.torres;
//			} else if ((local & brancas.cavalos.posicao) > 0) {
//				return brancas.cavalos;
//			} else if ((local & brancas.bispos.posicao) > 0) {
//				return brancas.bispos;
//			} else if ((local & brancas.rei.posicao) > 0) {
//				return brancas.rei;
//			} else if ((local & brancas.rainha.posicao) > 0) {
//				return brancas.rainha;
//			} 
////		}
//
//	}
}

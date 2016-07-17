using UnityEngine;
using System.Collections;
using System;

public class Peca {

	public Setdepecas setdepecas;

	public UInt64 movimentos {
		get;
		set;
	}
	public UInt64 posicao {
		get;
		set;
	}

	public Peca () {
		this.posicao = 0;
		this.movimentos = 0;
	}

	virtual public void SetPosicaoInicial() {

	}

	virtual public void SetMovimentos(){
		
	}

	public Peca (Setdepecas Set) {
		this.setdepecas = Set;
	}
}

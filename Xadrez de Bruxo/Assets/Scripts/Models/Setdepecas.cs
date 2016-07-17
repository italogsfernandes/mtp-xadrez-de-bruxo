using UnityEngine;
using System.Collections;
using System;

public class Setdepecas {

	public Tabuleiro tabuleiro;
	public enum Cordaspecas { Brancas = 0, Pretas = 1 };

	public Cordaspecas PecaCor {
		get;
		set;
	}

	public Peao peoes {
		get;
		set;
	}
	public Torre torres {
		get;
		set;
	}
	public Cavalo cavalos {
		get;
		set;
	}
	public Bispo bispos {
		get;
		set;
	}
	public Rei rei {
		get;
		set;
	}
	public Rainha rainha {
		get;
		set;
	}

	public UInt64 ocupadas {
		get{
			if (PecaCor.Equals (Cordaspecas.Pretas))
				return InverterRepresentacao ((peoes.posicao | torres.posicao
				| cavalos.posicao | bispos.posicao
				| rei.posicao | rainha.posicao));
			else
				return ( peoes.posicao | torres.posicao 
				| cavalos.posicao |  bispos.posicao
				| rei.posicao | rainha.posicao);
		}
		private set{ ; }
	}

	public Setdepecas (Tabuleiro Tab,int cordaspecas){
		this.peoes = new Peao (this);
		this.torres = new Torre (this);
		this.cavalos = new Cavalo (this);
		this.bispos = new Bispo (this);
		this.rei = new Rei (this);
		this.rainha = new Rainha (this);
		this.tabuleiro = Tab;

		if (cordaspecas == 0)
			this.PecaCor = Cordaspecas.Brancas;
		else
			this.PecaCor = Cordaspecas.Pretas;
	}
	public UInt64 InverterRepresentacao(UInt64 representacao) {
		UInt64 invertido = 0;

		return invertido;
	}

	public byte InverterByte(byte meubyte) {
		byte novobyte = 0;
		//meubyte = 0011 0101
		//meubyte << 7 = 1000 0000
		//novobyte = novobyte | last = 1000 0000
		//(meubyte >> 1) = 0001 1010
		//last << 7 = 0000 0000
		//last >> 1 = 0000 0000
		//novobyte = novobyte | last = 1000 0000
		//meubyte >> 2 = 0000 1101
		// last << 7 = 1000 0000
		// last >> 2 = 0010 0000
		// novobyte = novobyte | last = 1010 0000
		return novobyte;
	}
}

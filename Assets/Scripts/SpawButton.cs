﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawButton : MonoBehaviour {
	[SerializeField] GameObject _ObjectToSpawn;
	[SerializeField] GameObject UI;

	private PseudoHandle _PHandle;
	private TouchHandle _TouchHandle;
	// Use this for initialization
	void Start () {
		_TouchHandle = FindObjectOfType<TouchHandle> ();
		_PHandle = FindObjectOfType<PseudoHandle> ();
	}

	public void _Spawn(){
		//adicionando o componente pseudoblock do novo objeto spawnado na lsita do PseudoHandle para mais tarde ele dar play nesses objetos
		GameObject G = Instantiate (_ObjectToSpawn);
		Vector3 aux = Camera.main.transform.position + (Vector3.up * 5);
		aux.z = 0;
		G.transform.position = aux;

		PseudoBlock P = G.GetComponent<PseudoBlock> ();
		if (UI != null) P._SetUI (UI);
		_TouchHandle._SelectBlock (G.GetComponent<Collider2D>());

		_PHandle._PseudoBlockList.Add(P);
	}
}

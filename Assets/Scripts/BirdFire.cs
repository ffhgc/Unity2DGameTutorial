﻿using UnityEngine;
using System.Collections;

public class BirdFire : MonoBehaviour {

	public float attackDelay = 3f;

	private Animator animator;
	public BirdHid projectile;
	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();

		if (attackDelay > 0) {
			StartCoroutine(OnAttack());
		}
	}

	// Update is called once per frame
	void Update () {
		animator.SetInteger ("AnimState", 0);
	}

	IEnumerator OnAttack(){
		yield return new WaitForSeconds(attackDelay);
		Fire ();
		StartCoroutine (OnAttack ());
	}

	void Fire(){
		animator.SetInteger ("AnimState", 1);
	}
	void OnShoot(){
		if (projectile) {
			BirdHid clone = Instantiate (projectile, transform.position, Quaternion.identity) as BirdHid;
		}

	}
}

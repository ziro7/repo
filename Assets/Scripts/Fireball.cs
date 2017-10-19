using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	public int damage = 10; //todo change to calc
	public float speed = 5.0f;
	public ParticleSystem particle = null;
	//public AudioClip audioHit;
	//public AudioClip audioLaunch;
	private bool canMove = true;

	void Awake()
	{
		//this.GetComponent<AudioSource>().PlayOneShot(audioLaunch);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		MoveObject();
	}

	void MoveObject()
	{
		if (canMove)
		{
			this.transform.Translate(0, 0, speed * Time.deltaTime);
		}
		
	}

	void OnTriggerEnter (Collider other)
	{
		Debug.Log(other + " was hit");
		//this.GetComponent<AudioSource>().PlayOneShot(audiotHit);
		this.GetComponent<Renderer>().enabled = false;
		this.GetComponent<Collider>().enabled = false;
		canMove = false;
		Destroy(this.gameObject,3.0f);
	}

}

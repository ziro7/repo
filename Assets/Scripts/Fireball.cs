using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Characters;

public class Fireball : MonoBehaviour {

	public float speed = 5.0f;
	public bool isMagical = true;
	public float minDamage = 35.0f;
	public float maxDamage = 50.0F;
	public ParticleSystem particle = null;
	public GameObject spotLight;
	//public AudioClip audioHit;
	//public AudioClip audioLaunch;
	private bool canMove = true;
	GameObject target = null;

	MouseManager mouseManager;
		
	void Awake()
	{
		
	}

	// Use this for initialization
	void Start () {

		//this.GetComponent<AudioSource>().PlayOneShot(audioLaunch);

		//mouseManager
		mouseManager = GameObject.FindObjectOfType<MouseManager>();

		//info from target.
		if (mouseManager.selectedObject != null)
		{
			target = mouseManager.selectedObject;
		}
		
						
	}
	
	// Update is called once per frame
	void Update () {

		MoveObject();
	}

	void MoveObject()
	{
		if (canMove)
		{

			transform.LookAt(target.transform);
			transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
			Debug.Log(target);

		}
		
	}

	void OnTriggerEnter (Collider collider)
	{
		Debug.Log(collider + " was hit");

		Component damagableComponent = collider.gameObject.GetComponent(typeof(IDamageable));
		if (damagableComponent)
		{
			float damageDone = DamageFromMinMax(minDamage, maxDamage);
			Debug.Log("damage from fireball: " + damageDone);
			(damagableComponent as IDamageable).TakeDamage(damageDone);
		}
				
		//this.GetComponent<AudioSource>().PlayOneShot(audiotHit);
		GetComponent<Renderer>().enabled = false;
		GetComponent<Collider>().enabled = false;
		GetComponentInChildren<ParticleSystem>().Stop(true);
		spotLight.SetActive(false);
		canMove = false;
		Destroy(this.gameObject,3.0f);
	}


	
	private float DamageFromMinMax(float minDamage, float maxDamage)
	{
		return Random.Range(minDamage, maxDamage);
	}




}

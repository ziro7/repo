using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{ 
	public class PlayerControl : MonoBehaviour {

		public Transform castSocket;
		public GameObject fireball;
		public GameObject fireballCast;

		// Use this for initialization
		void Start() {

		}

		// Update is called once per frame
		void Update() {

			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				StartCoroutine(CastFireball());
			}
		}
		
		void LaunchFireball()
		{
			GameObject obj = Instantiate(fireball, castSocket.position, castSocket.rotation) as GameObject;
			obj.name = "fireball";
		}

		IEnumerator CastFireball()
		{
			StartCoroutine(CastingFireball());
			LaunchFireball();
			yield return new WaitForSeconds(0.5f);
		}

		IEnumerator CastingFireball()
		{
			GameObject obj = Instantiate(fireballCast, castSocket.position, castSocket.rotation) as GameObject;
			yield return new WaitForSeconds(1.5f); //todo affected by haste
			DestroyObject(obj);
		}


	}
}
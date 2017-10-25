using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{ 
	public class PlayerControl : MonoBehaviour {

		public Transform parent;
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
			GameObject obj = Instantiate(fireball, castSocket.position, castSocket.rotation, parent) as GameObject;
			obj.name = "fireball";
		}

		IEnumerator CastFireball()
		{
			StartCoroutine(CastingFireball());
			yield return new WaitForSeconds(1.5f);
			LaunchFireball();
		}

		IEnumerator CastingFireball()
		{
			GameObject obj = Instantiate(fireballCast, castSocket.position, castSocket.rotation) as GameObject;
			yield return new WaitForSeconds(1.5f); //todo affected by haste
			DestroyObject(obj);
		}
		
	}
}
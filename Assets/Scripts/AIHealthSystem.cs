using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Characters
{
	public class AIHealthSystem : MonoBehaviour
	{
		[SerializeField] Image healthBar;
		[SerializeField] AudioClip[] damageSounds;
		[SerializeField] AudioClip[] deathSounds;
		//[SerializeField] float deathVanishSeconds = 2.0f;
		//[SerializeField] float resisdencePrLevel = 30f;
		//[SerializeField] float maxResistance = 360f;
		[SerializeField] float hitPenaltyBoss = 0.16f;
		[SerializeField] float hitpenalty2levels = 0.05f;
		[SerializeField] float hitpenalty1levels = 0.03f;
		private float health; 
		//[SerializeField] float doubleDamagePenetration = 100f;
		//[SerializeField] float crushingBlowChance = 0.1f; 
		//[SerializeField] float glancingBlowChance = 0.25f;

		GameObject parent;

		const string DEATH_TRIGGER = "Death";

		float currentHealthPoints;
		//Animator animator;
		//AudioSource audioSource;
		Character character;

		public float healthAsPercentage { get { return currentHealthPoints / health; } }
		public float Health { get { return currentHealthPoints; } }
		//public float ResisdencePrLevel { get { return resisdencePrLevel; } }
		public float HitPenaltyBoss { get { return hitPenaltyBoss; } }
		public float Hitpenalty2levels { get { return hitpenalty2levels; } }
		public float HitPenalty1levels { get { return hitpenalty1levels; } }
		//public float DoubleDamagePenetration { get { return doubleDamagePenetration; } }

		void Start()
		{
			//animator = GetComponent<Animator>();
			//audioSource = GetComponent<AudioSource>();
			character = GetComponent<Character>();
			health = 220;
			currentHealthPoints = health;

		}

		void Update()
		{
			UpdateHealthBar();
		}

		void UpdateHealthBar()
		{
			if (healthBar) // Enemies may not have health bars to update
			{
				healthBar.fillAmount = healthAsPercentage;
			}
		}

		public void ReduceHealth(float damage)
		{
			Debug.Log("ReduceHealth was called with: " + damage);
			bool characterDies = (currentHealthPoints - damage <= 0);
		    currentHealthPoints = Mathf.Clamp(currentHealthPoints - damage, 0f, health);
		    //var clip = damageSounds[UnityEngine.Random.Range(0, damageSounds.Length)];
		    //audioSource.PlayOneShot(clip);
		    if (characterDies)
		    {
				//StartCoroutine(KillCharacter());
				Debug.Log("Har ikke implementeret død");
		    }
		}

		public void Heal(float points)
		{
			currentHealthPoints = Mathf.Clamp(currentHealthPoints + points, 0f, health);
		}


/*IEnumerator KillCharacter()
{
	characterMovement.Kill();
	animator.SetTrigger(DEATH_TRIGGER);

	audioSource.clip = deathSounds[UnityEngine.Random.Range(0, deathSounds.Length)];
	audioSource.Play(); // overrind any existing sounds
	yield return new WaitForSecondsRealtime(audioSource.clip.length);

	var playerComponent = GetComponent<PlayerControl>();
	if (playerComponent && playerComponent.isActiveAndEnabled) // relying on lazy evaluation
	{
		SceneManager.LoadScene(0);
	}
	else // assume is enemy fr now, reconsider on other NPCs
	{
		DestroyObject(gameObject, deathVanishSeconds);
	}
}*/
    }
}
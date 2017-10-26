using Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour, IDamageable
{
	AIHealthSystem aIHealthSystem;
	Character character;
	Player player;
	float hitChance;

	// Use this for initialization
	void Start () {

		//this.GetComponent<AudioSource>().PlayOneShot(audioLaunch);

		//info from this components gameObject
		character = GetComponent<Character>();

		//info from attacker.
		player = GameObject.FindObjectOfType<Player>();
		
		//HealthSystem
		aIHealthSystem = GetComponent<AIHealthSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(float damage, bool isMagical)
	{
		//Debug.Log("Damage in Damage - TakeDamage start at: " + damage);
		float damageDone = CalculateDamage(damage, isMagical);
		aIHealthSystem.ReduceHealth(damageDone);
	}

	private float CalculateDamage(float damage, bool isMagical)
	{
		float hitMultiplier = HitMultiplier();
		float multiplierOnCrit = MultiplierOnCrit();
		float damageDiffFromPenetrationAndResistance = DamageDiffFromPenetrationAndResistance(isMagical);
		float damageDiffFromMeleeCombat = DamageDiffFromMeleeCombat(isMagical);

		float damageDone = damage * hitMultiplier * multiplierOnCrit * damageDiffFromPenetrationAndResistance * damageDiffFromMeleeCombat;
		//Debug.Log("hitMultiplier: " + hitMultiplier);
		//Debug.Log("multiplierOnCrit: " + multiplierOnCrit);
		//Debug.Log("damageDiffFromPenetration: " + damageDiffFromPenetrationAndResistance);
		//Debug.Log("damageDiffFromMeleeCombat: " + damageDiffFromMeleeCombat);

		return damageDone;
	}

		
	private int levelDifference()
	{
		return (character.Level - player.Level);
	}

	private float HitMultiplier()
	{
	bool isBosslevel = (character.Level - 2 > player.Level);
	bool is2HigherLevel = (character.Level - 2 == player.Level);
	bool is1HigherLevel = (character.Level - 1 == player.Level);

	if (isBosslevel)
	{
		hitChance = player.HitChance - aIHealthSystem.HitPenaltyBoss;
	}
	else if (is2HigherLevel)
	{
		hitChance = player.HitChance - aIHealthSystem.Hitpenalty2levels;
	}
	else if (is1HigherLevel)
	{
		hitChance = player.HitChance - aIHealthSystem.HitPenalty1levels;
	} else
	{
		hitChance = player.HitChance;
	}

	float randomNumber = Random.Range(0, 101);

	if (randomNumber > (hitChance*100))
	{
		return 0;
	}
	else
	{
		return 1;
	}

}

	private float MultiplierOnCrit()
	{
		float randomNumber = Random.Range(0, 101);

		if (randomNumber > (player.CritChance*100))
		{
			return 1;
		}
		else
		{
			return 2;
		}
	}

	private float DamageDiffFromPenetrationAndResistance(bool isMagical)
	{
		if (isMagical) 
		{
			float resistance = character.ResistanceToSpells + levelDifference() * aIHealthSystem.ResisdencePrLevel;
					
			return (1 - (resistance / aIHealthSystem.MaxResistance) + (character.Penetration/aIHealthSystem.DoubleDamagePenetration));
		
		//eksempel 1 - 90/360 + 5/100 = 1-0,25+0,05 = 0,80
		//eksempel 2 - 0/360 + 30/100 = 1-0+0,3 = 1,3

		//target 58 - inflicter 60 / resist 90 / penn 20
		//eksempel  - (90-2*30)/360 + 20/100 = 1-0,0833+0,2 = 1,2833
		
		} else
		{
			return 1;
		}
	}

	private float DamageDiffFromMeleeCombat(bool isMagical)
	{
		if (isMagical == false)
		{
			float randomNumber = Random.Range(0, 100);
			float blockChance = character.BlockChance;

			if ((character.Level - 2) > player.Level)
			{
				//crushingBlow possible
				if (randomNumber < (aIHealthSystem.CrushingBlowChance))
				{
					return aIHealthSystem.CrushingBlowMultiplier;
				}
				else
				{
					return 1; //could be crushing hit - but is not
				}
			} else if ((character.Level + 2) < player.Level)
			{

				//GlancingBlow possible 
				if (randomNumber < (aIHealthSystem.GlancingBlowChance))
				{
					return aIHealthSystem.GlancingBlowMultiplier;
				}
				else
				{
					return 1; //could be Glanicing - but is not
				}

			} else
			{
				return 1; //Can't be either glancing or crushing
			}

		} else
		{
			return 1;  //Is not melee damage.
		}
	}

}

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
		//hitChance = transform.parent.gameObject.GetComponent<Character>().HitChance;
		//critChance = transform.parent.gameObject.GetComponent<Character>().CritChance;
		//critMultiplier = transform.parent.gameObject.GetComponent<Character>().CritMultiplier;
		//level = transform.parent.gameObject.GetComponent<Character>().Level;
		//charPenetration = transform.parent.gameObject.GetComponent<Character>().Penetration;
		//inteligence = transform.parent.gameObject.GetComponent<Character>().Inteligence;

		//info from attacker.
		player = GameObject.FindObjectOfType<Player>();
		//target = mouseManager.hoveredObject;
		//targetLevel = target.GetComponent<Character>().Level;
		//resistanceToSpells = target.GetComponent<Character>().ResistanceToSpells;
		//hitPenaltyBoss = target.GetComponent<HealthSystem>().HitPenaltyBoss;
		//hitpenalty2levels = target.GetComponent<HealthSystem>().Hitpenalty2levels;
		//hitpenalty1levels = target.GetComponent<HealthSystem>().HitPenalty1levels;
		//doubleDamagePenetration = target.GetComponent<HealthSystem>().DoubleDamagePenetration;
		//resisdencePrLevel = target.GetComponent<HealthSystem>().ResisdencePrLevel;

		//mouseManager
		//mouseManager = GameObject.FindObjectOfType<MouseManager>();

		//HealthSystem
		aIHealthSystem = GetComponent<AIHealthSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(float damage)
	{
		Debug.Log("Damage in Damage - TakeDamage start at: " + damage);
		float damageDone = CalculateDamage(damage);
		aIHealthSystem.ReduceHealth(damageDone);
	}

	private float CalculateDamage(float damage)
	{
		float hitMultiplier = HitMultiplier();
		float multiplierOnCrit = MultiplierOnCrit();
		//float damage = DamageFromMinMax(minDamage, maxDamage);
		//float damageDiffFromPenetrationAndResistance = DamageDiffFromPenetrationAndResistance(target, character);
		//float multiplierFromLevelDifference = MultiplierFromLevelDifference(target, character);

		float damageDone = hitMultiplier * damage * multiplierOnCrit; // * reducedDamageFromResistance * multiplierFromLevelDifference;
		Debug.Log("damageDone after Calc was: " + damageDone);
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

	Debug.Log("Hvad er hitchance: " + hitChance);
	float randomNumber = Random.Range(0, 100);
	Debug.Log("Hvad er random: " + randomNumber);
	if (randomNumber <= (1-hitChance*100))
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
		float randomNumber = Random.Range(0, 1);

		if (randomNumber <= (1 - player.CritChance))
		{
			return 1;
		}
		else
		{
			return 2;
		}
	}

	/* private float DamageDiffFromPenetrationAndResistance(int level, int targetLevel, float resisstanceToSpell, float resisdencePrLevel, float charPenetration);
	{
		if (isMagical) 
		{
			float resistance = resistanceToSpells - levelDifference(level, targetLevel) * resisdencePrLevel;
					
			return (1 - (resistance/maxResistance) + (charPenetration/doubleDamagePenetration);
		//eksempel 1 - 90/360 + 20/100 = 1-0,25+0,2 = 0,95
		//eksempel 1 - 0/360 + 30/100 = 1-0+0,3 = 1,3

		//target 58 - inflicter 60 / resist 90 / penn 20
		//eksempel  - (90-2*30)/360 + 20/100 = 1-0,0833+0,2 = 1,2833
		
		} else
		{
			Debug.log("Not implemented non magical damage")
		}
	}

	private float MultiplierFromLevelDifference(GameObject target, Character character);
	{
		//skal nok lige se om de er melee
		float randomNumber = Random.Range(0, 1);
		float blockChance = target.blockChance;

		if ((target.level-2) > character.level)
		{
			//crushingBlow possible
			if (randomNumber< (1-crushingBlowChance))
			{
			return 1;
			} 
			else
			{
			return 1,5;
			} 
		} else if ((target.level+2) < character.level)
		{
			
			//GlancingBlow possible 
			if (randomNumber< (1-glancingBlowChance))
			{
			return 1;
			} 
			else
			{
			return 0,5;
			} 

		} else
		{
		return 1;
		}
		
	}

*/
}

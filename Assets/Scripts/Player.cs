using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Characters
{
	[SelectionBase]
	public class Player : MonoBehaviour
	{
		//[Header("Capsule Collider")]
		//[SerializeField] Vector3 colliderCenter = new Vector3(0, 0, 0);
		//[SerializeField] float colliderRadius = 0.5f;
		//[SerializeField] float colliderHeight = 2.0f;

		//[Header("Nav Mesh Agent")]
		//[SerializeField] float navMeshAgentSteeringSpeed = 1.0f;
		//[SerializeField] float navMeshAgentStoppingDistance = 1.3f;

		[Header("Stats")]
		[SerializeField] private float hitChance = 0.96f;
		[SerializeField] private float critChance = 0.15f;
		[SerializeField] private float critMultiplier = 2.0f;
		[SerializeField] private int level = 1;
		[SerializeField] private float resistanceToSpells = 90.0f;
		[SerializeField] private float penetration = 5.0f;
		[SerializeField] private float blockChance = 0.05f; //dodge/Parry?
		[SerializeField] private float inteligence = 25f;
		[SerializeField] private float agility = 5f;
		[SerializeField] private float strength = 10f;
		[SerializeField] private float stamina = 22f;

		public float HitChance { get { return hitChance; } }
		public float CritChance { get { return critChance; } }
		public float CritMultiplier { get { return critMultiplier; } }
		public int Level { get { return level; } }
		public float ResistanceToSpells { get { return resistanceToSpells; } }
		public float Penetration { get { return penetration; } }
		public float BlockChance { get { return blockChance; } }
		public float Inteligence { get { return inteligence; } }
		public float Agility { get { return agility; } }
		public float Strength { get { return strength; } }
		public float Stamina { get { return stamina; } }

		//NavMeshAgent navMeshAgent;
		Animator animator;
		Rigidbody ridigBody;

		void Awake()
		{
			AddRequiredComponents();
		}

		// Use this for initialization
		void Start () {
		
		}
	
		// Update is called once per frame
		void Update () {
		
		}

		private void AddRequiredComponents()
		{
			//var capsuleCollider = gameObject.AddComponent<CapsuleCollider>();
			//capsuleCollider.center = colliderCenter;
			//capsuleCollider.radius = colliderRadius;
			//capsuleCollider.height = colliderHeight;

			ridigBody = gameObject.AddComponent<Rigidbody>();
			ridigBody.constraints = RigidbodyConstraints.FreezeRotation;
			ridigBody.mass = 80;

			//navMeshAgent = gameObject.AddComponent<NavMeshAgent>();
			//navMeshAgent.speed = navMeshAgentSteeringSpeed;
			//navMeshAgent.stoppingDistance = navMeshAgentStoppingDistance;
			//navMeshAgent.autoBraking = false;
			//navMeshAgent.updateRotation = false;
			//navMeshAgent.updatePosition = true;
		}
	}
}
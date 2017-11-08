﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyUI : MonoBehaviour
{


	[Tooltip("The UI canvas prefab")]
	[SerializeField] GameObject enemyCanvasPrefab = null;

	Camera cameraToLookAt;

	// Use this for initialization 
	void Start()
	{
		cameraToLookAt = Camera.main;
		Instantiate(enemyCanvasPrefab, transform.position, Quaternion.identity, transform);
	}

	// Update is called once per frame 
	void LateUpdate()
	{
		transform.LookAt(cameraToLookAt.transform);
		transform.rotation = Quaternion.LookRotation(cameraToLookAt.transform.forward);
	}
}



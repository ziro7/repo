using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent] //parameter til at stoppe flere af samme type script.
public class Oscillator : MonoBehaviour
{

	[SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
	[SerializeField] float period = 2f;

	float movementFactor; //0 for not moved, 1 for fully moved
	Vector3 startingPos;

	void Start()
	{

		startingPos = transform.position;
	}

	void Update()
	{

		//todo protect against divede by 0 (period = 0)
		float cycles = Time.time / period; //grows continuersly from 0

		const float tau = Mathf.PI * 2f; //about 6,28
		float rawSinWave = Mathf.Sin(cycles * tau); //goes from -1 to +1)

		movementFactor = rawSinWave / 2f + 0.5f;
		Vector3 offset = movementFactor * movementVector;
		transform.position = startingPos + offset;
	}
}

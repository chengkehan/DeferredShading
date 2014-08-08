﻿using UnityEngine;
using System.Collections;

public class SmallCube : MonoBehaviour
{
	static CSParticle[] particles_to_add;

	void Start()
	{
		GetComponent<TSEntity>().cbDestroyed = () => { CBDestroy(); };
	}

	static float R(float r=1.0f)
	{
		return Random.Range(-r, r);
	}

	void CBDestroy()
	{
		TestShooter ts = TestShooter.instance;
		if (!ts) { return; }

		Vector3 pos = transform.position;

		if (particles_to_add == null)
		{
			particles_to_add = new CSParticle[512];
		}
		for (int i = 0; i < particles_to_add.Length; ++i)
		{
			particles_to_add[i].position = new Vector3(pos.x + R(0.5f), pos.y + R(0.5f), pos.z + R(0.5f));
			particles_to_add[i].velocity = new Vector3(R(), R(), 0.0f) * 2.0f;
		}
		ts.fractions.AddParticles(particles_to_add);
	}
}

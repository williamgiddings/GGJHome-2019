using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour
{
	public float speed = 100f;


	void Update ()
	{
		transform.Rotate(0, 0, speed*Time.deltaTime, Space.Self);
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPatrol : MonoBehaviour {

	public GameObject[] waypoints;
	public int num = 0;
	public float minDist;
	public float speed;
	public bool rand = false;
	public bool go = true;



	void Update () 
	{
		float dist = Vector3.Distance (gameObject.transform.position, waypoints [num].transform.position);

		if (go) //if go is true
		{
			if (dist > minDist) //if AI is not at next waypoint, then moves to waypoint
			{
				Move ();
			} 
			else 
			{

				if (num == 0) 
				{
					num++;
				}

				/*if (!rand) //if rand is not selected, then follows set order of waypoints
				{
					if (num + 1 == waypoints.Length) 
					{
						num = 0;
					} 
					else 
					{
						num++;
					}
				} 
				else //if randon is selected
				{
					num = Random.Range (0, waypoints.Length); //if rand true, then select random waypoint
				}*/
			}
		}
	}

	public void Move()
	{
		gameObject.transform.LookAt(waypoints[num].transform.position);	//gameObject looks at specified waypoint
		gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime; //moves AI forward to waypoint
	}
}

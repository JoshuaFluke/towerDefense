using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int target = 0;
    public Transform exitPoint;
    public Transform[] wayPoints;
    public float navigationUpdate;

    private Transform enemy;
    private float navigationTime = 0;

    // Use this for initialization
    void Start () {
        enemy = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (wayPoints != null)
        {
            navigationTime += Time.deltaTime;
            if (navigationTime > navigationUpdate)
            {
                if (target < wayPoints.Length)
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, wayPoints[target].position, 0.8f * navigationTime);
                }
                else
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, exitPoint.position, 0.8f * navigationTime);
                }
                navigationTime = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "CheckPoint")
        {
            target += 1;
        }
        else if (other.tag == "Finish")
        {
            GameManager.instance.removeEnemyFromScreen();
            Destroy(gameObject);    
        }
    }
}

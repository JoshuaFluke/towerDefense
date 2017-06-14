using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    [SerializeField]
    private Transform exitPoint;
    [SerializeField]
    private Transform[] wayPoints;
    //used for deltaTime jumpiness
    [SerializeField]
    private float navigationUpdate;
    [SerializeField]
    private int healthPoints;
    [SerializeField] private int rewardAmt;

    private Transform enemy;
    private float navigationTime = 0;
    private Collider2D enemyCollider;
    private Animator anim;
    private int target = 0;
    private bool isDead = false;

    public bool IsDead
    {
        get
        {
            return isDead;
        }
    }



    // Use this for initialization
    void Start () {
        enemy = GetComponent<Transform>();
        enemyCollider = GetComponent<Collider2D>();
        GameManager.Instance.RegisterEnemy(this);
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (wayPoints != null && enemy !=isDead)
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
            GameManager.Instance.RoundEscaped += 1;
            GameManager.Instance.TotalEscaped += 1;
            target += 1;
        }
        else if (other.tag == "Finish")
        {
            //accessing the method from game manager via the generic "Instance" is the middle man
            GameManager.Instance.RoundEscaped += 1;
            GameManager.Instance.TotalEscaped += 1;
            GameManager.Instance.UnRegister(this); //this keyword passes in this enemy game object
            GameManager.Instance.isWaveOver();

        } else if (other.tag == "projectile")
        {
            Projectile newP = other.gameObject.GetComponent<Projectile>();
            EnemyHit(newP.AttackStrength);
            Destroy(other.gameObject);
        }
    }

    public void EnemyHit(int hitpoints)
    {
        if(healthPoints - hitpoints > 0)
        {
            healthPoints -= hitpoints;
            anim.Play("Hurt");
            GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Hit);
        } else  {
            anim.SetTrigger("didDie");
            die();
        }
        
    }

    public void die()
    {
        isDead = true;
        enemyCollider.enabled = false;
        GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Death);
        GameManager.Instance.TotalKilled += 1;
        GameManager.Instance.addMoney(rewardAmt);
        GameManager.Instance.isWaveOver();
    }


}

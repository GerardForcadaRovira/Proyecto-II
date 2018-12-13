using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour {

    #region Variables
    private Animator anim;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemy;
    public int damage;
    #endregion

    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Collider[] enemiesToDamage = Physics.OverlapSphere(attackPos.position, attackRange, whatIsEnemy);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                //enemiesToDamage[i].GetComponent<Enemy>().health -= damage;
                //Debug.Log(enemiesToDamage[i].GetComponent<Enemy>().health);
            }
            attack();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            anim.SetTrigger("CastSpell");
        }
    }

    private void attack()
    {
        anim.SetTrigger("Attack");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}

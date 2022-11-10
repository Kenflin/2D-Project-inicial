using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombatController : MonoBehaviour
{

    private Animator animator;
    public Transform attackPoint;
    private float attackRange = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Ataque");
            Attack();
        }
       
    }

    void Attack()
    {
        Debug.Log("AtaqueAnim");
        animator.SetTrigger("Attack");
        Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

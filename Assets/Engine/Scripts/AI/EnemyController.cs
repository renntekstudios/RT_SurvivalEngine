using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;
    public float MaxDistance = 10;
    public float MinDistance = 2;

    private Transform myTransform;


    //attack
    public float attackTime;
    public float coolDown;

    public GUIManager guiManager;

    void Awake()
    {
        myTransform = transform;
    }
    
    void Start()
    {
        //
        attackTime = 0;
        coolDown = 2.0f;
        //
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        guiManager = go.GetComponent<GUIManager>();

        target = go.transform;
    }

    void Update()
    {
        if (target == null)
            Destroy(gameObject);

        if ((Vector3.Distance(transform.position, target.position) < MaxDistance) && (Vector3.Distance(transform.position, target.position) > MinDistance))
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * Time.deltaTime);
        }

        if (attackTime > 0)
            attackTime -= Time.deltaTime;

        if (attackTime < 0)
            attackTime = 0;


        if (attackTime == 0)
        {
            Attack();
            attackTime = coolDown;
        }

    }

    void Attack()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);


        Vector3 dir = (target.transform.position - transform.position).normalized;
        float direction = Vector3.Dot(dir, transform.forward);


        if (distance < 2.5f)
        {
            if (direction > 0)
            {
                PlayerHealth eh = (PlayerHealth)target.GetComponent("PlayerHealth");
                eh.AddjustCurrentHealth(-10);
            }
        }
    }
}
using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {

    private float Speed = 60;

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.gameObject.name == "Ground")
            IAmOnTheGround();

        Debug.Log("On Collision Enter");
    }

    void Rotate()
    {
        transform.Rotate(Vector3.up, Speed * Time.deltaTime);
    }

    void IAmOnTheGround()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<BoxCollider>().isTrigger = true;
    }
}

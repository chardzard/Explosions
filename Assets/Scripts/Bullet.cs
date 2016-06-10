using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    Rigidbody myRigidBody;
    Vector3 target;

    public Rigidbody MyRigidBody {
        get { return myRigidBody; }
        set { myRigidBody = value; }
    }

    // Use this for initialization
    void Awake() {
        MyRigidBody = GetComponent<Rigidbody>();
        StartCoroutine(destroy());
    }

    IEnumerator destroy() {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    public void Explode() {
        
    }
}

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
    }

    // Update is called once per frame
    void Update() {

    }
}

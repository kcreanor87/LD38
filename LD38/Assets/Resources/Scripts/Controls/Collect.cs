using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour {

    public _manager manager;

    private void Start()
    {
        manager = GameObject.Find("SceneManager").GetComponent<_manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crate")
        {
            print("Crate Collected");
            manager.UpdateCrates();
            Destroy(other.transform.parent.gameObject);
        }
        else if (other.tag == "Wall")
        {
            manager.EndLevel(false);
        }
    }
}

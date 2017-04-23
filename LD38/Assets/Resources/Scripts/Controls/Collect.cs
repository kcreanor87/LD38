using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour {

    public _manager manager;
    public ParticleSystem _explosion;

    private void Start()
    {
        manager = GameObject.Find("SceneManager").GetComponent<_manager>();
        _explosion = transform.parent.FindChild("Explosion").GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crate")
        {           
            Destroy(other.transform.parent.gameObject);
            manager.UpdateCrates();
        }
        else if (other.tag == "Wall")
        {
            manager.EndLevel(false);
            _explosion.Play();
        }
        else if (other.tag == "Lock")
        {
            other.transform.GetComponentInParent<LockControl>().SwitchWalls(true);
        }
    }
}

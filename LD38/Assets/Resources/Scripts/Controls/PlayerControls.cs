using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public Transform _sphere;
    public float _speed = 2.0f;
    private int inputX;
    public _manager manager;

    // Use this for initialization
    void Start () {
        manager = GameObject.Find("SceneManager").GetComponent<_manager>();
        _sphere = GameObject.Find("World001Container").GetComponentInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (manager._inMenu) return;
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f)){
                if (hit.collider.tag == "Ground")
                {
                    var x = (Input.mousePosition.x + 1.0f);
                    if (x >= Screen.width / 2)
                    {
                        x -= (Screen.width / 2);
                        x = x / ((Screen.width) / 2);
                    }
                    else
                    {
                        x = x / ((Screen.width) / 2) - 1.0f;
                    }
                    var y = (Input.mousePosition.y + 1.0f);
                    if (y >= Screen.height / 2)
                    {
                        y -= (Screen.height / 2);
                        y = y / ((Screen.height) / 2);
                    }
                    else
                    {
                        y = y / ((Screen.height) / 2) - 1.0f;
                    }
                    x *= _speed;
                    y *= _speed;
                    _sphere.Rotate(y, x, 0, Space.World);
                    RotateTowards(hit.point);
                }                
            }
        }
	}

    void RotateTowards(Vector3 target)
    {
        Vector3 mousePos = new Vector3(target.x, target.y, 0);
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}

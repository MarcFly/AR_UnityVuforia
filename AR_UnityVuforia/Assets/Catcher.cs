using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour {

    public Manager manager;
    public GameObject particle;
    // Use this for initialization
    void Start () {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
	}

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        manager.points += 50;
        if (other.gameObject.name == manager.Fruits[manager.current_good_fruit].name)
            manager.points += 50;

        Destroy(other.gameObject);
        GameObject.Instantiate(particle);
    }
}

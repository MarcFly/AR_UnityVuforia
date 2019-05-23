using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    float last_time = 0;

    public Manager manager;
    public BoxCollider end;
	// Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        //end = gameObject.GetComponent<BoxCollider>();
    }
	
	// Update is called once per frame
	void Update () {
		if(manager.playing && (manager.timer - last_time) + (manager.points/1000) > 1)
        {
            int fruit_n = Random.Range(0, 8);
            Vector3 pos;
            pos.x =  gameObject.transform.position.x + Random.Range(-100, 100);
            pos.y = gameObject.transform.position.y + Random.Range(400, 500);
            pos.z = gameObject.transform.position.z + Random.Range(-100, 100);
            
            Instantiate(manager.Fruits[fruit_n], pos, Quaternion.identity);

            last_time = manager.timer;
        }        
	}

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}

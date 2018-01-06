using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	void Update () {
        Destroy(this.gameObject, 10f);
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            manager.@object.PlayerDied();
        }
    }
}

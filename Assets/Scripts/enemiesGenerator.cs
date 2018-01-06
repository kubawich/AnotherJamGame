using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesGenerator : MonoBehaviour
{
    [Range(.1f, 4f)]
    public float time = .5f;
	public GameObject enemy;

    public void Start()
    {
        StartCoroutine(generate());
    }

    IEnumerator generate()
    {
        while (true)
        {
			Instantiate (enemy, transform.position, Quaternion.Euler(0,0,Random.Range(0,90)),this.transform);
            Instantiate(enemy, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 90)), this.transform);

            yield return new WaitForSeconds(time);
        }
    }
}

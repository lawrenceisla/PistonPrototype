using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float delay = 2.0f;

    public void CallShake()
    {
        StartCoroutine(Shake(0.4f,0.7f));
    }

    public IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 originalPos = transform.position;
        
        float elapsed = 0.0f;
        while (elapsed < delay){
            elapsed += Time.deltaTime;

            yield return null;
        }


        while (elapsed < duration + delay)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPos;
        GameObject.Find("MainCharacter").GetComponent<MC>().DeathMessage();
    }
}
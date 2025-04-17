using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    public Vector3 translationSpeed;
    public float limitX;
    public GameObject hayBalePrefab;
    public Transform haySpawnpoint;
    public float shootInterval;
    private float shootTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow) && transform.position.x < limitX)
        {
            transform.Translate(translationSpeed * Time.deltaTime);         
        }

        if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -limitX)
        {
                transform.Translate(-translationSpeed * Time.deltaTime);
        }

        UpdateShooting();
    }

    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
            shootTimer = shootInterval;
            ShootHay();
        }
    }

    private void ShootHay()
    {
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
        SoundManager.Instance.PlayShootClip();
    }

}

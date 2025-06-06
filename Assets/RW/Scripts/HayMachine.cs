using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    public Vector3 translationSpeed;
    public float maxSpeed; // Maximum speed
    public float increaseRate; // Speed increase
    public float limitX;
    public GameObject hayBalePrefab;
    public Transform haySpawnpoint;
    public float shootInterval;
    public float minShootInterval; // Minimum time between shots
    public float decreaseRate; // Time decrease for each shot
    private float shootTimer;

    public Transform modelParent;
    public GameObject blueModelPrefab;
    public GameObject yellowModelPrefab;
    public GameObject redModelPrefab;


    // Start is called before the first frame update
    void Start()
    {
        LoadModel();
    }

    private void LoadModel()
    {
        Destroy(modelParent.GetChild(0).gameObject);

        switch (GameSettings.hayMachineColor)
        {
            case HayMachineColor.Blue:
                Instantiate(blueModelPrefab, modelParent);
                break;

            case HayMachineColor.Yellow:
                Instantiate(yellowModelPrefab, modelParent);
                break;

            case HayMachineColor.Red:
                Instantiate(redModelPrefab, modelParent);
                break;
        }
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
            if (translationSpeed.x < maxSpeed) // Translation speed increases
            {
                translationSpeed.x += increaseRate;
            }
            if (shootInterval > minShootInterval) // Time interval decreases
            {
                shootInterval -= decreaseRate;
            }
        }
    }

    private void ShootHay()
    {
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
        SoundManager.Instance.PlayShootClip();
    }

}

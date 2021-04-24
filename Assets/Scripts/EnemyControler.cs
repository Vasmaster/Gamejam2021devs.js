using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    public GameObject frontEnemy;
    [SerializeField] private GameObject sideEnemy;

    [Header("Enemy statistic")]
    [SerializeField] private float maxSize;
    [SerializeField] private float minSize;
    [SerializeField] private float fallSpeed;
    [SerializeField] private float growSpeed;

    void Start()
    {
        frontEnemy.transform.localScale = new Vector3(minSize,minSize);
        sideEnemy.SetActive(false);
    }

    private void Update()
    {
        if (frontEnemy.transform.localScale.x < maxSize) frontEnemy.transform.localScale += new Vector3(growSpeed, growSpeed);
        if(frontEnemy.transform.localScale.x > maxSize )
        {
            sideEnemy.SetActive(true);
            frontEnemy.SetActive(false);
            sideEnemy.transform.Translate(new Vector3(0,-fallSpeed));
            var hit = Physics2D.BoxCast(sideEnemy.transform.position, Vector3.one/5, 0, Vector3.down);
            if(hit)
            {
                if (hit.transform.CompareTag("Shredder")) Destroy(gameObject);
                if (hit.transform.CompareTag("Player"))
                    Debug.Log("Hit");
            }
        }
    }

    [ContextMenu("Reset Size")]
    public void RestartSize()
    {
        frontEnemy.transform.localScale = new Vector3(minSize, minSize);
    }

}

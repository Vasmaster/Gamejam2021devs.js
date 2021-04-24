using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform mirrorFront;
    [SerializeField] private Transform mirrorSide;
    [SerializeField] private int tickSpawnRate = 10;

    private const float DISTANT_FROM_CENTER_TO_SPRITE = 4.3f;

    private BoxCollider2D _mirrorCollider;
    private float _minXPos;
    private float _maxXPos;
    private float _minYPos;
    private float _maxYPos;

    void Start()
    {
        _mirrorCollider = mirrorFront.GetComponent<BoxCollider2D>();
        _minXPos = mirrorFront.position.x - (_mirrorCollider.offset.x + _mirrorCollider.size.x/2) * mirrorFront.localScale.x - DISTANT_FROM_CENTER_TO_SPRITE;
        _maxXPos = mirrorFront.position.x + (_mirrorCollider.offset.x + _mirrorCollider.size.x / 2) * mirrorFront.localScale.x - DISTANT_FROM_CENTER_TO_SPRITE;
        _minYPos = mirrorFront.position.y - (_mirrorCollider.offset.y + _mirrorCollider.size.y/2) * mirrorFront.localScale.y;
        _maxYPos = mirrorFront.position.y + (_mirrorCollider.offset.y + _mirrorCollider.size.y/2) * mirrorFront.localScale.y;
        TimeTickSystem.Create();
        TimeTickSystem.onTick += SpawnOnTick;
    }

    private void SpawnOnTick(object sender, TimeTickSystem.onTickEventArgs e)
    {
        if (e.tick % tickSpawnRate == 0) Spawn();
    }

    [ContextMenu("Spawn Enemy")]
    public void Spawn()
    {
        var randomXPos = Random.Range(_minXPos, _maxXPos);
        var randomYPos = Random.Range(_minYPos, _maxYPos);

        GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(randomXPos, mirrorSide.position.y), Quaternion.identity);
        GameObject newEnemyFront = newEnemy.transform.GetComponent<EnemyControler>().frontEnemy;
        newEnemyFront.transform.position = new Vector3(newEnemyFront.transform.position.x, randomYPos, -1);
    }
}

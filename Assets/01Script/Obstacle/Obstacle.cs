using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour, IScroll
{
    [SerializeField] private float scrollSpeed;
    [SerializeField] private float flyForce;

    private ScrollManager scrollManager;
    private PlayerController playerController;
    private Vector3 flyDir = new Vector3(-1.0f, 1.0f, 0.0f);
    private Rigidbody rig;
    private float returnZ = -200.0f;

    private int damage = 1;
    private ObjectType obstacleType;

    public ObjectType ObstacleType
    {
        get => obstacleType;
        set => obstacleType = value;
    }
    private void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        obj.TryGetComponent<PlayerController>(out playerController);

        gameObject.TryGetComponent<Rigidbody>(out rig);
        scrollSpeed = 0.0f;
        flyForce = 7.0f;

        StartCoroutine(GetScrollManager());
        SetObstacleType();
    }
    private IEnumerator GetScrollManager()
    {
        while (scrollManager == null)
        {
            scrollManager = FindObjectOfType<ScrollManager>();
            yield return null;
        }

        scrollManager.AddScrollObject(this);
    }
    private void OnEnable()
    {
        if (scrollManager != null)
        {
            scrollManager.AddScrollObject(this);
        }
    }
    private void OnDisable()
    {
        if (scrollManager != null)
        {
            scrollManager.RemoveScrollObject(this);
        }
    }
    private void Update()
    {
        // Scroll();
        if (transform.position.z < returnZ)
        {
            ReturnObject();
        }
    }
    // interface
    public void Scroll()
    {
        transform.position += Vector3.back * (scrollSpeed * Time.deltaTime);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HitBox"))
        {
            playerController.TakeDamage(damage);
            rig.AddForce(flyDir * flyForce, ForceMode.Impulse);
            StartCoroutine(ReturnObstacle());
        }
        if (other.gameObject.CompareTag("Item"))
        {
            rig.AddForce(flyDir * flyForce, ForceMode.Impulse);
            StartCoroutine(ReturnObstacle());
        }
    }
    public IEnumerator ReturnObstacle()
    {
        yield return new WaitForSeconds(1.0f);
        ReturnObject();
    }
    public void SetScrollSpeed(float newSpeed)
    {
        scrollSpeed = newSpeed;
    }
    public void ReturnObject()
    {
        SpawnObjectManager.instance.ReturnObjectToPool(gameObject, (int)obstacleType);
    }
    public abstract void SetObstacleType();
}

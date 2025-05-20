using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform ballSpawnPosition;
    [SerializeField] private GameObject ballPrefabs;

    [SerializeField] private ParticleSystem runParticle;
    [SerializeField] private ParticleSystem healParticle;
    [SerializeField] private ParticleSystem invincibleParticle;

    private Renderer[] playerRenderers;
    private Animator animator; 
    private float forwardSpeed = 20.0f;
    private Rigidbody rig;
    private Vector3 targetPosition;
    private float[] lanes = { -3.5f, 0, 3.5f };
    private int currentLane = 1;

    private Vector2 touchStartPos;
    private bool isMove = false;
    private bool isDrag = false;
    private bool isJump = false;
    private bool isMoveOnce = false;
    private bool isInvincible = false;

    private bool isStop = false;
    private int currentHP;
    private int maxHP = 3;
    private bool isInit = false;
    private bool isGameStart = false;

    private bool isTutorial;

    public delegate void ChangeHP(int hp);
    public event ChangeHP OnChangeHP;

    public delegate void GameOver();
    public event GameOver OnGameOver;
    public int CurrentHP
    {
        get => currentHP;
        set
        {
            currentHP = value;
            OnChangeHP?.Invoke(currentHP);
        }
    }
    private void Awake()
    {
        TryGetComponent<Rigidbody>(out rig);
        TryGetComponent<Animator>(out animator);
        playerRenderers = GetComponentsInChildren<Renderer>();
        CurrentHP = maxHP;
        moveSpeed = 12.0f;
        jumpForce = 25.0f;
    }
    private void Update()
    {
        if (isGameStart)
        {
            transform.position += Vector3.forward * (forwardSpeed * Time.deltaTime);
            animator.SetBool("Start", true);
        }
        if (isInit && !isStop)
        {
            MoveSide();
            Jump();
            HandleTouchInput();
        } 
    }
    public void InitPlayer()
    {
        CurrentHP = maxHP;
        Debug.Log("intialize");
        GameStart();
    }
    private void MoveSide()
    {
        if (Input.GetMouseButtonDown(0) && !isMove)
        {
            touchStartPos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0) && isDrag)
        {
            Vector3 touchEndPos = Input.mousePosition;

            float deltaX = touchEndPos.x - touchStartPos.x;

            if (Mathf.Abs(deltaX) > Screen.width * 0.1f && !isMove)
            {
                if (deltaX > 0 && currentLane < 2)
                {
                    // if player is jumping, can move once
                    if (!isJump || (isJump && !isMoveOnce))
                    { 
                        currentLane++;
                        if (isJump)
                            isMoveOnce = true;
                    }
                }
                else if (deltaX < 0 && currentLane > 0)
                {
                    if(!isJump || (isJump && !isMoveOnce))
                    {
                        currentLane--;
                        if (isJump)
                            isMoveOnce = true;
                    }
                }

                isDrag = false;
                isMove = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDrag = false;
        }


        targetPosition = new Vector3(lanes[currentLane], transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, (moveSpeed * Time.deltaTime));

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMove = false;
        }
    }
    public void Jump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStartPos = Input.mousePosition;
            isDrag = true;
        }

        if (Input.GetMouseButton(0) && isDrag)
        {
            Vector3 touchEndPos = Input.mousePosition;

            float deltaY = touchEndPos.y - touchStartPos.y;

            if (Mathf.Abs(deltaY) > Screen.height * 0.1f)
            {
                if (!isJump)
                {
                    // animation test
                    animator.SetTrigger("Jump");
                    
                    rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    isJump = true;

                    runParticle.Stop();
                }

                isDrag = false;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDrag = false;
        }
    }
    // touch
    private void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
                isDrag = true;
            }
            else if ((touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) && isDrag)
            {
                Vector2 touchEndPos = touch.position;
                float deltaX = touchEndPos.x - touchStartPos.x;
                float deltaY = touchEndPos.y - touchStartPos.y;

                if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
                {
                    if (Mathf.Abs(deltaX) > Screen.width * 0.1f && !isMove)
                    {
                        if (deltaX > 0 && currentLane < 2)
                        {
                            if (!isJump || (isJump && !isMoveOnce))
                            {
                                currentLane++;
                                if (isJump) isMoveOnce = true;
                            }
                        }
                        else if (deltaX < 0 && currentLane > 0)
                        {
                            if (!isJump || (isJump && !isMoveOnce))
                            {
                                currentLane--;
                                if (isJump) isMoveOnce = true;
                            }
                        }
                        isMove = true;
                        isDrag = false;
                    }
                }
                else
                {
                    if (deltaY > Screen.height * 0.1f && !isJump)
                    {
                        animator.SetTrigger("Jump");
                        rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                        isJump = true;
                        isDrag = false;
                    }
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isDrag = false;
            }
        }
    }
    private void GameStart()
    {
        isGameStart = true;
        StartCoroutine(SetInit());
    }
    private IEnumerator SetInit()
    {
        yield return new WaitForSeconds(3.0f);
        isGameStart = false;
        isInit = true;
        isStop = false;
        transform.position = new Vector3(0.0f, 2.0f, 0.0f);
        runParticle.Play();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && isInit)
        {
            animator.SetTrigger("Land");
            isJump = false;
            isMoveOnce = false;
            runParticle.Play();
        }
    }
    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            isInvincible = true;

            StartCoroutine(PlayerDamaged());
            CurrentHP -= damage;
            if (CurrentHP <= 0)
            {
                // game over
                OnGameOver?.Invoke();
                isStop = true;
                runParticle.Stop();
            }
        }
    }
    private IEnumerator PlayerDamaged()
    {
        StartCoroutine(BlinkPlayer());
        yield return new WaitForSeconds(2.0f);
        isInvincible = false;
        StopCoroutine(BlinkPlayer());
        foreach (Renderer renderer in playerRenderers)
        {
            renderer.enabled = true;
        }
    }
    private IEnumerator BlinkPlayer()
    {
        while (isInvincible)
        {
            foreach (Renderer renderer in playerRenderers)
            {
                renderer.enabled = false;
            }
            yield return new WaitForSeconds(0.1f);
            foreach (Renderer renderer in playerRenderers)
            {
                renderer.enabled = true;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void SetInvincible()
    {
        StartCoroutine(Invincible());
    }
    private IEnumerator Invincible()
    {
        isInvincible = true;
        invincibleParticle.Play();
        yield return new WaitForSeconds(3.0f);
        isInvincible = false;
        invincibleParticle.Stop();
    }
    public void RecoverHP()
    {
        Debug.Log("힐");
        healParticle.Play();
        CurrentHP++;
        if (CurrentHP >= 3)
        {
            CurrentHP = 3;
        }
    }
    public void ShootBall()
    {
        StartCoroutine(Ball());
    }
    private IEnumerator Ball()
    {
        float duration = 3.0f;

        GameObject ballObject = Instantiate(ballPrefabs, ballSpawnPosition.position, Quaternion.identity);
        Rigidbody ballRigidBody = ballObject.GetComponent<Rigidbody>();
        ballRigidBody.velocity = Vector3.forward * 20.0f;
        float timer = 0.0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        Destroy(ballObject);
    }
}

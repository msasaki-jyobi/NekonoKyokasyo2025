using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigid2D;
    private float _jumpForce = 600.0f;
    private float _walkForce = 30.0f;
    private float _maxWalkSpeed = 2.0f;

    public Sprite[] WalkSprites;
    public Sprite JumpSprite;
    private float _time = 0;
    int idx = 0;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        Application.targetFrameRate = 60;
        _rigid2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _rigid2D.AddForce(transform.up * _jumpForce);

        // 左右に働く力が maxWalkSpeed未満なら
        if (_rigid2D.linearVelocityX < _maxWalkSpeed)
            _rigid2D.AddForce(transform.right * _walkForce); // 右に移動

        if (_rigid2D.linearVelocityY != 0) // 空中にいる間（上下に働く重力が0じゃない）
        {
            _spriteRenderer.sprite = JumpSprite;
        }
        else
        {
            _time += Time.deltaTime;
            if (_time > 0.1f)
            {
                _time = 0;
                _spriteRenderer.sprite = WalkSprites[idx];
                idx = 1 - idx;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 触れたオブジェクトの名前を出力
        Debug.Log($"触れました：{collision.gameObject.name}");
        SceneManager.LoadScene("ClearScene"); // ClearSceneに遷移する

        var pos = transform.position; // ワールドにおける座標取得
        var localPos = transform.localPosition; // ローカルにおける座標取得

    }
}

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigid2D;
    private float _jumpForce = 600.0f;
    private float _walkForce = 30.0f;
    private float _maxWalkSpeed = 2.0f;

    public Sprite[] WalkSprites;
    private float _time = 0;
    int idx = 0;
    SpriteRenderer _spriteRenderer;

    void Start()
    {
        Application.targetFrameRate = 60;
        _rigid2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            _rigid2D.AddForce(transform.up * _jumpForce);

        // ç∂âEÇ…ì≠Ç≠óÕÇ™ maxWalkSpeedñ¢ñûÇ»ÇÁ
        if (_rigid2D.linearVelocityX < _maxWalkSpeed)
            _rigid2D.AddForce(transform.right * _walkForce); // âEÇ…à⁄ìÆ

        _time += Time.deltaTime;
        if(_time > 0.1f)
        {
            _time = 0;
            _spriteRenderer.sprite = WalkSprites[idx];
            idx = 1 - idx;
        }
    }
}

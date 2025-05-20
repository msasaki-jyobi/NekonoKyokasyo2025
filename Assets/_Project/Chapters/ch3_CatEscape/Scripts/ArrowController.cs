using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("player_0");
    }

    // Update is called once per frame
    void Update()
    {
        // 下に移動する
        transform.Translate(0, -0.1f, 0);

        // Y座標が-5.0未満になったら
        if(transform.position.y < -5.0f)
        {
            // Destroy(破棄したいオブジェクト）
            // gameObject = 自分自身
            Destroy(gameObject);
        }

        // 当たり判定
        Vector2 p1 = transform.position; // 矢の中心座標
        Vector2 p2 = player.transform.position; // プレイヤーの中心座標
        Vector2 dir = p1 - p2; // 差分を取得
        float d = dir.magnitude; // 距離を取得

        float r1 = 0.5f; // 矢の半径
        float r2 = 1.0f; // プレイヤーの半径

        if(d < r1 + r2) // 距離dが矢とプレイヤーの半径未満なら
        {
            Debug.Log($"座標差分:{dir}, 矢と猫の距離(d):{d} d < r1+r2:{d} < {r1+r2}");
            Destroy(gameObject);
        }
    }
}

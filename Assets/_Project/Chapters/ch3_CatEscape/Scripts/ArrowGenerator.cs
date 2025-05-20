using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _arrowPrefab;
    private float _span = 1.0f;
    private float _delta = 0;

    private void Start()
    {
        
    }

    private void Update()
    {
        // 現実で経過している時間を加算
        _delta += Time.deltaTime;

        if(_delta > _span) // 経過時間が_spanを超えたら
        {
            _delta = 0; //　経過時間をリセット
            GameObject go = Instantiate(_arrowPrefab); // 矢を生成
            int px = Random.Range(-6, 7); // -6 以上 7 未満の数値を取得
            go.transform.position = new Vector3(px, 7, 0); // 矢を画面上部に移動(X座標はpx)
        }
    }
}

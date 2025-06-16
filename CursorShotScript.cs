using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CursorShotScript : MonoBehaviour
{
	public GameObject Combo;
	public GameObject Runkobj;
	public AudioClip sound1;
	public AudioClip Destroy_sound;
	public GameObject particleObject;
	AudioSource audioSource;

	int timetodestroy = 1;	// 消えるまでの時間
	int D_nutMode = 0;      // 0:穴無し 1:真ん中穴 2:LU左上 3:LD左下 4:RU右上 5:RD右下
	RaycastHit hit;			//当たった判定はここに置いとく。（複数の関数にて使うためUpdate関数からお引っ越し）

	//　カーソルに使用するテクスチャ
	[SerializeField] GameObject CursorImage;
	[SerializeField] Material Donut_CentralMaterial;		//真ん中
	[SerializeField] Material Dnut_LUMaterial;		//左上
	[SerializeField] Material Dnut_LDMaterial;		//左下
	[SerializeField] Material Dnut_RUMaterial;		//右上
	[SerializeField] Material Dnut_RDMaterial;      //右下
	private Transform nowtex;

	[SerializeField]
	float speed = 400;
	float seconds;

	RectTransform rect;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		//escで強制終了
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}

			//　カーソルUIを動かす（左右：「X-Axis」	上下：「Y-Axis」）

			Vector2 input = Gamepad.current.leftStick.ReadValue();  // Gamepad.current.leftStick.ReadValue()…値が入っているReadValueが出したVector2の値をinputに代入。

        //if (input.magnitude == 0)			//入力しなかったら23行に戻って下のカーソル移動処理をさせない（※静止状態で射撃しても判定出ない不具合アリ）
        //{
			//return;
        //}
		if(Gamepad.current.leftTrigger.ReadValue()>0)
        {
			speed = 80;
        }
		else
        {
			speed = 900;
        }
		Vector3 pos = CursorImage.transform.position;           //CursorImage.transform.positionをVector3の形でposに代入
		pos.x += input.x * speed * Time.deltaTime;	//input×速さ×PCスピードみたいなの（PCによって0.001とか0.01とか値が変わるから、これを掛ければPC差が生まれない）
		pos.y += input.y * speed * Time.deltaTime;	//上のx(横)バージョンとは違いこっちはy(高さ)バージョン

		CursorImage.transform.position = pos;       //CursorImage.transform.positionにposの値を代入




		//　Yボタンで撃つ
		if (Gamepad.current.buttonNorth.wasPressedThisFrame) 
		{
			Shot();
			Debug.Log("shot");
		}
        
        //　RTボタンで撃つ
        if (Gamepad.current.rightTrigger.wasPressedThisFrame)
		{
			Shot();
			Debug.Log("RT_shot");
		}

		if (Gamepad.current.buttonSouth.isPressed)
        {
			Debug.Log("デバッグ用リザルト飛び");
			SceneManager.LoadScene("result");        //※　リザルトシーンへ
		}
	}
	Ray a;
	//　敵を撃つ
	void Shot()
	{
		audioSource.PlayOneShot(sound1);
		Ray ray = Camera.main.ScreenPointToRay(CursorImage.transform.position);
		a = ray;

		if (Physics.Raycast(ray, out hit, 150f, LayerMask.GetMask("Dnut")))
		{
			D_nutMode = 1;
			BlockAndDestroy();
		}
        else
        {
			//穴以外版（ミスショット）
			if (Physics.Raycast(ray, out hit, 150f, LayerMask.GetMask("MissLU")))	//	左上
			{
				D_nutMode = 2;
				BlockAndDestroy();
			}

			if (Physics.Raycast(ray, out hit, 150f, LayerMask.GetMask("MissRU")))	//　右上
			{
				D_nutMode = 4;
				BlockAndDestroy();
			}

			if (Physics.Raycast(ray, out hit, 150f, LayerMask.GetMask("MissLD")))	//　左下
			{
				D_nutMode = 3;
				BlockAndDestroy();
			}

			if (Physics.Raycast(ray, out hit, 150f, LayerMask.GetMask("MissRD")))	//　右下
			{
				D_nutMode = 5;
				BlockAndDestroy();
			}
		}
	}

	void BlockAndDestroy()
    {

		GameObject parent = hit.collider.gameObject.transform.root.gameObject;  //　命中したオブジェクトの一番上の親取得（↓に使う）
		Collider[] childColliders = parent.GetComponentsInChildren<Collider>(); //　↑で取得した親オブジェクトに連なる全ての子オブジェクトのコライダーをOFFにする

		foreach (Collider c in childColliders)
		{
			c.enabled = false;
		}                                                                       //＿＿＿＿ここまで＿＿＿＿
																				//Debug.Log("デストロイ関数成功＝＝＝＝＝＝＝＝＝");
		if(D_nutMode==1)    //真ん中判定時の反応
		{
			Runkobj.GetComponent<RankScript>().PointCount();    //	ランク毎破壊数記録関数へ飛ぶ。
			Combo.GetComponent<Combo_Script>().PlusOne();       //　コンボ加算関数へ飛ぶ。
			Instantiate(particleObject, hit.collider.gameObject.transform.root.position, Quaternion.identity);		//エフェクト発生
			hit.collider.gameObject.transform.root.GetComponent<Renderer>().material = Donut_CentralMaterial;   //GetComponentの前に"指定オブジェクト."可能
		}
		if(D_nutMode==2)
        {
			hit.collider.gameObject.transform.root.GetComponent<Renderer>().material = Dnut_LUMaterial;
		}
		if(D_nutMode==3)
        {
			hit.collider.gameObject.transform.root.GetComponent<Renderer>().material = Dnut_LDMaterial;
		}
		if(D_nutMode==4)
		{
			hit.collider.gameObject.transform.root.GetComponent<Renderer>().material = Dnut_RUMaterial;
		}
		if(D_nutMode==5)
        {
			hit.collider.gameObject.transform.root.GetComponent<Renderer>().material = Dnut_RDMaterial;
		}

		Destroy(hit.collider.gameObject.transform.root.gameObject,timetodestroy);
		Invoke("DestroySound", timetodestroy);
		D_nutMode = 0;  //デストロイ後に状態を0に
	}

	void DestroySound()
	{
		audioSource.PlayOneShot(Destroy_sound);
	}

    private void OnDrawGizmos()
    {
		Gizmos.DrawRay(a);
    }
}

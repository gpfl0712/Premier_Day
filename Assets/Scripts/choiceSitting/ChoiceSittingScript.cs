using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceSittingScript : MonoBehaviour
{
    public GameObject friendDetailPrefab; // ?꾨━??
    private GameObject _object; // ?앹꽦???ㅻ툕?앺듃
    public Transform parent; // 遺紐??몃옖?ㅽ뤌
    public Sprite characterSprite; // ?쒖떆??罹먮┃???ㅽ봽?쇱씠??
    public Image imageComponent; // ?먮뵒?곗뿉???좊떦???대?吏 而댄룷?뚰듃

    // Start is called before the first frame update
    void Start()
    {
        // 珥덇린?붽? ?꾩슂?섎㈃ ?ш린??泥섎━
    }

    // Update is called once per frame
    void Update()
    {
        // 留??꾨젅???낅뜲?댄듃媛 ?꾩슂?섎㈃ ?ш린??泥섎━
    }

    public void OnPointerEnter()
    {
        // ?꾨━?뱀쓣 ?몄뒪?댁뒪?뷀븯怨?遺紐⑤? ?ㅼ젙?⑸땲??
        _object = Instantiate(friendDetailPrefab, parent);
        parent.gameObject.SetActive(true);
        // ?먮뵒?곗뿉???좊떦???대?吏 而댄룷?뚰듃瑜??ъ슜?섏뿬 ?ㅽ봽?쇱씠?몃? ?ㅼ젙?⑸땲??
        if (imageComponent != null)
        {
            imageComponent.sprite = characterSprite;
            imageComponent.gameObject.SetActive(true); // ?대?吏 ?쒖꽦??
        }
    }

    public void OnPointerExit()
    {
        // 留덉슦?ㅺ? 踰쀬뼱?섎㈃ ?앹꽦???ㅻ툕?앺듃瑜??뚭눼?⑸땲??
        if (_object != null)
        {
            Destroy(_object);
        }

        // ?대?吏 鍮꾪솢?깊솕
        if (imageComponent != null)
        {
            imageComponent.gameObject.SetActive(false);
        }
        parent.gameObject.SetActive(false);
    }
}

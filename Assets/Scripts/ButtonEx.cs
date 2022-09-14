using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

namespace UiEx
{
    [RequireComponent(typeof(Image))]
    //[RequireComponent(typeof(Text))]
    [AddComponentMenu("UI/ExButton", 14)]
    public class ButtonEx : MonoBehaviour,IPointerClickHandler,IPointerDownHandler,IPointerUpHandler,IPointerEnterHandler,IPointerExitHandler,ISelectHandler
    {
        [Header("押した際のボタン画像")] [SerializeField] private Sprite pressedSprite=null;
        [Header("押した際に呼び出される関数")] [SerializeField] private UnityEvent onClick=null;
        
        private Sprite _defaultSprite;
        private bool isClicked=false;

        #region 準備

        private void Awake()
        {
            _defaultSprite = this.gameObject.GetComponent<Image>().sprite;
            //onClickに実行したい関数を登録する
            onClick.AddListener(TestOnClick);
        }

        #endregion

        /// <summary>
        /// オブジェクトをクリックした時に呼ばれるメソッド
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerClick(PointerEventData eventData)
        {
            //押された際に、登録された関数を実行する
            if(onClick!=null)onClick.Invoke();
            OnButtonClick();
        }

        /// <summary>
        /// オブジェクト内でポインタを押したとき時に呼ばれるメソッド
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerDown(PointerEventData eventData)
        {
            if(!isClicked)OnButtonDown();
        }

        /// <summary>
        /// オブジェクト内でポインタ放した時に呼ばれるメソッド
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerUp(PointerEventData eventData)
        {
            if(isClicked)OnButtonUp();
        }

        /// <summary>
        /// オブジェクト内にポインタを入れた時に呼ばれるメソッド
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerEnter(PointerEventData eventData)
        {
            OnButtonEnter();
        }

        /// <summary>
        /// オブジェクト内から、外にマウスを外した時に呼ばれるメソッド
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerExit(PointerEventData eventData)
        {
            OnButtonExit();
        }

        /// <summary>
        /// オブジェクト選択時に呼ばれるメソッド
        /// </summary>
        /// <param name="eventData"></param>
        public void OnSelect(BaseEventData eventData)
        {
            OnButtonSelect();
        }


        #region Buttonで実行したい共通処理

        private void OnButtonExit()
        {
            // Exit時の共通処理
            Debug.Log("Button  Exit");
        }

        private void OnButtonEnter()
        {
            // Enter時の共通処理
            Debug.Log("Button Enter");
        }

        private void OnButtonDown()
        {
            // Down時の共通処理
            if(pressedSprite!=null)this.gameObject.GetComponent<Image>().sprite = pressedSprite;
            isClicked = true;
            Debug.Log("Button Push");
        }

        private void OnButtonUp()
        {
            // Up時の共通処理
            isClicked = false;
            Debug.Log("Button Release");
        }

        private void OnButtonClick()
        {
            // Click時の共通処理
            this.gameObject.GetComponent<Image>().sprite = _defaultSprite;
            Debug.Log("Button Click");
        }
        
        /// <summary>
        /// クリック時に呼び出される関数(登録)
        /// </summary>
        public void TestOnClick()
        {
            Debug.Log("Event OnClick!");
        }

        private void OnButtonSelect()
        {
            // Select時の共通処理
            Debug.Log("This gameObject Selected!");
        }

        #endregion
    }
}

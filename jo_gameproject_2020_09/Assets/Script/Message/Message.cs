using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class Message : MonoBehaviour
{
    public bool isActive;               //Canvasの表示
    public GameObject canvas;           //使用するCanvas
    public Text messageText;            //メッセージを表示する文字
    public Text messengerText;          //メッセンジャーを表示する文字
    private string message;             //表示するメッセージ
    private string messenger;           //表示するメッセンジャー
    [SerializeField]
    private int maxTextLength = 90;     //最大文字数
    private int textLength = 0;         //現在のメッセージの文字数
    [SerializeField]
    private int maxLine = 2;            //メッセージの最大行数
    private int nowLine = 0;            //現在の行数
    [SerializeField]
    public float textSpeed = 0.05f;     //テキストスピード
    private float elapsedTime = 0f;     //経過時間
    private int nowTextNum = 0;         //現在見ている文字番号
    [SerializeField]
    //private float clickFlashTime = 0.2f;// クリックアイコンの点滅秒数
    private bool isOneMessage = false;  // 1回分のメッセージを表示したかどうか
    private bool isEndMessage = false;  // メッセージをすべて表示したかどうか
    //private string[] conversation;      // 会話
    //private int i = 0;                  // 文字列の列
    //private int stringsCount = 0;       // 文字列の総行数
    private string color_code = "";         //カラーコード
    private bool isColor = false;           //色文字かどうか
    private bool isWork = false;                    //メッセージ表示中に他のメッセージを受け付けない
    [SerializeField] Image image_left;      //画像表示左側
    [SerializeField] Image image_right;     //画像表示右側

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        messageText.text = "";                      //メッセージの初期化
        canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndMessage || message == null)
        {
            return;  //メッセージの終了もしくは設定なしでリターン
        }
        if (!isOneMessage)
        {
            if(elapsedTime >= textSpeed)                    //テキスト表示時間が経過したら
            {
                //if (message[nowTextNum] == '<')             //改行文字なら
                //{
                //    if(message[nowTextNum + 1] == '>')
                //    {
                //    Debug.Log("改行検知");
                //    messageText.text += System.Environment.NewLine;
                //    nowLine++;
                //    nowTextNum += 2;
                //    }
                //    else
                //    {
                //        messageText.text += message[nowTextNum];    //次の文字番号をセットする
                //        nowTextNum++;   //次の文字番号追加
                //        textLength++;   //次の文字数
                //        elapsedTime = 0f;   //経過時間リセット
                //    }
                //}
                if (!CodeCheck())
                {
                    messageText.text += message[nowTextNum];    //次の文字番号をセットする
                    nowTextNum++;   //次の文字番号追加
                    textLength++;   //次の文字数
                    elapsedTime = 0f;   //経過時間リセット
                }
                //else
                //{
                //messageText.text += message[nowTextNum];    //次の文字番号をセットする
                //nowTextNum++;   //次の文字番号追加
                //textLength++;   //次の文字数
                //elapsedTime = 0f;   //経過時間リセット
                //}

                if (nowTextNum >= message.Length || textLength >= maxTextLength || nowLine >= maxLine - 1)// もし、メッセージを全部表示、または行数が最大数表示されたなら、
                {
                    isColor = false;
                    color_code = "";
                    isOneMessage = true;
                }
            }
            elapsedTime += Time.deltaTime;

            //操作方法により変更有
            if (Input.GetMouseButtonDown(0))// もし、メッセージ表示中に左クリックされたら、
            {
                string allText = messageText.text;// allTextに、文字を入れる

                for (int i = nowTextNum; i < message.Length; i++)// 表示するメッセージ文繰り返す
                {
                    //allText += message[i];//allTextに表示するi番目のメッセージを足す

                    if (!CodeCheck())
                    {
                        messageText.text += message[nowTextNum];    //次の文字番号をセットする
                        nowTextNum++;   //次の文字番号追加
                        textLength++;   //次の文字数
                        elapsedTime = 0f;   //経過時間リセット
                    }
                    if (nowTextNum >= message.Length || textLength >= maxTextLength || nowLine >= maxLine - 1)// もし、メッセージがすべて表示される、または１回表示限度を超えたなら、
                    {
                       // messageText.text = allText;// messageTextをallTextにする
                        isOneMessage = true;// isOneMessageをtrueにする
                        break;// 処理を止める
                    }
                }
            }
        }

        else// クリックされていなければ、
        {
            elapsedTime += Time.deltaTime;// 経過時間に時間の経過分足す

            // クリックされたら次の文字を表示する処理
            //操作方法により変更有
            if (Input.GetMouseButtonDown(0))// もし、クリックされたら、
            {
                messageText.text = "";// メッセージを空白にする
                nowLine = 0;// 今の行を0にする
                elapsedTime = 0f;// 経過時間を0にする
                textLength = 0;// 文字数を0にする
                image_init();//立ち絵表示を初期化
                isOneMessage = false;// isOneMessageを0にする

                if (nowTextNum >= message.Length)// もし、メッセージが全部表示されていたら、
                {
                    nowTextNum = 0;// 現在の文字番号を0にする
                    isEndMessage = true;// isEndMessageをtrueにする
                    canvas.transform.GetChild(0).gameObject.SetActive(false);// キャンバスの子オブジェクトを非表示にする 
                    messengerText.text = "";        //メッセンジャーを初期化
                    //文字表示場所を初期化
                    messageText.GetComponent<Text>().alignment = TextAnchor.UpperLeft;
                    //立ち絵表示を初期化
                    image_init();
                    isWork = false;

                    //if (i == stringsCount - 1)// もし、文字列の総行数に達したら、
                    //{
                    //    isEndMessage = true;// isEndMessageをtrueにする
                    //    canvas.transform.GetChild(0).gameObject.SetActive(false);// キャンバスの子オブジェクトを非表示にする 
                    //}

                    //else// もし、文字列の総行数に達していなければ、
                    //{
                    //    i++; //iを1増やす
                    //    //SetMessage(conversation[i]);// SetMessageを実行する
                    //}
                }
            }
        }

    }

    private void SetMessage(string message)
    {
        this.message = message;
    }

    public void SetMessagePanel(MessageInfo message_info)// SetMessagePanel
    {
        if (isWork) return;
        isWork = true;
        string message = message_info.getMessage();
        messenger = message_info.getMessenger();
        messengerText.text = messenger;
        //i = 0;// iを0にする
        //stringsCount = message.Length;// 文字列の総行数をmessageの要素数にする
        //conversation = message;// coversationをmessageにする
        //表示画像の読み込み
        load_image(message_info);
        canvas.SetActive(true);// キャンバスを表示する
        SetMessage(message);// SetMessageを実行する
        canvas.transform.GetChild(0).gameObject.SetActive(true);// キャンバスの子オブジェクトを表示する
        isEndMessage = false;// isEndMessageをfalseにする
    }
    private bool CodeCheck()
    {
        //コード始まりなら
        if(message[nowTextNum] == '<')
        {
            string code = ""; 
            while(message[nowTextNum] != '>')
            {
                code += message[nowTextNum];
                nowTextNum++;
            }
            code += '>';
            nowTextNum++;
            //改行なら
            if(code == "<>")
            {
                messageText.text += System.Environment.NewLine;
                nowLine++;
            }
            //カラーコードなら
            else if (code.Contains("color"))
            {
                //カラーコード終了でなければカラーコードの更新
                if (!code.Contains("/"))
                {
                    color_code = code;
                }
                //色文字フラグの反転
                isColor = !isColor;
            }
            //文字中央寄せなら
            else if (code.Contains("center"))
            {
                messageText.GetComponent<Text>().alignment = TextAnchor.UpperCenter;
            }
            return true;
        }
        //色文字の追加
        if (isColor)
        {
            messageText.text += color_code + message[nowTextNum] + "</color>";    //次の文字番号をセットする
            nowTextNum++;   //次の文字番号追加
            textLength++;   //次の文字数
            elapsedTime = 0f;   //経過時間リセット
            return true;
        }
        return false;
    }
    private void load_image(MessageInfo message_info)
    {
        if (message_info.getImage() != null)
        {
            string image_name = message_info.getImage();
            if (image_name.Contains("right"))
            {
                image_name = image_name.Replace("right_", "");
                image_right.gameObject.SetActive(true);
                image_right.GetComponent<Image>().sprite = Resources.Load<Sprite>(image_name);
            }
            else
            {
                //right,leftが指定されていない場合も左側に立ち絵を設定
                image_name = image_name.Replace("left_", "");
                image_left.gameObject.SetActive(true);
                image_left.GetComponent<Image>().sprite = Resources.Load<Sprite>(image_name);
            }
        }
    }
    private void image_init()
    {
        image_right.gameObject.SetActive(false);
        image_right.GetComponent<Image>().sprite = Resources.Load<Sprite>(null);
        image_left.gameObject.SetActive(false);
        image_left.GetComponent<Image>().sprite = Resources.Load<Sprite>(null);
    }
}

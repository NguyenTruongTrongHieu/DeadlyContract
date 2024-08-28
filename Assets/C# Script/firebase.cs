using Firebase.Auth;
using Firebase.Extensions;

using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class firebase : MonoBehaviour
{
    public FirebaseAuth auth;
    public InputField ipEmail;
    public InputField ipPassword;
    public InputField password;
    public InputField username;
    public Button QMK;
    public Button btDangky;
    public Button btDangNhap;
    
    public Button movetore;
    public Button movetosight;
    public Text TB;
    public Text tb;
    public GameObject lognfrom;
    public GameObject registerfrom;

    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        btDangky.onClick.AddListener(dangky);
        btDangNhap.onClick.AddListener(Dangnhap);
        QMK.onClick.AddListener(DoiPass);
        movetore.onClick.AddListener(SwitchdFrom);
        movetosight.onClick.AddListener(SwitchdFrom);

    }

    public void dangky()
    {
        string email = username.text;
        string checkpassword = password.text;
        auth.CreateUserWithEmailAndPasswordAsync(email, checkpassword).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                tb.text = " Dang Ky That Bai";
                TB.text = " Dang Ky That Bai ";
                Debug.Log(" that bai");
                return;
            }
            else if (task.IsFaulted)
            {
                tb.text = (" Hay Kiem Tra Lai Gmail Hoac Mat Khau " + task.Result);

                TB.text = ("Hay Kiem Tra Lai Gmail Hoac Mat Khau");


                return;
            }
            else
            {
                tb.text = " Dang Ky Thanh Cong";
                TB.text = "Dang Ky Thanh Cong ";
                Debug.Log(" thanh cong");
                FirebaseUser user = task.Result.User;
            }
        });
    }
    public void Dangnhap()
    {
        string email = ipEmail.text;
        string password = ipPassword.text;
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                tb.text = " Dang Nhap That Bai";
                Debug.Log(" that bai");
                return;
            }
            else if (task.IsFaulted)
            {
                tb.text = " Hay Kiem Tra Lai Gmail Hoac Mat Khau ";

                return;
            }
            else if (task.IsCompleted)
            {

                tb.text = " Dang Nhap Thanh Cong";
                Debug.Log(" thanh cong");
                SceneManager.LoadScene(1);
            }
        });
    }
    public void SwitchdFrom()
    {
        tb.text = "";
        lognfrom.SetActive(!lognfrom.activeSelf);
        registerfrom.SetActive(!registerfrom.activeSelf);

    }
    public void DoiPass()
    {
        string email = ipEmail.text;
        auth.SendPasswordResetEmailAsync(email).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
               
                TB.text = " Dang Ky That Bai ";
                Debug.Log(" that bai");
                return;
            }
            else if (task.IsFaulted)
            {
                

                TB.text = ("Hay Kiem Tra Lai Gmail Hoac Mat Khau");


                return;
            }
            else
            {
                
                TB.text = "Dang Ky Thanh Cong ";
                Debug.Log(" thanh cong");
                
            }


        });
    }
}
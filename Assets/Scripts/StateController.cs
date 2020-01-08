using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vimeo.Player;

[RequireComponent(typeof(VimeoPlayer))]
public class StateController : MonoBehaviour
{

    public GameObject screen;
    public GameObject seekbar;
    public GameObject play;

    public Button button_0;
    public Button button_1;
    public Button button_2;
    public Button button_3;
    public Button button_4;
    public Button button_5;
    public Button button_home;

    private Text nav_button_0_txt;
    private Text nav_button_1_txt;
    private Text nav_button_2_txt;
    private Text nav_button_3_txt;
    private Text nav_button_4_txt;
    private Text nav_button_5_txt;
    private Text nav_button_6_txt;


    private Base selected_option;

    private bool _toggle_state = false;

    public VimeoPlayer vimeo_player;
    private VimeoPlayer vm;

    public enum appStateEnum
    {
        Home = 0,
        Takedowns,
        Submissions,
        Drills,
        Guards,
        Misc

    }

    private appStateEnum state;
    private GameObject clicked_cover;

    private IntroStrat introStrat;

    // Start is called before the first frame update
    void Start()
    {
        selected_option = new Intro(); 
        //introStrat = new IntroStrat();

        if (CheckDependencies())
        {
            Init();
            Home();
        }
        else
        {
            Debug.Log("Dependencies not met");
        }
    }

    bool CheckDependencies()
    {
        vm = vimeo_player;
        if (button_0 == null)
        {
            Debug.Log("Button 0 is null");
            return false;
        }
        return true;
    }

    void Toggle()
    {
        Toggle(!_toggle_state);
    }

    void Toggle(bool toggle)
    {
        screen.SetActive(toggle);
        seekbar.SetActive(toggle);
        play.SetActive(toggle);
        button_0.gameObject.SetActive(!toggle);
        button_1.gameObject.SetActive(!toggle);
        button_2.gameObject.SetActive(!toggle);
        button_3.gameObject.SetActive(!toggle);
        button_4.gameObject.SetActive(!toggle);
        button_5.gameObject.SetActive(!toggle);
        if (!toggle)
        {
            Screen.orientation = ScreenOrientation.Portrait;
        } else
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
        vm.LoadVideo(selected_option.VideoId);
    }

    void Init()
    {
        selected_option.SetAction(Toggle);
        nav_button_0_txt = button_0.GetComponentInChildren<Text>();
        nav_button_1_txt = button_1.GetComponentInChildren<Text>();
        nav_button_2_txt = button_2.GetComponentInChildren<Text>();
        nav_button_3_txt = button_3.GetComponentInChildren<Text>();
        nav_button_4_txt = button_4.GetComponentInChildren<Text>();
        nav_button_5_txt = button_5.GetComponentInChildren<Text>();
        nav_button_6_txt = button_home.GetComponentInChildren<Text>();
        Toggle(false);
    }

    void Home()
    {
        
        RemoveAllListeners();
        nav_button_0_txt.text = "Intro";
        button_0.onClick.AddListener(Intro);
        nav_button_1_txt.text = "Takedowns";
        button_1.onClick.AddListener(Takedowns);
        nav_button_2_txt.text = "Guards";
        button_2.onClick.AddListener(Guards);
        nav_button_3_txt.text = "Submissions";
        button_3.onClick.AddListener(Submissions);
        nav_button_4_txt.text = "Gi";
        button_4.onClick.AddListener(Intro);
        nav_button_5_txt.text = "NoGi";
        button_5.onClick.AddListener(Intro);
        nav_button_6_txt.text = "Home";
        button_home.onClick.AddListener(Home);
        Toggle(false);
    }

    void RemoveAllListeners()
    {
        button_0.onClick.RemoveAllListeners();
        button_1.onClick.RemoveAllListeners();
        button_2.onClick.RemoveAllListeners();
        button_3.onClick.RemoveAllListeners();
        button_4.onClick.RemoveAllListeners();
        button_5.onClick.RemoveAllListeners();
        button_home.onClick.RemoveAllListeners();
    }

    void Intro()
    {
        //selected_option = new Intro(); 
        selected_option.Assign(introStrat);
        RemoveAllListeners();
        selected_option.Start();
        nav_button_0_txt.text = selected_option.text_0;
        nav_button_1_txt.text = selected_option.text_1;
        nav_button_2_txt.text = selected_option.text_2;
        nav_button_3_txt.text = selected_option.text_3;
        nav_button_4_txt.text = selected_option.text_4;
        nav_button_5_txt.text = selected_option.text_5;
        button_0.onClick.AddListener(selected_option.o0);
        button_1.onClick.AddListener(selected_option.o1);
        button_2.onClick.AddListener(selected_option.o2);
        button_3.onClick.AddListener(selected_option.o3);
        button_4.onClick.AddListener(selected_option.o4);
        button_5.onClick.AddListener(selected_option.o5);
        button_home.onClick.AddListener(Home);
    } 

    void Takedowns()
    {
        selected_option.Assign(new TakeDownStrat());
    }

    void Guards()
    {
        nav_button_0_txt.text = "Intro";
        nav_button_1_txt.text = "Closed Guard";
        nav_button_2_txt.text = "Butterfly Guard";
        nav_button_3_txt.text = "Half Guard";
        nav_button_4_txt.text = "Open Guard";
        nav_button_0_txt.text = "Lapel Guards";
        nav_button_0_txt.text = "Home";
    }

    void Submissions() { }

    void Gi() { }

    void Nogi() { }


    void Playing(GameObject clicked) { }

    void ToggleCovers(bool toggle)
    {
        //cover_panel.SetActive(toggle);


    }
}

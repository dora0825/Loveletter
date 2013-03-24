using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Windows.ApplicationModel.DataTransfer;
using System.Text;

// 空白頁項目範本已記錄在 http://go.microsoft.com/fwlink/?LinkId=234238

namespace HackApp
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
     //   letter t_letter = new letter();

        ObservableCollection<string> oc_txts = new ObservableCollection<string>();
        letterViewModel letterVM = new letterViewModel();

        public MainPage()
        {
            
            this.InitializeComponent();
            oc_txts.Add("一個機緣認識你，兩次見面留意你，三番四次約會你，七上八下掛念你，九成應是喜歡你，十分肯定我愛你。百年修到遇真愛，千年成全你和我。");
            oc_txts.Add("在一年的每個日子，在一天每個小時，在一小時的每一分鐘，在一分鐘的每一秒，我都在想你。");
            oc_txts.Add("看見你的笑是世上最幸福的，看見你的淚是世上最回味的，看見你的怒是世上最難忘的，但看不到你的信息是世上最可憐的！");
            oc_txts.Add("你是一條清澈的小河，我是你身邊的河床，我永遠保護你到天涯海角、地老天荒！愛你到永遠！");
            oc_txts.Add("不愛你實在太過分,不愛你實在太對不起自己,不愛你我朋友會打我,我的目標只有一個--愛你。");
            oc_txts.Add("世有淵明，菊花無憾也；世有白石，梅花無憾也；世有嵇康，琴弦無憾也；世有餘純順，窮山惡水無憾也；吾有汝，亦無憾。");
            oc_txts.Add("這一生有了你，就算有再大的風雨，再大的不如意，我都要和你走過每一個春夏秋冬，我愛你。");
            oc_txts.Add("我要搬家了！地址：愛情市相愛路思念街530巷520號！房東：我最愛的你！房租：我一輩子的愛！日期：無限！就讓我住進你的心裡頭，到永久......");
            oc_txts.Add("喝了你釀的愛情酒，如果沒有續杯，我情願渴一輩子。");
            oc_txts.Add("我對你的思念，比全世界的水加起來還要多，我對你的愛，是好幾千萬的宇宙。");
            oc_txts.Add("在野獸的國度內，跟你漫步荒野；在生命之樹下，細數各種生物；在漫天飄雪的國度中，和你看盡魔幻景色；在時光隧道裡，跟你歷盡驚險旅程；在歐陸風情的小鎮大街上，和你挽手踱步；在滿天煙火飛舞的夜晚，與你悠閒地坐在花園裡賞茶；");


            ObservableCollection<string> oc_weather = new ObservableCollection<string>();
            oc_weather.Add("陰天");
            oc_weather.Add("晴天");
            oc_weather.Add("雨天");

            Combo.DataContext = oc_weather;
            Combo.SelectionChanged += new SelectionChangedEventHandler(Combo_SelectedChanged);
            RegisterForShare();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            r_txt.DataContext = letterVM;
            var dataTransferManager = DataTransferManager.GetForCurrentView();

        }

        private void RegisterForShare()
        {
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager,
            DataRequestedEventArgs>(this.ShareTextHandler);
        }

        private void ShareTextHandler(DataTransferManager sender, DataRequestedEventArgs e)
        {
            DataRequest request = e.Request;
            request.Data.Properties.Title = titleTxtBox.Text;
            request.Data.Properties.Description = descriptionTxtBox.Text;
            string s = string.Format(
                txt1.Text + ", " + 
                txt2a.Text + txt2b.Text +txt2c.Text + 
                txt3a.Text + txt3b.Text + txt3c.Text + 
                c_txt.Text + 
                r_txt.Text + 
                txt4a.Text + txt4b.Text + txt4c.Text);
            
            request.Data.SetText(s);

        }

        public void btnClick(object sender, RoutedEventArgs e)
        {
            r_txt.Text = "";
            Random random = new Random();
            int randomNumber = random.Next(0,oc_txts.Count);
            r_txt.Text = oc_txts[randomNumber];
        }

        void Combo_SelectedChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((string)Combo.SelectedItem == "陰天") 
            {
                c_txt.Text = "雖然妳偶爾陰晴不定，但我喜歡妳的任性~";
            }
            if ((string)Combo.SelectedItem == "晴天")
            {
                c_txt.Text = "妳的燦爛笑容是陽光，是我活力的來源!";
            }
            if ((string)Combo.SelectedItem == "雨天")
            {
                c_txt.Text = "下雨天和妳見面，總是只帶一把傘~";
            }
        
        }
    }
}

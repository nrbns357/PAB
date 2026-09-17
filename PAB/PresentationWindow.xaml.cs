using PAB.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PAB
{
    public partial class PresentationWindow : Window
    {
        private List<SlideData> slides;
        private int currentSlideIndex = 0;
        private int musicFontSize;
        private int bibleFontSize;
        private string fontName;

        public PresentationWindow(ObservableCollection<ShowingObject> list, string fontName, int musicFontSize, int bibleFontSize, string backgroundFilePath)
        {
            InitializeComponent();
            
            this.fontName = fontName;
            this.musicFontSize = musicFontSize;
            this.bibleFontSize = bibleFontSize;

            slides = new List<SlideData>();
            
            foreach (ShowingObject showingObject in list.Reverse())
            {
                bool isBible = showingObject is Bible;
                string content = showingObject.content;
                string[] contents = content.Split(new string[] { "\n\n" }, StringSplitOptions.None);
                
                slides.Add(new SlideData { Content = "", IsBible = false, Title = "" });

                for (int i = 0; i < contents.Length; i++)
                {
                    string slideContent = contents[(contents.Length - 1) - i];
                    slides.Add(new SlideData { Content = slideContent, IsBible = isBible, Title = showingObject.title });
                }
            }

            if (slides.Count > 0)
            {
                DisplaySlide(0);
            }
        }

        private void DisplaySlide(int index)
        {
            if (index < 0 || index >= slides.Count)
                return;

            currentSlideIndex = index;
            SlideData slide = slides[index];

            MusicPanel.Visibility = Visibility.Collapsed;
            BiblePanel.Visibility = Visibility.Collapsed;

            if (slide.IsBible)
            {
                DisplayBibleSlide(slide);
            }
            else
            {
                DisplayMusicSlide(slide);
            }

            SlideCounter.Text = $"{currentSlideIndex + 1}/{slides.Count}";
        }

        private void DisplayMusicSlide(SlideData slide)
        {
            MusicTitle.Text = slide.Content;
            MusicTitle.FontFamily = new System.Windows.Media.FontFamily(fontName);
            MusicTitle.FontSize = musicFontSize;
            MusicPanel.Visibility = Visibility.Visible;
        }

        private void DisplayBibleSlide(SlideData slide)
        {
            var lyricsList = slide.Content.Split('\n');
            
            BibleTitle.Text = lyricsList.Length > 0 ? lyricsList[0] : "";
            BibleTitle.FontFamily = new System.Windows.Media.FontFamily(fontName);
            BibleTitle.FontSize = bibleFontSize;

            string content = "";
            for (int index = 1; index < lyricsList.Length; index++)
            {
                content += lyricsList[index] + "\n";
            }
            
            BibleContent.Text = content;
            BibleContent.FontFamily = new System.Windows.Media.FontFamily(fontName);
            BibleContent.FontSize = bibleFontSize;
            
            BiblePanel.Visibility = Visibility.Visible;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right || e.Key == Key.Down || e.Key == Key.Space)
            {
                DisplaySlide(currentSlideIndex + 1);
                e.Handled = true;
            }
            else if (e.Key == Key.Left || e.Key == Key.Up)
            {
                DisplaySlide(currentSlideIndex - 1);
                e.Handled = true;
            }
            else if (e.Key == Key.Escape)
            {
                this.Close();
                e.Handled = true;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DisplaySlide(currentSlideIndex + 1);
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                DisplaySlide(currentSlideIndex - 1);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
    }

    public class SlideData
    {
        public string Content { get; set; }
        public bool IsBible { get; set; }
        public string Title { get; set; }
    }
}

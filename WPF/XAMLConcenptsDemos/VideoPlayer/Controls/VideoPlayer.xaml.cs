using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace VideoPlayer.Controls
{
    public partial class VideoPlayer : UserControl
    {
        public VideoPlayer()
        {
            InitializeComponent();
        }

        public string CurrentVideoElement
        {
            get
            {
                return (string)GetValue(CurrentVideoElementProperty);
            }
            set
            {
                SetValue(CurrentVideoElementProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for CurrentVideoElement.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentVideoElementProperty =
        DependencyProperty.Register("CurrentVideoElement",
                                    typeof(string),
                                    typeof(VideoPlayer),
                                    new UIPropertyMetadata("", new PropertyChangedCallback(
                                        (DependencyObject obj, DependencyPropertyChangedEventArgs args) =>
                                        {
                                            var mediaElement = obj as VideoPlayer;
                                            mediaElement.VideoElement.Source = new Uri(args.NewValue.ToString());
                                            mediaElement.Play();
                                        })));

        public IEnumerable<string> ItemsSources
        {
            get
            {
                return (IEnumerable<string>)GetValue(ItemsSourcesProperty);
            }
            set
            {
                SetValue(ItemsSourcesProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for ItemsSources.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourcesProperty =
        DependencyProperty.Register("ItemsSources", typeof(IEnumerable<string>), typeof(VideoPlayer), new UIPropertyMetadata(
        new List<string>(), new PropertyChangedCallback((DependencyObject obj, DependencyPropertyChangedEventArgs args) =>
                                                        {
                                                            var videoPlayer = obj as VideoPlayer;
                                                            videoPlayer.ListBoxPlaylist.ItemsSource = args.NewValue as List<string>;
                                                        })));

        public void Play()
        {
            this.VideoElement.Play();
        }

        private void ListBoxPlaylist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.CurrentVideoElement = ListBoxPlaylist.SelectedItem.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.ListBoxPlaylist.Visibility == Visibility.Collapsed)
            {
                this.ListBoxPlaylist.Visibility = Visibility.Visible;
            }
            else
            {
                this.ListBoxPlaylist.Visibility = Visibility.Collapsed;
            }
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && this.VideoElement.Volume < 1)
            {
                this.VideoElement.Volume += 0.01;
            }
            else if (e.Key == Key.Down && this.VideoElement.Volume > 0)
            {
                this.VideoElement.Volume -= 0.01;
            }
            else if (e.Key == Key.Right)
            {
                this.VideoElement.Position.Add(new TimeSpan(0, 0, 3));
            }
            else if (e.Key == Key.Left)
            {
                this.VideoElement.Position.Add(new TimeSpan(0, 0, -3));
            }
        }

    }
}
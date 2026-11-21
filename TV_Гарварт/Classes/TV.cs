using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace TV_Гарварт.Classes
{
    public class TV
    {
        private int activeChannel;
        private int activeVolume;
        public int ActiveVolume
        {

            get 
            {
                return activeVolume;
            }
            set
            {
                if (value < 0)
                    activeVolume = 0;
                else if (value > 100)
                    activeVolume = 100;
                else
                    activeVolume = value;
            }
        }
        public int ActiveChannel
        {
            get
            {
                return activeChannel;
            }
            set
            {
                if (activeChannel < Channels.Count - 1)
                    activeChannel = value;
                else
                    activeChannel = 0;
                if (activeChannel < 0)
                    activeChannel = Channels.Count - 1;
            }
        }
        public List<Channel> Channels = new List<Channel>();

        public TV()
        {
            activeVolume = 50;
            Channels.Add(new Channel()
            {
                Name = "Практическое задание №4 Конструкторы в ООП.mp4",
                Src = @"C:\Users\Пользователь\Desktop\TV\TV_Гарварт\TV_Гарварт\Video\Video2.mp4"
            });
            Channels.Add(new Channel()
            {
                Name = "Практическое занятие №5",
                Src = @"C:\Users\Пользователь\Desktop\TV\TV_Гарварт\TV_Гарварт\Video\Video3.mp4"
            });
            Channels.Add(new Channel()
            {
                Name = "Практическое занятие №6",
                Src = @"C:\Users\Пользователь\Desktop\TV\TV_Гарварт\TV_Гарварт\Video\Video1.mp4"
            });
            
        }

        
        public void SwapChanell(MediaElement _MediaElement, Label _NameChannel)
        {
            DoubleAnimation StartAnimation = new DoubleAnimation();
            StartAnimation.From = 1;
            StartAnimation.To = 0;
            StartAnimation.Duration = TimeSpan.FromSeconds(0.6);
            StartAnimation.Completed += delegate
            {
                _MediaElement.Source = new Uri(this.Channels[this.ActiveChannel].Src);
                _MediaElement.Play();
                DoubleAnimation EndAnimation = new DoubleAnimation();
                EndAnimation.From = 0;
                EndAnimation.To = 1;
                EndAnimation.Duration = TimeSpan.FromSeconds(0.6);
                _MediaElement.BeginAnimation(MediaElement.OpacityProperty, EndAnimation);
            };
            _MediaElement.BeginAnimation(MediaElement.OpacityProperty, StartAnimation);
            _NameChannel.Content = this.Channels[this.ActiveChannel].Name;
        }
        
        public void NextChannel(MediaElement _MediaElement, Label _NameChannel)
        {
            ActiveChannel++;
            SwapChanell(_MediaElement, _NameChannel);
        }
        public void BackChannel(MediaElement _MediaElement, Label _NameChannel)
        {
            ActiveChannel--;
            SwapChanell(_MediaElement, _NameChannel);
        }
        public void UpSound(MediaElement _MediaElement)
        {
            ActiveVolume += 10;
            _MediaElement.Volume = ActiveVolume / 100.0;
        }
        public void DownSound(MediaElement _MediaElement)
        {
            ActiveVolume -= 10;
            _MediaElement.Volume = ActiveVolume / 100.0;
        }
    }
}

using NALA.Models;
using NALA.ViewModels;
using NALA.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration.GTKSpecific;
using Xamarin.Forms.Xaml;

namespace NALA.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();
            Task.Run (GradiantAnimation);

            BindingContext = _viewModel = new ItemsViewModel();
            AnimateBackgroundImage();

        }

        private async void GradiantAnimation()
        {

            Action<double> forward = input => GradientBackground.AnchorX = input;
            Action<double> backward = input => GradientBackground.AnchorX = input;
            Action<double> up = input => GradientBackground.AnchorY = input;
            Action<double> down = input => GradientBackground.AnchorY = input;
            while (true)
            {
                GradientBackground.Animate(name: "forward", callback: forward, start: 0, end: 1, length: 100000, easing: Easing.SinIn);
                GradientBackground.Animate(name: "up", callback: up, start: 0, end: 1, length: 100000, easing: Easing.SinIn);
                await  Task.Delay(100000);
                GradientBackground.Animate(name: "down", callback: down, start: 1, end: 0, length: 100000, easing: Easing.SinIn);
                GradientBackground.Animate(name: "backward", callback: backward, start: 1, end: 0, length: 100000, easing: Easing.SinIn);
                await Task.Delay(100000);
            }
        }
        private void AnimateBackgroundImage()
        {
            AnimateBackgroundFade();
            AnimateBackgroundFade2();
            AnimateBackgroundRotate();
            AnimateBackgroundRotate2();
            AnimateBackgroundScale();
            AnimateBackgroundScale2();
        }

        private bool _isAnimate;
        private async void AnimateBackgroundFade()
        {
            var fade = 1.0;
            _isAnimate = true;
            while (_isAnimate)
            {
                await image1.FadeTo(Fade(), 10000, Easing.Linear);
            }
            double Fade()
            {
                fade = fade == 1 ? 0.1 : 1;
                return fade;
            }
        }
        private async void AnimateBackgroundFade2()
        {
            var fade = 1.0;
            _isAnimate = true;
            while (_isAnimate)
            {
                await image2.FadeTo(Fade(), 9000, Easing.Linear);
            }
            double Fade()
            {
                fade = fade == 1 ? 0.1 : 1;
                return fade;
            }
        }

        private async void AnimateBackgroundRotate()
        {
            _isAnimate = true;
            while (_isAnimate)
            {
                await image1.RotateTo(360, 110000);
                await image1.RotateTo(0, 100000);
            }
        }
        private async void AnimateBackgroundRotate2()
        {
            _isAnimate = true;
            while (_isAnimate)
            {
                await image2.RotateTo(0, 100000);
                await image2.RotateTo(360, 110000);
            }
        }
        private async void AnimateBackgroundScale()
        {
            _isAnimate = true;
            while (_isAnimate)
            {
                await image1.ScaleTo(3, 110000);
                await image1.ScaleTo(2, 100000);
            }
        }
        private async void AnimateBackgroundScale2()
        {
            _isAnimate = true;
            while (_isAnimate)
            {
                await image2.ScaleTo(3, 100000);
                await image2.ScaleTo(2, 110000);
            }
        }
    }
}
﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using MaterialDesignThemes.Wpf;
using MaterialForms.Wpf.Annotations;
using MaterialForms.Wpf.Annotations.Display;

namespace MaterialForms.Demo.Models
{
    public class Settings : INotifyPropertyChanged
    {
        private bool wiFi;
        private bool mobileData;
        private bool personalHotspot;
        private string hotspotName;
        private bool bluetooth;

        private bool facebook;
        private bool twitter;
        private bool instagram;
        private string deviceName;
        private bool sendAnonymousData;

        [Title("Settings")]

        [Heading("Connectivity", Icon = "Signal")]

        [Field(Name = "Wi-Fi", Icon = "Wifi"), Toggle]
        public bool WiFi
        {
            get => wiFi;
            set
            {
                wiFi = value;
                OnPropertyChanged();
            }
        }

        [Field(Icon = "Signal"), Toggle]
        public bool MobileData
        {
            get => mobileData;
            set
            {
                mobileData = value;
                OnPropertyChanged();
            }
        }

        [Field(Icon = "AccessPoint"), Toggle]
        public bool PersonalHotspot
        {
            get => personalHotspot;
            set
            {
                personalHotspot = value;
                OnPropertyChanged();
            }
        }

        [Field(IsVisible = "{Binding PersonalHotspot}")]
        public string HotspotName
        {
            get => hotspotName;
            set
            {
                hotspotName = value;
                OnPropertyChanged();
            }
        }

        [Field(Icon = "Bluetooth"), Toggle]
        public bool Bluetooth
        {
            get => bluetooth;
            set
            {
                bluetooth = value;
                OnPropertyChanged();
            }
        }

        [Divider]
        [Heading("Notifications", Icon = PackIconKind.MessageOutline)]

        [Field(Icon = "Twitter"), Toggle]
        public bool Twitter
        {
            get => twitter;
            set
            {
                twitter = value;
                OnPropertyChanged();
            }
        }

        [Field(Icon = "Facebook"), Toggle]
        public bool Facebook
        {
            get => facebook;
            set
            {
                facebook = value;
                OnPropertyChanged();
            }
        }

        [Field(Icon = "Instagram"), Toggle]
        public bool Instagram
        {
            get => instagram;
            set
            {
                instagram = value;
                OnPropertyChanged();
            }
        }

        [Divider]
        [Heading("Device", Icon = PackIconKind.Cellphone)]

        public string DeviceName
        {
            get => deviceName;
            set
            {
                deviceName = value;
                OnPropertyChanged();
            }
        }

        [Toggle]
        public bool SendAnonymousData
        {
            get => sendAnonymousData;
            set
            {
                sendAnonymousData = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return "Settings";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

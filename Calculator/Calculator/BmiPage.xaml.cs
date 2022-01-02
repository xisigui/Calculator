﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BmiPage : ContentPage
    {
        public BmiPage()
        {
            InitializeComponent();
            BindingContext = new BmiViewModel();
        }

        
    }
}
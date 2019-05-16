﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
namespace MVVM.VML
{
    class ViewModelLocator
    {
        public static bool GetAutoHookedUpViewModel(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoHookedUpViewModeProperty);
        }
        public static void SetAutoHookedUpViewModel(DependencyObject obj,bool value)
        {
            obj.SetValue(AutoHookedUpViewModeProperty, value);
        }
        public static readonly DependencyProperty AutoHookedUpViewModeProperty =
            DependencyProperty.RegisterAttached("AutoHookedUpViewModel",
                typeof(bool), typeof(ViewModelLocator), new
                PropertyMetadata(false, AutoHookedUpViewModelChanged));
        private static void AutoHookedUpViewModelChanged(DependencyObject d,DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(d)) return;
            var viewType = d.GetType();
            string str = viewType.FullName;
            str = str.Replace(".Views.", ".ViewModel.");
            var viewTypeName = str;
            var viewModelTypeName = viewTypeName + "Model";
            var viewModelType = Type.GetType(viewModelTypeName);
            var viewModel = Activator.CreateInstance(viewModelType);
            ((FrameworkElement)d).DataContext = viewModel;
        }
    }
}

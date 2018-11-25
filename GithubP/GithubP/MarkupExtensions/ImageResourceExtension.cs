using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GithubP.MarkupExtensions
{
    /// <summary>
    /// Because there is no built-in type converter from string to ResourceImageSource, 
    /// these types of images cannot be natively loaded by XAML. 
    /// Instead, a simple custom XAML markup extension can be written 
    /// to load images using a Resource ID specified in XAML 
    /// (source :https://docs.microsoft.com/fr-fr/xamarin/xamarin-forms/user-interface/images?tabs=windows#Embedded_Images)
    /// </summary>
    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }

            // Do your translation lookup here, using whatever method you require
            var imageSource = ImageSource.FromResource(Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);

            return imageSource;
        }
    }
}
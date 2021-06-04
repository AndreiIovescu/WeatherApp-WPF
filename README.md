# WeatherApp-WPF

## About

This project is an application written with C# and the WPF UI framework.

On the main screen, the user must enter the name of a city then choose from a dropdown list the desired city.

The weather in the selected city at that moment will be displayed on the window.

It will display the city name, the temperature, a general text about the weather and if it is raining or not.

At the bottom of the main window there is also a button that will launch a second window.

In the second window there will be displayed a 5 day forecast for the selected city.

## Code Notes

We used the Model View ViewModel (MVVM) architectural pattern that is targeted at modern UI development platforms like WPF and Silverlight.

VIEW: A View is defined in XAML and should not have any logic in the code-behind. It binds to the view-model by only using data binding.

MODEL: A Model is responsible for exposing data in a way that is easily consumable by WPF. It must implement INotifyPropertyChanged and/or INotifyCollectionChanged as appropriate.

VIEWMODEL: A ViewModel is a model for a view in the application or we can say as abstraction of the view. It exposes data relevant to the view and exposes the behaviors for the views, usually with Commands.


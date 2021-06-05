# WeatherApp-WPF
Team:
* Iovescu Andrei
* Borza Alexandru
## About

This project is an application written with C# and the WPF UI framework.

On the main screen, the user must enter the name of a city then choose from a dropdown list the desired city.

The weather in the selected city at that moment will be displayed on the window.

It will display the city name, the temperature, a general text about the weather and if it is raining or not.

At the bottom of the main window there is also a button that will launch a second window.

In the second window there will be displayed a 5 day forecast for the selected city.

## Code Notes

We used the Model View ViewModel (MVVM) architectural pattern that is targeted at modern UI development platforms like WPF.

Regarding the API, we used the ones from AccuWeather API https://developer.accuweather.com/. 

More specifically
* **5 Days of Daily Forecasts** - that is used to obtain a forecast for 5 days based on a city key. 
https://developer.accuweather.com/accuweather-forecast-api/apis/get/forecasts/v1/daily/5day/%7BlocationKey%7D
* **Current Conditions** -that is used to get the current weather conditions in a city 
https://developer.accuweather.com/accuweather-current-conditions-api/apis/get/currentconditions/v1/%7BlocationKey%7D

VIEWS: 

* **WeatherWindowView**: 

  This is the view that represents the first window, that will be displayed on application launch.
The search command will be able to execute only when the user enters a value in the textbox. We can see that in the snippet below.

  ![image](https://user-images.githubusercontent.com/61495316/120893814-d41db500-c61d-11eb-9e08-3f93eb50cf25.png)

  After we introduce a value in the textbox and hit the search button we must choose the corresponding city from a dropdown list as seen in the snippet below.
  In our example, Timisoara has only one entry, but there are cities with more than 1 entry in the data set.
  
  ![image](https://user-images.githubusercontent.com/61495316/120893917-527a5700-c61e-11eb-833b-9cded5a238da.png)
  
  After choosing the city, we can see that now we have displayed in the bottom part of the window the city, a general text about the weather, if it is raining and 
  the temperature.
  
  ![image](https://user-images.githubusercontent.com/61495316/120893893-32e32e80-c61e-11eb-92d2-ab9ac880ea1a.png)
  
* **ForecastWindow**:

  This window will launch upon pressing the see forecast button on the main window. It will display the weather forecast for the next 5 days in the selected city.
  The details shown are the date, the chance of precipitation and the temperature high and low value.
  
  ![image](https://user-images.githubusercontent.com/61495316/120894005-cae11800-c61e-11eb-927b-ad855f75ea49.png)

  
MODELS: 

VIEWMODELS: 

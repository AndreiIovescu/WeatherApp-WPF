# **WeatherApp-WPF**
Team:
* Iovescu Andrei
* Borza Alexandru
## **Note** 

The latest working version will always be found on the branch main.
## **About**

This project is an application written with C# and the WPF UI framework.

On the main screen, the user must enter the name of a city then choose from a dropdown list the desired city.

The weather in the selected city at that moment will be displayed on the window.

It will display the city name, the temperature, a general text about the weather and if it is raining or not.

At the bottom of the main window there is also a button that will launch a second window.

In the second window there will be displayed a 5 day forecast for the selected city.

## **Code Notes**

We used the Model View ViewModel (MVVM) architectural pattern that is targeted at modern UI development platforms like WPF.

Regarding the API, we used the ones from AccuWeather API https://developer.accuweather.com/. 

More specifically
* **5 Days of Daily Forecasts** - that is used to obtain a forecast for 5 days based on a city key. 
https://developer.accuweather.com/accuweather-forecast-api/apis/get/forecasts/v1/daily/5day/%7BlocationKey%7D
* **Current Conditions** -that is used to get the current weather conditions in a city 
https://developer.accuweather.com/accuweather-current-conditions-api/apis/get/currentconditions/v1/%7BlocationKey%7D

**VIEWS**: 

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

  
**MODELS**:

* **City**:

  This model is needed in order to represent in C# the information retrieved from the API regarding the city. 
  We construct this class based on the information provided by the AccuWeather documentation.
  
  ![image](https://user-images.githubusercontent.com/61495316/120894172-ba7d6d00-c61f-11eb-99d8-6d9e941c3647.png)
  
  We also create a helper class **Area**, since attributes like Country and AdministrativeArea both have properties of their own like ID and LocalizedName.
  
  ![image](https://user-images.githubusercontent.com/61495316/120894369-b0a83980-c620-11eb-8bbc-d74d5cb4998b.png)

  
* **CurrentCondition**:

  Same as with the City class, this class is used to represent in C# the information recieved from the API call about the current conditions in the selected city.
  
  ![image](https://user-images.githubusercontent.com/61495316/120894228-17792300-c620-11eb-80f8-46163dc2d133.png)
  
  CurrentConditions also needs some helper classes like **Temperature** and **Units**. 
  
  ![image](https://user-images.githubusercontent.com/61495316/120894429-fa911f80-c620-11eb-835c-819429d022b1.png)
  
* **DailyForecast**:

  The 5DaysForecast API returns an array of 5 DailyForecast objects and for that we need to be able to translate the json recieved from the API into C# data.
  
  ![image](https://user-images.githubusercontent.com/61495316/120896373-e271ce00-c629-11eb-94b1-36b067a701bc.png)
  
  To better represent the DailyForecast objects we once again need some helper classes like Headline, Day and DailyTemperature.
  We won't post pictures with all of them in here, but we will briefly describe them.
  
  **Headline**:
    
     Each Forecast object has an headline property that includes:
     * EffectiveDate, the date when this headline is in effect.
     * Text, which represents the most significant weather event over the next 5 days.
     
  **Day**
  
    Each Forecast object has 2 properties, one for the night time and one for the day time that contain:
    * Icon, numeric value representing an icon that matches the forecast. 
    * HasPrecipitation, boolean value that indicates the presence of any type of precipitation for a given day.
    * Precipitation probability, percent representing the probability of precipitation.

  **DailyTemperature** 
  
  Each Forecast object has one property of type DailyTemperature that holds the properties:
  * Minimum, minimum temperature value for the respective day.
  * Maximum, maximum temperature value for the respective day.



**VIEWMODELS**: 

  The view model is a non-visual class and does not derive from any WPF or Silverlight base class. It encapsulates the presentation logic required to support a use case or user task   in the application. The view model is testable independently of the view and the model.
  
  For a better separation of logic we have two view models in our application, one for each view and some helper classes that we'll explain later.
  
* **WeatherVM**:
    
  This view model corresponds to the first window. It is responsible to store (in code) the weather information about the city that was introduced. It first stores the city name that   was selected and based on it, it calls the AccuWeather API to get the current conditions. It will act as the mediator between the information and the view. 
    
    ![image](https://user-images.githubusercontent.com/61495316/120917874-3e843300-c6ba-11eb-9e03-c90377fb83f1.png)
    
    This is the GetCurrentConditions method that is implemented in a helper class **AccuWeatherHelper**, where all the methods that involve an API call are written. 
    In there, we also have a similar method to get all the cities that correspond to the introduced one in the main window and a method to get the five day forecast. 
    
   ![image](https://user-images.githubusercontent.com/61495316/120918394-f286bd80-c6bc-11eb-82f5-81f1fae0e2ef.png)
   
   Still there, we also need to create the URL for each different call and store the API key.
   
   ![image](https://user-images.githubusercontent.com/61495316/120918547-a425ee80-c6bd-11eb-8c69-d33b8f07f678.png)
   
* **ForecastVM**

  The second view model corresponds to the ForecastWindov view. It needs to hold the DailyForecast list that is recieved from the API and pass it to the view whenever is needed.
  Since there is no actual interaction between the user and the second view, as it is just a window used for dispaly, this is the sole purpose of this second view model.
  
  We call the forecast method in **ForecastVM**:
  
  ![image](https://user-images.githubusercontent.com/61495316/120918816-06cbba00-c6bf-11eb-8358-c62565df3198.png)
  
  And the implementation can be found in the **AccuWeatherHelper** class:
  
  ![image](https://user-images.githubusercontent.com/61495316/120918840-367ac200-c6bf-11eb-9aa5-2fcce66fda55.png)


  


    
    


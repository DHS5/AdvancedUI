# AdvancedUI
## Flexible and User-friendly UI System based on Unity UI System

This UI System uses the Style Sheet principle to gather all of the UI datas on a single asset,
meaning that you just have to fill the style sheet with the different styles you wish to use in your project.
Then when you instantiate a UI element you just select the style to use and fill all the contents of the UI element on a single user-friendly component.
Also, several events corresponding to the element of your choice are already set up for you to use the whole potential of each UI element easily.

#### Example : Popup Button
The Popup Button is a button which opens a popup window when you click on it, very useful for info button or confirmation button.
![image](https://user-images.githubusercontent.com/94963203/225280691-825f459e-fd9d-4710-b7ab-6901aea34015.png)

Here you'll select the style to use for the button as well as for the popup :

![image](https://user-images.githubusercontent.com/94963203/225281078-32dbb2bc-9a8f-45d5-a9c6-9112f8062c4e.png)

Here you can fill the button and popup contents, in this case we'll use the button as a confirmation button and asks the user if he is sure that he wants to proceed :

![image](https://user-images.githubusercontent.com/94963203/225282722-494e0cf9-d665-4d55-9c4c-1775b05a2012.png)

NOTE : The content of the button is not entirely filled because there are default values set up in the style sheet, if you don't want to override it you just leave the content empty.


Result, when you click on the "Buy" button, this popup is shown :

![image](https://user-images.githubusercontent.com/94963203/225282912-0b319f30-eb81-4b83-b6d1-64f41da7fb45.png)

And here are the events that you can use for the popup button :

![image](https://user-images.githubusercontent.com/94963203/225283993-045cbaea-63ab-49e2-ba95-e2c58ee75c58.png)


### List of available advanced UI elements at the moment :
- Text
- Button
- Popup Button
- Toggle
- Dropdown Item Toggle
- Switch Toggle :

![image](https://user-images.githubusercontent.com/94963203/225286376-7aa94394-2be8-4c67-9c0c-638d9f53a410.png) ![image](https://user-images.githubusercontent.com/94963203/225286453-bf3b1144-7ab6-4fc1-9fa5-6dde84cf6521.png)

- Slider
- Input Slider : 

![image](https://user-images.githubusercontent.com/94963203/225285930-61921cbb-5a1f-40c3-8a23-5a3104f74949.png)
- Dropdown
- Scrollbar
- Input Field
- Scroll View
- Scroll List : 

![image](https://user-images.githubusercontent.com/94963203/225285583-968e140b-4e64-4544-be95-3c32192ee834.png)
- Popup
- Mask

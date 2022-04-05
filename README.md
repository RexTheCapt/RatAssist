# RatAssist  
An ED neutron plotter made to help fuel rats with they're missions. Its not locked to only rats, everyone is able to use it!

## How to use  
I tried to make it as easy to use as possible.  
When you start RatAssist, it will only show "User info" and "Spansh", click the button "ToggleRatMode" to change it into "Rat mode" (basically just gives you a few more options).  
In rat mode, you get access to "Case info", "User info" and "Spansh" with extra routing settings.  
  
### User mode  
#### User info  
The text field "Current sys" (read only) will be automatically updated as you go.  
The number field "Jump range" is where you put in your current jump range (was not able to figure out how to do it automatically).  
The text field "Target sys" is the system where you want to go.  
The bar right below "Target sys" is your current fuel level, i tried to make it as live as possible.  
The button "Set target system" does two things, set spansh mode to user and plot route to the target system.  
  
In the spansh field:  
This spansh field contains two different objects, jump list and message box.  
The jump list shows you the entire route to your destination, it works the same as spansh but it wont show the first system in the list due to it always being your current system, so its kinda redundant.  
On each jump you do, it will automatically update as you go, so remembering where you was in the list is no more, it will just get shorter for every single jump you do, or longer if you are going away, but thats a you problem.  
The auto highlight logic will always take your jump range and multiply it by 4 (highest boost available), find the furthest system away from your current location within this travel distance, copy it to your keyboard. The system which is marked in green is the one that is copied to your clipboard by the program it self, double click to copy something else.  
The message box should only show when there is an message to be shown to the user. It should notify you about errors, if its updating the list and show an fuel warning at 25% or less, click the fuel warning to open up [fuelrats website](https://fuelrats.com/).  
  
### Rat mode  
#### Case info  
The button "Set case" requires to have the entire ratsignal message in your clipboard on use, if not it will fail (might crash too).  
When a case is set and the textbox "System name" is filled, it will automatically plot a route to the client and set the route mode to "Client".  
The button "Clear case" removes all case info from the program, and it will disable routing at the same time.  
The text box "System name" is required to "Set target system" and spansh mode "Client".  
The text box "Client name" is not required at all, it purpose is to remind you about what the client's name is.  
The text box "Platform" is kinda redundant, i just added it since its a part of the ratsignal.  
The number box "Case NR" (default 0) will show you your current case number.  
The checkbox "Code Red" is the client code red?  
The button "Set target system" works exactly the same as the other button of same name, only it uses the case's system name and set the routing setting to client instead of user.  
  
#### User info  
Works exactly the same as "User mode".  
  
#### Spansh  
Works exactly the same as "User mode" but with an extra setting.  
You can choose the routing mode "Disable", "User" and "Client".  
Disable: Completely disables routing, will not auto update.  
User: Use the "User"'s target system.  
Client: Use the "Client"'s target system.  
  
## Settings  
Only a single setting so far, "Top most" which will make the program stay on top at all times.  
  
## ToggleRatMode  
Toggles between "Normal" and "Rat" mode.  
  
## QuickSelect  
Basically it is a list of "favorite" systems. At first its blank, but click the "[EDIT]" button to add/remove systems, please only a single system name per line, also ignores all lines which beghins with #.  
  
## About  
Opens an window with some info about this program (open as many as you want).  
About content:
```
Rat Spansh Tool
Scroll down for usages!

An Unofficial Tool by RexTheCapt ( https://github.com/RexTheCapt )
Logo mashed together by ShiftTGC ( https://www.youtube.com/ShiftTGC )


This Program requires an internet connection to work.

Takes use of Gareth Harper’s Neutron Router found here:
https://spansh.co.uk/plotter

You are not required to be a Fuel Rat to take use of this program
But if you want to help and become a Fuel Rat, you are more than welcome to!
https://fuelrats.com/register

Spansh API taken from https://github.com/pulganosaure/ED-NeutronRouter/tree/888c16dc527e66cd770766151512bc8395bd9213

Usages:
Double click an system in the list to copy the system name, The highlighed system on update is already copied to your clipboard.

In game commands (these message get sent into current chat channel):
RANGE:
    Usage: RANGE <number>
    Info: Lets you set jump range.

DEST:
DESTINATION:
TARGETSYSTEM:
TARGET:
SYSTEM:
    Usage: <cmd> <system name>
    Info: Change the target system.

UPDATE:
    Usage: UPDATE
    Info: Forces the program to update the route.

TOP:
    Usage: TOP
    Info: Makes the program stay on top of everything, or disables this function.
```
  
## The end note  
If you have any suggestions, bug reports or whatever just add them in issues on the [github page](https://github.com/RexTheCapt/RatAssist) for RatAssist.  

## Windows Presetation Foundation
*These notes are for the **.Net** version not the **.Net Framework 4** version  

### Markup
XAML is an XML-based markup language that implements an application's appearance declaratively. You typicallyuse it to define windows, dialog boxes, pages, and user controls, and to fill them with controls, shapes, and graphics. 
- Similar to android app developement I did...

### Input and Commands
Controls most often detect and respond to user input. The WPF input system uses both direct and routed events to support text input, focus management, and mouse positioning.

WPF provides a command system that separates user-input actions from the code that responds to those actions. The command system allows for multiple sources to invoke the same command logic.

### Layout
When you create a user interface, you arrange your controls by locations and size to form a layout. A key requirement of any layout is to adapt to changes in window sizez and display settings.  
The cornerstone of the layout system is relative positioniong, which increase the ability to adapt to changing window and display conditions. 

### Data Binding
Most applications are created to provide users with the means to view and edit data. For WPF applications, the work of storing and accessing data is already provided for by many different .NET data access libraries.  
WPF provides a data binding engine to automatically copy data from the managed objects into controls and ensure changes made to data in controls are saved back to the managed objects. 

Different types of data flow:
- **OneWay:** if there's no need to monitor the changes of the target property, using the OneWay binding mode avoids the overhead of the TwoWay binding mode.
- **TwoWay:** Causes changes to either the source property of the target property to automatically update the other.
- **OneWayToSource:** Revaluating the source value from the UI

OneWay and TwoWay bindings, must implement a suitable property change notification mechanism. Done VIA the **UpdateSourceTrigger**.








Entity Framework(ORM)  
MS SQL Server


Need to like have the grid be dynamically generated based on the size of the read in grid. Then each grid location needs to be bound to the 2D character array to be displayed. Can likely add a layer inbetween to make it look nicer

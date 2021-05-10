# Olive.GlobalSearch

It's a distributed enterprise boards solution.


**Olive.Microservices.Hub.Board** provides a solution to make that happen in the easiest way possible.

## How does it work?


## Installing board providers

In each microservice that contributes to board results (perhaps including Access Hub itself) add the following:

### Step 1
Add the [Olive.Microservices.Hub.BoardComponent.Source](https://www.nuget.org/packages/Olive.Microservices.Hub.BoardComponent.Source/) nuget package.

### Step 2
Add the following class to the Website project:

```c#
public class BoardComponentsSource : Olive.Microservices.Hub.BoardComponent.BoardComponentsSource
{
     public override async Task Process(ClaimsPrincipal user, string id, string type)
     {
         
         if (type == "Project"){
			 // TODO: Process the id and type and add result items.
			 
			 foreach (var something in await SomeThings...())
			 {
				Add(new Olive.Microservices.Hub.BoardComponent.BoardComponentsResult { Url = "...", Name = "...", Body = "...", IconUrl = "..." });
			 }        
		 }        
		 else if (type == "Person") { 
		 	 // TODO: Process the id and type and add result items.
			 
			 foreach (var something in await SomeThings...())
			 {
				Add(new Olive.Microservices.Hub.BoardComponent.BoardComponentsResult { Url = "...", Name = "...", Body = "...", IconUrl = "..." });
			 }  
		 }		 
         
         
         await AddableItem(user, id, type);
     }
}
```

### Step 3 (.NET Core Apps)


2. In StartUp.cs, add: 
```c#
public override void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    base.Configure(app, env);
    ...
    app.UseBoardComponents<BoardComponentsSource>();
    ...
}
```


### Step 3 (.Net 4.6+ Apps)
For legacy ASP.NET applications, add the following code to Web.config:

```xml
<configuration>
   <system.webServer>
      <handlers>
         <add name="Olive Global Search" verb="GET" path="board-components.axd" type="BoardComponentsSource" />
      </handlers>
   <system.webServer>
</configuration>
```

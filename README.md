### Book WebAPI 
This project has been developed with [Clean Architecture](https://img.shields.io/github/stars/iammukeshm/CleanArchitecture.WebApi "CleanArchitecture").
![](https://github.com/saj86/SampleWebApi/blob/main/Image/Architecture.png?raw=true)

Clean architecture is a software design philosophy that separates the elements of a design into ring levels. An important goal of clean architecture is to provide developers with a way to organize code in such a way that it encapsulates the business logic but keeps it separate from the delivery mechanism. 

The main rule of clean architecture is that code dependencies can only move from the outer levels inward. Code on the inner layers can have no knowledge of functions on the outer layers. The variables, functions and classes (any entities) that exist in the outer layers can not be mentioned in the more inward levels. It is recommended that data formats also stay separate between levels.

Clean architecture was created by Robert C. Martin and promoted on his blog, Uncle Bob. Like other software design philosophies, clean architecture attempts to provide a cost-effective methodology that makes it easier to develop quality code that will perform better, is easier to change and has fewer dependencies.

Visually, the levels of clean architecture are organized into an unspecified number of rings. The outer levels of the rings are lower level mechanisms and the inner, higher levels contain policies and Entities.




Domain
All the Entities and the most common models are available here. Note that this Layer will NEVER depend on anything else.
![Domain](https://github.com/saj86/SampleWebApi/blob/main/Image/Domain.png?raw=true)

Application
Interfaces, CQRS Features, Exceptions, Behaviors are available here.
![Application](https://github.com/saj86/SampleWebApi/blob/main/Image/Application.png?raw=true)

Bussiness Service
The business logic of the project is implemented here and shared between all Presentation layers 
![Bussiness Service](https://github.com/saj86/SampleWebApi/blob/main/Image/BussinessService.png?raw=true)

Infrastructure.Persistence
An Application Specific Database will be maintained. This is to ensure that there is no relation between the DBContext classes of Application .
![Persistence](https://github.com/saj86/SampleWebApi/blob/main/Image/Persistence.png?raw=true)

WebApi
This is also known as the Presentation Layer, where you would put in the project that the user can interact with. In our case it is the WebAPI Project.
![WebApi](https://github.com/saj86/SampleWebApi/blob/main/Image/WebApi.png?raw=true)
